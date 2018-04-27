// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cedita.Payroll.Tests
{
    public partial class NiTests
    {
        [TestCategory("NI Tests"), TestMethod]
        public void NationalInsurance2018()
        {
            // A
            var niCode = 'A';
            Assert.AreEqual(0.00m, TestShim(162.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0.02m, TestShim(162.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(188.34m, TestShim(892.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(188.35m, TestShim(892.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(188.38m, TestShim(892.29m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(188.39m, TestShim(892.30m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(233.84m, TestShim(1180.00m, niCode, PayPeriods.Weekly, 2018));

            Assert.AreEqual(0.00m, TestShim(324.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0.02m, TestShim(324.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(376.42m, TestShim(1783.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(376.43m, TestShim(1783.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(376.46m, TestShim(1783.29m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(376.47m, TestShim(1783.30m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(496.82m, TestShim(2545m, niCode, PayPeriods.Fortnightly, 2018));

            Assert.AreEqual(0.00m, TestShim(648.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0.02m, TestShim(648.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(752.84m, TestShim(3566.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(752.85m, TestShim(3566.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(752.88m, TestShim(3566.29m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(752.89m, TestShim(3566.30m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(955.71m, TestShim(4850m, niCode, PayPeriods.FourWeekly, 2018));

            Assert.AreEqual(0.00m, TestShim(702.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0.02m, TestShim(702.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(815.54m, TestShim(3863.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(815.55m, TestShim(3863.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(815.58m, TestShim(3863.29m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(815.59m, TestShim(3863.30m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(1074.19m, TestShim(5500m, niCode, PayPeriods.Monthly, 2018));

            // B
            niCode = 'B';
            Assert.AreEqual(0.00m, TestShim(162.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0.01m, TestShim(162.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0.01m, TestShim(162.10m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0.02m, TestShim(162.11m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(143.44m, TestShim(892.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(143.45m, TestShim(892.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(143.48m, TestShim(892.29m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(143.49m, TestShim(892.30m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(188.94m, TestShim(1180m, niCode, PayPeriods.Weekly, 2018));

            Assert.AreEqual(0.00m, TestShim(324.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0.01m, TestShim(324.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0.01m, TestShim(324.10m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0.02m, TestShim(324.11m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(286.69m, TestShim(1783.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(286.70m, TestShim(1783.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(286.73m, TestShim(1783.29m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(286.74m, TestShim(1783.30m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(407.09m, TestShim(2545m, niCode, PayPeriods.Fortnightly, 2018));

            Assert.AreEqual(0.00m, TestShim(648.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0.01m, TestShim(648.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0.01m, TestShim(648.10m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0.02m, TestShim(648.11m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(573.38m, TestShim(3566.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(573.39m, TestShim(3566.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(573.42m, TestShim(3566.29m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(573.43m, TestShim(3566.30m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(776.25m, TestShim(4850m, niCode, PayPeriods.FourWeekly, 2018));

            Assert.AreEqual(0.00m, TestShim(702.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0.01m, TestShim(702.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0.01m, TestShim(702.10m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0.02m, TestShim(702.11m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(621.14m, TestShim(3863.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(621.15m, TestShim(3863.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(621.18m, TestShim(3863.29m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(621.19m, TestShim(3863.30m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(879.79m, TestShim(5500m, niCode, PayPeriods.Monthly, 2018));

            // C
            niCode = 'C';
            Assert.AreEqual(0.00m, TestShim(162.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0.01m, TestShim(162.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(100.74m, TestShim(892.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(100.75m, TestShim(892.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(140.48m, TestShim(1180m, niCode, PayPeriods.Weekly, 2018));

            Assert.AreEqual(0.00m, TestShim(324.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0.01m, TestShim(324.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(201.34m, TestShim(1783.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(201.35m, TestShim(1783.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(306.50m, TestShim(2545m, niCode, PayPeriods.Fortnightly, 2018));

            Assert.AreEqual(0.00m, TestShim(648.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0.01m, TestShim(648.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(402.68m, TestShim(3566.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(402.69m, TestShim(3566.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(579.87m, TestShim(4850m, niCode, PayPeriods.FourWeekly, 2018));

            Assert.AreEqual(0.00m, TestShim(702.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0.01m, TestShim(702.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(436.22m, TestShim(3863.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(436.23m, TestShim(3863.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(662.13m, TestShim(5500m, niCode, PayPeriods.Monthly, 2018));

            // H
            niCode = 'H';
            Assert.AreEqual(0.00m, TestShim(162.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0.01m, TestShim(162.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(87.6m, TestShim(892.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(87.61m, TestShim(892.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(87.64m, TestShim(892.29m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(87.65m, TestShim(892.30m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(133.1m, TestShim(1180m, niCode, PayPeriods.Weekly, 2018));

            Assert.AreEqual(0.00m, TestShim(324.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0.01m, TestShim(324.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(175.08m, TestShim(1783.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(175.09m, TestShim(1783.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(175.12m, TestShim(1783.29m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(175.13m, TestShim(1783.30m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(295.48m, TestShim(2545m, niCode, PayPeriods.Fortnightly, 2018));

            Assert.AreEqual(0.00m, TestShim(648.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0.01m, TestShim(648.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(350.16m, TestShim(3566.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(350.17m, TestShim(3566.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(350.20m, TestShim(3566.29m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(350.21m, TestShim(3566.30m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(553.03m, TestShim(4850m, niCode, PayPeriods.FourWeekly, 2018));

            Assert.AreEqual(0.00m, TestShim(702.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0.01m, TestShim(702.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(379.32m, TestShim(3863.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(379.33m, TestShim(3863.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(379.36m, TestShim(3863.29m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(379.37m, TestShim(3863.30m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(637.97m, TestShim(5500m, niCode, PayPeriods.Monthly, 2018));

            // J
            niCode = 'J';
            Assert.AreEqual(0.00m, TestShim(162.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0.01m, TestShim(162.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0.04m, TestShim(162.29m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0.05m, TestShim(162.30m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(115.34m, TestShim(892.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(115.35m, TestShim(892.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(115.38m, TestShim(892.29m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(115.39m, TestShim(892.30m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(160.84m, TestShim(1180m, niCode, PayPeriods.Weekly, 2018));

            Assert.AreEqual(0.00m, TestShim(324.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0.01m, TestShim(324.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0.04m, TestShim(324.29m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0.05m, TestShim(324.30m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(230.52m, TestShim(1783.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(230.53m, TestShim(1783.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(230.56m, TestShim(1783.29m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(230.57m, TestShim(1783.30m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(350.92m, TestShim(2545m, niCode, PayPeriods.Fortnightly, 2018));

            Assert.AreEqual(0.00m, TestShim(648.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0.01m, TestShim(648.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0.04m, TestShim(648.29m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0.05m, TestShim(648.30m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(461.04m, TestShim(3566.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(461.05m, TestShim(3566.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(461.08m, TestShim(3566.29m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(461.09m, TestShim(3566.3m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(663.91m, TestShim(4850m, niCode, PayPeriods.FourWeekly, 2018));

            Assert.AreEqual(0.00m, TestShim(702.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0.01m, TestShim(702.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0.04m, TestShim(702.29m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0.05m, TestShim(702.30m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(499.44m, TestShim(3863.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(499.45m, TestShim(3863.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(499.48m, TestShim(3863.29m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(499.49m, TestShim(3863.30m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(758.09m, TestShim(5500m, niCode, PayPeriods.Monthly, 2018));

            // M
            niCode = 'M';
            Assert.AreEqual(0.00m, TestShim(162.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0.01m, TestShim(162.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(87.60m, TestShim(892.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(87.61m, TestShim(892.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(87.64m, TestShim(892.29m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(87.65m, TestShim(892.30m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(133.1m, TestShim(1180m, niCode, PayPeriods.Weekly, 2018));

            Assert.AreEqual(0.00m, TestShim(324.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0.01m, TestShim(324.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(175.08m, TestShim(1783.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(175.09m, TestShim(1783.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(175.12m, TestShim(1783.29m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(175.13m, TestShim(1783.30m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(295.48m, TestShim(2545m, niCode, PayPeriods.Fortnightly, 2018));

            Assert.AreEqual(0.00m, TestShim(648.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0.01m, TestShim(648.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(350.16m, TestShim(3566.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(350.17m, TestShim(3566.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(350.20m, TestShim(3566.29m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(350.21m, TestShim(3566.30m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(553.03m, TestShim(4850m, niCode, PayPeriods.FourWeekly, 2018));

            Assert.AreEqual(0.00m, TestShim(702.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0.01m, TestShim(702.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(379.32m, TestShim(3863.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(379.33m, TestShim(3863.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(379.36m, TestShim(3863.29m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(379.37m, TestShim(3863.30m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(637.97m, TestShim(5500m, niCode, PayPeriods.Monthly, 2018));

            // Z
            niCode = 'Z';
            Assert.AreEqual(0.00m, TestShim(162.29m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0.01m, TestShim(162.30m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(14.6m, TestShim(892.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(14.61m, TestShim(892.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(14.64m, TestShim(892.29m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(14.65m, TestShim(892.30m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(60.1m, TestShim(1180m, niCode, PayPeriods.Weekly, 2018));

            Assert.AreEqual(0.00m, TestShim(324.29m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0.01m, TestShim(324.30m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(29.18m, TestShim(1783.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(29.19m, TestShim(1783.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(29.22m, TestShim(1783.29m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(29.23m, TestShim(1783.30m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(149.58m, TestShim(2545m, niCode, PayPeriods.Fortnightly, 2018));

            Assert.AreEqual(0.00m, TestShim(648.29m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0.01m, TestShim(648.30m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(58.36m, TestShim(3566.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(58.37m, TestShim(3566.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(58.40m, TestShim(3566.29m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(58.41m, TestShim(3566.30m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(261.23m, TestShim(4850m, niCode, PayPeriods.FourWeekly, 2018));

            Assert.AreEqual(0.00m, TestShim(702.29m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0.01m, TestShim(702.30m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(63.22m, TestShim(3863.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(63.23m, TestShim(3863.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(63.26m, TestShim(3863.29m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(63.27m, TestShim(3863.30m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(321.87m, TestShim(5500m, niCode, PayPeriods.Monthly, 2018));

            // X Code
            niCode = 'X';
            Assert.AreEqual(0m, TestShim(162.29m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0m, TestShim(162.30m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0m, TestShim(892.04m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0m, TestShim(892.05m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0m, TestShim(892.29m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0m, TestShim(892.30m, niCode, PayPeriods.Weekly, 2018));
            Assert.AreEqual(0m, TestShim(1180m, niCode, PayPeriods.Weekly, 2018));

            Assert.AreEqual(0m, TestShim(324.29m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0m, TestShim(324.30m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0m, TestShim(1783.04m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0m, TestShim(1783.05m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0m, TestShim(1783.29m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0m, TestShim(1783.30m, niCode, PayPeriods.Fortnightly, 2018));
            Assert.AreEqual(0m, TestShim(2545m, niCode, PayPeriods.Fortnightly, 2018));

            Assert.AreEqual(0m, TestShim(648.29m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0m, TestShim(648.30m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0m, TestShim(3566.04m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0m, TestShim(3566.05m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0m, TestShim(3566.29m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0m, TestShim(3566.30m, niCode, PayPeriods.FourWeekly, 2018));
            Assert.AreEqual(0m, TestShim(4850m, niCode, PayPeriods.FourWeekly, 2018));

            Assert.AreEqual(0m, TestShim(702.29m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0m, TestShim(702.30m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0m, TestShim(3863.04m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0m, TestShim(3863.05m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0m, TestShim(3863.29m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0m, TestShim(3863.30m, niCode, PayPeriods.Monthly, 2018));
            Assert.AreEqual(0m, TestShim(5500m, niCode, PayPeriods.Monthly, 2018));

            // Ensure the UEL/LEL Figures are all zero for X Code
            var niResult = GetCalculationResult(600m, niCode, PayPeriods.Weekly, 2018);
            Assert.AreEqual(0m, niResult.EarningsUptoIncludingLEL);
            Assert.AreEqual(0m, niResult.EarningsAboveUEL);
            Assert.AreEqual(0m, niResult.EarningsAboveSTUptoIncludingUEL);
            Assert.AreEqual(0m, niResult.EarningsAbovePTUptoIncludingST);
            Assert.AreEqual(0m, niResult.EarningsAboveLELUptoIncludingPT);
        }
    }
}
