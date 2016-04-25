// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cedita.Payroll.Rates
{
    public class RateAccess
    {
        private static Dictionary<int, IRateYear> RateCache = new Dictionary<int, IRateYear>();

        private int _year;

        public RateAccess(int year = 2014)
        {
            _year = year;
            if (!RateCache.ContainsKey(year))
            {
                var t = Type.GetType("Cedita.Payroll.Rates.Rates" + _year);
                RateCache[year] = (IRateYear)Activator.CreateInstance(t);
            }
        }

        public Dictionary<string, decimal> FixedCodes { get { return RateCache[_year].FixedCodes; } }
        public List<TaxBracket> Brackets { get { return RateCache[_year].Brackets; } }
        public Dictionary<char, NiRateTable> NiRates { get { return RateCache[_year].NiRates; } }

        public string DefaultTaxCode { get { return RateCache[_year].DefaultTaxCode; } }

        public decimal LowerEarningsLimit { get { return RateCache[_year].LowerEarningsLimit; } }
        public decimal UpperEarningsLimit { get { return RateCache[_year].UpperEarningsLimit; } }
        public decimal PrimaryThreshold { get { return RateCache[_year].PrimaryThreshold; } }
        public decimal SecondaryThreshold { get { return RateCache[_year].SecondaryThreshold; } }
        public decimal UpperAccrualPoint { get { return RateCache[_year].UpperAccrualPoint; } }

        public decimal UpperSecondaryThreshold { get { return RateCache[_year].UpperSecondaryThreshold; } }
        public decimal ApprenticeUpperSecondaryThreshold { get { return RateCache[_year].ApprenticeUpperSecondaryThreshold; } }

        public decimal StudentLoanThreshold { get { return RateCache[_year].StudentLoanThreshold; } }
        public decimal StudentLoanRate { get { return RateCache[_year].StudentLoanRate; } }

        public decimal DeaProtectedEarnings { get { return RateCache[_year].DeaProtectedEarnings; } }
    }
}
