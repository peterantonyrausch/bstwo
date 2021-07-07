using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using BS2.Foundation.Extensions;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates IsEmpty(IEnumerable value, string message, params string[] memberNames)
        {
            var success = value is object && !value.Cast<object>().Any();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotEmpty(IEnumerable value, string message, params string[] memberNames)
        {
            var success = value is object && value.Cast<object>().Any();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNullOrEmpty(IEnumerable value, string message, params string[] memberNames)
        {
            var success = value is null || !value.Cast<object>().Any();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotNullOrEmpty(IEnumerable value, string message, params string[] memberNames)
        {
            var success = value is object && value.Cast<object>().Any();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates OnlyHaveUniqueItems(IEnumerable value, string message, params string[] memberNames)
        {
            var success = value is object && !value.Cast<object>().GroupBy(o => o).Any(g => g.Count() > 1);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates OnlyHaveUniqueItemsBy<T, TKey>(IEnumerable value, Expression<Func<T, TKey>> predicate, string message, params string[] memberNames)
        {
            var success = value is object && !value.Cast<T>().GroupBy(predicate.Compile()).Any(g => g.Count() > 1);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotContainNulls(IEnumerable value, string message, params string[] memberNames)
        {
            var success = value is object && !value.Cast<object>().Any(e => e is null);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates ContainOnlyItemsInstanceOf<T>(IEnumerable value, string message, params string[] memberNames)
        {
            var success = value is object && value.Cast<object>().All(v => v is T);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates Contain(IEnumerable value, IEnumerable expected, string message, params string[] memberNames)
        {
            if (expected == null)
            {
                return Compute(false, value, message, memberNames);
            }

            var expectedObjects = expected.Cast<object>().ToList();
            if (!expectedObjects.Any())
            {
                return Compute(false, value, message, memberNames);
            }

            if (value is null)
            {
                return Compute(false, value, message, memberNames);
            }

            if (expected is string)
            {
                var stringSuccess = value.Cast<object>().Contains(expected);
                return Compute(stringSuccess, value, message, memberNames);
            }

            var missingItems = expectedObjects.Except(value.Cast<object>());
            var success = !missingItems.Any();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotContain(IEnumerable value, IEnumerable unexpected, string message, params string[] memberNames)
        {
            if (unexpected == null)
            {
                return Compute(false, value, message, memberNames);
            }

            var unexpectedObjects = unexpected.Cast<object>().ToList();
            if (!unexpectedObjects.Any())
            {
                return Compute(false, value, message, memberNames);
            }

            if (value is null)
            {
                return Compute(false, value, message, memberNames);
            }

            if (unexpected is string)
            {
                var stringSuccess = !value.Cast<object>().Contains(unexpected);
                return Compute(stringSuccess, value, message, memberNames);
            }

            var foundItems = unexpectedObjects.Intersect(value.Cast<object>());
            var success = !foundItems.Any();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasSameCount(IEnumerable value, IEnumerable other, string message, params string[] memberNames)
        {
            var success = value is object && value.Cast<object>().Count() == other.Cast<object>().Count();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotHasSameCount(IEnumerable value, IEnumerable other, string message, params string[] memberNames)
        {
            var success = value is object && value.Cast<object>().Count() != other.Cast<object>().Count();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasElementAt(IEnumerable value, int index, object element, string message, params string[] memberNames)
        {
            if (value is null)
            {
                return Compute(false, value, message, memberNames);
            }

            var enumerable = value.Cast<object>().ToList();
            var success = enumerable.ElementAt(index).IsSameOrEqualTo(element);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IntersectWith(IEnumerable value, IEnumerable other, string message, params string[] memberNames)
        {
            var success = value is object && value.Cast<object>().Intersect(other.Cast<object>()).Any();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates NotIntersectWith(IEnumerable value, IEnumerable other, string message, params string[] memberNames)
        {
            var success = value is object && !value.Cast<object>().Intersect(other.Cast<object>()).Any();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates AnyGreaterThan<T>(T[] values, T lowerLimit, string message, params string[] memberNames) where T : IComparable<T>
        {
            var success = !values.All(v => v.CompareTo(lowerLimit) <= 0);
            return Compute(success, values, message, memberNames);
        }

        public MemberValidates AnyLessThan<T>(T[] values, T upperLimit, string message, params string[] memberNames) where T : IComparable<T>
        {
            var success = !values.All(v => v.CompareTo(upperLimit) >= 0);
            return Compute(success, values, message, memberNames);
        }
    }
}