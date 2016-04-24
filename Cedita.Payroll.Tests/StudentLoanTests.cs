// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using Cedita.Payroll;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cedita.Payroll.Tests
{
    [TestClass]
    public class StudentLoanTests
    {
        [TestMethod]
        public void StudentLoan2014()
        {
            // Weekly
            Assert.AreEqual(0m, StudentLoan.Calculate(336.30m, PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(1m, StudentLoan.Calculate(336.33m, PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(1m, StudentLoan.Calculate(347.41m, PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(6m, StudentLoan.Calculate(393.09m, PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(119m, StudentLoan.Calculate(1649.00m, PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(150m, StudentLoan.Calculate(2000m, PayrollFrequency.Weekly, 2014));
            // Fortnightly
            Assert.AreEqual(0m, StudentLoan.Calculate(661.49m, PayrollFrequency.Fortnightly, 2014));
            Assert.AreEqual(1m, StudentLoan.Calculate(661.50m, PayrollFrequency.Fortnightly, 2014));
            Assert.AreEqual(1m, StudentLoan.Calculate(672.60m, PayrollFrequency.Fortnightly, 2014));
            Assert.AreEqual(7m, StudentLoan.Calculate(736.00m, PayrollFrequency.Fortnightly, 2014));
            Assert.AreEqual(13m, StudentLoan.Calculate(805.00m, PayrollFrequency.Fortnightly, 2014));
            Assert.AreEqual(252m, StudentLoan.Calculate(3456.78m, PayrollFrequency.Fortnightly, 2014));
            Assert.AreEqual(391m, StudentLoan.Calculate(5000m, PayrollFrequency.Fortnightly, 2014));
            // 4 Weekly
            Assert.AreEqual(0m, StudentLoan.Calculate(1311.87m, PayrollFrequency.FourWeekly, 2014));
            Assert.AreEqual(1m, StudentLoan.Calculate(1311.88m, PayrollFrequency.FourWeekly, 2014));
            Assert.AreEqual(3m, StudentLoan.Calculate(1343.11m, PayrollFrequency.FourWeekly, 2014));
            Assert.AreEqual(17m, StudentLoan.Calculate(1490.00m, PayrollFrequency.FourWeekly, 2014));
            Assert.AreEqual(23m, StudentLoan.Calculate(1556.91m, PayrollFrequency.FourWeekly, 2014));
            Assert.AreEqual(530m, StudentLoan.Calculate(7199.25m, PayrollFrequency.FourWeekly, 2014));
            Assert.AreEqual(602m, StudentLoan.Calculate(8000.00m, PayrollFrequency.FourWeekly, 2014));
            // Monthly
            Assert.AreEqual(0m, StudentLoan.Calculate(1420.27m, PayrollFrequency.Monthly, 2014));
            Assert.AreEqual(1m, StudentLoan.Calculate(1420.28m, PayrollFrequency.Monthly, 2014));
            Assert.AreEqual(1m, StudentLoan.Calculate(1431.38m, PayrollFrequency.Monthly, 2014));
            Assert.AreEqual(18m, StudentLoan.Calculate(1614.29m, PayrollFrequency.Monthly, 2014));
            Assert.AreEqual(34m, StudentLoan.Calculate(1791.91m, PayrollFrequency.Monthly, 2014));
            Assert.AreEqual(73m, StudentLoan.Calculate(2222.22m, PayrollFrequency.Monthly, 2014));
            Assert.AreEqual(600m, StudentLoan.Calculate(8080.00m, PayrollFrequency.Monthly, 2014));
        }

        [TestMethod]
        public void StudentLoan2013()
        {
            // Weekly
            Assert.AreEqual(0m, StudentLoan.Calculate(325.82m, PayrollFrequency.Weekly, 2013));
            Assert.AreEqual(1m, StudentLoan.Calculate(325.83m, PayrollFrequency.Weekly, 2013));
            Assert.AreEqual(5m, StudentLoan.Calculate(372.41m, PayrollFrequency.Weekly, 2013));
            Assert.AreEqual(6m, StudentLoan.Calculate(382.61m, PayrollFrequency.Weekly, 2013));
            Assert.AreEqual(119m, StudentLoan.Calculate(1638.00m, PayrollFrequency.Weekly, 2013));
            Assert.AreEqual(151m, StudentLoan.Calculate(2000.00m, PayrollFrequency.Weekly, 2013));
            // Fortnightly
            Assert.AreEqual(0m, StudentLoan.Calculate(640.53m, PayrollFrequency.Fortnightly, 2013));
            Assert.AreEqual(1m, StudentLoan.Calculate(640.54m, PayrollFrequency.Fortnightly, 2013));
            Assert.AreEqual(2m, StudentLoan.Calculate(651.90m, PayrollFrequency.Fortnightly, 2013));
            Assert.AreEqual(6m, StudentLoan.Calculate(706.00m, PayrollFrequency.Fortnightly, 2013));
            Assert.AreEqual(12m, StudentLoan.Calculate(770.04m, PayrollFrequency.Fortnightly, 2013));
            Assert.AreEqual(253m, StudentLoan.Calculate(3441.65m, PayrollFrequency.Fortnightly, 2013));
            Assert.AreEqual(393m, StudentLoan.Calculate(5000.00m, PayrollFrequency.Fortnightly, 2013));
            // 4 Weekly
            Assert.AreEqual(0m, StudentLoan.Calculate(1269.95m, PayrollFrequency.FourWeekly, 2013));
            Assert.AreEqual(1m, StudentLoan.Calculate(1269.96m, PayrollFrequency.FourWeekly, 2013));
            Assert.AreEqual(4m, StudentLoan.Calculate(1303.80m, PayrollFrequency.FourWeekly, 2013));
            Assert.AreEqual(16m, StudentLoan.Calculate(1440.84m, PayrollFrequency.FourWeekly, 2013));
            Assert.AreEqual(23m, StudentLoan.Calculate(1516.23m, PayrollFrequency.FourWeekly, 2013));
            Assert.AreEqual(531m, StudentLoan.Calculate(7169.34m, PayrollFrequency.FourWeekly, 2013));
            Assert.AreEqual(606m, StudentLoan.Calculate(8000.00m, PayrollFrequency.FourWeekly, 2013));
            // Monthly
            Assert.AreEqual(0m, StudentLoan.Calculate(1374.86m, PayrollFrequency.Monthly, 2013));
            Assert.AreEqual(1m, StudentLoan.Calculate(1374.87m, PayrollFrequency.Monthly, 2013));
            Assert.AreEqual(1m, StudentLoan.Calculate(1375.50m, PayrollFrequency.Monthly, 2013));
            Assert.AreEqual(18m, StudentLoan.Calculate(1568.84m, PayrollFrequency.Monthly, 2013));
            Assert.AreEqual(34m, StudentLoan.Calculate(1746.50m, PayrollFrequency.Monthly, 2013));
            Assert.AreEqual(72m, StudentLoan.Calculate(2163.75m, PayrollFrequency.Monthly, 2013));
            Assert.AreEqual(599m, StudentLoan.Calculate(8023.00m, PayrollFrequency.Monthly, 2013));
        }
    }
}
