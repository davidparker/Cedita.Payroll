// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cedita.Payroll
{
    public static class Paye
    {

        /*
         * L, P, Y
         * T?
         * Prefix - Negative K
         * 
         * BR - 20%
         * 0T - Standard, no personal allowance
         * D0 - 40%
         * D1 - 45%
         * NT - No Tax
         */


        /// <summary>
        /// Codes that do not require any adjustment to be made to pay
        /// </summary>
        internal static readonly List<string> NoAdjustmentCodes
            = new List<string> { "BR", "D", "D0", "D1", "NT", "N1" };

        /// <summary>
        /// Codes that are a prefix instead of a suffix
        /// </summary>
        internal static readonly List<string> PrefixCodes
            = new List<string> { "K" };

        /// <summary>
        /// Regular Expression to match components of a tax code
        /// </summary>
        internal static readonly string CodeRegex = @"^(\d*)([A-Z]{1,2})(\d*)$";

        #region Separation
        internal static string SanitiseTaxCode(string taxCode)
        {
            if (taxCode == null)
                throw new TaxCodeFormatException("{NULL}");

            taxCode = taxCode.ToUpper();

            return taxCode;
        }

        /// <summary>
        /// Get the tax letter from the provided tax code
        /// </summary>
        /// <param name="taxCode">Tax Code to retrieve letter from</param>
        /// <returns>Coding letter</returns>
        public static string CodeLetter(string taxCode)
        {
            taxCode = SanitiseTaxCode(taxCode);

            if (!AdjustPay(taxCode))
                return taxCode;

            var codeMatches = new Regex(CodeRegex).Matches(taxCode);
            if (codeMatches.Count > 0)
                return codeMatches[0].Groups[2].Value;

            throw new TaxCodeFormatException(taxCode);
        }

        /// <summary>
        /// Get the tax number from the provided tax code
        /// </summary>
        /// <param name="taxCode">Tax Code to retrieve letter from</param>
        /// <returns>Code number</returns>
        public static int? CodeNumber(string taxCode)
        {
            taxCode = SanitiseTaxCode(taxCode);

            if (!AdjustPay(taxCode))
                return null;

            var codeMatches = new Regex(CodeRegex).Matches(taxCode);
            if (codeMatches.Count > 0)
            {
                if (codeMatches[0].Groups[3].Length > 0)
                    return Int32.Parse(codeMatches[0].Groups[1].Value + codeMatches[0].Groups[3].Value);

                return Int32.Parse(codeMatches[0].Groups[1].Value);
            }

            throw new TaxCodeFormatException(taxCode);
        }

        /// <summary>
        /// Does the pay require adjusting prior to tax calculation
        /// </summary>
        /// <param name="taxCode">Tax Code to test</param>
        /// <returns>true if adjustment required, false otherwise</returns>
        public static bool AdjustPay(string taxCode)
        {
            return !NoAdjustmentCodes.Contains(taxCode);
        }

        /// <summary>
        /// Is the code a preifx code
        /// </summary>
        /// <param name="taxCode">Tax Code to test</param>
        /// <returns>true if is a prefix code, false otherwise</returns>
        public static bool PrefixCode(string taxCode)
        {
            var taxLetter = CodeLetter(taxCode);
            return PrefixCodes.Contains(taxLetter);
        }
        #endregion

        #region Calculation
        internal static decimal PayAdjustment(string taxCode, PayrollFrequency frequency, int period)
        {
            var codeNumber = CodeNumber(taxCode);

            if (!AdjustPay(taxCode) || !codeNumber.HasValue || codeNumber == 0)
                return 0;

            var codeDbl = (decimal)codeNumber.Value;
            var remainder = (decimal)((codeNumber - 1) % 500) + 1;

            var quotient = Math.Floor((codeDbl - remainder) / 500m);

            // Work it out based on 12 months
            if (frequency == PayrollFrequency.Monthly)
            {
                remainder = ((remainder * 10) + 9) / 12;
                remainder = Math.Ceiling(remainder * 100) / 100;

                quotient = quotient * 416.67m;
            }
            // Work it out based on 52 weeks
            else
            {
                remainder = ((remainder * 10) + 9) / 52;
                remainder = Math.Ceiling(remainder * 100) / 100;

                quotient = quotient * 96.16m;
                switch(frequency)
                {
                    case PayrollFrequency.Fortnightly:
                        remainder *= 2;
                        break;
                    case PayrollFrequency.FourWeekly:
                        remainder *= 4;
                        break;
                }
            }

            decimal adjustment = (quotient + remainder) * period;

            if (PrefixCode(taxCode))
                adjustment *= -1;

            return adjustment;
        }

        public static decimal? FixedRate(string taxCode, int taxYear)
        {
            var rates = new Rates.RateAccess(taxYear);

            // Lookup code
            if (rates.FixedCodes.ContainsKey(taxCode))
                return rates.FixedCodes[taxCode];

            return null;
        }

        public static decimal Calculate(decimal gross, string taxCode, PayrollFrequency frequency, int period = 1,
            decimal grossToDate = 0, decimal taxToDate = 0, bool week1month1 = false, int? taxYear = null)
        {
            if (taxYear == null)
                // Get a default date
                taxYear = TaxDate.GetTaxYear(null);

            var rateAccess = new Rates.RateAccess(taxYear.Value);

            if (taxCode == null)
                // Get a default tax code
                taxCode = rateAccess.DefaultTaxCode;

            int periods = TaxDate.GetPeriods(frequency);
            period = ((period - 1) % periods) + 1;

            if (week1month1 || period == 1)
            {
                period = 1;
                grossToDate = 0;
                taxToDate = 0;
            }

            var adjustment = PayAdjustment(taxCode, frequency, period);

            var taxableIncome = Math.Floor((gross + grossToDate) - adjustment);
            if (taxableIncome < 0) return 0;

            var taxCalc = new PayeCalc();

            // Check if this is a fixed rate tax code
            var fixedRate = FixedRate(taxCode, taxYear.Value);
            if (fixedRate.HasValue)
            {
                taxCalc.Ln = taxableIncome * fixedRate.Value;
            }
            else
            {
                var untaxedIncome = taxableIncome;

                taxCalc.n = period;
                taxCalc.pn = gross;
                taxCalc.Pn1 = grossToDate;
                taxCalc.Pn = grossToDate + gross;
                taxCalc.M = 50;
                taxCalc.Ln = 0;
                taxCalc.ln = 0;

                taxCalc.Un = (gross + grossToDate) - adjustment;
                taxCalc.Tn = TaxMath.Truncate(taxCalc.Un, 0);

                var brackets = PayeCalc.GetBrackets(taxYear.Value, period, periods);

                // Calc tax for each bracket
                for(int i = 0; i < brackets.Count; i++)
                {
                    var lastv = i > 0 ? brackets[i-1].v : 0;
                    var lastc = i > 0 ? brackets[i-1].c : 0;
                    var lastk = i > 0 ? brackets[i-1].k : 0;

                    if (taxCalc.Un > lastv && taxCalc.Un <= brackets[i].v) {
                        taxCalc.Ln = lastk + ((taxCalc.Tn - lastc) * brackets[i].R);
                        break;
                    }
                }
            }

            taxCalc.ln = TaxMath.Truncate(taxCalc.Ln, 2);

            // Subtract the tax already paid from total amount owed
            if (period > 1)
                taxCalc.ln -= taxToDate;

            // Ensure that no more than 50% of gross this week is deducted
            if (PrefixCode(taxCode))
                taxCalc.ln = Math.Min(taxCalc.ln, TaxMath.Truncate(gross * .5m, 2));

            return taxCalc.ln;
        }
        #endregion
    }

    internal class PayeCalc
    {
        internal static Dictionary<string, List<InternalCalcBracket>> _brackets
            = new Dictionary<string,List<InternalCalcBracket>>();

        internal static List<InternalCalcBracket> GetBrackets(int taxYear, int period, int periods)
        {
            var key = taxYear + "-" + period + "-" + periods;
            if (_brackets.ContainsKey(key))
                return _brackets[key];

            // Set up the brackets
            _brackets[key] = new List<InternalCalcBracket>();

            var rateAccess = new Rates.RateAccess(taxYear);
            var brackets = rateAccess.Brackets;

            decimal lastC = 0;
            decimal lastK = 0;
            foreach (var bracket in brackets)
            {
                var newBracket = new InternalCalcBracket();
                newBracket.R = bracket.Multiplier;
                newBracket.B = bracket.To - bracket.From;
                newBracket.C = newBracket.B + lastC;
                lastC = newBracket.C;
                newBracket.c = TaxMath.Factor(newBracket.C, period, periods);
                newBracket.c = TaxMath.Truncate(newBracket.c, 4);
                newBracket.v = Math.Ceiling(newBracket.c);

                newBracket.K = lastK + TaxMath.Multiply(newBracket.B, newBracket.R, MultiplicationAccuracy.High);
                lastK = newBracket.K;

                newBracket.k = TaxMath.Factor(newBracket.K, period, periods);
                newBracket.k = TaxMath.Truncate(newBracket.k, 4);

                _brackets[key].Add(newBracket);
            }

            return _brackets[key];
        }

        internal decimal n, pn, Pn1, Pn, M, Ln, ln, Un, Tn;
    }

    internal class InternalCalcBracket
    {
        internal decimal R, B, C, c, V, v, K, k;
    }
}
