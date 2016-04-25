// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cedita.Payroll.Tests
{
    /**
     * PAYE Tests
     * 
     * Official Test Data can be sourced from: http://www.hmrc.gov.uk/ebu/testdata.htm
     */
    [TestClass]
    public partial class PayeTests
    {
        [TestCategory("Payroll PAYE Tests"), TestMethod]
        public void TaxLetterSeparation()
        {
            // Standard
            Assert.AreEqual("L", Paye.CodeLetter("1000L"));

            // Prefix Codes
            Assert.AreEqual("K", Paye.CodeLetter("K944"));
            Assert.AreEqual("K", Paye.CodeLetter("K1000"));

            // Basic Rate
            Assert.AreEqual("BR", Paye.CodeLetter("BR"));
            Assert.AreEqual("BR", Paye.CodeLetter("0BR"));
            Assert.AreEqual("BR", Paye.CodeLetter("BR0"));

            // D Codes
            Assert.AreEqual("D", Paye.CodeLetter("D"));
            Assert.AreEqual("D0", Paye.CodeLetter("D0"));
            Assert.AreEqual("D1", Paye.CodeLetter("D1"));

            // N* Codes
            Assert.AreEqual("NT", Paye.CodeLetter("NT"));
            Assert.AreEqual("NI", Paye.CodeLetter("NI"));

            // Erroneous Codes
            Assert.AreEqual("AB", Paye.CodeLetter("AB12"));
            try
            {
                Assert.AreEqual(null, Paye.CodeLetter("ABC"));
                Assert.Fail();
            }
            catch (TaxCodeFormatException) { }
            catch (Exception) { Assert.Fail(); }

            try
            {
                Assert.AreEqual(null, Paye.CodeLetter("!"));
                Assert.Fail();
            }
            catch (TaxCodeFormatException) { }
            catch (Exception) { Assert.Fail(); }

            try
            {
                Assert.AreEqual(null, Paye.CodeLetter(null));
                Assert.Fail();
            }
            catch (TaxCodeFormatException) { }
            catch (Exception) { Assert.Fail(); }
        }

        [TestCategory("Payroll PAYE Tests"), TestMethod]
        public void TaxNumberSeparation()
        {
            // Standard
            Assert.AreEqual(944, Paye.CodeNumber("944L"));
            Assert.AreEqual(1000, Paye.CodeNumber("1000L"));

            // Prefix Codes
            Assert.AreEqual(944, Paye.CodeNumber("K944"));
            Assert.AreEqual(1000, Paye.CodeNumber("K1000"));

            // Basic Rate
            Assert.AreEqual(null, Paye.CodeNumber("BR"));
            Assert.AreEqual(0, Paye.CodeNumber("0BR"));
            Assert.AreEqual(0, Paye.CodeNumber("BR0"));

            // D Codes
            Assert.AreEqual(null, Paye.CodeNumber("D"));
            Assert.AreEqual(null, Paye.CodeNumber("D0"));
            Assert.AreEqual(null, Paye.CodeNumber("D1"));

            // N* Codes
            Assert.AreEqual(null, Paye.CodeNumber("NT"));
            Assert.AreEqual(null, Paye.CodeNumber("N1"));

            // Erroneous Codes
            Assert.AreEqual(12, Paye.CodeNumber("AB12"));
            try
            {
                Assert.AreEqual(null, Paye.CodeNumber("ABC"));
                Assert.Fail();
            }
            catch (TaxCodeFormatException) { }
            catch (Exception) { Assert.Fail(); }

            try
            {
                Assert.AreEqual(null, Paye.CodeNumber("!"));
                Assert.Fail();
            }
            catch (TaxCodeFormatException) { }
            catch (Exception) { Assert.Fail(); }

            try
            {
                Assert.AreEqual(null, Paye.CodeNumber(null));
                Assert.Fail();
            }
            catch (TaxCodeFormatException) { }
            catch (Exception) { Assert.Fail(); }
        }

        [TestMethod]
        public void PeriodTests()
        {
            Assert.AreEqual(10.40m, Paye.Calculate(244.74m, "1000L", PayrollFrequency.Weekly, 17, 3518.49m, 87.6m, false, 2014));
            Assert.AreEqual(43.80m, Paye.Calculate(218.64m, "1000L", PayrollFrequency.Weekly, 17, 3763.23m, 98m, false, 2014));
            Assert.AreEqual(11.17m, NationalInsurance.Calculate(246.09m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Employee, 2014));
            Assert.AreEqual(12.85m, NationalInsurance.Calculate(246.09m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Employer, 2014));
            //Assert.AreEqual(26.50m, NationalInsurance.Calculate(220.85m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Employee, 2014, 246.09m));
            //Assert.AreEqual(30.47m, NationalInsurance.Calculate(220.85m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Employee, 2014, 246.09m));
        }
    }
}
