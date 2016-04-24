// Copyright (c) Cedita Ltd. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.

using System;

namespace Cedita.Payroll
{
    public enum MultiplicationAccuracy { High, Low }
    public static class TaxMath
    {
        public static decimal Truncate(decimal value, int places = 2)
        {
            decimal multiplier = (decimal)System.Math.Pow(10, places);

            return System.Math.Truncate(value * multiplier) / multiplier;
        }

        public static decimal Multiply(decimal x, decimal y, MultiplicationAccuracy accuracy = MultiplicationAccuracy.High)
        {
            switch (accuracy)
            {
                default:
                case MultiplicationAccuracy.High:
                    return x * y;
                case MultiplicationAccuracy.Low:
                    var xFloat = (float)x;
                    var yFloat = (float)y;
                    var result = xFloat * yFloat;
                    var highAccResult = (decimal)result;
                    return highAccResult;
            }
        }

        public static decimal Factor(decimal start, decimal factorOf, decimal factorBy)
        {
            return (start / factorBy) * factorOf;
        }

        public static decimal PeriodRound(decimal value, int periods)
        {
            if (periods > 1)
                return Math.Ceiling(value);
            return Math.Round(value, 0, MidpointRounding.AwayFromZero);
        }

        public static decimal BankersRound(decimal value, int places = 2)
        {
            value = TaxMath.Truncate(value, places + 1);
            value = Math.Round(value, places, MidpointRounding.ToEven);
            return value;
        }

        public static decimal HmrcRound(decimal value, int places = 2)
        {
            value = TaxMath.Truncate(value, places + 1);
            decimal factor = (decimal)Math.Pow(10, places);
            var unround = decimal.Floor(value * factor);
            var fraction = value * factor - unround;
            if (fraction <= 0.5m) return unround / factor;
            return (unround + 1m) / 100m;
        }

        public static decimal PositiveOnly(decimal value)
        {
            if (value > 0)
                return value;
            return 0m;
        }

        public static decimal Smallest(decimal x, decimal y)
        {
            if (x >= y)
                return y;
            return x;
        }
    }
}
