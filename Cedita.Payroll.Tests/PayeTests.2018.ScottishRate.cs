// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cedita.Payroll.Tests
{
    public partial class PayeTests
    {
        [TestCategory("PAYE Tests"), TestMethod]
        public void ScottishRatePayeCalculations2018()
        {
            // (Scottish) General Tax Rate
            Assert.AreEqual(0m, LegacyShim(39.24m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(0.19m, LegacyShim(39.25m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(31.73m, LegacyShim(205.25m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(31.73m, LegacyShim(205.26m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(31.93m, LegacyShim(206.25m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(200.93m, LegacyShim(1051.25m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(200.93m, LegacyShim(1051.26m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(201.14m, LegacyShim(1052.25m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(540.92m, LegacyShim(2670.25m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(540.99m, LegacyShim(2670.26m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(4586.87m, LegacyShim(12539.24m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(4587.33m, LegacyShim(12539.25m, "S45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(19.80m, LegacyShim(99.99m, "SBR", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(20.79m, LegacyShim(99.99m, "SD0", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(40.59m, LegacyShim(99.99m, "SD1", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(45.54m, LegacyShim(99.99m, "SD2", PayPeriods.Monthly, 1, 0, 0, false, 2018));

            Assert.AreEqual(0m, LegacyShim(9.82m, "S45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(0.19m, LegacyShim(9.83m, "S45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(7.41m, LegacyShim(47.83m, "S45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(7.41m, LegacyShim(47.84m, "S45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(7.61m, LegacyShim(48.83m, "S45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(46.41m, LegacyShim(242.83m, "S45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(46.41m, LegacyShim(242.84m, "S45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(46.62m, LegacyShim(243.83m, "S45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(124.95m, LegacyShim(616.83m, "S45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(125.09m, LegacyShim(616.84m, "S45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(1058.66m, LegacyShim(2893.83m, "S45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(1058.68m, LegacyShim(2893.84m, "S45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));

            Assert.AreEqual(39.80m, LegacyShim(199.99m, "SBR", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(41.79m, LegacyShim(199.99m, "SD0", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(81.59m, LegacyShim(199.99m, "SD1", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(91.54m, LegacyShim(199.99m, "SD2", PayPeriods.Weekly, 1, 0, 0, false, 2018));

            // General Tax Rate
            Assert.AreEqual(0m, LegacyShim(39.24m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(0.2m, LegacyShim(39.25m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(33.4m, LegacyShim(205.25m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(33.4m, LegacyShim(205.26m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(33.6m, LegacyShim(206.25m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(202.6m, LegacyShim(1051.25m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(202.6m, LegacyShim(1051.26m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(202.8m, LegacyShim(1052.25m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(526.4m, LegacyShim(2670.25m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(526.4m, LegacyShim(2670.26m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(4425m, LegacyShim(12539.24m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(4425.45m, LegacyShim(12539.25m, "45L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(19.80m, LegacyShim(99.99m, "BR", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(39.6m, LegacyShim(99.99m, "D0", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(44.55m, LegacyShim(99.99m, "D1", PayPeriods.Monthly, 1, 0, 0, false, 2018));

            Assert.AreEqual(0m, LegacyShim(9.82m, "45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(0.2m, LegacyShim(9.83m, "45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(7.8m, LegacyShim(47.83m, "45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(7.8m, LegacyShim(47.84m, "45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(8m, LegacyShim(48.83m, "45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(46.8m, LegacyShim(242.83m, "45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(46.8m, LegacyShim(242.84m, "45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(47m, LegacyShim(243.83m, "45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(121.6m, LegacyShim(616.83m, "45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(121.6m, LegacyShim(616.84m, "45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(1021.3m, LegacyShim(2893.83m, "45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(1021.32m, LegacyShim(2893.84m, "45L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(39.80m, LegacyShim(199.99m, "BR", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(79.6m, LegacyShim(199.99m, "D0", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(89.55m, LegacyShim(199.99m, "D1", PayPeriods.Weekly, 1, 0, 0, false, 2018));

            // Cumulative
            Assert.AreEqual(31.73m, LegacyShim(1155.26m, "S1185L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(31.73m, LegacyShim(1155.27m, "S1185L", PayPeriods.Monthly, 2, 1155.26m, 31.73m, false, 2018));
            Assert.AreEqual(539.14m, LegacyShim(3692.26m, "S1185L", PayPeriods.Monthly, 3, 2310.53m, 63.46m, false, 2018));
            Assert.AreEqual(1560.96m, LegacyShim(8477.26m, "S1185L", PayPeriods.Monthly, 4, 6002.79m, 602.6m, false, 2018));
            Assert.AreEqual(20771.27m, LegacyShim(52962.25m, "S1185L", PayPeriods.Monthly, 5, 14480.05m, 2163.56m, false, 2018));
            Assert.AreEqual(21381.94m, LegacyShim(50000m, "S1185L", PayPeriods.Monthly, 6, 67442.30m, 22934.83m, false, 2018));
            Assert.AreEqual(-16503.95m, LegacyShim(15000m, "SD0", PayPeriods.Monthly, 7, 117442.30m, 44316.77m, false, 2018));
            Assert.AreEqual(7000.27m, LegacyShim(14000.55m, "SD1", PayPeriods.Monthly, 8, 132442.3m, 27812.82m, false, 2018));
            Assert.AreEqual(6295.22m, LegacyShim(12590.45m, "SD2", PayPeriods.Monthly, 9, 146442.85m, 34813.09m, false, 2018));
            Assert.AreEqual(-7052.71m, LegacyShim(11245.05m, "SBR", PayPeriods.Monthly, 10, 159033.3m, 41108.31m, false, 2018));
            Assert.AreEqual(-34055.6m, LegacyShim(2000m, "SNT", PayPeriods.Monthly, 11, 170278.35m, 34055.6m, false, 2018));

            Assert.AreEqual(7.41m, LegacyShim(267.07m, "S1185L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(7.22m, LegacyShim(266.08m, "S1185L", PayPeriods.Weekly, 2, 267.07m, 7.41m, false, 2018));
            Assert.AreEqual(124.41m, LegacyShim(853.05m, "S1185L", PayPeriods.Weekly, 3, 533.15m, 14.63m, false, 2018));
            Assert.AreEqual(360.52m, LegacyShim(1956.09m, "S1185L", PayPeriods.Weekly, 4, 1386.2m, 139.04m, false, 2018));
            Assert.AreEqual(4793.41m, LegacyShim(12222.07m, "S1185L", PayPeriods.Weekly, 5, 3342.29m, 499.56m, false, 2018));
            Assert.AreEqual(6526.24m, LegacyShim(15000m, "S1185L", PayPeriods.Weekly, 6, 15564.36m, 5292.97m, false, 2018));
            Assert.AreEqual(-5349.74m, LegacyShim(242.84m, "SD0", PayPeriods.Weekly, 7, 30564.36m, 11819.21m, false, 2018));
            Assert.AreEqual(121.91m, LegacyShim(243.83m, "SD1", PayPeriods.Weekly, 8, 30807.2m, 6469.47m, false, 2018));
            Assert.AreEqual(316.41m, LegacyShim(632.83m, "SD2", PayPeriods.Weekly, 9, 31051.03m, 6591.38m, false, 2018));
            Assert.AreEqual(-444.59m, LegacyShim(632.84m, "SBR", PayPeriods.Weekly, 10, 31683.87m, 6907.79m, false, 2018));
            Assert.AreEqual(-6463.2m, LegacyShim(2893.83m, "SNT", PayPeriods.Weekly, 11, 31683.87m, 6463.2m, false, 2018));

            // Starters
            Assert.AreEqual(300m, LegacyShim(1500m, "SBR", PayPeriods.Monthly, 1, 0, 0, true, 2018));
            Assert.AreEqual(-98.74m, LegacyShim(1500m, "S1185L", PayPeriods.Monthly, 2, 1500m, 300m, false, 2018));
            Assert.AreEqual(200m, LegacyShim(1000m, "SBR", PayPeriods.Monthly, 1, 0, 0, true, 2018));
            Assert.AreEqual(-157.63m, LegacyShim(1200m, "S1185L", PayPeriods.Monthly, 2, 1000m, 200m, false, 2018));
            Assert.AreEqual(691.87m, LegacyShim(3000m, "S0T", PayPeriods.Monthly, 1, 0, 0, true, 2018));
            Assert.AreEqual(129.37m, LegacyShim(3000m, "S1185L", PayPeriods.Monthly, 2, 3000m, 691.87m, false, 2018));
            Assert.AreEqual(158.33m, LegacyShim(800m, "S0T", PayPeriods.Monthly, 1, 0, 0, true, 2018));
            Assert.AreEqual(-153.96m, LegacyShim(1200m, "S1185L", PayPeriods.Monthly, 2, 800m, 158.33m, false, 2018));
            
            Assert.AreEqual(125m, LegacyShim(625m, "SBR", PayPeriods.Weekly, 1, 0, 0, true, 2018));
            Assert.AreEqual(36.08m, LegacyShim(625m, "S1185L", PayPeriods.Weekly, 2, 625m, 125m, false, 2018));
            Assert.AreEqual(40m, LegacyShim(200m, "SBR", PayPeriods.Weekly, 1, 0, 0, true, 2018));
            Assert.AreEqual(7.83m, LegacyShim(500m, "S1185L", PayPeriods.Weekly, 2, 200m, 40m, false, 2018));
            Assert.AreEqual(162.81m, LegacyShim(700m, "S0T", PayPeriods.Weekly, 1, 0, 0, true, 2018));
            Assert.AreEqual(29.77m, LegacyShim(700m, "S1185L", PayPeriods.Weekly, 2, 700m, 162.81m, false, 2018));
            Assert.AreEqual(49.77m, LegacyShim(250m, "S0T", PayPeriods.Weekly, 1, 0, 0, true, 2018));
            Assert.AreEqual(-31.94m, LegacyShim(300m, "S1185L", PayPeriods.Weekly, 2, 250m, 49.77m, false, 2018));

            // Tax Code SBR
            Assert.AreEqual(30m, LegacyShim(150.75m, "SBR", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(50.2m, LegacyShim(250.85m, "SBR", PayPeriods.Monthly, 2, 150.75m, 30m, false, 2018));
            Assert.AreEqual(540m, LegacyShim(2700m, "SBR", PayPeriods.Monthly, 3, 401.6m, 80.2m, false, 2018));
            Assert.AreEqual(1580m, LegacyShim(7900.05m, "SBR", PayPeriods.Monthly, 4, 3101.6m, 620.2m, false, 2018));
            Assert.AreEqual(10300m, LegacyShim(51500m, "SBR", PayPeriods.Monthly, 5, 11001.65m, 2200.2m, false, 2018));

            Assert.AreEqual(7m, LegacyShim(35.95m, "SBR", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(40.4m, LegacyShim(201.5m, "SBR", PayPeriods.Weekly, 2, 35.95m, 7m, false, 2018));
            Assert.AreEqual(110m, LegacyShim(550.25m, "SBR", PayPeriods.Weekly, 3, 237.45m, 47.4m, false, 2018));
            Assert.AreEqual(500.2m, LegacyShim(2500.55m, "SBR", PayPeriods.Weekly, 4, 787.7m, 157.4m, false, 2018));
            Assert.AreEqual(2250m, LegacyShim(11250m, "SBR", PayPeriods.Weekly, 5, 3288.25m, 657.6m, false, 2018));

            // Tax Code NT
            Assert.AreEqual(33.13m, LegacyShim(550, "S450L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(0m, LegacyShim(475.25m, "SNT", PayPeriods.Monthly, 2, 550, 33.13m, true, 2018));
            Assert.AreEqual(113.13m, LegacyShim(950.25m, "S450L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(-113.13m, LegacyShim(825.50m, "SNT", PayPeriods.Monthly, 2, 950.25m, 113.13m, false, 2018));
            Assert.AreEqual(199.3m, LegacyShim(895m, "S550L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(0m, LegacyShim(776m, "SNT", PayPeriods.Weekly, 2, 895m, 199.3m, true, 2018));
            Assert.AreEqual(33.41m, LegacyShim(275m, "S550L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(-33.41m, LegacyShim(350m, "SNT", PayPeriods.Weekly, 2, 275m, 33.41m, false, 2018));
            
            // Tax Code SK
            Assert.AreEqual(278.63m, LegacyShim(895m, "SK585", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(353.19m, LegacyShim(1250m, "SK585", PayPeriods.Monthly, 2, 895m, 278.63m, false, 2018));
            Assert.AreEqual(251.34m, LegacyShim(765m, "SK585", PayPeriods.Monthly, 3, 2145m, 631.82m, false, 2018));
            Assert.AreEqual(195.93m, LegacyShim(950m, "SK45", PayPeriods.Monthly, 1, 0, 0, true, 2018));
            Assert.AreEqual(273.38m, LegacyShim(1120m, "SK285", PayPeriods.Monthly, 2, 0, 0, true, 2018));
            Assert.AreEqual(244.19m, LegacyShim(885m, "SK401", PayPeriods.Monthly, 3, 0, 0, true, 2018));
            Assert.AreEqual(54.18m, LegacyShim(150m, "SK630", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(85.69m, LegacyShim(300m, "SK630", PayPeriods.Weekly, 2, 150m, 54.18m, false, 2018));
            Assert.AreEqual(74.35m, LegacyShim(245m, "SK630", PayPeriods.Weekly, 3, 450m, 139.87m, false, 2018));
            Assert.AreEqual(115.92m, LegacyShim(560m, "SK27", PayPeriods.Weekly, 1, 0, 0, true, 2018));
            Assert.AreEqual(94.29m, LegacyShim(432m, "SK159", PayPeriods.Weekly, 2, 0, 0, true, 2018));
            Assert.AreEqual(239.07m, LegacyShim(810m, "SK396", PayPeriods.Weekly, 3, 0, 0, true, 2018));
            
            // Large Tax Code
            Assert.AreEqual(338.06m, LegacyShim(2500m, "S999L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(442.85m, LegacyShim(3000m, "S1000L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(1169.52m, LegacyShim(5000m, "S1001L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(114.24m, LegacyShim(750m, "S999L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(165.68m, LegacyShim(900m, "S1000L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(411.68m, LegacyShim(1500m, "S1001L", PayPeriods.Weekly, 1, 0, 0, false, 2018));

            // 50% Regulatory Limit
            Assert.AreEqual(48.13m, LegacyShim(1000m, "S900L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(224.59m, LegacyShim(449.18m, "S40L", PayPeriods.Monthly, 2, 1000m, 48.13m, false, 2018));
            Assert.AreEqual(114.73m, LegacyShim(1000m, "S500L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(150m, LegacyShim(300m, "SD0", PayPeriods.Monthly, 2, 1000m, 114.73m, false, 2018));
            Assert.AreEqual(205.86m, LegacyShim(950m, "S750L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(137.5m, LegacyShim(275m, "SD1", PayPeriods.Weekly, 2, 950m, 205.86m, false, 2018));
            Assert.AreEqual(226.36m, LegacyShim(1000m, "S750L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(450m, LegacyShim(900m, "SD2", PayPeriods.Weekly, 2, 1000m, 226.36m, false, 2018));

            // Change of Regime
            Assert.AreEqual(515.51m, LegacyShim(3500m, "S1185L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(489.09m, LegacyShim(3500m, "1185L", PayPeriods.Monthly, 2, 3500m, 515.51m, false, 2018));
            Assert.AreEqual(69.93m, LegacyShim(575m, "S1185L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(68.67m, LegacyShim(575m, "1185L", PayPeriods.Weekly, 2, 575m, 69.93m, false, 2018));
            Assert.AreEqual(302.2m, LegacyShim(2500m, "1185L", PayPeriods.Monthly, 1, 0, 0, false, 2018));
            Assert.AreEqual(309.04m, LegacyShim(2500m, "S1185L", PayPeriods.Monthly, 2, 2500m, 302.2m, false, 2018));
            Assert.AreEqual(135.70m, LegacyShim(900m, "1185L", PayPeriods.Weekly, 1, 0, 0, false, 2018));
            Assert.AreEqual(166.56m, LegacyShim(900m, "S1185L", PayPeriods.Weekly, 2, 900m, 135.70m, false, 2018));
        }
    }
}
