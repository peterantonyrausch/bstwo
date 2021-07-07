using System;

namespace BS2.Foundation.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal Percentage(this decimal value, decimal percentage)
        {
            return value * (percentage / 100);
        }

        public static decimal? Percentage(this decimal? value, decimal percentage)
        {
            if (value.HasValue)
            {
                return value.Value.Percentage(percentage);
            }

            return null;
        }

        public static decimal RoundTo(this decimal value, int decimals)
        {
            return Math.Round(value, decimals);
        }

        public static decimal? RoundTo(this decimal? value, int decimals)
        {
            if (value.HasValue)
            {
                return value.Value.RoundTo(decimals);
            }

            return null;
        }

        public static decimal? Ignore(this decimal? value, decimal ignoreValue)
        {
            if (value.GetValueOrDefault(ignoreValue) == ignoreValue)
            {
                return null;
            }

            return value;
        }

        public static decimal PercentValueRelativeTo(this decimal value, decimal newValue, int decimals = 2)
        {
            if (value == 0 && newValue > 0)
            {
                return 100;
            }
            else if (value == 0 && newValue == 0)
            {
                return 0;
            }

            var result = (newValue / value - 1) * 100;

            return Math.Round(result, decimals);
        }
    }
}
