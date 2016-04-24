// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cedita.Payroll
{
    public enum NationalInsuranceMode { Employee, Employer, Net }

    public class NiCalculationResult
    {
        /// <summary>
        /// Employee National Insurance Gross Value
        /// </summary>
        public decimal EmployeeNiGross { get; set; }

        /// <summary>
        /// Employee National Insurance Rebate Value
        /// </summary>
        public decimal EmployeeNiRebate { get; set; }


        /// <summary>
        /// Employer National Insurance Gross Value
        /// </summary>
        public decimal EmployerNiGross { get; set; }

        /// <summary>
        /// Employer National Insurance Rebate Value
        /// </summary>
        public decimal EmployerNiRebate { get; set; }

        /// <summary>
        /// Net Employee National Insurance
        /// </summary>
        public decimal EmployeeNi { get { return EmployeeNiGross - EmployeeNiRebate; } }

        /// <summary>
        /// Net Employer National Insurance
        /// </summary>
        public decimal EmployerNi { get { return EmployerNiGross - EmployerNiRebate; } }

        /// <summary>
        /// Net National Insurance (Employer + Employee)
        /// </summary>
        public decimal NetNi { get { return EmployeeNi + EmployerNi; } }

        public override bool Equals(object obj)
        {
            if (obj is NiCalculationResult)
            {
                var that = obj as NiCalculationResult;
                return
                    this.EmployeeNiGross == that.EmployeeNiGross &&
                    this.EmployerNiGross == that.EmployerNiGross &&
                    this.EmployeeNiRebate == that.EmployeeNiRebate &&
                    this.EmployerNiRebate == that.EmployerNiRebate;
            }
            return false;
        }
    }
    public static class NationalInsurance
    {
        private static decimal SubtractRound(decimal gross, decimal limit, decimal subtract)
        {
            var subtractFrom = TaxMath.Smallest(gross, limit);
            var subtracted = subtractFrom - subtract;
            subtracted = Math.Round(subtracted, 2, MidpointRounding.AwayFromZero);
            return TaxMath.PositiveOnly(subtracted);
        }
        
        /// <summary>
        /// Perform a full calculation of National Insurance
        /// </summary>
        /// <param name="gross">Gross pay for NI</param>
        /// <param name="niCategory">National Insurance Category Letter</param>
        /// <param name="frequency">Payroll Frequency</param>
        /// <param name="taxYear">Tax Year</param>
        /// <returns>Calculated Result of National Insurance</returns>
        public static NiCalculationResult CalculateAll(decimal gross, char niCategory, PayrollFrequency frequency, int? taxYear = null,
            decimal periodGross = 0)
        {
            if (taxYear == null)
                // Default tax year
                taxYear = TaxDate.GetTaxYear(null);

            gross += periodGross;

            var rateAccess = new Rates.RateAccess(taxYear.Value);

            if (!rateAccess.NiRates.ContainsKey(niCategory))
                throw new InvalidNiCategoryException(niCategory);

            var niRates = rateAccess.NiRates[niCategory];

            int weeksInPeriod = 1, periods = 52;
            switch (frequency)
            {
                case PayrollFrequency.Fortnightly:
                    weeksInPeriod = 2;
                    break;
                case PayrollFrequency.FourWeekly:
                    weeksInPeriod = 4;
                    break;
                case PayrollFrequency.Monthly:
                    periods = 12;
                    break;
            }

            decimal EeNi = 0m, ErNi = 0m, EeNiR = 0m, ErNiR = 0m;
            decimal periodPT = TaxMath.PeriodRound(TaxMath.Factor(rateAccess.PrimaryThreshold, weeksInPeriod, periods), weeksInPeriod),
                periodST = TaxMath.PeriodRound(TaxMath.Factor(rateAccess.SecondaryThreshold, weeksInPeriod, periods), weeksInPeriod),
                periodUAP = TaxMath.PeriodRound(TaxMath.Factor(rateAccess.UpperAccrualPoint, weeksInPeriod, periods), weeksInPeriod),
                periodUEL = TaxMath.PeriodRound(TaxMath.Factor(rateAccess.UpperEarningsLimit, weeksInPeriod, periods), weeksInPeriod),
                periodLEL = TaxMath.PeriodRound(TaxMath.Factor(rateAccess.LowerEarningsLimit, weeksInPeriod, periods), weeksInPeriod)
                ;

            // Employee NI Gross
            EeNi = TaxMath.HmrcRound(SubtractRound(gross, periodUAP, periodPT) * (niRates.EeD / 100));
            EeNi += TaxMath.HmrcRound(SubtractRound(gross, periodUEL, periodUAP) * (niRates.EeE / 100));
            EeNi += TaxMath.HmrcRound(SubtractRound(gross, gross, periodUEL) * (niRates.EeF / 100));

            EeNiR = TaxMath.HmrcRound(SubtractRound(gross, periodST, periodLEL) * (niRates.EeB / 100));
            EeNiR += TaxMath.HmrcRound(SubtractRound(gross, periodPT, periodST) * (niRates.EeC / 100));

            // Employer NI Gross
            ErNi = TaxMath.HmrcRound(SubtractRound(gross, periodPT, periodST) * (niRates.ErC / 100));
            ErNi += TaxMath.HmrcRound(SubtractRound(gross, periodUAP, periodPT) * (niRates.ErD / 100));
            ErNi += TaxMath.HmrcRound(SubtractRound(gross, periodUEL, periodUAP) * (niRates.ErE / 100));
            ErNi += TaxMath.HmrcRound(SubtractRound(gross, gross, periodUEL) * (niRates.ErF / 100));

            ErNiR = TaxMath.HmrcRound(SubtractRound(gross, periodST, periodLEL) * (niRates.ErB / 100));

            return new NiCalculationResult
            {
                EmployeeNiGross = EeNi,
                EmployeeNiRebate = EeNiR,
                EmployerNiGross = ErNi,
                EmployerNiRebate = ErNiR
            };
        }

        /// <summary>
        /// Calculate National Insurance and return a single aspect of the calculation
        /// </summary>
        /// <param name="gross">Gross pay for NI</param>
        /// <param name="niCategory">National Insurance Category Letter</param>
        /// <param name="frequency">Payroll Frequency</param>
        /// <param name="mode">Aspect of National Insurance calculation to return</param>
        /// <param name="taxYear">Tax Year</param>
        /// <returns>Aspect of the result of a calculation of National Insurance</returns>
        public static decimal Calculate(decimal gross, char niCategory, PayrollFrequency frequency = PayrollFrequency.Weekly,
            NationalInsuranceMode mode = NationalInsuranceMode.Employee, int? taxYear = null, decimal periodGross = 0)
        {
            var calcResult = CalculateAll(gross, niCategory, frequency, taxYear, periodGross);

            switch (mode)
            {
                default:
                case NationalInsuranceMode.Net:
                    return calcResult.NetNi;
                case NationalInsuranceMode.Employee:
                    return calcResult.EmployeeNi;
                case NationalInsuranceMode.Employer:
                    return calcResult.EmployerNi;
            }
        }
    }
}
