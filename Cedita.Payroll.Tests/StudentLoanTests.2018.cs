// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.
using Cedita.Payroll.Engines;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cedita.Payroll.Tests
{
    public partial class StudentLoanTests
    {
        [TestCategory("Student Loan Tests"), TestMethod]
        public void StudentLoanPlan1ExactMethod2018()
        {
            Assert.AreEqual(0, TestShim(2018, StudentLoanPlan.Plan1, 363.61m, PayPeriods.Weekly));
            Assert.AreEqual(1, TestShim(2018, StudentLoanPlan.Plan1, 363.62m, PayPeriods.Weekly));
            Assert.AreEqual(1, TestShim(2018, StudentLoanPlan.Plan1, 364.04m, PayPeriods.Weekly));
            Assert.AreEqual(8, TestShim(2018, StudentLoanPlan.Plan1, 450m, PayPeriods.Weekly));
            Assert.AreEqual(116, TestShim(2018, StudentLoanPlan.Plan1, 1650m, PayPeriods.Weekly));
            Assert.AreEqual(157, TestShim(2018, StudentLoanPlan.Plan1, 2100m, PayPeriods.Weekly));

            Assert.AreEqual(0, TestShim(2018, StudentLoanPlan.Plan1, 716.11m, PayPeriods.Fortnightly));
            Assert.AreEqual(1, TestShim(2018, StudentLoanPlan.Plan1, 716.12m, PayPeriods.Fortnightly));
            Assert.AreEqual(4, TestShim(2018, StudentLoanPlan.Plan1, 750.52m, PayPeriods.Fortnightly));
            Assert.AreEqual(6, TestShim(2018, StudentLoanPlan.Plan1, 775m, PayPeriods.Fortnightly));
            Assert.AreEqual(16, TestShim(2018, StudentLoanPlan.Plan1, 888m, PayPeriods.Fortnightly));
            Assert.AreEqual(265, TestShim(2018, StudentLoanPlan.Plan1, 3654m, PayPeriods.Fortnightly));
            Assert.AreEqual(386, TestShim(2018, StudentLoanPlan.Plan1, 5000m, PayPeriods.Fortnightly));
            
            Assert.AreEqual(0, TestShim(2018, StudentLoanPlan.Plan1, 1421.11m, PayPeriods.FourWeekly));
            Assert.AreEqual(1, TestShim(2018, StudentLoanPlan.Plan1, 1421.12m, PayPeriods.FourWeekly));
            Assert.AreEqual(18, TestShim(2018, StudentLoanPlan.Plan1, 1610m, PayPeriods.FourWeekly));
            Assert.AreEqual(52, TestShim(2018, StudentLoanPlan.Plan1, 1989.52m, PayPeriods.FourWeekly));
            Assert.AreEqual(106, TestShim(2018, StudentLoanPlan.Plan1, 2588.91m, PayPeriods.FourWeekly));
            Assert.AreEqual(593, TestShim(2018, StudentLoanPlan.Plan1, 8000, PayPeriods.FourWeekly));
            
            Assert.AreEqual(0, TestShim(2018, StudentLoanPlan.Plan1, 1538.61m, PayPeriods.Monthly));
            Assert.AreEqual(1, TestShim(2018, StudentLoanPlan.Plan1, 1538.62m, PayPeriods.Monthly));
            Assert.AreEqual(31, TestShim(2018, StudentLoanPlan.Plan1, 1874.46m, PayPeriods.Monthly));
            Assert.AreEqual(39, TestShim(2018, StudentLoanPlan.Plan1, 1964.71m, PayPeriods.Monthly));
            Assert.AreEqual(113, TestShim(2018, StudentLoanPlan.Plan1, 2791, PayPeriods.Monthly));
            Assert.AreEqual(242, TestShim(2018, StudentLoanPlan.Plan1, 4222, PayPeriods.Monthly));
            Assert.AreEqual(591, TestShim(2018, StudentLoanPlan.Plan1, 8100, PayPeriods.Monthly));
        }

        [TestCategory("Student Loan Tests"), TestMethod]
        public void StudentLoanPlan2ExactMethod2018()
        {
            Assert.AreEqual(0, TestShim(2018, StudentLoanPlan.Plan2, 491.87m, PayPeriods.Weekly));
            Assert.AreEqual(1, TestShim(2018, StudentLoanPlan.Plan2, 491.88m, PayPeriods.Weekly));
            Assert.AreEqual(6, TestShim(2018, StudentLoanPlan.Plan2, 550m, PayPeriods.Weekly));
            Assert.AreEqual(35, TestShim(2018, StudentLoanPlan.Plan2, 876.5m, PayPeriods.Weekly));
            Assert.AreEqual(107, TestShim(2018, StudentLoanPlan.Plan2, 1675m, PayPeriods.Weekly));
            Assert.AreEqual(136, TestShim(2018, StudentLoanPlan.Plan2, 2000m, PayPeriods.Weekly));
            
            Assert.AreEqual(0, TestShim(2018, StudentLoanPlan.Plan2, 972.64m, PayPeriods.Fortnightly));
            Assert.AreEqual(1, TestShim(2018, StudentLoanPlan.Plan2, 972.65m, PayPeriods.Fortnightly));
            Assert.AreEqual(48, TestShim(2018, StudentLoanPlan.Plan2, 1500m, PayPeriods.Fortnightly));
            Assert.AreEqual(116, TestShim(2018, StudentLoanPlan.Plan2, 2252.4m, PayPeriods.Fortnightly));
            Assert.AreEqual(194, TestShim(2018, StudentLoanPlan.Plan2, 3125.9m, PayPeriods.Fortnightly));
            Assert.AreEqual(224, TestShim(2018, StudentLoanPlan.Plan2, 3456m, PayPeriods.Fortnightly));
            Assert.AreEqual(363, TestShim(2018, StudentLoanPlan.Plan2, 5000m, PayPeriods.Fortnightly));

            Assert.AreEqual(0, TestShim(2018, StudentLoanPlan.Plan2, 1934.18m, PayPeriods.FourWeekly));
            Assert.AreEqual(1, TestShim(2018, StudentLoanPlan.Plan2, 1934.19m, PayPeriods.FourWeekly));
            Assert.AreEqual(49, TestShim(2018, StudentLoanPlan.Plan2, 2475.5m, PayPeriods.FourWeekly));
            Assert.AreEqual(149, TestShim(2018, StudentLoanPlan.Plan2, 3588.91m, PayPeriods.FourWeekly));
            Assert.AreEqual(366, TestShim(2018, StudentLoanPlan.Plan2, 5992.2m, PayPeriods.FourWeekly));
            Assert.AreEqual(546, TestShim(2018, StudentLoanPlan.Plan2, 8000m, PayPeriods.FourWeekly));

            Assert.AreEqual(0, TestShim(2018, StudentLoanPlan.Plan2, 2094.44m, PayPeriods.Monthly));
            Assert.AreEqual(1, TestShim(2018, StudentLoanPlan.Plan2, 2094.45m, PayPeriods.Monthly));
            Assert.AreEqual(212, TestShim(2018, StudentLoanPlan.Plan2, 4444m, PayPeriods.Monthly));
            Assert.AreEqual(395, TestShim(2018, StudentLoanPlan.Plan2, 6475m, PayPeriods.Monthly));
            Assert.AreEqual(531, TestShim(2018, StudentLoanPlan.Plan2, 7990m, PayPeriods.Monthly));
            Assert.AreEqual(541, TestShim(2018, StudentLoanPlan.Plan2, 8100m, PayPeriods.Monthly));
            Assert.AreEqual(667, TestShim(2018, StudentLoanPlan.Plan2, 9500.75m, PayPeriods.Monthly));
        }
    }
}
