using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using BS2.Foundation.Extensions;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates IsEmpty(IEnumerable value)
        {
            var success = value is object && !value.Cast<object>().Any();
            return Compute(success, value);
        }

        public BasicValidates IsNotEmpty(IEnumerable value)
        {
            var success = value is object && value.Cast<object>().Any();
            return Compute(success, value);
        }

        public BasicValidates IsNullOrEmpty(IEnumerable value)
        {
            var success = value is null || !value.Cast<object>().Any();
            return Compute(success, value);
        }

        public BasicValidates IsNotNullOrEmpty(IEnumerable value)
        {
            var success = value is object && value.Cast<object>().Any();
            return Compute(success, value);
        }

        public BasicValidates OnlyHaveUniqueItems(IEnumerable value)
        {
            var success = value is object && !value.Cast<object>().GroupBy(o => o).Any(g => g.Count() > 1);
            return Compute(success, value);
        }

        public BasicValidates OnlyHaveUniqueItemsBy<T, TKey>(IEnumerable value, Expression<Func<T, TKey>> predicate)
        {
            var success = value is object && !value.Cast<T>().GroupBy(predicate.Compile()).Any(g => g.Count() > 1);
            return Compute(success, value);
        }

        public BasicValidates NotContainNulls(IEnumerable value)
        {
            var success = value is object && !value.Cast<object>().Any(e => e is null);
            return Compute(success, value);
        }

        public BasicValidates ContainOnlyItemsInstanceOf<T>(IEnumerable value)
        {
            var success = value is object && value.Cast<object>().All(v => v is T);
            return Compute(success, value);
        }

        public BasicValidates Contain(IEnumerable value, IEnumerable expected)
        {
            if (expected == null)
            {
                return Compute(false, value);
            }

            var expectedObjects = expected.Cast<object>().ToList();
            if (!expectedObjects.Any())
            {
                return Compute(false, value);
            }

            if (value is null)
            {
                return Compute(false, value);
            }

            if (expected is string)
            {
                var stringSuccess = value.Cast<object>().Contains(expected);
                return Compute(stringSuccess, value);
            }

            var missingItems = expectedObjects.Except(value.Cast<object>());
            var success = !missingItems.Any();
            return Compute(success, value);
        }

        public BasicValidates NotContain(IEnumerable value, IEnumerable unexpected)
        {
            if (unexpected == null)
            {
                return Compute(false, value);
            }

            var unexpectedObjects = unexpected.Cast<object>().ToList();
            if (!unexpectedObjects.Any())
            {
                return Compute(false, value);
            }

            if (value is null)
            {
                return Compute(false, value);
            }

            if (unexpected is string)
            {
                var stringSuccess = !value.Cast<object>().Contains(unexpected);
                return Compute(stringSuccess, value);
            }

            var foundItems = unexpectedObjects.Intersect(value.Cast<object>());
            var success = !foundItems.Any();
            return Compute(success, value);
        }

        public BasicValidates HasSameCount(IEnumerable value, IEnumerable other)
        {
            var success = value is object && value.Cast<object>().Count() == other.Cast<object>().Count();
            return Compute(success, value);
        }

        public BasicValidates NotHasSameCount(IEnumerable value, IEnumerable other)
        {
            var success = value is object && value.Cast<object>().Count() != other.Cast<object>().Count();
            return Compute(success, value);
        }

        public BasicValidates HasElementAt(IEnumerable value, int index, object element)
        {
            if (value is null)
            {
                return Compute(false, value);
            }

            var enumerable = value.Cast<object>().ToList();
            var success = enumerable.ElementAt(index).IsSameOrEqualTo(element);
            return Compute(success, value);
        }

        public BasicValidates IntersectWith(IEnumerable value, IEnumerable other)
        {
            var success = value is object && value.Cast<object>().Intersect(other.Cast<object>()).Any();
            return Compute(success, value);
        }

        public BasicValidates NotIntersectWith(IEnumerable value, IEnumerable other)
        {
            var success = value is object && !value.Cast<object>().Intersect(other.Cast<object>()).Any();
            return Compute(success, value);
        }

        public BasicValidates AnyGreaterThan<T>(T[] values, T lowerLimit) where T : IComparable<T>
        {
            var success = !values.All(v => v.CompareTo(lowerLimit) <= 0);
            return Compute(success, values);
        }

        public BasicValidates AnyLessThan<T>(T[] values, T upperLimit) where T : IComparable<T>
        {
            var success = !values.All(v => v.CompareTo(upperLimit) >= 0);
            return Compute(success, values);
        }
    }
}