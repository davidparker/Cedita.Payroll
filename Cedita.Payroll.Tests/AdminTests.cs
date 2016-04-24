// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using Cedita.Payroll.Rates;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cedita.Payroll.Tests
{
    [TestClass]
    public class AdminTests
    {
        [TestCategory("Payroll Admin Tests"), TestMethod]
        public void TaxBracketRetrieval()
        {
            TestBracket(2012, 20, 0, 34370);
            TestBracket(2012, 40, 34370, 150000);
            TestBracket(2012, 50, 150000, Int32.MaxValue);

            TestBracket(2013, 20, 0, 32010);
            TestBracket(2013, 40, 32010, 150000);
            TestBracket(2013, 45, 150000, Int32.MaxValue);

            TestBracket(2014, 20, 0, 31865);
            TestBracket(2014, 40, 31865, 150000);
            TestBracket(2014, 45, 150000, Int32.MaxValue);
        }

        [TestCategory("Payroll Admin Tests"), TestMethod]
        public void TaxDatesDerivation()
        {
            Assert.AreEqual(52, TaxDate.GetTaxWeek(new DateTime(2014, 04, 03)));
            Assert.AreEqual(52, TaxDate.GetTaxWeek(new DateTime(2014, 04, 04)));
            Assert.AreEqual(53, TaxDate.GetTaxWeek(new DateTime(2014, 04, 05)));
            Assert.AreEqual(1, TaxDate.GetTaxWeek(new DateTime(2014, 04, 06)));
            Assert.AreEqual(1, TaxDate.GetTaxWeek(new DateTime(2014, 04, 07)));
            Assert.AreEqual(10, TaxDate.GetTaxWeek(new DateTime(2014, 06, 09)));
        }

        [TestCategory("Payroll Admin Tests"), TestMethod]
        public void NumberTruncationTest()
        {
            Assert.AreEqual(9999.99999m, TaxMath.Truncate(9999.999999999m, 5));
            Assert.AreEqual(9999.9999m, TaxMath.Truncate(9999.999999999m, 4));
            Assert.AreEqual(9999.999m, TaxMath.Truncate(9999.999999999m, 3));
            Assert.AreEqual(9999.99m, TaxMath.Truncate(9999.999999999m, 2));
            Assert.AreEqual(9999.9m, TaxMath.Truncate(9999.999999999m, 1));
            Assert.AreEqual(9999m, TaxMath.Truncate(9999.999999999m, 0));
            Assert.AreEqual(9990m, TaxMath.Truncate(9999.999999999m, -1));

            Assert.AreEqual(-9999.99999m, TaxMath.Truncate(-9999.999999999m, 5));
            Assert.AreEqual(-9999.9999m, TaxMath.Truncate(-9999.999999999m, 4));
            Assert.AreEqual(-9999.999m, TaxMath.Truncate(-9999.999999999m, 3));
            Assert.AreEqual(-9999.99m, TaxMath.Truncate(-9999.999999999m, 2));
            Assert.AreEqual(-9999.9m, TaxMath.Truncate(-9999.999999999m, 1));
            Assert.AreEqual(-9999m, TaxMath.Truncate(-9999.999999999m, 0));
            Assert.AreEqual(-9990m, TaxMath.Truncate(-9999.999999999m, -1));
        }

        [TestCategory("Payroll Admin Tests"), TestMethod]
        public void BankersRoundingTest()
        {
            Assert.AreEqual(1m, TaxMath.BankersRound(0.99999m));
            Assert.AreEqual(1.96m, TaxMath.BankersRound(1.956m));
            Assert.AreEqual(2.96m, TaxMath.BankersRound(2.9555555m));
            Assert.AreEqual(2.47m, TaxMath.BankersRound(2.4719m));
            Assert.AreEqual(978.55m, TaxMath.BankersRound(978.54823m));
            Assert.AreEqual(8956.54m, TaxMath.BankersRound(8956.54168m));
            Assert.AreEqual(654.17m, TaxMath.BankersRound(654.168749m));
            Assert.AreEqual(236514.47m, TaxMath.BankersRound(236514.46984m));
            Assert.AreEqual(784.47m, TaxMath.BankersRound(784.4687m));
        }

        [TestCategory("Payroll Admin Tests"), TestMethod]
        public void HmrcRoundingTest()
        {
            Assert.AreEqual(1m, TaxMath.HmrcRound(0.99999m));
            Assert.AreEqual(1.96m, TaxMath.HmrcRound(1.956m));
            Assert.AreEqual(2.95m, TaxMath.HmrcRound(2.9555555m));
            Assert.AreEqual(2.47m, TaxMath.HmrcRound(2.4719m));
            Assert.AreEqual(978.55m, TaxMath.HmrcRound(978.54823m));
            Assert.AreEqual(8956.54m, TaxMath.HmrcRound(8956.54168m));
            Assert.AreEqual(654.17m, TaxMath.HmrcRound(654.168749m));
            Assert.AreEqual(236514.47m, TaxMath.HmrcRound(236514.46984m));
            Assert.AreEqual(784.47m, TaxMath.HmrcRound(784.4687m));
        }

        public void TestBracket(int year, int perc, decimal from, decimal to)
        {
            var rateAccess = new RateAccess(year);
            var brackets = rateAccess.Brackets;
            var percBracket = brackets.SingleOrDefault(b => b.Multiplier == (perc / 100m));
            if (percBracket == null)
                Assert.Fail("Cannot find bracket for " + perc + "% in " + year + ".");

            Assert.AreEqual(from, percBracket.From);
            Assert.AreEqual(to, percBracket.To);
        }
    }
}
