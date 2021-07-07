using System.Collections;
using System.Linq;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates ContainKey<TKey>(IDictionary value, TKey expectedKey, string message, params string[] memberNames)
        {
            var success = value is object && value.Keys.Cast<TKey>().Contains(expectedKey);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates ContainKeys<TKey>(IDictionary value, TKey[] expectedKeys, string message, params string[] memberNames)
        {
            var success = value is object && !expectedKeys.Except(value.Keys.Cast<TKey>()).Any();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotContainKey<TKey>(IDictionary value, TKey unexpectedKey, string message, params string[] memberNames)
        {
            var success = value is object && !value.Keys.Cast<TKey>().Contains(unexpectedKey);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotContainKeys<TKey>(IDictionary value, TKey[] unexpectedKeys, string message, params string[] memberNames)
        {
            var success = value is object && !unexpectedKeys.Intersect(value.Keys.Cast<TKey>()).Any();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates ContainValue<TValue>(IDictionary value, TValue expectedValue, string message, params string[] memberNames)
        {
            var success = value is object && value.Values.Cast<TValue>().Contains(expectedValue);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates ContainValues<TValue>(IDictionary value, TValue[] expectedValues, string message, params string[] memberNames)
        {
            var success = value is object && !expectedValues.Except(value.Keys.Cast<TValue>()).Any();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotContainValue<TValue>(IDictionary value, TValue unexpectedValue, string message, params string[] memberNames)
        {
            var success = value is object && !value.Keys.Cast<TValue>().Contains(unexpectedValue);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotContainValues<TValue>(IDictionary value, TValue[] unexpectedValues, string message, params string[] memberNames)
        {
            var success = value is object && !unexpectedValues.Intersect(value.Keys.Cast<TValue>()).Any();
            return Compute(success, value, message, memberNames);
        }
    }
}