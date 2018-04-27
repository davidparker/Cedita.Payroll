using Cedita.Payroll.Engines;
using System;
using Cedita.Payroll.Models.TaxYearSpecifics;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Cedita.Payroll
{
    /// <summary>
    /// JSON Tax Year Provider for Cedita.Payroll
    /// </summary>
    public class JsonTaxYearSpecificProvider : IProvideTaxYearSpecifics
    {
        protected string JsonFileName { get; } = "PayrollConfig.json";
        protected Dictionary<int, JsonConfigTaxYear> ParsedConfig { get; set; }

        protected JsonConfigTaxYear CurrentTaxYear { get; set; }

        public JsonTaxYearSpecificProvider()
        {
            LoadJson();
        }

        public JsonTaxYearSpecificProvider(string jsonFileName) : this()
        {
            JsonFileName = jsonFileName;
        }

        protected void LoadJson()
        {
            var fileContents = File.ReadAllText(JsonFileName);
            var convertedYears = JsonConvert.DeserializeObject<List<JsonConfigTaxYear>>(fileContents);
            ParsedConfig = convertedYears.ToDictionary(m => m.TaxYear, m => m);
        }

        public void SetTaxYear(int taxYear)
        {
            if (!ParsedConfig.ContainsKey(taxYear))
                throw new ArgumentException($"Could not find tax year specifics for tax year {taxYear}.", nameof(taxYear));

            CurrentTaxYear = ParsedConfig[taxYear];
        }

        protected void EnsureTaxYearSet()
        {
            if (CurrentTaxYear == null)
                throw new InvalidOperationException("You must set tax year before calling this method.");
        }

        public NationalInsuranceCode GetCodeSpecifics(char niCode)
        {
            EnsureTaxYearSet();

            return CurrentTaxYear.NiRates.SingleOrDefault(m => m.Code == niCode);
        }

        public FixedCode GetFixedCode(string taxCode, bool scottish = false)
        {
            EnsureTaxYearSet();

            return ((scottish ? CurrentTaxYear.ScottishFixedCodes : null) ?? CurrentTaxYear.FixedCodes).SingleOrDefault(m => m.Code == taxCode);
        }

        public bool IsFixedCode(string taxCode, bool scottish = false)
        {
            EnsureTaxYearSet();
            
            return ((scottish ? CurrentTaxYear.ScottishFixedCodes : null) ?? CurrentTaxYear.FixedCodes).Any(m => m.Code == taxCode);
        }

        public T GetSpecificValue<T>(TaxYearSpecificValues specificValueType)
        {
            EnsureTaxYearSet();

            object retValue;
            switch (specificValueType)
            {
                case TaxYearSpecificValues.ApprenticeUpperSecondaryThreshold:
                    retValue = CurrentTaxYear.ApprenticeUpperSecondaryThreshold;
                    break;
                case TaxYearSpecificValues.DeaProtectedEarnings:
                    retValue = CurrentTaxYear.DeaProtectedEarnings;
                    break;
                case TaxYearSpecificValues.LowerEarningsLimit:
                    retValue = CurrentTaxYear.LowerEarningsLimit;
                    break;
                case TaxYearSpecificValues.UpperEarningsLimit:
                    retValue = CurrentTaxYear.UpperEarningsLimit;
                    break;
                case TaxYearSpecificValues.PrimaryThreshold:
                    retValue = CurrentTaxYear.PrimaryThreshold;
                    break;
                case TaxYearSpecificValues.SecondaryThreshold:
                    retValue = CurrentTaxYear.SecondaryThreshold;
                    break;
                case TaxYearSpecificValues.UpperAccrualPoint:
                    retValue = CurrentTaxYear.UpperAccrualPoint;
                    break;
                case TaxYearSpecificValues.UpperSecondaryThreshold:
                    retValue = CurrentTaxYear.UpperSecondaryThreshold;
                    break;
                case TaxYearSpecificValues.Plan1StudentLoanThreshold:
                    retValue = CurrentTaxYear.Plan1StudentLoanThreshold;
                    break;
                case TaxYearSpecificValues.Plan1StudentLoanRate:
                    retValue = CurrentTaxYear.Plan1StudentLoanRate;
                    break;
                case TaxYearSpecificValues.Plan2StudentLoanThreshold:
                    retValue = CurrentTaxYear.Plan2StudentLoanThreshold;
                    break;
                case TaxYearSpecificValues.Plan2StudentLoanRate:
                    retValue = CurrentTaxYear.Plan2StudentLoanRate;
                    break;
                case TaxYearSpecificValues.PensionLowerThreshold:
                    retValue = CurrentTaxYear.PensionLowerThreshold;
                    break;
                case TaxYearSpecificValues.PensionAutomaticEnrolment:
                    retValue = CurrentTaxYear.PensionAutomaticEnrolment;
                    break;
                case TaxYearSpecificValues.PensionUpperThreshold:
                    retValue = CurrentTaxYear.PensionUpperThreshold;
                    break;
                case TaxYearSpecificValues.DefaultTaxCode:
                    retValue = CurrentTaxYear.DefaultTaxCode;
                    break;
                default:
                    throw new NotImplementedException($"Could not provide a value for {specificValueType} using this provider. Ensure you are using the latest version.");
            }

            return (T)retValue;
        }

        /// <summary>
        /// Returns a rounded period value
        /// </summary>
        /// <param name="specificValueType"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public decimal GetPeriodTaxYearValue(TaxYearSpecificValues specificValueType, PayPeriods period)
        {
            // Get the annual value
            decimal annualValue = GetSpecificValue<decimal>(specificValueType);

            // By default for weekly we have 52 weeks in our period
            int periodCnt = 52;
            int weeksInPeriod = 1;
            if (period == PayPeriods.Monthly)
                periodCnt = 12;
            else
                weeksInPeriod = (int)Math.Round((decimal)periodCnt / (int)period);

            return TaxMath.PeriodRound((annualValue * weeksInPeriod) / periodCnt, weeksInPeriod);
        }

        public IEnumerable<TaxBracket> GetTaxBrackets(bool scottish = false)
        {
            EnsureTaxYearSet();

            return scottish ? CurrentTaxYear.ScottishBrackets : CurrentTaxYear.Brackets;
        }
    }
}
