using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates IsEquals(string value, string expected, string message, params string[] memberNames)
        {
            var success = string.Equals(value, expected, StringComparison.CurrentCulture);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotEquals(string value, string unexpected, string message, params string[] memberNames)
        {
            var success = value != unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsOneOf(string value, string[] validValues, string message, params string[] memberNames)
        {
            var success = validValues.Contains(value);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsEqualsIgnoreCase(string value, string expected, string message, params string[] memberNames)
        {
            var success = string.Equals(value, expected, StringComparison.CurrentCultureIgnoreCase);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotEqualsIgnoreCase(string value, string unexpected, string message, params string[] memberNames)
        {
            var success = !string.Equals(value, unexpected, StringComparison.CurrentCultureIgnoreCase);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsMatchRegex(string value, string pattern, string message, params string[] memberNames)
        {
            var success = Regex.IsMatch(value, pattern);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotMatchRegex(string value, string pattern, string message, params string[] memberNames)
        {
            var success = !Regex.IsMatch(value, pattern);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates StartWith(string value, string expected, string message, params string[] memberNames)
        {
            var success = value.StartsWith(expected);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotStartWith(string value, string unexpected, string message, params string[] memberNames)
        {
            var success = !value.StartsWith(unexpected);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates EndsWith(string value, string expected, string message, params string[] memberNames)
        {
            var success = value.EndsWith(expected);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotEndsWith(string value, string unexpected, string message, params string[] memberNames)
        {
            var success = !value.EndsWith(unexpected);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates Contain(string value, string expected, string message, params string[] memberNames)
        {
            var success = Contains(value, expected, StringComparison.Ordinal);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotContain(string value, string unexpected, string message, params string[] memberNames)
        {
            var success = !Contains(value, unexpected, StringComparison.Ordinal);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates ContainIgnoreCase(string value, string expected, string message, params string[] memberNames)
        {
            var success = Contains(value, expected, StringComparison.OrdinalIgnoreCase);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotContainIgnoreCase(string value, string unexpected, string message, params string[] memberNames)
        {
            var success = !Contains(value, unexpected, StringComparison.OrdinalIgnoreCase);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates ContainAll(string value, string[] values, string message, params string[] memberNames)
        {
            var success = values.All(expected => Contains(value, expected, StringComparison.Ordinal));
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotContainAll(string value, string[] values, string message, params string[] memberNames)
        {
            var success = !values.All(expected => Contains(value, expected, StringComparison.Ordinal));
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates ContainAny(string value, string[] values, string message, params string[] memberNames)
        {
            var success = values.Any(expected => Contains(value, expected, StringComparison.Ordinal));
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotContainAny(string value, string[] values, string message, params string[] memberNames)
        {
            var success = !values.Any(expected => Contains(value, expected, StringComparison.Ordinal)); ;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates ContainAllIgnoreCase(string value, string[] values, string message, params string[] memberNames)
        {
            var success = values.All(expected => Contains(value, expected, StringComparison.OrdinalIgnoreCase));
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotContainAllIgnoreCase(string value, string[] values, string message, params string[] memberNames)
        {
            var success = !values.All(expected => Contains(value, expected, StringComparison.OrdinalIgnoreCase)); ;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates ContainAnyIgnoreCase(string value, string[] values, string message, params string[] memberNames)
        {
            var success = values.Any(expected => Contains(value, expected, StringComparison.OrdinalIgnoreCase));
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotContainAnyIgnoreCase(string value, string[] values, string message, params string[] memberNames)
        {
            var success = !values.Any(expected => Contains(value, expected, StringComparison.OrdinalIgnoreCase));
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsEmpty(string value, string message, params string[] memberNames)
        {
            var success = string.Equals(value, string.Empty, StringComparison.CurrentCulture);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotEmpty(string value, string message, params string[] memberNames)
        {
            var success = !string.Equals(value, string.Empty, StringComparison.CurrentCulture);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNullOrEmpty(string value, string message, params string[] memberNames)
        {
            var success = string.IsNullOrEmpty(value);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotNullOrEmpty(string value, string message, params string[] memberNames)
        {
            var success = !string.IsNullOrEmpty(value);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNullOrWhiteSpace(string value, string message, params string[] memberNames)
        {
            var success = string.IsNullOrWhiteSpace(value);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotNullOrWhiteSpace(string value, string message, params string[] memberNames)
        {
            var success = !string.IsNullOrWhiteSpace(value);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasLength(string value, int expected, string message, params string[] memberNames)
        {
            var success = (value?.Length ?? 0) == expected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasNotLength(string value, int unexpected, string message, params string[] memberNames)
        {
            var success = (value?.Length ?? 0) != unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasLengthLessThan(string value, int expected, string message, params string[] memberNames)
        {
            var success = (value?.Length ?? 0) < expected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasLengthGreaterThan(string value, int unexpected, string message, params string[] memberNames)
        {
            var success = (value?.Length ?? 0) > unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasLengthLessOrEqualTo(string value, int expected, string message, params string[] memberNames)
        {
            var success = (value?.Length ?? 0) <= expected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasLengthGreaterOrEqualTo(string value, int unexpected, string message, params string[] memberNames)
        {
            var success = (value?.Length ?? 0) >= unexpected;
            return Compute(success, value, message, memberNames);
        }

        private bool Contains(string value, string expected, StringComparison comparison)
        {
            return (value ?? "").IndexOf(expected ?? "", comparison) >= 0;
        }

        public MemberValidates HasOnlyNumbers(string value, string message, params string[] memberNames)
        {
            var success = value?.All(char.IsNumber) ?? false;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasOnlyDigits(string value, string message, params string[] memberNames)
        {
            var success = value.All(char.IsDigit);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasOnlyLetters(string value, string message, params string[] memberNames)
        {
            var success = value.All(char.IsLetter);
            return Compute(success, value, message, memberNames);
        }
    }
}