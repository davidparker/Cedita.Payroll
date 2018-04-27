// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.
using System;
using System.Collections.Generic;
using Cedita.Payroll.Models;
using Cedita.Payroll.Models.TaxYearSpecifics;

namespace Cedita.Payroll.Engines.Paye
{
    [EngineApplicableTaxYear(TaxYearStartYear = 2014)]
    public class PayeVersion12 : PayeCalculationEngine
    {
        public override decimal CalculateTaxDueForPeriod(TaxCode taxCode, decimal gross, PayPeriods periods, int period, bool week1 = false, decimal grossToDate = 0, decimal taxToDate = 0)
        {
            CreateContainer(taxCode, gross, periods, period, week1, grossToDate, taxToDate);
            CalculateTax();

            return CalculationContainer.ln;
        }

        protected override void CalculateTax()
        {
            CalculateLn();
            Calculateln();
        }

        protected virtual void CalculateLn()
        {
            var taxableIncome = Math.Max(Math.Floor(CalculationContainer.Pn - CalculationContainer.na1), 0);
            FixedCode fixedCode;
            if ((fixedCode = TaxYearSpecificProvider.GetFixedCode(CalculationContainer.TaxCode.SanitisedTaxCode, CalculationContainer.TaxCode.IsScotlandTax)) != null)
            {
                CalculationContainer.Ln = taxableIncome * fixedCode.Rate;
            }
            else
            {
                var brackets = GetBracketsForPeriod();//TaxYear, CalculationContainer.n, (int)CalculationContainer.Periods);

                for (int i = 0; i < brackets.Length; i++)
                {
                    var lastv = i > 0 ? brackets[i - 1].v : 0;
                    var lastc = i > 0 ? brackets[i - 1].c : 0;
                    var lastk = i > 0 ? brackets[i - 1].k : 0;

                    if (CalculationContainer.Un > lastv && CalculationContainer.Un <= brackets[i].v)
                    {
                        CalculationContainer.Ln = lastk + ((CalculationContainer.Tn - lastc) * brackets[i].R);
                        break;
                    }
                }
            }
        }

        protected virtual void Calculateln()
        {
            CalculationContainer.ln = TaxMath.Truncate(CalculationContainer.Ln, 2);

            if (CalculationContainer.n > 1)
                CalculationContainer.ln -= CalculationContainer.TaxToDate;

            if (CalculationContainer.TaxCode.IsPrefixCode)
                CalculationContainer.ln = Math.Min(CalculationContainer.ln, TaxMath.Truncate(CalculationContainer.pn * (CalculationContainer.M / 100), 2));
        }

        protected override void CreateContainer(TaxCode taxCode, decimal grossForPeriod, PayPeriods periods, int period = 1, bool week1 = false, decimal grossToDateExcludingPeriod = 0, decimal taxToDateExcludingPeriod = 0)
        {
            if (week1 || period == 1)
            {
                period = 1;
                grossToDateExcludingPeriod = 0;
                taxToDateExcludingPeriod = 0;
            }

            CalculationContainer = new PayeCalculationContainer
            {
                TaxCode = taxCode,
                Week1 = week1,
                Periods = periods,
                TaxToDate = taxToDateExcludingPeriod,
                n = period,
                pn = grossForPeriod,
                Pn1 = grossToDateExcludingPeriod,
                Pn = grossForPeriod + grossToDateExcludingPeriod,
                a1 = GetPayAdjustment(taxCode, periods),
                // Constants
                M = 50
            };

            CalculationContainer.na1 = CalculationContainer.a1 * CalculationContainer.n;
            CalculationContainer.Un = CalculationContainer.Pn - CalculationContainer.na1;
            CalculationContainer.Tn = TaxMath.Truncate(CalculationContainer.Un, 0);
        }

        protected override PayeCalculationContainer CreateDefaultContainer()
        {
            return new PayeCalculationContainer();
        }

        protected virtual IEnumerable<TaxBracket> GetBracketsFromProvider(bool scottish = false)
        {
            return TaxYearSpecificProvider.GetTaxBrackets(scottish);
        }

        protected override PayeInternalBracket[] GetBracketsForPeriod()
        {
            int year = TaxYear, period = CalculationContainer.n, periods = (int)CalculationContainer.Periods;
            bool scottish = CalculationContainer.TaxCode.IsScotlandTax;

            Tuple<int, int, int, bool> brKey;
            if (BracketCache.ContainsKey(brKey = new Tuple<int, int, int, bool>(year, period, periods, scottish)))
                return BracketCache[brKey];

            var taxYearBrackets = GetBracketsFromProvider(TaxYear > 2016 ? scottish : false);
            var periodBrackets = new List<PayeInternalBracket>();

            decimal lastC = 0, lastK = 0;
            foreach(var taxYearBracket in taxYearBrackets)
            {
#pragma warning disable IDE0017 // Simplify object initialization
                var periodBracket = new PayeInternalBracket();
#pragma warning restore IDE0017 // Simplify object initialization
                periodBracket.R = taxYearBracket.Multiplier;
                periodBracket.B = taxYearBracket.To - taxYearBracket.From;

                periodBracket.C = periodBracket.B + lastC;
                lastC = periodBracket.C;

                periodBracket.c = TaxMath.Factor(periodBracket.C, period, periods);
                periodBracket.c = TaxMath.Truncate(periodBracket.c, 4);
                periodBracket.v = Math.Ceiling(periodBracket.c);

                periodBracket.K = lastK + TaxMath.Multiply(periodBracket.B, periodBracket.R, TaxMath.MultiplicationAccuracy.High);
                lastK = periodBracket.K;

                periodBracket.k = TaxMath.Factor(periodBracket.K, period, periods);
                periodBracket.k = TaxMath.Truncate(periodBracket.k, 4);

                periodBrackets.Add(periodBracket);
            }

            BracketCache[brKey] = periodBrackets.ToArray();
            return periodBrackets.ToArray();
        }

        protected override decimal GetPayAdjustment(TaxCode taxCode, PayPeriods periods/*, int period*/)
        {
            if (taxCode.IsNoAdjustmentCode || !taxCode.TaxCodeNumber.HasValue || taxCode.TaxCodeNumber.Value == 0)
                return 0;

            var codeNumber = taxCode.TaxCodeNumber.Value;
            var remainder = ((codeNumber - 1m) % 500) + 1m;
            var quotient = Math.Floor(codeNumber - remainder) / 500m;

            var payPeriodForQuotient = (periods == PayPeriods.Monthly ? PayPeriods.Monthly : PayPeriods.Weekly);
            var quotientMult = TaxMath.UpRound(500 * (10 / (decimal)payPeriodForQuotient), 2);
            remainder = ((remainder * 10) + 9) / (int)payPeriodForQuotient;
            remainder = Math.Ceiling(remainder * 100) / 100;
            //remainder *= Math.Round((decimal)payPeriodForQuotient / (decimal)periods);
            quotient = quotient * quotientMult;

            var adjustment = (quotient + remainder);// * period;
            adjustment *= Math.Round((decimal)payPeriodForQuotient / (decimal)periods);

            if (taxCode.IsPrefixCode)
                adjustment *= -1;

            return adjustment;
        }
    }
}
