using System;
using System.Linq;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates IsEquals(DateTime value, DateTime expected)
        {
            var success = value == expected;
            return Compute(success, value);
        }

        public BasicValidates IsNotEquals(DateTime value, DateTime unexpected)
        {
            var success = value != unexpected;
            return Compute(success, value);
        }

        public BasicValidates IsCloseTo(DateTime value, DateTime nearbyTime, int precisionInMilliseconds)
        {
            var success = IsCloseTo(value, nearbyTime, TimeSpan.FromMilliseconds(precisionInMilliseconds));
            return Compute(success, value);
        }

        public BasicValidates IsCloseTo(DateTime value, DateTime nearbyTime, TimeSpan precision)
        {
            var distanceToMinInTicks = (nearbyTime - DateTime.MinValue).Ticks;
            var minimumValue = nearbyTime.AddTicks(-Math.Min(precision.Ticks, distanceToMinInTicks));

            var distanceToMaxInTicks = (DateTime.MaxValue - nearbyTime).Ticks;
            var maximumValue = nearbyTime.AddTicks(Math.Min(precision.Ticks, distanceToMaxInTicks));

            var success = value >= minimumValue && value <= maximumValue;
            return Compute(success, value);
        }

        public BasicValidates IsNotCloseTo(DateTime value, DateTime distantTime, int precisionInMilliseconds)
        {
            var success = IsNotCloseTo(value, distantTime, TimeSpan.FromMilliseconds(precisionInMilliseconds));
            return Compute(success, value);
        }

        public BasicValidates IsNotCloseTo(DateTime value, DateTime distantTime, TimeSpan precision)
        {
            var distanceToMinInTicks = (distantTime - DateTime.MinValue).Ticks;
            var minimumValue = distantTime.AddTicks(-Math.Min(precision.Ticks, distanceToMinInTicks));

            var distanceToMaxInTicks = (DateTime.MaxValue - distantTime).Ticks;
            var maximumValue = distantTime.AddTicks(Math.Min(precision.Ticks, distanceToMaxInTicks));

            var success = value < minimumValue || value > maximumValue;
            return Compute(success, value);
        }

        public BasicValidates IsBefore(DateTime value, DateTime expected)
        {
            var success = value.CompareTo(expected) < 0;
            return Compute(success, value);
        }

        public BasicValidates IsNotBefore(DateTime value, DateTime unexpected)
        {
            var success = value.CompareTo(unexpected) >= 0;
            return Compute(success, value);
        }

        public BasicValidates IsOnOrBefore(DateTime value, DateTime expected)
        {
            var success = value.CompareTo(expected) <= 0;
            return Compute(success, value);
        }

        public BasicValidates IsNotOnOrBefore(DateTime value, DateTime unexpected)
        {
            var success = value.CompareTo(unexpected) > 0;
            return Compute(success, value);
        }

        public BasicValidates IsAfter(DateTime value, DateTime expected)
        {
            var success = value.CompareTo(expected) > 0;
            return Compute(success, value);
        }

        public BasicValidates IsNotAfter(DateTime value, DateTime unexpected)
        {
            var success = value.CompareTo(unexpected) <= 0;
            return Compute(success, value);
        }

        public BasicValidates IsOnOrAfter(DateTime value, DateTime expected)
        {
            var success = value.CompareTo(expected) >= 0;
            return Compute(success, value);
        }

        public BasicValidates IsNotOnOrAfter(DateTime value, DateTime unexpected)
        {
            var success = value.CompareTo(unexpected) < 0;
            return Compute(success, value);
        }

        public BasicValidates HasYear(DateTime value, int expected)
        {
            var success = value.Year == expected;
            return Compute(success, value);
        }

        public BasicValidates NotHasYear(DateTime value, int unexpected)
        {
            var success = value.Year != unexpected;
            return Compute(success, value);
        }

        public BasicValidates HasMonth(DateTime value, int expected)
        {
            var success = value.Month == expected;
            return Compute(success, value);
        }

        public BasicValidates NotHasMonth(DateTime value, int unexpected)
        {
            var success = value.Month != unexpected;
            return Compute(success, value);
        }

        public BasicValidates HasDay(DateTime value, int expected)
        {
            var success = value.Day == expected;
            return Compute(success, value);
        }

        public BasicValidates NotHasDay(DateTime value, int unexpected)
        {
            var success = value.Day != unexpected;
            return Compute(success, value);
        }

        public BasicValidates HasHour(DateTime value, int expected)
        {
            var success = value.Hour == expected;
            return Compute(success, value);
        }

        public BasicValidates NotHasHour(DateTime value, int unexpected)
        {
            var success = value.Hour != unexpected;
            return Compute(success, value);
        }

        public BasicValidates HasMinute(DateTime value, int expected)
        {
            var success = value.Minute == expected;
            return Compute(success, value);
        }

        public BasicValidates NotHasMinute(DateTime value, int unexpected)
        {
            var success = value.Minute != unexpected;
            return Compute(success, value);
        }

        public BasicValidates HasSecond(DateTime value, int expected)
        {
            var success = value.Second == expected;
            return Compute(success, value);
        }

        public BasicValidates NotHasSecond(DateTime value, int unexpected)
        {
            var success = value.Second != unexpected;
            return Compute(success, value);
        }

        public BasicValidates IsSameDate(DateTime value, DateTime expected)
        {
            var success = value.Date == expected.Date;
            return Compute(success, value);
        }

        public BasicValidates IsNotSameDate(DateTime value, DateTime unexpected)
        {
            var success = value.Date != unexpected.Date;
            return Compute(success, value);
        }

        public BasicValidates IsOneOf(DateTime value, DateTime[] validValues)
        {
            var success = validValues.Contains(value);
            return Compute(success, value);
        }

        public BasicValidates IsIn(DateTime value, DateTimeKind expectedKind)
        {
            var success = value.Kind == expectedKind;
            return Compute(success, value);
        }

        public BasicValidates IsBetween(DateTime value, DateTime start, DateTime end)
        {
            var isAfter = value.CompareTo(start) > 0;
            var isBefore = value.CompareTo(end) < 0;

            var success = isAfter && isBefore;
            return Compute(success, value);
        }

        public BasicValidates IsOnOrBetween(DateTime value, DateTime start, DateTime end)
        {
            var isOnOrAfter = value.CompareTo(start) >= 0;
            var isOnOrBefore = value.CompareTo(end) <= 0;

            var success = isOnOrAfter && isOnOrBefore;
            return Compute(success, value);
        }

        public BasicValidates IsNotBetween(DateTime value, DateTime start, DateTime end)
        {
            var isNotAfter = value.CompareTo(start) <= 0;
            var isNotBefore = value.CompareTo(end) >= 0;

            var success = isNotAfter && isNotBefore;
            return Compute(success, value);
        }

        public BasicValidates IsNotOnOrBetween(DateTime value, DateTime start, DateTime end)
        {
            var isNotOnOrAfter = value.CompareTo(start) < 0;
            var isNotOnOrBefore = value.CompareTo(end) > 0;

            var success = isNotOnOrAfter && isNotOnOrBefore;
            return Compute(success, value);
        }
    }
}