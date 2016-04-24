// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using System;

namespace Cedita.Payroll
{
    public class TaxCodeFormatException : Exception
    {
        public TaxCodeFormatException(string taxCode) : base(taxCode + " is an invalid tax code format.") { }
    }

    public class InvalidNiCategoryException : Exception
    {
        public InvalidNiCategoryException(char niCategory) : base(niCategory + " is not a valid NI category.") { }
    }
}
