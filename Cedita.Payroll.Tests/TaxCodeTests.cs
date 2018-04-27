// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cedita.Payroll.Models;

namespace Cedita.Payroll.Tests
{
    [TestClass]
    public class TaxCodeTests
    {
        [TestCategory("Tax Code Tests"), TestMethod]
        public void ErroneousCodeHandling()
        {
            // Test TryParse
            Assert.AreEqual(false, TaxCode.TryParse("ABC", out var failedTaxCode));
            Assert.AreEqual(false, TaxCode.TryParse("X", out failedTaxCode));
            Assert.AreEqual(false, TaxCode.TryParse("0", out failedTaxCode));
            Assert.AreEqual(false, TaxCode.TryParse("-", out failedTaxCode));
            Assert.AreEqual(false, TaxCode.TryParse("!", out failedTaxCode));
            Assert.AreEqual(false, TaxCode.TryParse(null, out failedTaxCode));
            // Test Parse
            try { TaxCode.Parse("ABC"); Assert.Fail(); } catch { }
            try { TaxCode.Parse("X"); Assert.Fail(); } catch { }
            try { TaxCode.Parse("0"); Assert.Fail(); } catch { }
            try { TaxCode.Parse("-"); Assert.Fail(); } catch { }
            try { TaxCode.Parse("!"); Assert.Fail(); } catch { }
            try { TaxCode.Parse(null); Assert.Fail(); } catch { }
        }

        [TestCategory("Tax Code Tests"), TestMethod]
        public void TaxCodeDetermination()
        {
            var taxCode = TaxCode.Parse("S1100L");
            Assert.AreEqual(true, taxCode.IsValidTaxCode);
            Assert.AreEqual(true, taxCode.IsScotlandTax);
            Assert.AreEqual(false, taxCode.IsNoAdjustmentCode);
            Assert.AreEqual(false, taxCode.IsPrefixCode);

            taxCode = TaxCode.Parse("D0");
            Assert.AreEqual(true, taxCode.IsValidTaxCode);
            Assert.AreEqual(false, taxCode.IsScotlandTax);
            Assert.AreEqual(true, taxCode.IsNoAdjustmentCode);
            Assert.AreEqual(false, taxCode.IsPrefixCode);

            taxCode = TaxCode.Parse("0T");
            Assert.AreEqual(true, taxCode.IsValidTaxCode);
            Assert.AreEqual(false, taxCode.IsScotlandTax);
            Assert.AreEqual(false, taxCode.IsNoAdjustmentCode);
            Assert.AreEqual(false, taxCode.IsPrefixCode);

            taxCode = TaxCode.Parse("K666");
            Assert.AreEqual(true, taxCode.IsValidTaxCode);
            Assert.AreEqual(false, taxCode.IsScotlandTax);
            Assert.AreEqual(false, taxCode.IsNoAdjustmentCode);
            Assert.AreEqual(true, taxCode.IsPrefixCode);

            TaxCode.TryParse("!", out taxCode);
            Assert.AreEqual(false, taxCode.IsValidTaxCode);
            Assert.AreEqual(false, taxCode.IsScotlandTax);
            Assert.AreEqual(false, taxCode.IsNoAdjustmentCode);
            Assert.AreEqual(false, taxCode.IsPrefixCode);

            TaxCode.TryParse("D2", out taxCode);
            Assert.AreEqual(false, taxCode.IsValidTaxCode);
            Assert.AreEqual(false, taxCode.IsScotlandTax);
            Assert.AreEqual(false, taxCode.IsNoAdjustmentCode);
            Assert.AreEqual(false, taxCode.IsPrefixCode);

            taxCode = TaxCode.Parse("SD2");
            Assert.AreEqual(true, taxCode.IsValidTaxCode);
            Assert.AreEqual(true, taxCode.IsScotlandTax);
            Assert.AreEqual(true, taxCode.IsNoAdjustmentCode);
            Assert.AreEqual(false, taxCode.IsPrefixCode);
        }

        [TestCategory("Tax Code Tests"), TestMethod]
        public void TaxLetterSeparation()
        {
            // Standard
            Assert.AreEqual("L", TaxCode.Parse("1000L").TaxCodeLetter);
            Assert.AreEqual("L", TaxCode.Parse("S1000L").TaxCodeLetter);

            // Prefix Codes
            Assert.AreEqual("K", TaxCode.Parse("K944").TaxCodeLetter);
            Assert.AreEqual("K", TaxCode.Parse("K1000").TaxCodeLetter);
            Assert.AreEqual("K", TaxCode.Parse("SK1000").TaxCodeLetter);

            // Basic Rate
            Assert.AreEqual("BR", TaxCode.Parse("BR").TaxCodeLetter);
            Assert.AreEqual("BR", TaxCode.Parse("SBR").TaxCodeLetter);

            // D Codes
            Assert.AreEqual("D", TaxCode.Parse("D").TaxCodeLetter);
            Assert.AreEqual("D0", TaxCode.Parse("D0").TaxCodeLetter);
            Assert.AreEqual("D1", TaxCode.Parse("D1").TaxCodeLetter);
            Assert.AreEqual("D0", TaxCode.Parse("SD0").TaxCodeLetter);
            Assert.AreEqual("D2", TaxCode.Parse("SD2").TaxCodeLetter);

            // N* Codes
            Assert.AreEqual("NT", TaxCode.Parse("NT").TaxCodeLetter);
        }

        [TestCategory("Tax Code Tests"), TestMethod]
        public void TaxNumberSeparation()
        {
            // Standard
            Assert.AreEqual(944, TaxCode.Parse("944L").TaxCodeNumber);
            Assert.AreEqual(1000, TaxCode.Parse("1000L").TaxCodeNumber);
            Assert.AreEqual(1000, TaxCode.Parse("S1000L").TaxCodeNumber);

            // Prefix Codes
            Assert.AreEqual(944, TaxCode.Parse("K944").TaxCodeNumber);
            Assert.AreEqual(1000, TaxCode.Parse("K1000").TaxCodeNumber);
            Assert.AreEqual(1100, TaxCode.Parse("SK1100").TaxCodeNumber);

            // Basic Rate
            Assert.AreEqual(null, TaxCode.Parse("BR").TaxCodeNumber);
            //Assert.AreEqual(0, TaxCode.Parse("0BR").TaxCodeNumber);
            //Assert.AreEqual(0, TaxCode.Parse("BR0").TaxCodeNumber);

            // D Codes
            Assert.AreEqual(null, TaxCode.Parse("D").TaxCodeNumber);
            Assert.AreEqual(null, TaxCode.Parse("D0").TaxCodeNumber);
            Assert.AreEqual(null, TaxCode.Parse("D1").TaxCodeNumber);
            Assert.AreEqual(null, TaxCode.Parse("SD2").TaxCodeNumber);

            // N* Codes
            Assert.AreEqual(null, TaxCode.Parse("NT").TaxCodeNumber);
            Assert.AreEqual(null, TaxCode.Parse("N1").TaxCodeNumber);
        }
    }
}
