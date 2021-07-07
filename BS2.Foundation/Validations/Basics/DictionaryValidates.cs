using System.Collections;
using System.Linq;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates ContainKey<TKey>(IDictionary value, TKey expectedKey)
        {
            var success = value is object && value.Keys.Cast<TKey>().Contains(expectedKey);
            return Compute(success, value);
        }

        public BasicValidates ContainKeys<TKey>(IDictionary value, TKey[] expectedKeys)
        {
            var success = value is object && !expectedKeys.Except(value.Keys.Cast<TKey>()).Any();
            return Compute(success, value);
        }

        public BasicValidates NotContainKey<TKey>(IDictionary value, TKey unexpectedKey)
        {
            var success = value is object && !value.Keys.Cast<TKey>().Contains(unexpectedKey);
            return Compute(success, value);
        }

        public BasicValidates NotContainKeys<TKey>(IDictionary value, TKey[] unexpectedKeys)
        {
            var success = value is object && !unexpectedKeys.Intersect(value.Keys.Cast<TKey>()).Any();
            return Compute(success, value);
        }

        public BasicValidates ContainValue<TValue>(IDictionary value, TValue expectedValue)
        {
            var success = value is object && value.Values.Cast<TValue>().Contains(expectedValue);
            return Compute(success, value);
        }

        public BasicValidates ContainValues<TValue>(IDictionary value, TValue[] expectedValues)
        {
            var success = value is object && !expectedValues.Except(value.Keys.Cast<TValue>()).Any();
            return Compute(success, value);
        }

        public BasicValidates NotContainValue<TValue>(IDictionary value, TValue unexpectedValue)
        {
            var success = value is object && !value.Keys.Cast<TValue>().Contains(unexpectedValue);
            return Compute(success, value);
        }

        public BasicValidates NotContainValues<TValue>(IDictionary value, TValue[] unexpectedValues)
        {
            var success = value is object && !unexpectedValues.Intersect(value.Keys.Cast<TValue>()).Any();
            return Compute(success, value);
        }
    }
}