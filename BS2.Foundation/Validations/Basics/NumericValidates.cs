using System;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates IsEquals(IComparable value, IComparable expected)
        {
            var success = value != null && value.CompareTo(expected) == 0;
            return Compute(success, value);
        }

        public BasicValidates IsNotEquals(IComparable value, IComparable unexpected)
        {
            var success = value != unexpected;
            return Compute(success, value);
        }

        public BasicValidates IsPositive<T>(T value) where T : IComparable
        {
            var success = value != null && value.CompareTo(default(T)) > 0;
            return Compute(success, value);
        }

        public BasicValidates IsNegative<T>(T value) where T : IComparable
        {
            var success = value != null && value.CompareTo(default(T)) < 0;
            return Compute(success, value);
        }

        public BasicValidates IsLessThan<T>(T value, T expected) where T : IComparable
        {
            var success = value != null && value.CompareTo(expected) < 0;
            return Compute(success, value);
        }

        public BasicValidates IsLessOrEqualTo<T>(T value, T expected) where T : IComparable
        {
            var success = value != null && value.CompareTo(expected) <= 0;
            return Compute(success, value);
        }

        public BasicValidates IsGreaterThan<T>(T value, T expected) where T : IComparable
        {
            var success = value != null && value.CompareTo(expected) > 0;
            return Compute(success, value);
        }

        public BasicValidates IsGreaterOrEqualTo<T>(T value, T expected) where T : IComparable
        {
            var success = value != null && value.CompareTo(expected) >= 0;
            return Compute(success, value);
        }

        public BasicValidates IsInRange<T>(T value, T minimum, T maximum) where T : IComparable
        {
            var success = value != null && value.CompareTo(minimum) >= 0 && value.CompareTo(maximum) <= 0;
            return Compute(success, value);
        }

        public BasicValidates IsNotInRange<T>(T value, T minimum, T maximum) where T : IComparable
        {
            var success = !IsInRange(value, minimum, maximum);
            return Compute(success, value);
        }
    }
}