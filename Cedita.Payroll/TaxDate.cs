// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cedita.Payroll
{
    public class TaxPeriod
    {
        public int Year { get; set; }
        public int Week { get; set; }
        public int Fortnight { get; set; }
        public int FourWeek { get; set; }
        public int Month { get; set; }
    }

    public static class TaxDate
    {
        public static TaxPeriod GetTaxPeriods(DateTime? date)
        {
            if (date == null)
                date = DateTime.Now;

            DateTime workDate = date.Value;

            var taxPeriod = new TaxPeriod { Year = workDate.Year };

            if (workDate.Month < 4 || (workDate.Month == 4 && workDate.Day < 6))
                taxPeriod.Year--;

            var taxYearStart = new DateTime(taxPeriod.Year, 4, 6);

            var span = workDate - taxYearStart;

            taxPeriod.Week = (int)(Math.Floor(span.Days / 7d)) + 1;
            taxPeriod.Fortnight = taxPeriod.Week / 2;
            taxPeriod.FourWeek = taxPeriod.Week / 4;

            // Month is a little more tricky
            if (workDate.Day < 6)
                workDate = workDate.AddMonths(-1);

            var monthDiff = workDate.Month - 4;
            var yearDiff = workDate.Year - taxPeriod.Year;
            taxPeriod.Month = ((yearDiff * 12) + monthDiff) + 1;

            return taxPeriod;
        }

        public static int GetPeriods(PayrollFrequency frequency)
        {
            switch (frequency)
            {
                default:
                case PayrollFrequency.Weekly:
                    return 52;
                case PayrollFrequency.Fortnightly:
                    return 28;
                case PayrollFrequency.FourWeekly:
                    return 13;
                case PayrollFrequency.Monthly:
                    return 12;
            }
        }

        public static int GetTaxYear(DateTime? date = null)
        {
            var periods = GetTaxPeriods(date);
            return periods.Year;
        }

        public static int GetTaxWeek(DateTime? date = null)
        {
            var periods = GetTaxPeriods(date);
            return periods.Week;
        }

        public static int GetTaxPeriod(PayrollFrequency frequency, DateTime? date)
        {
            var periods = GetTaxPeriods(date);
            switch (frequency)
            {
                case PayrollFrequency.Monthly:
                    return periods.Month;
                case PayrollFrequency.Weekly:
                    return periods.Week;
                case PayrollFrequency.FourWeekly:
                    return periods.FourWeek;
                case PayrollFrequency.Fortnightly:
                    return periods.Fortnight;
            }
            return 0;
        }
    }
}
