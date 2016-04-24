// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using Cedita.Payroll;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cedita.Payroll.Tests
{
    [TestClass]
    public class NiTests
    {
        [TestMethod]
        public void NationalInsuranceWeekly()
        {
            // A
            Assert.AreEqual(0.00m, NationalInsurance.Calculate(153.04m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(0.02m, NationalInsurance.Calculate(153.05m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(159.19m, NationalInsurance.Calculate(770.04m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(159.21m, NationalInsurance.Calculate(770.05m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(168.22m, NationalInsurance.Calculate(805.04m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(168.23m, NationalInsurance.Calculate(805.05m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(168.26m, NationalInsurance.Calculate(805.29m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(168.27m, NationalInsurance.Calculate(805.30m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(227.47m, NationalInsurance.Calculate(1180.00m, 'A', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));

            // B
            Assert.AreEqual(0.00m, NationalInsurance.Calculate(153.04m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(0.01m, NationalInsurance.Calculate(153.05m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(0.01m, NationalInsurance.Calculate(153.10m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(0.02m, NationalInsurance.Calculate(153.11m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(121.24m, NationalInsurance.Calculate(770.04m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(121.25m, NationalInsurance.Calculate(770.05m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(121.25m, NationalInsurance.Calculate(770.10m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(121.26m, NationalInsurance.Calculate(770.11m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(128.12m, NationalInsurance.Calculate(805.04m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(128.13m, NationalInsurance.Calculate(805.05m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(128.16m, NationalInsurance.Calculate(805.29m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(128.17m, NationalInsurance.Calculate(805.30m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(187.37m, NationalInsurance.Calculate(1180.00m, 'B', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));

            // C
            Assert.AreEqual(0.00m, NationalInsurance.Calculate(153.04m, 'C', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(0.01m, NationalInsurance.Calculate(153.05m, 'C', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(85.15m, NationalInsurance.Calculate(770.04m, 'C', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(85.16m, NationalInsurance.Calculate(770.05m, 'C', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(89.98m, NationalInsurance.Calculate(805.04m, 'C', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(89.99m, NationalInsurance.Calculate(805.05m, 'C', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(141.73m, NationalInsurance.Calculate(1180.00m, 'C', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));

            // D
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0m, EmployerNiGross = 0m, EmployerNiRebate = 0m },
                NationalInsurance.CalculateAll(111.17m, 'D', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0m, EmployerNiGross = 0m, EmployerNiRebate = 0.01m },
                NationalInsurance.CalculateAll(111.18m, 'D', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0m, EmployerNiGross = 0m, EmployerNiRebate = 0.01m },
                NationalInsurance.CalculateAll(111.42m, 'D', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0.01m, EmployerNiGross = 0m, EmployerNiRebate = 0.01m },
                NationalInsurance.CalculateAll(111.43m, 'D', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0.59m, EmployerNiGross = 0m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(153.05m, 'D', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0.01m, EmployeeNiRebate = 0.59m, EmployerNiGross = 0.01m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(153.06m, 'D', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 65.40m, EmployeeNiRebate = 0.59m, EmployerNiGross = 64.17m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(770.04m, 'D', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 65.41m, EmployeeNiRebate = 0.59m, EmployerNiGross = 64.18m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(770.05m, 'D', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 69.60m, EmployeeNiRebate = 0.59m, EmployerNiGross = 69.00m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(805.04m, 'D', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 69.60m, EmployeeNiRebate = 0.59m, EmployerNiGross = 69.01m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(805.05m, 'D', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 69.60m, EmployeeNiRebate = 0.59m, EmployerNiGross = 69.04m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(805.29m, 'D', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 69.61m, EmployeeNiRebate = 0.59m, EmployerNiGross = 69.04m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(805.30m, 'D', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 77.10m, EmployeeNiRebate = 0.59m, EmployerNiGross = 120.75m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(1180.00m, 'D', PayrollFrequency.Weekly, 2014));

            // E
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0m, EmployerNiGross = 0m, EmployerNiRebate = 0m },
                NationalInsurance.CalculateAll(111.17m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0m, EmployerNiGross = 0m, EmployerNiRebate = 0.01m },
                NationalInsurance.CalculateAll(111.18m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0m, EmployerNiGross = 0m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(153.05m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0m, EmployerNiGross = 0.01m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(153.06m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0m, EmployerNiGross = 0.01m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(153.10m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0.01m, EmployeeNiRebate = 0m, EmployerNiGross = 0.01m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(153.11m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 36.09m, EmployeeNiRebate = 0m, EmployerNiGross = 64.17m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(770.04m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 36.09m, EmployeeNiRebate = 0m, EmployerNiGross = 64.18m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(770.05m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 36.09m, EmployeeNiRebate = 0m, EmployerNiGross = 64.18m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(770.10m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 36.10m, EmployeeNiRebate = 0m, EmployerNiGross = 64.18m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(770.11m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 38.14m, EmployeeNiRebate = 0m, EmployerNiGross = 69.00m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(805.04m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 38.14m, EmployeeNiRebate = 0m, EmployerNiGross = 69.01m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(805.05m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 38.14m, EmployeeNiRebate = 0m, EmployerNiGross = 69.04m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(805.29m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 38.15m, EmployeeNiRebate = 0m, EmployerNiGross = 69.04m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(805.30m, 'E', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 45.64m, EmployeeNiRebate = 0m, EmployerNiGross = 120.75m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(1180.00m, 'E', PayrollFrequency.Weekly, 2014));

            // J
            Assert.AreEqual(0.00m, NationalInsurance.Calculate(153.04m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(0.01m, NationalInsurance.Calculate(153.05m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(0.04m, NationalInsurance.Calculate(153.29m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(0.05m, NationalInsurance.Calculate(153.30m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(97.49m, NationalInsurance.Calculate(770.04m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(97.50m, NationalInsurance.Calculate(770.05m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(97.53m, NationalInsurance.Calculate(770.29m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(97.54m, NationalInsurance.Calculate(770.30m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(103.02m, NationalInsurance.Calculate(805.04m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(103.03m, NationalInsurance.Calculate(805.05m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(103.06m, NationalInsurance.Calculate(805.29m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(103.07m, NationalInsurance.Calculate(805.30m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(162.27m, NationalInsurance.Calculate(1180.00m, 'J', PayrollFrequency.Weekly, NationalInsuranceMode.Net, 2014));

            // L
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0m, EmployerNiGross = 0m, EmployerNiRebate = 0m },
                NationalInsurance.CalculateAll(111.17m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0m, EmployerNiGross = 0m, EmployerNiRebate = 0.01m },
                NationalInsurance.CalculateAll(111.18m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0m, EmployerNiGross = 0m, EmployerNiRebate = 0.01m },
                NationalInsurance.CalculateAll(111.42m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0.01m, EmployerNiGross = 0m, EmployerNiRebate = 0.01m },
                NationalInsurance.CalculateAll(111.43m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0.59m, EmployerNiGross = 0m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(153.05m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0.59m, EmployerNiGross = 0.01m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(153.06m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0m, EmployeeNiRebate = 0.59m, EmployerNiGross = 0.03m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(153.29m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 0.01m, EmployeeNiRebate = 0.59m, EmployerNiGross = 0.03m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(153.30m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 12.34m, EmployeeNiRebate = 0.59m, EmployerNiGross = 64.17m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(770.04m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 12.34m, EmployeeNiRebate = 0.59m, EmployerNiGross = 64.18m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(770.05m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 12.34m, EmployeeNiRebate = 0.59m, EmployerNiGross = 64.21m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(770.29m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 12.35m, EmployeeNiRebate = 0.59m, EmployerNiGross = 64.21m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(770.30m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 13.04m, EmployeeNiRebate = 0.59m, EmployerNiGross = 69.00m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(805.04m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 13.04m, EmployeeNiRebate = 0.59m, EmployerNiGross = 69.01m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(805.05m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 13.04m, EmployeeNiRebate = 0.59m, EmployerNiGross = 69.04m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(805.29m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 13.05m, EmployeeNiRebate = 0.59m, EmployerNiGross = 69.04m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(805.30m, 'L', PayrollFrequency.Weekly, 2014));
            Assert.AreEqual(new NiCalculationResult { EmployeeNiGross = 20.54m, EmployeeNiRebate = 0.59m, EmployerNiGross = 120.75m, EmployerNiRebate = 1.43m },
                NationalInsurance.CalculateAll(1180.00m, 'L', PayrollFrequency.Weekly, 2014));
        }

        [TestMethod]
        public void NationalInsuranceFortnightly()
        {
            Assert.AreEqual(0.00m, NationalInsurance.Calculate(306.04m, 'A', PayrollFrequency.Fortnightly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(0.02m, NationalInsurance.Calculate(306.05m, 'A', PayrollFrequency.Fortnightly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(318.37m, NationalInsurance.Calculate(1540.04m, 'A', PayrollFrequency.Fortnightly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(318.39m, NationalInsurance.Calculate(1540.05m, 'A', PayrollFrequency.Fortnightly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(336.69m, NationalInsurance.Calculate(1611.04m, 'A', PayrollFrequency.Fortnightly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(336.70m, NationalInsurance.Calculate(1611.05m, 'A', PayrollFrequency.Fortnightly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(336.73m, NationalInsurance.Calculate(1611.29m, 'A', PayrollFrequency.Fortnightly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(336.74m, NationalInsurance.Calculate(1611.30m, 'A', PayrollFrequency.Fortnightly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(484.26m, NationalInsurance.Calculate(2545.00m, 'A', PayrollFrequency.Fortnightly, NationalInsuranceMode.Net, 2014));
        }

        [TestMethod]
        public void NationalInsurance4Weekly()
        {
            Assert.AreEqual(0.00m, NationalInsurance.Calculate(612.04m, 'A', PayrollFrequency.FourWeekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(0.02m, NationalInsurance.Calculate(612.05m, 'A', PayrollFrequency.FourWeekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(636.74m, NationalInsurance.Calculate(3080.04m, 'A', PayrollFrequency.FourWeekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(636.76m, NationalInsurance.Calculate(3080.05m, 'A', PayrollFrequency.FourWeekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(673.12m, NationalInsurance.Calculate(3221.04m, 'A', PayrollFrequency.FourWeekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(673.13m, NationalInsurance.Calculate(3221.05m, 'A', PayrollFrequency.FourWeekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(673.16m, NationalInsurance.Calculate(3221.29m, 'A', PayrollFrequency.FourWeekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(673.17m, NationalInsurance.Calculate(3221.30m, 'A', PayrollFrequency.FourWeekly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(930.50m, NationalInsurance.Calculate(4850.00m, 'A', PayrollFrequency.FourWeekly, NationalInsuranceMode.Net, 2014));
        }

        [TestMethod]
        public void NationalInsuranceMonthly()
        {
            Assert.AreEqual(0.00m, NationalInsurance.Calculate(663.04m, 'A', PayrollFrequency.Monthly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(0.02m, NationalInsurance.Calculate(663.05m, 'A', PayrollFrequency.Monthly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(689.89m, NationalInsurance.Calculate(3337.04m, 'A', PayrollFrequency.Monthly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(689.91m, NationalInsurance.Calculate(3337.05m, 'A', PayrollFrequency.Monthly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(729.11m, NationalInsurance.Calculate(3489.04m, 'A', PayrollFrequency.Monthly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(729.12m, NationalInsurance.Calculate(3489.05m, 'A', PayrollFrequency.Monthly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(729.15m, NationalInsurance.Calculate(3489.29m, 'A', PayrollFrequency.Monthly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(729.16m, NationalInsurance.Calculate(3489.30m, 'A', PayrollFrequency.Monthly, NationalInsuranceMode.Net, 2014));
            Assert.AreEqual(1046.85m, NationalInsurance.Calculate(5500.00m, 'A', PayrollFrequency.Monthly, NationalInsuranceMode.Net, 2014));
        }
    }
}
