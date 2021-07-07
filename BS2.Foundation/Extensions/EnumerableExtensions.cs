using System;
using System.Collections.Generic;
using System.Linq;

namespace BS2.Foundation.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Searches for the first different element in two sequences using specified <paramref name="equalityComparison" />
        /// </summary>
        /// <typeparam name="TFirst">The type of the elements of the <paramref name="first" /> sequence.</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the <paramref name="second" /> sequence.</typeparam>
        /// <param name="first">The first sequence to compare.</param>
        /// <param name="second">The second sequence to compare.</param>
        /// <param name="equalityComparison">Method that is used to compare 2 elements with the same index.</param>
        /// <returns>Index at which two sequences have elements that are not equal, or -1 if enumerables are equal</returns>
        public static int IndexOfFirstDifferenceWith<TFirst, TSecond>(this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second, Func<TFirst, TSecond, bool> equalityComparison)
        {
            using (var firstEnumerator = first.GetEnumerator())
            using (var secondEnumerator = second.GetEnumerator())
            {
                var index = 0;
                while (true)
                {
                    var isFirstCompleted = !firstEnumerator.MoveNext();
                    var isSecondCompleted = !secondEnumerator.MoveNext();

                    if (isFirstCompleted && isSecondCompleted)
                    {
                        return -1;
                    }

                    if (isFirstCompleted ^ isSecondCompleted)
                    {
                        return index;
                    }

                    if (!equalityComparison(firstEnumerator.Current, secondEnumerator.Current))
                    {
                        return index;
                    }

                    index++;
                }
            }
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count <= 0;
        }

        public static bool AddIfNotContains<T>(this ICollection<T> source, T item)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (source.Contains(item))
            {
                return false;
            }

            source.Add(item);
            return true;
        }

        /// <summary>
        /// Filters elements that are different from null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereElementNotNull<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return source.Where(s => s != null);
        }

        public static decimal? TryMin<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            try
            {
                return source.Min(selector);
            }
            catch
            {
                return null;
            }
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem,
            Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem)
            where TSource : class
        {
            return source.FromHierarchy(nextItem, s => s != null);
        }

        public static decimal TryAverage<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            try
            {
                return source.Average(selector);
            }
            catch (OverflowException)
            {
                return decimal.MaxValue;
            }
            catch
            {
                return 0;
            }
        }

        public static double TryAverage<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            try
            {
                return source.Average(selector);
            }
            catch (OverflowException)
            {
                return double.MaxValue;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Filters a <see cref="IEnumerable{T}"/> by given predicate if given condition is true.
        /// </summary>
        /// <param name="source">Enumerable to apply filtering</param>
        /// <param name="condition">A boolean value</param>
        /// <param name="predicate">Predicate to filter the enumerable</param>
        /// <returns>Filtered or not filtered enumerable based on <paramref name="condition"/></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
        {
            return condition
                ? source.Where(predicate)
                : source;
        }

        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
        {
            return items.GroupBy(property).Select(x => x.First());
        }
    }
}