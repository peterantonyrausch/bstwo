using System;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates IsEquals(TimeSpan value, TimeSpan expected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(expected) == 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotEquals(TimeSpan value, TimeSpan unexpected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(unexpected) != 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsPositive(TimeSpan value, string message, params string[] memberNames)
        {
            var success = value.CompareTo(TimeSpan.Zero) > 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNegative(TimeSpan value, string message, params string[] memberNames)
        {
            var success = value.CompareTo(TimeSpan.Zero) < 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsLessThan(TimeSpan value, TimeSpan expected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(expected) < 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsLessOrEqualTo(TimeSpan value, TimeSpan expected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(expected) <= 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsGreaterThan(TimeSpan value, TimeSpan expected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(expected) > 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsGreaterOrEqualTo(TimeSpan value, TimeSpan expected, string message, params string[] memberNames)
        {
            var success = value.CompareTo(expected) >= 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsCloseTo(TimeSpan value, TimeSpan nearbyTime, int precisionInMilliseconds, string message, params string[] memberNames)
        {
            var success = IsCloseTo(value, nearbyTime, TimeSpan.FromMilliseconds(precisionInMilliseconds));
            return Compute(success, value, message, memberNames);
        }

        private bool IsCloseTo(TimeSpan value, TimeSpan nearbyTime, TimeSpan precision)
        {
            var minimumValue = nearbyTime - precision;
            var maximumValue = nearbyTime + precision;
            return value >= minimumValue && value <= maximumValue;
        }

        public MemberValidates IsCloseTo(TimeSpan value, TimeSpan nearbyTime, TimeSpan precision, string message, params string[] memberNames)
        {
            var success = IsCloseTo(value, nearbyTime, precision);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotBeCloseTo(TimeSpan value, TimeSpan distantTime, int precisionInMilliseconds, string message, params string[] memberNames)
        {
            var success = !IsCloseTo(value, distantTime, TimeSpan.FromMilliseconds(precisionInMilliseconds));
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotCloseTo(TimeSpan value, TimeSpan distantTime, TimeSpan precision, string message, params string[] memberNames)
        {
            var success = !IsCloseTo(value, distantTime, precision);
            return Compute(success, value, message, memberNames);
        }
    }
}