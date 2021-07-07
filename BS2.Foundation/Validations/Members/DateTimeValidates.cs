using System;
using System.Linq;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates IsEquals(DateTime value, DateTime expected, string message, params string[] memberNames)
        {
            var success = value == expected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotEquals(DateTime value, DateTime unexpected, string message, params string[] memberNames)
        {
            var success = value != unexpected;
            return Compute(success, value, message, memberNames);
        }

        private bool IsCloseTo(DateTime value, DateTime nearbyTime, TimeSpan precision)
        {
            var distanceToMinInTicks = (nearbyTime - DateTime.MinValue).Ticks;
            var minimumValue = nearbyTime.AddTicks(-Math.Min(precision.Ticks, distanceToMinInTicks));

            var distanceToMaxInTicks = (DateTime.MaxValue - nearbyTime).Ticks;
            var maximumValue = nearbyTime.AddTicks(Math.Min(precision.Ticks, distanceToMaxInTicks));

            return value >= minimumValue && value <= maximumValue;
        }

        private bool IsNotCloseTo(DateTime value, DateTime distantTime, TimeSpan precision)
        {
            var distanceToMinInTicks = (distantTime - DateTime.MinValue).Ticks;
            var minimumValue = distantTime.AddTicks(-Math.Min(precision.Ticks, distanceToMinInTicks));

            var distanceToMaxInTicks = (DateTime.MaxValue - distantTime).Ticks;
            var maximumValue = distantTime.AddTicks(Math.Min(precision.Ticks, distanceToMaxInTicks));

            return value < minimumValue || value > maximumValue;
        }

        public MemberValidates IsCloseTo(DateTime value, DateTime nearbyTime, int precisionInMilliseconds, string message, params string[] memberNames)
        {
            var success = IsCloseTo(value, nearbyTime, TimeSpan.FromMilliseconds(precisionInMilliseconds));
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsCloseTo(DateTime value, DateTime nearbyTime, TimeSpan precision, string message, params string[] memberNames)
        {
            var success = IsCloseTo(value, nearbyTime, precision);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotCloseTo(DateTime value, DateTime distantTime, int precisionInMilliseconds, string message, params string[] memberNames)
        {
            var success = IsNotCloseTo(value, distantTime, TimeSpan.FromMilliseconds(precisionInMilliseconds));
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotCloseTo(DateTime value, DateTime distantTime, TimeSpan precision, string message, params string[] memberNames)
        {
            var success = IsNotCloseTo(value, distantTime, precision);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsBefore(DateTime value, DateTime expected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(expected) < 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotBefore(DateTime value, DateTime unexpected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(unexpected) >= 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsOnOrBefore(DateTime value, DateTime expected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(expected) <= 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotOnOrBefore(DateTime value, DateTime unexpected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(unexpected) > 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsAfter(DateTime value, DateTime expected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(expected) > 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotAfter(DateTime value, DateTime unexpected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(unexpected) <= 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsOnOrAfter(DateTime value, DateTime expected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(expected) >= 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotOnOrAfter(DateTime value, DateTime unexpected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(unexpected) < 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasYear(DateTime value, int expected, string message, params string[] memberNames)
        {
            var success = value.Year == expected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotHasYear(DateTime value, int unexpected, string message, params string[] memberNames)
        {
            var success = value.Year != unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasMonth(DateTime value, int expected, string message, params string[] memberNames)
        {
            var success = value.Month == expected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotHasMonth(DateTime value, int unexpected, string message, params string[] memberNames)
        {
            var success = value.Month != unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasDay(DateTime value, int expected, string message, params string[] memberNames)
        {
            var success = value.Day == expected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotHasDay(DateTime value, int unexpected, string message, params string[] memberNames)
        {
            var success = value.Day != unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasHour(DateTime value, int expected, string message, params string[] memberNames)
        {
            var success = value.Hour == expected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotHasHour(DateTime value, int unexpected, string message, params string[] memberNames)
        {
            var success = value.Hour != unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasMinute(DateTime value, int expected, string message, params string[] memberNames)
        {
            var success = value.Minute == expected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotHasMinute(DateTime value, int unexpected, string message, params string[] memberNames)
        {
            var success = value.Minute != unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasSecond(DateTime value, int expected, string message, params string[] memberNames)
        {
            var success = value.Second == expected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotHasSecond(DateTime value, int unexpected, string message, params string[] memberNames)
        {
            var success = value.Second != unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsSameDate(DateTime value, DateTime expected, string message, params string[] memberNames)
        {
            var success = value.Date == expected.Date;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotSameDate(DateTime value, DateTime unexpected, string message, params string[] memberNames)
        {
            var success = value.Date != unexpected.Date;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsOneOf(DateTime value, DateTime[] validValues, string message, params string[] memberNames)
        {
            var success = validValues.Contains(value);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsIn(DateTime value, DateTimeKind expectedKind, string message, params string[] memberNames)
        {
            var success = value.Kind == expectedKind;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsBetween(DateTime value, DateTime start, DateTime end, string message, params string[] memberNames)
        {
            var isAfter = value.CompareTo(start) > 0;
            var isBefore = value.CompareTo(end) < 0;

            var success = isAfter && isBefore;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsOnOrBetween(DateTime value, DateTime start, DateTime end, string message, params string[] memberNames)
        {
            var isOnOrAfter = value.CompareTo(start) >= 0;
            var isOnOrBefore = value.CompareTo(end) <= 0;

            var success = isOnOrAfter && isOnOrBefore;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotBetween(DateTime value, DateTime start, DateTime end, string message, params string[] memberNames)
        {
            var isNotAfter = value.CompareTo(start) <= 0;
            var isNotBefore = value.CompareTo(end) >= 0;

            var success = isNotAfter && isNotBefore;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotOnOrBetween(DateTime value, DateTime start, DateTime end, string message, params string[] memberNames)
        {
            var isNotOnOrAfter = value.CompareTo(start) < 0;
            var isNotOnOrBefore = value.CompareTo(end) > 0;

            var success = isNotOnOrAfter && isNotOnOrBefore;
            return Compute(success, value, message, memberNames);
        }
    }
}