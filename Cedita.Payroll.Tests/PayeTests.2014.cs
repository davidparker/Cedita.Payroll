// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cedita.Payroll.Tests
{
    /**
     * PAYE Tests - 2014/15 tax year
     * 
     * Official Test Data can be sourced from: http://www.hmrc.gov.uk/ebu/testdata.htm
     */
    public partial class PayeTests
    {
        [TestCategory("Payroll PAYE Tests"), TestMethod]
        public void PayeCalculations2014()
        {
            // General Tax Rate
            Assert.AreEqual(0m, Paye.Calculate(39m, "45L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(0.20m, Paye.Calculate(39.25m, "45L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(531.00m, Paye.Calculate(2694.24m, "45L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(531.20m, Paye.Calculate(2694.25m, "45L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(531.31m, Paye.Calculate(2694.26m, "45L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(4468.51m, Paye.Calculate(12538.24m, "45L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(4468.91m, Paye.Calculate(12538.25m, "45L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(4468.91m, Paye.Calculate(12538.26m, "45L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(4469.36m, Paye.Calculate(12539.25m, "45L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));

            Assert.AreEqual(122.40m, Paye.Calculate(621.82m, "45L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(122.60m, Paye.Calculate(621.83m, "45L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(122.64m, Paye.Calculate(621.84m, "45L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(1031.04m, Paye.Calculate(2893.82m, "45L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(1031.44m, Paye.Calculate(2893.83m, "45L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(1031.46m, Paye.Calculate(2893.84m, "45L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));

            // Large Tax Code
            Assert.AreEqual(316.20m, Paye.Calculate(2000m, "501L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(253.20m, Paye.Calculate(2100m, "999L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(283m, Paye.Calculate(2250m, "1000L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(283m, Paye.Calculate(2250m, "1001L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(261m, Paye.Calculate(2612m, "1567L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(216.60m, Paye.Calculate(2750m, "1999L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(333m, Paye.Calculate(3333.33m, "2000L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(333m, Paye.Calculate(3333.33m, "2001L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));

            Assert.AreEqual(80.60m, Paye.Calculate(500m, "501L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(130.24m, Paye.Calculate(825m, "999L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(130.24m, Paye.Calculate(825m, "1000L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(130.24m, Paye.Calculate(825m, "1001L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(39.60m, Paye.Calculate(500m, "1567L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(88m, Paye.Calculate(825m, "1999L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(88m, Paye.Calculate(825m, "2000L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(88.2m, Paye.Calculate(827m, "2001L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));

            // Tax Code L
            // Test 1
            Assert.AreEqual(5576.36m, Paye.Calculate(15000m, "45L", PayrollFrequency.Monthly, 1, 0, 0, true, 2014));
            Assert.AreEqual(48.2m, Paye.Calculate(280m, "45L", PayrollFrequency.Monthly, 2, 15000m, 5576.36m, true, 2014));
            Assert.AreEqual(-1039.81m, Paye.Calculate(280m, "45L", PayrollFrequency.Monthly, 3, 15280m, 5624.56m, false, 2014));
            // Test 2
            Assert.AreEqual(92.20m, Paye.Calculate(500m, "45L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(152.20m, Paye.Calculate(800m, "45L", PayrollFrequency.Monthly, 2, 500m, 92.20m, true, 2014));
            // Test 3
            Assert.AreEqual(94.20m, Paye.Calculate(471m, "BR", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(84.60m, Paye.Calculate(500m, "45L", PayrollFrequency.Monthly, 2, 471m, 94.20m, false, 2014));
            // Test 4
            Assert.AreEqual(92.20m, Paye.Calculate(500m, "45L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(125.40m, Paye.Calculate(627m, "BR", PayrollFrequency.Monthly, 2, 500m, 92.20m, true, 2014));
            // Test 5
            Assert.AreEqual(92.20m, Paye.Calculate(500m, "45L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(98.80m, Paye.Calculate(623.23m, "100L", PayrollFrequency.Monthly, 2, 500m, 92.20m, false, 2014));
            // Test 6
            Assert.AreEqual(83m, Paye.Calculate(500m, "100L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(-0.80m, Paye.Calculate(80m, "100L", PayrollFrequency.Monthly, 2, 500m, 83m, false, 2014));
            // Test 7
            Assert.AreEqual(96m, Paye.Calculate(500m, "100L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(96.20m, Paye.Calculate(500m, "100L", PayrollFrequency.Weekly, 2, 500m, 96m, false, 2014));

            // Tax Code D0
            // Test 1
            Assert.AreEqual(5600m, Paye.Calculate(14000.53m, "D0", PayrollFrequency.Monthly, 1, 0, 0, true, 2014));
            Assert.AreEqual(480m, Paye.Calculate(1200m, "D0", PayrollFrequency.Monthly, 2, 14000.53m, 5600, true, 2014));
            // Test 2
            Assert.AreEqual(100m, Paye.Calculate(250m, "D0", PayrollFrequency.Weekly, 1, 0, 0, true, 2014));
            Assert.AreEqual(-34.80m, Paye.Calculate(250m, "450L", PayrollFrequency.Weekly, 2, 250m, 100m, false, 2014));
            // Test 3
            Assert.AreEqual(32.60m, Paye.Calculate(250m, "450L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(100m, Paye.Calculate(250m, "D0", PayrollFrequency.Weekly, 2, 250m, 32.60m, true, 2014));
            // Test 4
            Assert.AreEqual(280m, Paye.Calculate(700.77m, "D0", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(6000m, Paye.Calculate(15000m, "D0", PayrollFrequency.Monthly, 2, 700.77m, 280m, false, 2014));
            Assert.AreEqual(6000m, Paye.Calculate(15000m, "D0", PayrollFrequency.Monthly, 3, 15700.77m, 6280m, false, 2014));
            Assert.AreEqual(6000m, Paye.Calculate(15000m, "D0", PayrollFrequency.Monthly, 4, 30700.77m, 12280m, false, 2014));
            // Test 5
            Assert.AreEqual(200m, Paye.Calculate(500.22m, "D0", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(240m, Paye.Calculate(600.37m, "D0", PayrollFrequency.Weekly, 2, 500.22m, 200m, false, 2014));
            Assert.AreEqual(320m, Paye.Calculate(799.90m, "D0", PayrollFrequency.Weekly, 3, 1100.59m, 440m, false, 2014));
            Assert.AreEqual(320.40m, Paye.Calculate(801.10m, "D0", PayrollFrequency.Weekly, 4, 1900.49m, 760m, false, 2014));

            // Tax Code D1
            // Test 1
            Assert.AreEqual(6300m, Paye.Calculate(14000.53m, "D1", PayrollFrequency.Monthly, 1, 0, 0, true, 2014));
            Assert.AreEqual(540m, Paye.Calculate(1200m, "D1", PayrollFrequency.Monthly, 2, 14000.53m, 6300, true, 2014));
            // Test 2
            Assert.AreEqual(112.50m, Paye.Calculate(250m, "D1", PayrollFrequency.Weekly, 1, 0, 0, true, 2014));
            Assert.AreEqual(-47.30m, Paye.Calculate(250m, "450L", PayrollFrequency.Weekly, 2, 250m, 112.50m, false, 2014));
            // Test 3
            Assert.AreEqual(32.60m, Paye.Calculate(250m, "450L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(112.50m, Paye.Calculate(250m, "D1", PayrollFrequency.Weekly, 2, 250m, 32.60m, true, 2014));
            // Test 4
            Assert.AreEqual(315m, Paye.Calculate(700.77m, "D1", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(6750m, Paye.Calculate(15000m, "D1", PayrollFrequency.Monthly, 2, 700.77m, 315m, false, 2014));
            Assert.AreEqual(6750m, Paye.Calculate(15000m, "D1", PayrollFrequency.Monthly, 3, 15700.77m, 7065m, false, 2014));
            Assert.AreEqual(6750m, Paye.Calculate(15000m, "D1", PayrollFrequency.Monthly, 4, 30700.77m, 13815m, false, 2014));
            // Test 5
            Assert.AreEqual(225m, Paye.Calculate(500.22m, "D1", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(270m, Paye.Calculate(600.37m, "D1", PayrollFrequency.Weekly, 2, 500.22m, 225m, false, 2014));
            Assert.AreEqual(360m, Paye.Calculate(799.90m, "D1", PayrollFrequency.Weekly, 3, 1100.59m, 495m, false, 2014));
            Assert.AreEqual(360.45m, Paye.Calculate(801.10m, "D1", PayrollFrequency.Weekly, 4, 1900.49m, 855m, false, 2014));

            // Tax Code BR
            Assert.AreEqual(24m, Paye.Calculate(120m, "BR", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(24m, Paye.Calculate(120.99m, "BR", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(100m, Paye.Calculate(500m, "BR", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(3000m, Paye.Calculate(15000m, "BR", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            // Test 4 (really 5 but HMRC can't count)
            Assert.AreEqual(134m, Paye.Calculate(670m, "BR", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(148m, Paye.Calculate(740m, "BR", PayrollFrequency.Monthly, 2, 670m, 134m, false, 2014));
            // Test 5
            Assert.AreEqual(110m, Paye.Calculate(550m, "BR", PayrollFrequency.Monthly, 1, 0, 0, true, 2014));
            Assert.AreEqual(110m, Paye.Calculate(550m, "BR", PayrollFrequency.Monthly, 2, 550m, 110m, true, 2014));
            // Test 6
            Assert.AreEqual(120m, Paye.Calculate(600.24m, "BR", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(166.4m, Paye.Calculate(1500m, "400L", PayrollFrequency.Monthly, 2, 600.24m, 120m, false, 2014));
            // Test 7
            Assert.AreEqual(233m, Paye.Calculate(1500m, "400L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(300m, Paye.Calculate(1500.33m, "BR", PayrollFrequency.Monthly, 2, 1500m, 233m, true, 2014));
            // Test 8
            Assert.AreEqual(115m, Paye.Calculate(575m, "BR", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(96m, Paye.Calculate(480m, "BR", PayrollFrequency.Weekly, 2, 575m, 115m, false, 2014));

            // Tax Code NT
            Assert.AreEqual(0m, Paye.Calculate(500m, "NT", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            // Test 2
            Assert.AreEqual(0m, Paye.Calculate(500m, "NT", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(133m, Paye.Calculate(1000m, "400L", PayrollFrequency.Monthly, 2, 500, 0, true, 2014));
            // Test 3
            Assert.AreEqual(87m, Paye.Calculate(770m, "400L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(-87m, Paye.Calculate(770m, "NT", PayrollFrequency.Monthly, 2, 770, 87, false, 2014));
            // Test 4
            Assert.AreEqual(0m, Paye.Calculate(770m, "NT", PayrollFrequency.Monthly, 1, 0, 0, true, 2014));
            Assert.AreEqual(33m, Paye.Calculate(500m, "400L", PayrollFrequency.Monthly, 2, 770, 0, true, 2014));
            // Test 5
            Assert.AreEqual(84.40m, Paye.Calculate(500m, "400L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(0m, Paye.Calculate(770m, "NT", PayrollFrequency.Weekly, 2, 770, 84.40m, true, 2014));

            // Tax Code 0T
            // Test 1
            Assert.AreEqual(25m, Paye.Calculate(125m, "0T", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(200m, Paye.Calculate(1000m, "0T", PayrollFrequency.Monthly, 2, 125m, 25m, false, 2014));
            // Test 2
            Assert.AreEqual(170m, Paye.Calculate(850m, "0T", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(40.20m, Paye.Calculate(1050m, "508L", PayrollFrequency.Monthly, 2, 850m, 170m, false, 2014));
            // Test 3
            Assert.AreEqual(125m, Paye.Calculate(1050m, "508L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(210m, Paye.Calculate(1050m, "0T", PayrollFrequency.Monthly, 2, 1050m, 125m, true, 2014));
            // Test 4
            Assert.AreEqual(93m, Paye.Calculate(465m, "0T", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(97m, Paye.Calculate(485m, "0T", PayrollFrequency.Weekly, 2, 465m, 93m, false, 2014));
            // Test 5
            Assert.AreEqual(95m, Paye.Calculate(475m, "0T", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(95m, Paye.Calculate(475m, "0T", PayrollFrequency.Weekly, 2, 475, 95m, false, 2014));

            // Tax Code K
            // Test 1
            Assert.AreEqual(173.2m, Paye.Calculate(510m, "K427", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(198m, Paye.Calculate(633.22m, "K427", PayrollFrequency.Monthly, 2, 510m, 173.20m, false, 2014));
            // Test 2
            Assert.AreEqual(193.2m, Paye.Calculate(610m, "K427", PayrollFrequency.Monthly, 1, 0, 0, true, 2014));
            Assert.AreEqual(207.8m, Paye.Calculate(683.22m, "K427", PayrollFrequency.Monthly, 2, 610m, 193.20m, true, 2014));
            // Test 3
            Assert.AreEqual(173.20m, Paye.Calculate(510m, "K427", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(32.50m, Paye.Calculate(65m, "K427", PayrollFrequency.Monthly, 2, 510m, 173.20m, false, 2014));
            Assert.AreEqual(225.10m, Paye.Calculate(510m, "K427", PayrollFrequency.Monthly, 3, 575m, 205.70m, false, 2014));
            // Test 4
            Assert.AreEqual(189.60m, Paye.Calculate(600m, "K417", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(30.40m, Paye.Calculate(500m, "0T", PayrollFrequency.Monthly, 2, 600m, 189.60m, false, 2014));
            // Test 5
            Assert.AreEqual(150m, Paye.Calculate(750m, "0T", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(170.2m, Paye.Calculate(500m, "K421", PayrollFrequency.Monthly, 2, 750m, 150m, true, 2014));
            // Test 6
            Assert.AreEqual(5m, Paye.Calculate(15m, "K55", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(18.2m, Paye.Calculate(80m, "K55", PayrollFrequency.Weekly, 2, 15m, 5m, false, 2014));
            Assert.AreEqual(302.2m, Paye.Calculate(1500m, "K55", PayrollFrequency.Weekly, 3, 95m, 23.20m, false, 2014));

            // Weekly 20% Bandwidth Tests
            Assert.AreEqual(5.80m, Paye.Calculate(120m, "470L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(5.80m, Paye.Calculate(120m, "470L", PayrollFrequency.Weekly, 2, 120m, 5.8m, false, 2014));
            Assert.AreEqual(6m, Paye.Calculate(120m, "470L", PayrollFrequency.Weekly, 3, 240m, 11.60m, false, 2014));
            Assert.AreEqual(5.80m, Paye.Calculate(120m, "470L", PayrollFrequency.Weekly, 4, 360m, 17.60m, false, 2014));
            Assert.AreEqual(6m, Paye.Calculate(120m, "470L", PayrollFrequency.Weekly, 5, 480m, 23.40m, false, 2014));
            Assert.AreEqual(5.80m, Paye.Calculate(120m, "470L", PayrollFrequency.Weekly, 6, 600m, 29.4m, false, 2014));
            Assert.AreEqual(6m, Paye.Calculate(120m, "470L", PayrollFrequency.Weekly, 7, 720m, 35.2m, false, 2014));
            Assert.AreEqual(5.80m, Paye.Calculate(120m, "470L", PayrollFrequency.Weekly, 8, 840m, 41.2m, false, 2014));

            // Weekly 40% Bandwidth Tests
            Assert.AreEqual(466.24m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(466.64m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 2, 1500.63m * 1, 466.24m, false, 2014));
            Assert.AreEqual(466.24m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 3, 1500.63m * 2, 932.88m, false, 2014));
            Assert.AreEqual(466.64m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 4, 1500.63m * 3, 1399.12m, false, 2014));
            Assert.AreEqual(466.25m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 5, 1500.63m * 4, 1865.76m, false, 2014));
            Assert.AreEqual(466.64m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 6, 1500.63m * 5, 2332.01m, false, 2014));
            Assert.AreEqual(466.24m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 7, 1500.63m * 6, 2798.65m, false, 2014));
            Assert.AreEqual(466.64m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 8, 1500.63m * 7, 3264.89m, false, 2014));

            // Weekly 45% Bandwidth Tests
            Assert.AreEqual(1052.16m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(1052.16m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 2, 3010.77m * 1, 1052.16m, false, 2014));
            Assert.AreEqual(1052.61m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 3, 3010.77m * 2, 2104.32m, false, 2014));
            Assert.AreEqual(1052.16m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 4, 3010.77m * 3, 3156.93m, false, 2014));
            Assert.AreEqual(1052.16m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 5, 3010.77m * 4, 4209.09m, false, 2014));
            Assert.AreEqual(1052.61m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 6, 3010.77m * 5, 5261.25m, false, 2014));
            Assert.AreEqual(1052.17m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 7, 3010.77m * 6, 6313.86m, false, 2014));
            Assert.AreEqual(1052.16m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 8, 3010.77m * 7, 7366.03m, false, 2014));

            // Weekly Variable Pay
            Assert.AreEqual(0m, Paye.Calculate(0, "500L", PayrollFrequency.Weekly, 1, 0, 0, false, 2014));
            Assert.AreEqual(21.40m, Paye.Calculate(300m, "500L", PayrollFrequency.Weekly, 2, 0, 0, false, 2014));
            Assert.AreEqual(3683.18m, Paye.Calculate(10000m, "500L", PayrollFrequency.Weekly, 3, 300m, 21.40m, false, 2014));
            Assert.AreEqual(2299.56m, Paye.Calculate(5800m, "500L", PayrollFrequency.Weekly, 4, 10300m, 3704.58m, false, 2014));
            Assert.AreEqual(-264.99m, Paye.Calculate(100m, "500L", PayrollFrequency.Weekly, 5, 16100m, 6004.14m, false, 2014));
            Assert.AreEqual(1033.26m, Paye.Calculate(2985m, "500L", PayrollFrequency.Weekly, 6, 16200m, 5739.15m, false, 2014));
            Assert.AreEqual(393.68m, Paye.Calculate(1550m, "500L", PayrollFrequency.Weekly, 7, 19185m, 6772.41m, false, 2014));
            Assert.AreEqual(-140.96m, Paye.Calculate(50m, "500L", PayrollFrequency.Weekly, 8, 20735m, 7166.09m, false, 2014));

            // Monthly 20% Bandwidth Tests
            Assert.AreEqual(21.80m, Paye.Calculate(452m, "410L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(22m, Paye.Calculate(452m, "410L", PayrollFrequency.Monthly, 2, 452m * 1, 21.8m, false, 2014));
            Assert.AreEqual(21.80m, Paye.Calculate(452m, "410L", PayrollFrequency.Monthly, 3, 452m * 2, 43.8m, false, 2014));
            Assert.AreEqual(22m, Paye.Calculate(452m, "410L", PayrollFrequency.Monthly, 4, 452m * 3, 65.6m, false, 2014));
            Assert.AreEqual(21.80m, Paye.Calculate(452m, "410L", PayrollFrequency.Monthly, 5, 452m * 4, 87.6m, false, 2014));
            Assert.AreEqual(22m, Paye.Calculate(452m, "410L", PayrollFrequency.Monthly, 6, 452m * 5, 109.4m, false, 2014));
            Assert.AreEqual(22m, Paye.Calculate(452m, "410L", PayrollFrequency.Monthly, 7, 452m * 6, 131.4m, false, 2014));
            Assert.AreEqual(21.80m, Paye.Calculate(452m, "410L", PayrollFrequency.Monthly, 8, 452m * 7, 153.4m, false, 2014));
            Assert.AreEqual(22m, Paye.Calculate(452m, "410L", PayrollFrequency.Monthly, 9, 452m * 8, 175.2m, false, 2014));
            Assert.AreEqual(21.80m, Paye.Calculate(452m, "410L", PayrollFrequency.Monthly, 10, 452m * 9, 197.2m, false, 2014));
            Assert.AreEqual(22m, Paye.Calculate(452m, "410L", PayrollFrequency.Monthly, 11, 452m * 10, 219m, false, 2014));
            Assert.AreEqual(21.80m, Paye.Calculate(452m, "410L", PayrollFrequency.Monthly, 12, 452m * 11, 241m, false, 2014));

            // Monthly 40% Bandwidth Tests
            Assert.AreEqual(867.31m, Paye.Calculate(3856m, "430L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(867.72m, Paye.Calculate(3856m, "430L", PayrollFrequency.Monthly, 2, 3856m * 1, 867.31m, false, 2014));
            Assert.AreEqual(867.72m, Paye.Calculate(3856m, "430L", PayrollFrequency.Monthly, 3, 3856m * 2, 1735.03m, false, 2014));
            Assert.AreEqual(867.71m, Paye.Calculate(3856m, "430L", PayrollFrequency.Monthly, 4, 3856m * 3, 2602.75m, false, 2014));
            Assert.AreEqual(867.72m, Paye.Calculate(3856m, "430L", PayrollFrequency.Monthly, 5, 3856m * 4, 3470.46m, false, 2014));
            Assert.AreEqual(867.72m, Paye.Calculate(3856m, "430L", PayrollFrequency.Monthly, 6, 3856m * 5, 4338.18m, false, 2014));
            Assert.AreEqual(867.71m, Paye.Calculate(3856m, "430L", PayrollFrequency.Monthly, 7, 3856m * 6, 5205.90m, false, 2014));
            Assert.AreEqual(867.72m, Paye.Calculate(3856m, "430L", PayrollFrequency.Monthly, 8, 3856m * 7, 6073.61m, false, 2014));
            Assert.AreEqual(867.72m, Paye.Calculate(3856m, "430L", PayrollFrequency.Monthly, 9, 3856m * 8, 6941.33m, false, 2014));
            Assert.AreEqual(867.71m, Paye.Calculate(3856m, "430L", PayrollFrequency.Monthly, 10, 3856m * 9, 7809.05m, false, 2014));
            Assert.AreEqual(867.72m, Paye.Calculate(3856m, "430L", PayrollFrequency.Monthly, 11, 3856m * 10, 8676.76m, false, 2014));
            Assert.AreEqual(867.32m, Paye.Calculate(3856m, "430L", PayrollFrequency.Monthly, 12, 3856m * 11, 9544.48m, false, 2014));

            // Monthly 45% Bandwidth Tests
            Assert.AreEqual(5582.66m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(5582.67m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 2, 15000.81m * 1, 5582.66m, false, 2014));
            Assert.AreEqual(5582.67m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 3, 15000.81m * 2, 11165.33m, false, 2014));
            Assert.AreEqual(5582.66m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 4, 15000.81m * 3, 16748.00m, false, 2014));
            Assert.AreEqual(5582.67m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 5, 15000.81m * 4, 22330.66m, false, 2014));
            Assert.AreEqual(5582.67m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 6, 15000.81m * 5, 27913.33m, false, 2014));
            Assert.AreEqual(5582.66m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 7, 15000.81m * 6, 33496.00m, false, 2014));
            Assert.AreEqual(5582.67m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 8, 15000.81m * 7, 39078.66m, false, 2014));
            Assert.AreEqual(5582.67m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 9, 15000.81m * 8, 44661.33m, false, 2014));
            Assert.AreEqual(5582.66m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 10, 15000.81m * 9, 50244.00m, false, 2014));
            Assert.AreEqual(5582.67m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 11, 15000.81m * 10, 55826.66m, false, 2014));
            Assert.AreEqual(5582.67m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 12, 15000.81m * 11, 61409.33m, false, 2014));

            // Monthly Variable Pay
            Assert.AreEqual(242.40m, Paye.Calculate(2000m, "944L", PayrollFrequency.Monthly, 1, 0, 0, false, 2014));
            Assert.AreEqual(-157.40m, Paye.Calculate(0m, "944L", PayrollFrequency.Monthly, 2, 2000m, 242.40m, false, 2014));
            Assert.AreEqual(4876.55m, Paye.Calculate(16750m, "944L", PayrollFrequency.Monthly, 3, 2000m, 85.00m, false, 2014));
            Assert.AreEqual(-245.89m, Paye.Calculate(1500m, "944L", PayrollFrequency.Monthly, 4, 18750m, 4961.55m, false, 2014));
            Assert.AreEqual(-646.28m, Paye.Calculate(500m, "944L", PayrollFrequency.Monthly, 5, 20250m, 4715.66m, false, 2014));
            Assert.AreEqual(-605.88m, Paye.Calculate(600m, "944L", PayrollFrequency.Monthly, 6, 20750m, 4069.38m, false, 2014));
            Assert.AreEqual(-55.90m, Paye.Calculate(1200m, "944L", PayrollFrequency.Monthly, 7, 21350m, 3463.50m, false, 2014));
            Assert.AreEqual(4283.73m, Paye.Calculate(13600m, "944L", PayrollFrequency.Monthly, 8, 22550m, 3407.60m, false, 2014));
            Assert.AreEqual(354.12m, Paye.Calculate(3000m, "944L", PayrollFrequency.Monthly, 9, 36150m, 7691.33m, false, 2014));
            Assert.AreEqual(-846.29m, Paye.Calculate(0m, "944L", PayrollFrequency.Monthly, 10, 39150m, 8045.45m, false, 2014));
            Assert.AreEqual(354.12m, Paye.Calculate(3000m, "944L", PayrollFrequency.Monthly, 11, 39150m, 7199.16m, false, 2014));
            Assert.AreEqual(-446.28m, Paye.Calculate(1000m, "944L", PayrollFrequency.Monthly, 12, 42150m, 7553.28m, false, 2014));
        }
    }
}
