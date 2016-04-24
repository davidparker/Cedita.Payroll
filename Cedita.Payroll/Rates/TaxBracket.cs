// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cedita.Payroll.Rates
{
    public class TaxBracket
    {
        /// <summary>
        /// Bracket From (Monetary)
        /// </summary>
        public decimal From { get; set; }

        /// <summary>
        /// Bracket To (Monetary)
        /// </summary>
        public decimal To { get; set; }

        /// <summary>
        /// Tax Multiplier Value (Percentage Rate)
        /// </summary>
        public decimal Multiplier { get; set; }
    }
}
