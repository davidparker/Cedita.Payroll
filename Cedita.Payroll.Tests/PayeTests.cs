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
    public class PayeTests
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

        [TestMethod]
        public void PayeCalculations2013()
        {
            Assert.AreEqual(43.60m, Paye.Calculate(400, "944L", PayrollFrequency.Weekly, 1, 0, 0, false, 2013));

            Assert.AreEqual(116.20m, Paye.Calculate(400, "K944", PayrollFrequency.Weekly, 1, 0, 0, false, 2013));
            Assert.AreEqual(118.40m, Paye.Calculate(400, "K1000", PayrollFrequency.Weekly, 1, 0, 0, false, 2013));
            Assert.AreEqual(190.48m, Paye.Calculate(400, "K2000", PayrollFrequency.Weekly, 1, 0, 0, false, 2013));
            Assert.AreEqual(200m, Paye.Calculate(400, "K3000", PayrollFrequency.Weekly, 1, 0, 0, false, 2013));
            Assert.AreEqual(200m, Paye.Calculate(400, "K4000", PayrollFrequency.Weekly, 1, 0, 0, false, 2013));

            Assert.AreEqual(80m, Paye.Calculate(400, "BR", PayrollFrequency.Weekly, 1, 0, 0, false, 2013));
            Assert.AreEqual(160m, Paye.Calculate(400, "D0", PayrollFrequency.Weekly, 1, 0, 0, false, 2013));
            Assert.AreEqual(180m, Paye.Calculate(400, "D1", PayrollFrequency.Weekly, 1, 0, 0, false, 2013));
            Assert.AreEqual(0m, Paye.Calculate(400, "NT", PayrollFrequency.Weekly, 1, 0, 0, false, 2013));

            Assert.AreEqual(5573.95m, Paye.Calculate(15000.00m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(48.20m, Paye.Calculate(280.00m, "45L", PayrollFrequency.Monthly, 2, 15000.00m, 5573.95m, true, 2013));
            Assert.AreEqual(-1044.65m, Paye.Calculate(280.00m, "45L", PayrollFrequency.Monthly, 3, 15280.00m, 5622.15m, false, 2013));
            Assert.AreEqual(92.20m, Paye.Calculate(500.00m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(152.20m, Paye.Calculate(800.00m, "45L", PayrollFrequency.Monthly, 2, 500.00m, 92.20m, true, 2013));
            Assert.AreEqual(94.20m, Paye.Calculate(471.00m, "BR", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(84.60m, Paye.Calculate(500.00m, "45L", PayrollFrequency.Monthly, 2, 471.00m, 94.20m, false, 2013));
            Assert.AreEqual(92.20m, Paye.Calculate(500.00m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(125.40m, Paye.Calculate(627.00m, "BR", PayrollFrequency.Monthly, 2, 500.00m, 92.20m, true, 2013));
            Assert.AreEqual(92.20m, Paye.Calculate(500.00m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(98.80m, Paye.Calculate(623.23m, "100L", PayrollFrequency.Monthly, 2, 500.00m, 92.20m, false, 2013));
            Assert.AreEqual(83.00m, Paye.Calculate(500.00m, "100L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(-0.80m, Paye.Calculate(80.00m, "100L", PayrollFrequency.Monthly, 2, 500.00m, 83.00m, false, 2013));
            Assert.AreEqual(96.00m, Paye.Calculate(500.00m, "100L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(96.20m, Paye.Calculate(500.00m, "100L", PayrollFrequency.Weekly, 2, 500.00m, 96.00m, false, 2013));
            Assert.AreEqual(5600.00m, Paye.Calculate(14000.53m, "D0", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(480.00m, Paye.Calculate(1200.00m, "D0", PayrollFrequency.Monthly, 2, 14000.53m, 5600.00m, true, 2013));
            Assert.AreEqual(100.00m, Paye.Calculate(250.00m, "D0", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(-34.80m, Paye.Calculate(250.00m, "450L", PayrollFrequency.Weekly, 2, 250.00m, 100.00m, false, 2013));
            Assert.AreEqual(32.60m, Paye.Calculate(250.00m, "450L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(100.00m, Paye.Calculate(250.00m, "D0", PayrollFrequency.Weekly, 2, 250.00m, 32.60m, true, 2013));
            Assert.AreEqual(280.00m, Paye.Calculate(700.77m, "D0", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(6000.00m, Paye.Calculate(15000.00m, "D0", PayrollFrequency.Monthly, 2, 700.77m, 280.00m, false, 2013));
            Assert.AreEqual(6000.00m, Paye.Calculate(15000.00m, "D0", PayrollFrequency.Monthly, 3, 15700.77m, 6280.00m, false, 2013));
            Assert.AreEqual(6000.00m, Paye.Calculate(15000.00m, "D0", PayrollFrequency.Monthly, 4, 30700.77m, 12280.00m, false, 2013));
            Assert.AreEqual(200.00m, Paye.Calculate(500.22m, "D0", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(240.00m, Paye.Calculate(600.37m, "D0", PayrollFrequency.Weekly, 2, 500.22m, 200.00m, false, 2013));
            Assert.AreEqual(320.00m, Paye.Calculate(799.90m, "D0", PayrollFrequency.Weekly, 3, 1100.59m, 440.00m, false, 2013));
            Assert.AreEqual(320.40m, Paye.Calculate(801.10m, "D0", PayrollFrequency.Weekly, 4, 1900.49m, 760.00m, false, 2013));
            Assert.AreEqual(6300.00m, Paye.Calculate(14000.53m, "D1", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(540.00m, Paye.Calculate(1200.00m, "D1", PayrollFrequency.Monthly, 2, 14000.53m, 6300.00m, true, 2013));
            Assert.AreEqual(112.50m, Paye.Calculate(250.00m, "D1", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(-47.30m, Paye.Calculate(250.00m, "450L", PayrollFrequency.Weekly, 2, 250.00m, 112.50m, false, 2013));
            Assert.AreEqual(32.60m, Paye.Calculate(250.00m, "450L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(112.50m, Paye.Calculate(250.00m, "D1", PayrollFrequency.Weekly, 2, 250.00m, 32.60m, true, 2013));
            Assert.AreEqual(315.00m, Paye.Calculate(700.77m, "D1", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(6750.00m, Paye.Calculate(15000.00m, "D1", PayrollFrequency.Monthly, 2, 700.77m, 315.00m, false, 2013));
            Assert.AreEqual(6750.00m, Paye.Calculate(15000.00m, "D1", PayrollFrequency.Monthly, 3, 15700.77m, 7065.00m, false, 2013));
            Assert.AreEqual(6750.00m, Paye.Calculate(15000.00m, "D1", PayrollFrequency.Monthly, 4, 30700.77m, 13815.00m, false, 2013));
            Assert.AreEqual(225.00m, Paye.Calculate(500.22m, "D1", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(270.00m, Paye.Calculate(600.37m, "D1", PayrollFrequency.Weekly, 2, 500.22m, 225.00m, false, 2013));
            Assert.AreEqual(360.00m, Paye.Calculate(799.90m, "D1", PayrollFrequency.Weekly, 3, 1100.59m, 495.00m, false, 2013));
            Assert.AreEqual(360.45m, Paye.Calculate(801.10m, "D1", PayrollFrequency.Weekly, 4, 1900.49m, 855.00m, false, 2013));
            Assert.AreEqual(24.00m, Paye.Calculate(120.00m, "BR", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(24.00m, Paye.Calculate(120.99m, "BR", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(100.00m, Paye.Calculate(500.00m, "BR", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(3000.00m, Paye.Calculate(15000.00m, "BR", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(134.00m, Paye.Calculate(670.00m, "BR", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(148.00m, Paye.Calculate(740.00m, "BR", PayrollFrequency.Monthly, 2, 670.00m, 134.00m, false, 2013));
            Assert.AreEqual(110.00m, Paye.Calculate(550.00m, "BR", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(110.00m, Paye.Calculate(550.00m, "BR", PayrollFrequency.Monthly, 2, 550.00m, 110.00m, true, 2013));
            Assert.AreEqual(120.00m, Paye.Calculate(600.24m, "BR", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(166.40m, Paye.Calculate(1500.00m, "400L", PayrollFrequency.Monthly, 2, 600.24m, 120.00m, false, 2013));
            Assert.AreEqual(233.00m, Paye.Calculate(1500.00m, "400L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(300.00m, Paye.Calculate(1500.33m, "BR", PayrollFrequency.Monthly, 2, 1500.00m, 233.00m, true, 2013));
            Assert.AreEqual(115.00m, Paye.Calculate(575.00m, "BR", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(96.00m, Paye.Calculate(480.00m, "BR", PayrollFrequency.Weekly, 2, 575.00m, 115.00m, false, 2013));
            Assert.AreEqual(0.00m, Paye.Calculate(500.00m, "NT", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(0.00m, Paye.Calculate(500.00m, "NT", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(133.00m, Paye.Calculate(1000.00m, "400L", PayrollFrequency.Monthly, 2, 500.00m, 0.00m, true, 2013));
            Assert.AreEqual(87.00m, Paye.Calculate(770.00m, "400L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(-87.00m, Paye.Calculate(770.00m, "NT", PayrollFrequency.Monthly, 2, 770.00m, 87.00m, false, 2013));
            Assert.AreEqual(0.00m, Paye.Calculate(770.00m, "NT", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(33.00m, Paye.Calculate(500.00m, "400L", PayrollFrequency.Monthly, 2, 770.00m, 0.00m, true, 2013));
            Assert.AreEqual(84.40m, Paye.Calculate(500.00m, "400L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(0.00m, Paye.Calculate(770.00m, "NT", PayrollFrequency.Weekly, 2, 500.00m, 84.40m, true, 2013));
            Assert.AreEqual(25.00m, Paye.Calculate(125.00m, "0T", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(200.00m, Paye.Calculate(1000.00m, "0T", PayrollFrequency.Monthly, 2, 125.00m, 25.00m, false, 2013));
            Assert.AreEqual(170.00m, Paye.Calculate(850.00m, "0T", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(40.20m, Paye.Calculate(1050.00m, "508L", PayrollFrequency.Monthly, 2, 850.00m, 170.00m, false, 2013));
            Assert.AreEqual(125.00m, Paye.Calculate(1050.00m, "508L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(210.00m, Paye.Calculate(1050.00m, "0T", PayrollFrequency.Monthly, 2, 1050.00m, 125.00m, true, 2013));
            Assert.AreEqual(93.00m, Paye.Calculate(465.00m, "0T", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(97.00m, Paye.Calculate(485.00m, "0T", PayrollFrequency.Weekly, 2, 465.00m, 93.00m, false, 2013));
            Assert.AreEqual(95.00m, Paye.Calculate(475.00m, "0T", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(95.00m, Paye.Calculate(475.00m, "0T", PayrollFrequency.Weekly, 2, 475.00m, 95.00m, true, 2013));
            Assert.AreEqual(173.20m, Paye.Calculate(510.00m, "K427", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(198.00m, Paye.Calculate(633.22m, "K427", PayrollFrequency.Monthly, 2, 510.00m, 173.20m, false, 2013));
            Assert.AreEqual(193.20m, Paye.Calculate(610.00m, "K427", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(207.80m, Paye.Calculate(683.22m, "K427", PayrollFrequency.Monthly, 2, 610.00m, 193.20m, true, 2013));
            Assert.AreEqual(173.20m, Paye.Calculate(510.00m, "K427", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(32.50m, Paye.Calculate(65.00m, "K427", PayrollFrequency.Monthly, 2, 510.00m, 173.20m, false, 2013));
            Assert.AreEqual(225.10m, Paye.Calculate(510.00m, "K427", PayrollFrequency.Monthly, 3, 575.00m, 205.70m, false, 2013));
            Assert.AreEqual(189.60m, Paye.Calculate(600.00m, "K417", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(30.40m, Paye.Calculate(500.00m, "0T", PayrollFrequency.Monthly, 2, 600.00m, 189.60m, false, 2013));
            Assert.AreEqual(150.00m, Paye.Calculate(750.00m, "0T", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(170.20m, Paye.Calculate(500.00m, "K421", PayrollFrequency.Monthly, 2, 750.00m, 150.00m, true, 2013));
            Assert.AreEqual(5.00m, Paye.Calculate(15.00m, "K55", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(18.20m, Paye.Calculate(80.00m, "K55", PayrollFrequency.Weekly, 2, 15.00m, 5.00m, false, 2013));
            Assert.AreEqual(302.20m, Paye.Calculate(1500.00m, "K55", PayrollFrequency.Weekly, 3, 95.00m, 23.20m, false, 2013));
            Assert.AreEqual(5.80m, Paye.Calculate(120.00m, "470L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(5.80m, Paye.Calculate(120.00m, "470L", PayrollFrequency.Weekly, 2, 120.00m, 5.80m, false, 2013));
            Assert.AreEqual(6.00m, Paye.Calculate(120.00m, "470L", PayrollFrequency.Weekly, 3, 240.00m, 11.60m, false, 2013));
            Assert.AreEqual(5.80m, Paye.Calculate(120.00m, "470L", PayrollFrequency.Weekly, 4, 360.00m, 17.60m, false, 2013));
            Assert.AreEqual(6.00m, Paye.Calculate(120.00m, "470L", PayrollFrequency.Weekly, 5, 480.00m, 23.40m, false, 2013));
            Assert.AreEqual(5.80m, Paye.Calculate(120.00m, "470L", PayrollFrequency.Weekly, 6, 600.00m, 29.40m, false, 2013));
            Assert.AreEqual(6.00m, Paye.Calculate(120.00m, "470L", PayrollFrequency.Weekly, 7, 720.00m, 35.20m, false, 2013));
            Assert.AreEqual(5.80m, Paye.Calculate(120.00m, "470L", PayrollFrequency.Weekly, 8, 840.00m, 41.20m, false, 2013));
            Assert.AreEqual(465.68m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(466.08m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 2, 1500.63m, 465.68m, false, 2013));
            Assert.AreEqual(465.69m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 3, 3001.26m, 931.76m, false, 2013));
            Assert.AreEqual(466.08m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 4, 4501.89m, 1397.45m, false, 2013));
            Assert.AreEqual(465.69m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 5, 6002.52m, 1863.53m, false, 2013));
            Assert.AreEqual(466.08m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 6, 7503.15m, 2329.22m, false, 2013));
            Assert.AreEqual(465.69m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 7, 9003.78m, 2795.30m, false, 2013));
            Assert.AreEqual(466.08m, Paye.Calculate(1500.63m, "145L", PayrollFrequency.Weekly, 8, 10504.41m, 3260.99m, false, 2013));
            Assert.AreEqual(1051.60m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(1051.60m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 2, 3010.77m, 1051.60m, false, 2013));
            Assert.AreEqual(1052.06m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 3, 6021.54m, 2103.20m, false, 2013));
            Assert.AreEqual(1051.60m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 4, 9032.31m, 3155.26m, false, 2013));
            Assert.AreEqual(1051.60m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 5, 12043.08m, 4206.86m, false, 2013));
            Assert.AreEqual(1052.06m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 6, 15053.85m, 5258.46m, false, 2013));
            Assert.AreEqual(1051.60m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 7, 18064.62m, 6310.52m, false, 2013));
            Assert.AreEqual(1051.61m, Paye.Calculate(3010.77m, "412L", PayrollFrequency.Weekly, 8, 21075.39m, 7362.12m, false, 2013));
            Assert.AreEqual(0.00m, Paye.Calculate(0.00m, "500L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(21.40m, Paye.Calculate(300.00m, "500L", PayrollFrequency.Weekly, 2, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(3681.51m, Paye.Calculate(10000.00m, "500L", PayrollFrequency.Weekly, 3, 300.00m, 21.40m, false, 2013));
            Assert.AreEqual(2299.00m, Paye.Calculate(5800.00m, "500L", PayrollFrequency.Weekly, 4, 10300.00m, 3702.91m, false, 2013));
            Assert.AreEqual(-265.55m, Paye.Calculate(100.00m, "500L", PayrollFrequency.Weekly, 5, 16100.00m, 6001.91m, false, 2013));
            Assert.AreEqual(1032.71m, Paye.Calculate(2985.00m, "500L", PayrollFrequency.Weekly, 6, 16200.00m, 5736.36m, false, 2013));
            Assert.AreEqual(393.12m, Paye.Calculate(1550.00m, "500L", PayrollFrequency.Weekly, 7, 19185.00m, 6769.07m, false, 2013));
            Assert.AreEqual(-141.52m, Paye.Calculate(50.00m, "500L", PayrollFrequency.Weekly, 8, 20735.00m, 7162.19m, false, 2013));
            Assert.AreEqual(21.80m, Paye.Calculate(452.00m, "410L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(22.00m, Paye.Calculate(452.00m, "410L", PayrollFrequency.Monthly, 2, 452.00m, 21.80m, false, 2013));
            Assert.AreEqual(21.80m, Paye.Calculate(452.00m, "410L", PayrollFrequency.Monthly, 3, 904.00m, 43.80m, false, 2013));
            Assert.AreEqual(22.00m, Paye.Calculate(452.00m, "410L", PayrollFrequency.Monthly, 4, 1356.00m, 65.60m, false, 2013));
            Assert.AreEqual(21.80m, Paye.Calculate(452.00m, "410L", PayrollFrequency.Monthly, 5, 1808.00m, 87.60m, false, 2013));
            Assert.AreEqual(22.00m, Paye.Calculate(452.00m, "410L", PayrollFrequency.Monthly, 6, 2260.00m, 109.40m, false, 2013));
            Assert.AreEqual(22.00m, Paye.Calculate(452.00m, "410L", PayrollFrequency.Monthly, 7, 2712.00m, 131.40m, false, 2013));
            Assert.AreEqual(21.80m, Paye.Calculate(452.00m, "410L", PayrollFrequency.Monthly, 8, 3164.00m, 153.40m, false, 2013));
            Assert.AreEqual(22.00m, Paye.Calculate(452.00m, "410L", PayrollFrequency.Monthly, 9, 3616.00m, 175.20m, false, 2013));
            Assert.AreEqual(21.80m, Paye.Calculate(452.00m, "410L", PayrollFrequency.Monthly, 10, 4068.00m, 197.20m, false, 2013));
            Assert.AreEqual(22.00m, Paye.Calculate(452.00m, "410L", PayrollFrequency.Monthly, 11, 4520.00m, 219.00m, false, 2013));
            Assert.AreEqual(21.80m, Paye.Calculate(452.00m, "410L", PayrollFrequency.Monthly, 12, 4972.00m, 241.00m, false, 2013));
            Assert.AreEqual(864.90m, Paye.Calculate(3856.00m, "430L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(865.30m, Paye.Calculate(3856.00m, "430L", PayrollFrequency.Monthly, 2, 3856.00m, 864.90m, false, 2013));
            Assert.AreEqual(865.30m, Paye.Calculate(3856.00m, "430L", PayrollFrequency.Monthly, 3, 7712.00m, 1730.20m, false, 2013));
            Assert.AreEqual(865.30m, Paye.Calculate(3856.00m, "430L", PayrollFrequency.Monthly, 4, 11568.00m, 2595.50m, false, 2013));
            Assert.AreEqual(865.30m, Paye.Calculate(3856.00m, "430L", PayrollFrequency.Monthly, 5, 15424.00m, 3460.80m, false, 2013));
            Assert.AreEqual(865.30m, Paye.Calculate(3856.00m, "430L", PayrollFrequency.Monthly, 6, 19280.00m, 4326.10m, false, 2013));
            Assert.AreEqual(865.30m, Paye.Calculate(3856.00m, "430L", PayrollFrequency.Monthly, 7, 23136.00m, 5191.40m, false, 2013));
            Assert.AreEqual(865.30m, Paye.Calculate(3856.00m, "430L", PayrollFrequency.Monthly, 8, 26992.00m, 6056.70m, false, 2013));
            Assert.AreEqual(865.30m, Paye.Calculate(3856.00m, "430L", PayrollFrequency.Monthly, 9, 30848.00m, 6922.00m, false, 2013));
            Assert.AreEqual(865.30m, Paye.Calculate(3856.00m, "430L", PayrollFrequency.Monthly, 10, 34704.00m, 7787.30m, false, 2013));
            Assert.AreEqual(865.30m, Paye.Calculate(3856.00m, "430L", PayrollFrequency.Monthly, 11, 38560.00m, 8652.60m, false, 2013));
            Assert.AreEqual(864.90m, Paye.Calculate(3856.00m, "430L", PayrollFrequency.Monthly, 12, 42416.00m, 9517.90m, false, 2013));
            Assert.AreEqual(5580.25m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(5580.25m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 2, 15000.81m, 5580.25m, false, 2013));
            Assert.AreEqual(5580.25m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 3, 30001.62m, 11160.50m, false, 2013));
            Assert.AreEqual(5580.25m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 4, 45002.43m, 16740.75m, false, 2013));
            Assert.AreEqual(5580.25m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 5, 60003.24m, 22321.00m, false, 2013));
            Assert.AreEqual(5580.25m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 6, 75004.05m, 27901.25m, false, 2013));
            Assert.AreEqual(5580.25m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 7, 90004.86m, 33481.50m, false, 2013));
            Assert.AreEqual(5580.25m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 8, 105005.67m, 39061.75m, false, 2013));
            Assert.AreEqual(5580.25m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 9, 120006.48m, 44642.00m, false, 2013));
            Assert.AreEqual(5580.25m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 10, 135007.29m, 50222.25m, false, 2013));
            Assert.AreEqual(5580.25m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 11, 150008.10m, 55802.50m, false, 2013));
            Assert.AreEqual(5580.25m, Paye.Calculate(15000.81m, "30L", PayrollFrequency.Monthly, 12, 165008.91m, 61382.75m, false, 2013));
            Assert.AreEqual(242.40m, Paye.Calculate(2000.00m, "944L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(-157.40m, Paye.Calculate(0.00m, "944L", PayrollFrequency.Monthly, 2, 2000.00m, 242.40m, false, 2013));
            Assert.AreEqual(4869.30m, Paye.Calculate(16750.00m, "944L", PayrollFrequency.Monthly, 3, 2000.00m, 85.00m, false, 2013));
            Assert.AreEqual(-248.30m, Paye.Calculate(1500.00m, "944L", PayrollFrequency.Monthly, 4, 18750.00m, 4954.30m, false, 2013));
            Assert.AreEqual(-648.70m, Paye.Calculate(500.00m, "944L", PayrollFrequency.Monthly, 5, 20250.00m, 4706.00m, false, 2013));
            Assert.AreEqual(-608.30m, Paye.Calculate(600.00m, "944L", PayrollFrequency.Monthly, 6, 20750.00m, 4057.30m, false, 2013));
            Assert.AreEqual(-41.40m, Paye.Calculate(1200.00m, "944L", PayrollFrequency.Monthly, 7, 21350.00m, 3449.00m, false, 2013));
            Assert.AreEqual(4264.40m, Paye.Calculate(13600.00m, "944L", PayrollFrequency.Monthly, 8, 22550.00m, 3407.60m, false, 2013));
            Assert.AreEqual(351.70m, Paye.Calculate(3000.00m, "944L", PayrollFrequency.Monthly, 9, 36150.00m, 7672.00m, false, 2013));
            Assert.AreEqual(-848.70m, Paye.Calculate(0.00m, "944L", PayrollFrequency.Monthly, 10, 39150.00m, 8023.70m, false, 2013));
            Assert.AreEqual(351.70m, Paye.Calculate(3000.00m, "944L", PayrollFrequency.Monthly, 11, 39150.00m, 7175.00m, false, 2013));
            Assert.AreEqual(-448.70m, Paye.Calculate(1000.00m, "944L", PayrollFrequency.Monthly, 12, 42150.00m, 7526.70m, false, 2013));
            Assert.AreEqual(0.00m, Paye.Calculate(39.00m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(0.20m, Paye.Calculate(39.25m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(533.40m, Paye.Calculate(2706.24m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(533.60m, Paye.Calculate(2706.25m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(533.70m, Paye.Calculate(2706.26m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(4466.10m, Paye.Calculate(12538.24m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(4466.50m, Paye.Calculate(12538.25m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(4466.50m, Paye.Calculate(12538.26m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(4466.95m, Paye.Calculate(12539.25m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(123.00m, Paye.Calculate(624.82m, "45L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(123.20m, Paye.Calculate(624.83m, "45L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(123.28m, Paye.Calculate(624.84m, "45L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(123.68m, Paye.Calculate(625.83m, "45L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(1030.48m, Paye.Calculate(2893.82m, "45L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(1030.88m, Paye.Calculate(2893.83m, "45L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(1030.90m, Paye.Calculate(2893.84m, "45L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(316.20m, Paye.Calculate(2000.00m, "501L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(253.20m, Paye.Calculate(2100.00m, "999L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(283.00m, Paye.Calculate(2250.00m, "1000L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(283.00m, Paye.Calculate(2250.00m, "1001L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(261.00m, Paye.Calculate(2612.00m, "1567L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(216.60m, Paye.Calculate(2750.00m, "1999L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(333.00m, Paye.Calculate(3333.33m, "2000L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(333.00m, Paye.Calculate(3333.33m, "2001L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(80.60m, Paye.Calculate(500.00m, "501L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(129.68m, Paye.Calculate(825.00m, "999L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(129.68m, Paye.Calculate(825.00m, "1000L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(129.68m, Paye.Calculate(825.00m, "1001L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(39.60m, Paye.Calculate(500.00m, "1567L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(88.00m, Paye.Calculate(825.00m, "1999L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(88.00m, Paye.Calculate(825.00m, "2000L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(88.20m, Paye.Calculate(827.00m, "2001L", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(32.00m, Paye.Calculate(160.00m, "BR", PayrollFrequency.Weekly, 1, 0.00m, 0.00m, true, 2013));
            Assert.AreEqual(392.20m, Paye.Calculate(2000.00m, "45L", PayrollFrequency.Monthly, 1, 0.00m, 0.00m, false, 2013));
            Assert.AreEqual(-7.60m, Paye.Calculate(0.00m, "45L", PayrollFrequency.Monthly, 2, 2000.00m, 392.20m, false, 2013));
            Assert.AreEqual(5468.90m, Paye.Calculate(16750.00m, "45L", PayrollFrequency.Monthly, 3, 2000.00m, 384.60m, false, 2013));
            Assert.AreEqual(51.30m, Paye.Calculate(1500.00m, "45L", PayrollFrequency.Monthly, 4, 18750.00m, 5853.50m, false, 2013));
            Assert.AreEqual(-349.10m, Paye.Calculate(500.00m, "45L", PayrollFrequency.Monthly, 5, 20250.00m, 5904.80m, false, 2013));
            Assert.AreEqual(-308.70m, Paye.Calculate(600.00m, "45L", PayrollFrequency.Monthly, 6, 20750.00m, 5555.70m, false, 2013));
            Assert.AreEqual(-68.70m, Paye.Calculate(1200.00m, "45L", PayrollFrequency.Monthly, 7, 21350.00m, 5247.00m, false, 2013));
            Assert.AreEqual(4891.30m, Paye.Calculate(13600.00m, "45L", PayrollFrequency.Monthly, 8, 22550.00m, 5178.30m, false, 2013));
            Assert.AreEqual(650.90m, Paye.Calculate(3000.00m, "45L", PayrollFrequency.Monthly, 9, 36150.00m, 10069.60m, false, 2013));
            Assert.AreEqual(-548.70m, Paye.Calculate(0.00m, "45L", PayrollFrequency.Monthly, 10, 39150.00m, 10720.50m, false, 2013));
            Assert.AreEqual(651.30m, Paye.Calculate(3000.00m, "45L", PayrollFrequency.Monthly, 11, 39150.00m, 10171.80m, false, 2013));
            Assert.AreEqual(-148.70m, Paye.Calculate(1000.00m, "45L", PayrollFrequency.Monthly, 12, 42150.00m, 10823.10m, false, 2013));

        }
    }
}
