using System;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates IsEquals(IComparable value, IComparable expected, string message, params string[] memberNames)
        {
            var success = value != null && value.CompareTo(expected) == 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotEquals(IComparable value, IComparable unexpected, string message, params string[] memberNames)
        {
            var success = value != unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsPositive<T>(T value, string message, params string[] memberNames) where T : IComparable
        {
            var success = value != null && value.CompareTo(default(T)) > 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNegative<T>(T value, string message, params string[] memberNames) where T : IComparable
        {
            var success = value != null && value.CompareTo(default(T)) < 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsLessThan<T>(T value, T expected, string message, params string[] memberNames) where T : IComparable
        {
            var success = value != null && value.CompareTo(expected) < 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsLessOrEqualTo<T>(T value, T expected, string message, params string[] memberNames) where T : IComparable
        {
            var success = value != null && value.CompareTo(expected) <= 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsGreaterThan<T>(T value, T expected, string message, params string[] memberNames) where T : IComparable
        {
            var success = value != null && value.CompareTo(expected) > 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsGreaterOrEqualTo<T>(T value, T expected, string message, params string[] memberNames) where T : IComparable
        {
            var success = value != null && value.CompareTo(expected) >= 0;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsInRange<T>(T value, T minimum, T maximum, string message, params string[] memberNames) where T : IComparable
        {
            var success = IsInRange(value, minimum, maximum);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotInRange<T>(T value, T minimum, T maximum, string message, params string[] memberNames) where T : IComparable
        {
            var success = !IsInRange(value, minimum, maximum);
            return Compute(success, value, message, memberNames);
        }

        private bool IsInRange<T>(T value, T minimum, T maximum) where T : IComparable
        {
            return value != null && value.CompareTo(minimum) >= 0 && value.CompareTo(maximum) <= 0;
        }
    }
}