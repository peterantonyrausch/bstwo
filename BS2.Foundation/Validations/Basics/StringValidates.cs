using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates IsEquals(string value, string expected)
        {
            var success = string.Equals(value, expected, StringComparison.CurrentCulture);
            return Compute(success, value);
        }

        public BasicValidates IsNotEquals(string value, string unexpected)
        {
            var success = value != unexpected;
            return Compute(success, value);
        }

        public BasicValidates IsOneOf(string value, string[] validValues)
        {
            var success = validValues.Contains(value);
            return Compute(success, value);
        }

        public BasicValidates IsEqualsIgnoreCase(string value, string expected)
        {
            var success = string.Equals(value, expected, StringComparison.CurrentCultureIgnoreCase);
            return Compute(success, value);
        }

        public BasicValidates IsNotEqualsIgnoreCase(string value, string unexpected)
        {
            var success = !string.Equals(value, unexpected, StringComparison.CurrentCultureIgnoreCase);
            return Compute(success, value);
        }

        public BasicValidates IsMatchRegex(string value, string pattern)
        {
            var success = Regex.IsMatch(value, pattern);
            return Compute(success, value);
        }

        public BasicValidates IsNotMatchRegex(string value, string pattern)
        {
            var success = !Regex.IsMatch(value, pattern);
            return Compute(success, value);
        }

        public BasicValidates StartWith(string value, string expected)
        {
            var success = value.StartsWith(expected);
            return Compute(success, value);
        }

        public BasicValidates NotStartWith(string value, string unexpected)
        {
            var success = !value.StartsWith(unexpected);
            return Compute(success, value);
        }

        public BasicValidates EndsWith(string value, string expected)
        {
            var success = value.EndsWith(expected);
            return Compute(success, value);
        }

        public BasicValidates NotEndsWith(string value, string unexpected)
        {
            var success = !value.EndsWith(unexpected);
            return Compute(success, value);
        }

        public BasicValidates Contain(string value, string expected)
        {
            var success = Contains(value, expected, StringComparison.Ordinal);
            return Compute(success, value);
        }

        public BasicValidates NotContain(string value, string unexpected)
        {
            var success = !Contains(value, unexpected, StringComparison.Ordinal);
            return Compute(success, value);
        }

        public BasicValidates ContainIgnoreCase(string value, string expected)
        {
            var success = Contains(value, expected, StringComparison.OrdinalIgnoreCase);
            return Compute(success, value);
        }

        public BasicValidates NotContainIgnoreCase(string value, string unexpected)
        {
            var success = !Contains(value, unexpected, StringComparison.OrdinalIgnoreCase);
            return Compute(success, value);
        }

        public BasicValidates ContainAll(string value, string[] values)
        {
            var success = values.All(expected => Contains(value, expected, StringComparison.Ordinal));
            return Compute(success, value);
        }

        public BasicValidates NotContainAll(string value, string[] values)
        {
            var success = !values.All(expected => Contains(value, expected, StringComparison.Ordinal));
            return Compute(success, value);
        }

        public BasicValidates ContainAny(string value, string[] values)
        {
            var success = values.Any(expected => Contains(value, expected, StringComparison.Ordinal));
            return Compute(success, value);
        }

        public BasicValidates NotContainAny(string value, string[] values)
        {
            var success = !values.Any(expected => Contains(value, expected, StringComparison.Ordinal)); ;
            return Compute(success, value);
        }

        public BasicValidates ContainAllIgnoreCase(string value, string[] values)
        {
            var success = values.All(expected => Contains(value, expected, StringComparison.OrdinalIgnoreCase));
            return Compute(success, value);
        }

        public BasicValidates NotContainAllIgnoreCase(string value, string[] values)
        {
            var success = !values.All(expected => Contains(value, expected, StringComparison.OrdinalIgnoreCase)); ;
            return Compute(success, value);
        }

        public BasicValidates ContainAnyIgnoreCase(string value, string[] values)
        {
            var success = values.Any(expected => Contains(value, expected, StringComparison.OrdinalIgnoreCase));
            return Compute(success, value);
        }

        public BasicValidates NotContainAnyIgnoreCase(string value, string[] values)
        {
            var success = !values.Any(expected => Contains(value, expected, StringComparison.OrdinalIgnoreCase));
            return Compute(success, value);
        }

        public BasicValidates IsEmpty(string value)
        {
            var success = string.Equals(value, string.Empty, StringComparison.CurrentCulture);
            return Compute(success, value);
        }

        public BasicValidates IsNotEmpty(string value)
        {
            var success = !string.Equals(value, string.Empty, StringComparison.CurrentCulture);
            return Compute(success, value);
        }

        public BasicValidates IsNullOrEmpty(string value)
        {
            var success = string.IsNullOrEmpty(value);
            return Compute(success, value);
        }

        public BasicValidates IsNotNullOrEmpty(string value)
        {
            var success = !string.IsNullOrEmpty(value);
            return Compute(success, value);
        }

        public BasicValidates IsNullOrWhiteSpace(string value)
        {
            var success = string.IsNullOrWhiteSpace(value);
            return Compute(success, value);
        }

        public BasicValidates IsNotNullOrWhiteSpace(string value)
        {
            var success = !string.IsNullOrWhiteSpace(value);
            return Compute(success, value);
        }

        public BasicValidates HasLength(string value, int expected)
        {
            var success = value.Length == expected;
            return Compute(success, value);
        }

        public BasicValidates HasNotLength(string value, int unexpected)
        {
            var success = value.Length != unexpected;
            return Compute(success, value);
        }

        public BasicValidates HasLengthLessThan(string value, int expected)
        {
            var success = value.Length < expected;
            return Compute(success, value);
        }

        public BasicValidates HasLengthGreaterThan(string value, int unexpected)
        {
            var success = value.Length > unexpected;
            return Compute(success, value);
        }

        public BasicValidates HasLengthLessOrEqualTo(string value, int expected)
        {
            var success = value.Length <= expected;
            return Compute(success, value);
        }

        public BasicValidates HasLengthGreaterOrEqualTo(string value, int unexpected)
        {
            var success = value.Length >= unexpected;
            return Compute(success, value);
        }

        private bool Contains(string value, string expected, StringComparison comparison)
        {
            return (value ?? "").IndexOf(expected ?? "", comparison) >= 0;
        }

        public BasicValidates HasOnlyNumbers(string value)
        {
            var success = value.All(char.IsNumber);
            return Compute(success, value);
        }

        public BasicValidates HasOnlyDigits(string value)
        {
            var success = value.All(char.IsDigit);
            return Compute(success, value);
        }

        public BasicValidates HasOnlyLetters(string value)
        {
            var success = value.All(char.IsLetter);
            return Compute(success, value);
        }
    }
}