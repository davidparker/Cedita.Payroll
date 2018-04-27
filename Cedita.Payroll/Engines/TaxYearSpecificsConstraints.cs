// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.
using Cedita.Payroll.Models.TaxYearSpecifics;
using System.Collections.Generic;

namespace Cedita.Payroll.Engines
{
    /// <summary>
    /// Interface that supports the injection of an <see cref="IProvideTaxYearSpecifics"/> instance
    /// </summary>
    public interface IRequireTaxYearSpecifics
    {
        void SetTaxYearSpecificsProvider(IProvideTaxYearSpecifics provider);
        void SetTaxYear(int taxYear);
    }

    /// <summary>
    /// Interface to support the retrieval of Tax Year Specifics
    /// 
    /// It is recommended for high performance applications to provide your own static in-code implementation of this,
    /// or database / cache based at a minimum. This is to apply instead of the default JSON provider.
    /// </summary>
    public interface IProvideTaxYearSpecifics
    {
        void SetTaxYear(int taxYear);

        T GetSpecificValue<T>(TaxYearSpecificValues specificValueType);
        decimal GetPeriodTaxYearValue(TaxYearSpecificValues specificValueType, PayPeriods period);
        NationalInsuranceCode GetCodeSpecifics(char niCode);
        bool IsFixedCode(string taxCode, bool scottish = false);
        FixedCode GetFixedCode(string taxCode, bool scottish = false);
        IEnumerable<TaxBracket> GetTaxBrackets(bool scottish = false);
    }
}
