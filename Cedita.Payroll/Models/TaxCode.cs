// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cedita.Payroll.Models
{
    /// <summary>
    /// <see cref="TaxCode"/> represents a United Kingdom tax code translated into a system usable format
    /// </summary>
    public class TaxCode
    {
        #region Public Properties
        /// <summary>
        /// Original tax code as received
        /// </summary>
        public string OriginalTaxCode { get; protected set; }
        /// <summary>
        /// Sanitised tax code after Scottish Tax determined and normalised
        /// </summary>
        public string SanitisedTaxCode { get; protected set; }
        /// <summary>
        /// Number portion of the tax code, if any
        /// </summary>
        public int? TaxCodeNumber { get; protected set; }
        /// <summary>
        /// Letter part of the tax code, if any. Note that this will not include 'S', and only references the calculation type
        /// </summary>
        public string TaxCodeLetter { get; protected set; }
        /// <summary>
        /// Determination of whether the tax code is a 'Prefix code'
        /// </summary>
        public bool IsPrefixCode { get; protected set; }
        /// <summary>
        /// Determination of whether the tax code is a 'No Adjustment' code, not requiring adjustment to be made to pay before calculation
        /// </summary>
        public bool IsNoAdjustmentCode { get; protected set; }
        /// <summary>
        /// Determination of whether the tax code should calculate tax at the Scottish Rate
        /// </summary>
        public bool IsScotlandTax { get; protected set; }

        /// <summary>
        /// True if the code was able to be translated.
        /// </summary>
        public bool IsValidTaxCode { get; protected set; }
        #endregion

        #region Public API
        /// <summary>
        /// Factory method for <see cref="TaxCode"/>
        /// </summary>
        /// <param name="taxCode">United Kingdom Tax Code</param>
        /// <returns></returns>
        public static bool TryParse(string input, out TaxCode taxCode)
        {
            taxCode = new TaxCode();
            return taxCode.PerformTranslation(input);
        }
        /// <summary>
        /// Converts the string to a <see cref="TaxCode"/> representation
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        /// <param name="input"></param>
        /// <returns></returns>
        public static TaxCode Parse(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (!TryParse(input, out TaxCode taxCode))
                throw new FormatException($"{input} is an invalid tax code format.");

            return taxCode;
        }

        #endregion

        #region Protected Properties
        #endregion

        #region Workings
        protected readonly string[] NoAdjustmentCodes = { "BR", "D", "D0", "D1", "NT", "N1" };
        protected readonly string[] PrefixCodes = { "K" };
        protected readonly string[] ScottishNoAdjustmentCodes = { "D2" };

        protected TaxCode() { }
        
        protected bool PerformTranslation(string taxCode)
        {
            if (taxCode == null) return false;

            SanitiseTaxCode(taxCode);
            
            if (string.IsNullOrWhiteSpace(taxCode)) return false;
            
            DetermineNoAdjustmentCode();

            if (!DetermineCodeComponents()) return false;
            DeterminePrefixCode();
            
            IsValidTaxCode = true;

            return true;
        }

        protected void SanitiseTaxCode(string taxCode)
        {
            SanitisedTaxCode = taxCode.Trim();
            SanitisedTaxCode = SanitisedTaxCode.ToUpperInvariant();
            
            if (SanitisedTaxCode.Length == 0) return;

            // Do this here as it affects the sanitised tax code directly
            DetermineScottishTaxCode();
            if (IsScotlandTax)
                SanitisedTaxCode = SanitisedTaxCode.Substring(1);
        }

        protected void DetermineScottishTaxCode()
        {
            IsScotlandTax = SanitisedTaxCode[0] == 'S';
        }

        protected void DetermineNoAdjustmentCode()
        {
            IsNoAdjustmentCode = NoAdjustmentCodes.Contains(SanitisedTaxCode);
            // Check for Scotland specific No Adjustment Code
            if (IsScotlandTax && !IsNoAdjustmentCode)
            {
                IsNoAdjustmentCode = ScottishNoAdjustmentCodes.Contains(SanitisedTaxCode);
            }
        }
        protected void DeterminePrefixCode()
        {
            IsPrefixCode = PrefixCodes.Contains(TaxCodeLetter);
        }

        protected readonly string CodeRegex = @"^(S?)((([0-9]{0,6})([LMNPTY]))|(([K])([1-9][0-9]{0,5})))$";
        protected bool DetermineCodeComponents()
        {
            if (!IsNoAdjustmentCode)
            {
                var codeMatches = new Regex(CodeRegex).Matches(SanitisedTaxCode);
                // If we don't have a match, we failed to get it
                if (codeMatches.Count == 0)
                    return false;

                // Letter first, from the middle group supporting either prefix or suffix codes
                TaxCodeLetter = $"{codeMatches[0].Groups[5].Value}{codeMatches[0].Groups[7].Value}";

                // Now the numbers
                if (Int32.TryParse($"{codeMatches[0].Groups[4].Value}{codeMatches[0].Groups[8].Value}", out int result))
                    TaxCodeNumber = result;
            }
            else
            {
                TaxCodeLetter = SanitisedTaxCode;
            }
            return true;
        }

        #endregion
    }
}
