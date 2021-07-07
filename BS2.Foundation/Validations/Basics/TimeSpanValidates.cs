using System;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates IsEquals(TimeSpan value, TimeSpan expected)
        {
            var success = value.CompareTo(expected) == 0;
            return Compute(success, value);
        }

        public BasicValidates IsNotEquals(TimeSpan value, TimeSpan unexpected)
        {
            var success = value.CompareTo(unexpected) != 0;
            return Compute(success, value);
        }

        public BasicValidates IsPositive(TimeSpan value)
        {
            var success = value.CompareTo(TimeSpan.Zero) > 0;
            return Compute(success, value);
        }

        public BasicValidates IsNegative(TimeSpan value)
        {
            var success = value.CompareTo(TimeSpan.Zero) < 0;
            return Compute(success, value);
        }

        public BasicValidates IsLessThan(TimeSpan value, TimeSpan expected)
        {
            var success = value.CompareTo(expected) < 0;
            return Compute(success, value);
        }

        public BasicValidates IsLessOrEqualTo(TimeSpan value, TimeSpan expected)
        {
            var success = value.CompareTo(expected) <= 0;
            return Compute(success, value);
        }

        public BasicValidates IsGreaterThan(TimeSpan value, TimeSpan expected)
        {
            var success = value.CompareTo(expected) > 0;
            return Compute(success, value);
        }

        public BasicValidates IsGreaterOrEqualTo(TimeSpan value, TimeSpan expected)
        {
            var success = value.CompareTo(expected) >= 0;
            return Compute(success, value);
        }

        public BasicValidates IsCloseTo(TimeSpan value, TimeSpan nearbyTime, int precisionInMilliseconds)
        {
            var success = IsCloseTo(value, nearbyTime, TimeSpan.FromMilliseconds(precisionInMilliseconds));
            return Compute(success, value);
        }

        public BasicValidates IsCloseTo(TimeSpan value, TimeSpan nearbyTime, TimeSpan precision)
        {
            var minimumValue = nearbyTime - precision;
            var maximumValue = nearbyTime + precision;
            var success = value >= minimumValue && value <= maximumValue;
            return Compute(success, value);
        }

        public BasicValidates IsNotBeCloseTo(TimeSpan value, TimeSpan distantTime, int precisionInMilliseconds)
        {
            var success = !IsCloseTo(value, distantTime, TimeSpan.FromMilliseconds(precisionInMilliseconds));
            return Compute(success, value);
        }

        public BasicValidates IsNotCloseTo(TimeSpan value, TimeSpan distantTime, TimeSpan precision)
        {
            var success = !IsCloseTo(value, distantTime, precision);
            return Compute(success, value);
        }
    }
}