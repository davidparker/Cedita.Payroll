// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using System;
using System.Collections.Generic;

namespace Cedita.Payroll.Rates
{
    internal class Rates2015 : IRateYear
    {
        public Dictionary<string, decimal> FixedCodes
        { 
            get {
                return new Dictionary<string, decimal>
                {
                    { "BR", 0.2m },
                    { "D0", 0.4m },
                    { "D1", 0.45m },
                    { "N1", 0 },
                    { "NT", 0 },
                };
            }
        }
        public Dictionary<char, NiRateTable> NiRates
        {
            get
            {
                return new Dictionary<char, NiRateTable>
                {
                    { 'A', new NiRateTable
                        {
                            EeB = 0.00m,
                            EeC = 0.00m,
                            EeD = 12.00m,
                            EeE = 12.00m,
                            EeF = 2.00m,
                            ErB = 0.00m,
                            ErC = 0.00m,
                            ErD = 13.80m,
                            ErE = 13.80m,
                            ErF = 13.80m
                        }
                    },
                    { 'B', new NiRateTable
                        {
                            EeB = 0.00m,
                            EeC = 0.00m,
                            EeD = 5.85m,
                            EeE = 5.85m,
                            EeF = 2.00m,
                            ErB = 0.00m,
                            ErC = 0.00m,
                            ErD = 13.80m,
                            ErE = 13.80m,
                            ErF = 13.80m
                        }
                    },
                    { 'C', new NiRateTable
                        {
                            EeB = 0.00m,
                            EeC = 0.00m,
                            EeD = 0.00m,
                            EeE = 0.00m,
                            EeF = 0.00m,
                            ErB = 0.00m,
                            ErC = 0.00m,
                            ErD = 13.80m,
                            ErE = 13.80m,
                            ErF = 13.80m
                        }
                    },
                    { 'D', new NiRateTable
                        {
                            EeB = 1.40m,
                            EeC = 1.40m,
                            EeD = 10.60m,
                            EeE = 12.00m,
                            EeF = 2.00m,
                            ErB = 3.40m,
                            ErC = 3.40m,
                            ErD = 10.40m,
                            ErE = 13.80m,
                            ErF = 13.80m
                        }
                    },
                    { 'E', new NiRateTable
                        {
                            EeB = 0.00m,
                            EeC = 0.00m,
                            EeD = 5.85m,
                            EeE = 5.85m,
                            EeF = 2.00m,
                            ErB = 3.40m,
                            ErC = 3.40m,
                            ErD = 10.40m,
                            ErE = 13.80m,
                            ErF = 13.80m
                        }
                    },
                    { 'I', new NiRateTable
                        {
                            EeB = 1.40m,
                            EeC = 1.40m,
                            EeD = 10.60m,
                            EeE = 12.00m,
                            EeF = 2.00m,
                            ErB = 3.40m,
                            ErC = 3.40m,
                            ErD = 10.40m,
                            ErE = 13.80m,
                            ErF = 13.80m
                        }
                    },
                    { 'J', new NiRateTable
                        {
                            EeB = 0.00m,
                            EeC = 0.00m,
                            EeD = 2.00m,
                            EeE = 2.00m,
                            EeF = 2.00m,
                            ErB = 0.00m,
                            ErC = 0.00m,
                            ErD = 13.80m,
                            ErE = 13.80m,
                            ErF = 13.80m
                        }
                    },
                    { 'K', new NiRateTable
                        {
                            EeB = 1.40m,
                            EeC = 1.40m,
                            EeD = 2.00m,
                            EeE = 2.00m,
                            EeF = 2.00m,
                            ErB = 3.40m,
                            ErC = 3.40m,
                            ErD = 10.40m,
                            ErE = 13.80m,
                            ErF = 13.80m
                        }
                    },
                    { 'L', new NiRateTable
                        {
                            EeB = 1.40m,
                            EeC = 1.40m,
                            EeD = 2.00m,
                            EeE = 2.00m,
                            EeF = 2.00m,
                            ErB = 3.40m,
                            ErC = 3.40m,
                            ErD = 10.40m,
                            ErE = 13.80m,
                            ErF = 13.80m
                        }
                    },
                    { 'M', new NiRateTable
                        {
                            EeB = 0.00m,
                            EeC = 0.00m,
                            EeD = 12.00m,
                            EeE = 12.00m,
                            EeF = 2.00m,
                            ErB = 0.00m,
                            ErC = 0.00m,
                            ErD = 0.00m,
                            ErE = 0.00m,
                            ErF = 13.80m
                        }
                    },
                    { 'Z', new NiRateTable
                        {
                            EeB = 0.00m,
                            EeC = 0.00m,
                            EeD = 2.00m,
                            EeE = 2.00m,
                            EeF = 2.00m,
                            ErB = 0.00m,
                            ErC = 0.00m,
                            ErD = 0.00m,
                            ErE = 0.00m,
                            ErF = 13.80m
                        }
                    },
                };
            }
        }
        public List<TaxBracket> Brackets
        {
            get
            {
                return new List<TaxBracket>
                {
                    new TaxBracket { From = 0, To = 31785, Multiplier = 0.2m },
                    new TaxBracket { From = 31785, To = 150000, Multiplier = 0.4m },
                    new TaxBracket { From = 150000, To = Int32.MaxValue, Multiplier = 0.45m },
                };
            }
        }

        public string DefaultTaxCode { get { return "1060L"; } }

        public decimal LowerEarningsLimit { get { return 5824; } }
        public decimal UpperEarningsLimit { get { return 42385; } }
        public decimal PrimaryThreshold { get { return 8060; } }
        public decimal SecondaryThreshold { get { return 8112; } }
        public decimal UpperAccrualPoint { get { return 40040; } }

        public decimal StudentLoanThreshold { get { return 16910; } }
        public decimal StudentLoanRate { get { return 0.09m; } }

        public decimal DeaProtectedEarnings { get { return 0.6m; } }

        public decimal PensionLowerThreshold { get { return 5824m; } }
        public decimal PensionAutomaticEnrolment { get { return 10000m; } }
        public decimal PensionUpperThreshold { get { return 43000m; } }

        public decimal UpperSecondaryThreshold
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal ApprenticeUpperSecondaryThreshold
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
