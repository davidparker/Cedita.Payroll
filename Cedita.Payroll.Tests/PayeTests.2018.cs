// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cedita.Payroll.Tests
{
    public partial class PayeTests
    {
        [TestCategory("PAYE Tests"), TestMethod]
        public void PayeCalculations2018()
        {
            // General Tax Rate
            Assert.AreEqual(0m, LegacyShim(39.24m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(0.20m, LegacyShim(39.25m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(575.00m, LegacyShim(2914.24m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(575.40m, LegacyShim(2914.25m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(4425m, LegacyShim(12539.24m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(4425.45m, LegacyShim(12539.25m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));

            Assert.AreEqual(19.80m, LegacyShim(99.99m, "BR", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(39.60m, LegacyShim(99.99m, "D0", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(44.55m, LegacyShim(99.99m, "D1", PayPeriods.Monthly, 1, 0, 0, false, 2018));

            Assert.AreEqual(0m, LegacyShim(29.05m, "145L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(0.2m, LegacyShim(29.06m, "145L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(132.80m, LegacyShim(692.06m, "145L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(132.90m, LegacyShim(692.07m, "145L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(1021.30m, LegacyShim(2913.06m, "145L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(1021.32m, LegacyShim(2913.07m, "145L", PayPeriods.Weekly, 1, 0, 0, false, 2018));

            Assert.AreEqual(20.20m, LegacyShim(101.99m, "BR", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(40.40m, LegacyShim(101.99m, "D0", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(45.45m, LegacyShim(101.99m, "D1", PayPeriods.Weekly, 1, 0, 0, false, 2018));

            // (Scottish) General Tax Rate
            Assert.AreEqual(0m, LegacyShim(39.24m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(0.19m, LegacyShim(39.25m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(640.62m, LegacyShim(2914.24m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(641.03m, LegacyShim(2914.25m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(4586.87m, LegacyShim(12539.24m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(4587.33m, LegacyShim(12539.25m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));

            Assert.AreEqual(19.80m, LegacyShim(99.99m, "SBR", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(20.79m, LegacyShim(99.99m, "SD0", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(40.59m, LegacyShim(99.99m, "SD1", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(45.54m, LegacyShim(99.99m, "SD2", PayPeriods.Monthly, 1, 0, 0, false, 2018));

            Assert.AreEqual(0m, LegacyShim(29.05m, "S145L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(0.19m, LegacyShim(29.06m, "S145L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(148.05m, LegacyShim(692.06m, "S145L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(148.05m, LegacyShim(692.07m, "S145L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(1058.66m, LegacyShim(2913.06m, "S145L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(1058.68m, LegacyShim(2913.07m, "S145L", PayPeriods.Weekly, 1, 0, 0, false, 2018));

            Assert.AreEqual(20.20m, LegacyShim(101.99m, "SBR", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(21.21m, LegacyShim(101.99m, "SD0", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(41.41m, LegacyShim(101.99m, "SD1", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(46.46m, LegacyShim(101.99m, "SD2", PayPeriods.Weekly, 1, 0, 0, false, 2018));

            // Cumulative
            Assert.AreEqual(33.4m, LegacyShim(1155.26m, "1185L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(33.4m, LegacyShim(1155.27m, "1185L", PayPeriods.Monthly, 2, 1155.26m, 33.4m, false, 2018));
            Assert.AreEqual(540.8m, LegacyShim(3692.26m, "1185L", PayPeriods.Monthly, 3, 2310.53m, 66.8m, false, 2018));
            Assert.AreEqual(1554m, LegacyShim(8758.26m, "1185L", PayPeriods.Monthly, 4, 6002.79m, 607.6m, false, 2018));
            Assert.AreEqual(19963.85m, LegacyShim(52681.25m, "1185L", PayPeriods.Monthly, 5, 14761.05m, 2161.6m, false, 2018));
            Assert.AreEqual(20854.95m, LegacyShim(50000m, "1185L", PayPeriods.Monthly, 6, 67442.30m, 22125.45m, false, 2018));
            Assert.AreEqual(7500m, LegacyShim(15000m, "D0", PayPeriods.Monthly, 7, 117442.30m, 42980.4m, false, 2018));
            Assert.AreEqual(7000.27m, LegacyShim(14000.55m, "D1", PayPeriods.Monthly, 8, 132442.3m, 50480.4m, false, 2018));
            Assert.AreEqual(-25674.07m, LegacyShim(12590.45m, "BR", PayPeriods.Monthly, 9, 146442.85m, 57480.67m, false, 2018));
            Assert.AreEqual(-31806.60m, LegacyShim(11245.05m, "NT", PayPeriods.Monthly, 10, 159033.3m, 31806.6m, false, 2018));

            Assert.AreEqual(7.8m, LegacyShim(267.07m, "1185L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(7.6m, LegacyShim(266.08m, "1185L", PayPeriods.Weekly, 2, 267.07m, 7.8m, false, 2018));
            Assert.AreEqual(124.8m, LegacyShim(853.05m, "1185L", PayPeriods.Weekly, 3, 533.15m, 15.4m, false, 2018));
            Assert.AreEqual(358.8m, LegacyShim(2021.09m, "1185L", PayPeriods.Weekly, 4, 1386.2m, 140.20m, false, 2018));
            Assert.AreEqual(4607.18m, LegacyShim(12157.07m, "1185L", PayPeriods.Weekly, 5, 3407.29m, 499m, false, 2018));
            Assert.AreEqual(6370.03m, LegacyShim(15000m, "1185L", PayPeriods.Weekly, 6, 15564.36m, 5106.18m, false, 2018));
            Assert.AreEqual(121.42m, LegacyShim(242.84m, "D0", PayPeriods.Weekly, 7, 30564.36m, 11476.21m, false, 2018));
            Assert.AreEqual(121.91m, LegacyShim(243.83m, "D1", PayPeriods.Weekly, 8, 30807.2m, 11597.63m, false, 2018));
            Assert.AreEqual(-5382.94m, LegacyShim(632.84m, "BR", PayPeriods.Weekly, 9, 31051.03m, 11719.54m, false, 2018));
            Assert.AreEqual(-6336.60m, LegacyShim(2893.83m, "NT", PayPeriods.Weekly, 10, 31683.87m, 6336.6m, false, 2018));

            // Starters
            Assert.AreEqual(599m, LegacyShim(2995.75m, "BR", PayPeriods.Monthly, 1, 0, 0, true, 2018));
            Assert.AreEqual(203.8m, LegacyShim(2995.75m, "1185L", PayPeriods.Monthly, 2, 2995.75m, 599m, false, 2018));
            Assert.AreEqual(315.8m, LegacyShim(1579.85m, "BR", PayPeriods.Monthly, 1, 0, 0, true, 2018));
            Assert.AreEqual(154.8m, LegacyShim(2750.2m, "1185L", PayPeriods.Monthly, 2, 1579.85m, 315.8m, false, 2018));
            Assert.AreEqual(625.4m, LegacyShim(3001m, "0T", PayPeriods.Monthly, 1, 0, 0, true, 2018));
            Assert.AreEqual(179.6m, LegacyShim(3001m, "1185L", PayPeriods.Monthly, 2, 3001m, 625.4m, false, 2018));
            Assert.AreEqual(201.6m, LegacyShim(1008m, "0T", PayPeriods.Monthly, 1, 0, 0, true, 2018));
            Assert.AreEqual(-28m, LegacyShim(1837m, "1185L", PayPeriods.Monthly, 2, 1008m, 201.6m, false, 2018));
            
            Assert.AreEqual(150m, LegacyShim(750.19m, "BR", PayPeriods.Weekly, 1, 0, 0, true, 2018));
            Assert.AreEqual(58.8m, LegacyShim(750.19m, "1185L", PayPeriods.Weekly, 2, 750.19m, 150m, false, 2018));
            Assert.AreEqual(131.4m, LegacyShim(657.15m, "BR", PayPeriods.Weekly, 1, 0, 0, true, 2018));
            Assert.AreEqual(88.2m, LegacyShim(897.90m, "1185L", PayPeriods.Weekly, 2, 657.15m, 131.4m, false, 2018));
            Assert.AreEqual(265.3m, LegacyShim(995m, "0T", PayPeriods.Weekly, 1, 0, 0, true, 2018));
            Assert.AreEqual(82.51m, LegacyShim(995m, "1185L", PayPeriods.Weekly, 2, 995m, 265.3m, false, 2018));
            Assert.AreEqual(370.1m, LegacyShim(1257m, "0T", PayPeriods.Weekly, 1, 0, 0, true, 2018));
            Assert.AreEqual(269.71m, LegacyShim(1463m, "1185L", PayPeriods.Weekly, 2, 1257m, 370.1m, false, 2018));

            // Tax Code BR
            Assert.AreEqual(574.00m, LegacyShim(2870.55m, "BR", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(700.20m, LegacyShim(3500.95m, "BR", PayPeriods.Monthly, 2, 2870.55m, 574m, false, 2018));
            Assert.AreEqual(6400m, LegacyShim(32000m, "BR", PayPeriods.Monthly, 3, 2870.55m + 3500.95m, 574m + 700.2m, false, 2018));
            Assert.AreEqual(130m, LegacyShim(650.15m, "BR", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(199m, LegacyShim(995.55m, "BR", PayPeriods.Weekly, 2, 650.15m, 130m, false, 2018));
            Assert.AreEqual(1420.2m, LegacyShim(7100.35m, "BR", PayPeriods.Weekly, 3, 650.15m + 995.55m, 130m + 199m, false, 2018));

            // Tax Code NT
            Assert.AreEqual(34.80m, LegacyShim(550, "450L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(0m, LegacyShim(475.25m, "NT", PayPeriods.Monthly, 2, 550, 34.80m, true, 2018));
            Assert.AreEqual(114.8m, LegacyShim(950.25m, "450L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(-114.8m, LegacyShim(825.50m, "NT", PayPeriods.Monthly, 2, 950.25m, 114.8m, false, 2018));
            Assert.AreEqual(182.9m, LegacyShim(895m, "550L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(0m, LegacyShim(776m, "NT", PayPeriods.Weekly, 2, 895m, 0, true, 2018));
            Assert.AreEqual(33.8m, LegacyShim(275m, "550L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(-33.8m, LegacyShim(350m, "NT", PayPeriods.Weekly, 2, 275m, 33.8m, false, 2018));
            
            // Tax Code K
            Assert.AreEqual(276.6m, LegacyShim(895m, "K585", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(347.6m, LegacyShim(1250m, "K585", PayPeriods.Monthly, 2, 895m, 276.6m, false, 2018));
            Assert.AreEqual(250.6m, LegacyShim(765m, "K585", PayPeriods.Monthly, 3, 895m + 1250m, 276.6m + 347.6m, false, 2018));
            Assert.AreEqual(197.6m, LegacyShim(950m, "K45", PayPeriods.Monthly, 1, 0, 0, true, 2018));
            Assert.AreEqual(271.6m, LegacyShim(1120m, "K285", PayPeriods.Monthly, 2, 0, 0, true, 2018));
            Assert.AreEqual(243.8m, LegacyShim(885m, "K401", PayPeriods.Monthly, 3, 0, 0, true, 2018));
            Assert.AreEqual(54.2m, LegacyShim(150m, "K630", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(84.2m, LegacyShim(300m, "K630", PayPeriods.Weekly, 2, 150m, 54.2m, false, 2018));
            Assert.AreEqual(73.4m, LegacyShim(245m, "K630", PayPeriods.Weekly, 3, 150m + 300m, 54.2m + 84.2m, false, 2018));
            Assert.AreEqual(113m, LegacyShim(560m, "K27", PayPeriods.Weekly, 1, 0, 0, true, 2018));
            Assert.AreEqual(92.4m, LegacyShim(432m, "K159", PayPeriods.Weekly, 2, 0, 0, true, 2018));
            Assert.AreEqual(214.9m, LegacyShim(810m, "K306", PayPeriods.Weekly, 3, 0, 0, true, 2018));
            
            // Large Tax Code
            Assert.AreEqual(333.20m, LegacyShim(2500m, "999L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(433m, LegacyShim(3000m, "1000L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(1091m, LegacyShim(5000m, "1001L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(111.40m, LegacyShim(750m, "999L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(150.10m, LegacyShim(900m, "1000L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(390.10m, LegacyShim(1500m, "1001L", PayPeriods.Weekly, 1, 0, 0, false, 2018));

            // 50% Regulatory Limit
            Assert.AreEqual(49.8m, LegacyShim(1000m, "900L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(200m, LegacyShim(400m, "45L", PayPeriods.Monthly, 2, 1000m, 0, false, 2018));
            Assert.AreEqual(28.8m, LegacyShim(895m, "900L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(450m, LegacyShim(900m, "D0", PayPeriods.Monthly, 2, 895m, 28.8m, false, 2018));
            Assert.AreEqual(114.2m, LegacyShim(800m, "1185L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(450m, LegacyShim(900m, "D1", PayPeriods.Weekly, 2, 800m, 114.2m, false, 2018));
        }
    }
}
