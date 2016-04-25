// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cedita.Payroll.Rates
{
    interface IRateYear
    {
        Dictionary<string, decimal> FixedCodes { get; }
        List<TaxBracket> Brackets { get; }
        Dictionary<char, NiRateTable> NiRates { get; }

        string DefaultTaxCode { get; }

        decimal LowerEarningsLimit { get; }
        decimal UpperEarningsLimit { get; }
        decimal PrimaryThreshold { get; }
        decimal SecondaryThreshold { get; }
        decimal UpperAccrualPoint { get; }
        decimal UpperSecondaryThreshold { get; }
        decimal ApprenticeUpperSecondaryThreshold { get; }

        decimal StudentLoanThreshold { get; }
        decimal StudentLoanRate { get; }

        decimal PensionLowerThreshold { get; }
        decimal PensionAutomaticEnrolment { get; }
        decimal PensionUpperThreshold { get; }

        decimal DeaProtectedEarnings { get; }
    }
}
