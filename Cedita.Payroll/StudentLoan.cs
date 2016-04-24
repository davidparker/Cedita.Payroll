// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cedita.Payroll
{
    public static class StudentLoan
    {
        public static decimal Calculate(decimal gross, PayrollFrequency frequency = PayrollFrequency.Weekly, int? taxYear = null)
        {
            if (!taxYear.HasValue)
                taxYear = TaxDate.GetTaxYear();

            var rateAccess = new Rates.RateAccess(taxYear.Value);

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

            var periodThreshold = TaxMath.Truncate(rateAccess.StudentLoanThreshold / periods, 2) * weeksInPeriod;

            var aboveThreshold = gross - periodThreshold;

            if (aboveThreshold < 0)
                return 0m;

            var studentLoanRepayment = aboveThreshold * rateAccess.StudentLoanRate;
            studentLoanRepayment = TaxMath.Truncate(studentLoanRepayment, 0);
            studentLoanRepayment = Math.Round(studentLoanRepayment, 2);

            return studentLoanRepayment;
        }
    }
}
