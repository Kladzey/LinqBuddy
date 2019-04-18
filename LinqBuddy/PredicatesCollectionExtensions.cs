using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// Extensions for collections of predicates.
    /// </summary>
    public static class PredicatesCollectionExtensions
    {
        /// <summary>
        /// And.
        /// </summary>
        /// <typeparam name="T">Type of parameter.</typeparam>
        /// <param name="predicates">Sequence of predicates.</param>
        /// <returns>And combination of predicates.</returns>
        public static Expression<Func<T, bool>> And<T>(this IEnumerable<Expression<Func<T, bool>>> predicates)
        {
            if (predicates == null)
            {
                throw new ArgumentNullException(nameof(predicates));
            }

            return Aggregate(predicates, Predicates.True<T>(), Expression.AndAlso);
        }

        /// <summary>
        /// Or.
        /// </summary>
        /// <typeparam name="T">Type of parameter.</typeparam>
        /// <param name="predicates">Sequence of predicates.</param>
        /// <returns>Or combination of predicates.</returns>
        public static Expression<Func<T, bool>> Or<T>(this IEnumerable<Expression<Func<T, bool>>> predicates)
        {
            if (predicates == null)
            {
                throw new ArgumentNullException(nameof(predicates));
            }

            return Aggregate(predicates, Predicates.False<T>(), Expression.OrElse);
        }

        private static Expression<Func<T, bool>> Aggregate<T>(
            IEnumerable<Expression<Func<T, bool>>> predicates,
            Expression<Func<T, bool>> defaultValue,
            Func<Expression, Expression, Expression> aggregateSelector)
        {
            using (var enumerator = predicates.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    return defaultValue;
                }

                var first = enumerator.Current;

                var expression = enumerator
                    .AsEnumerableInternal()
                    .Prepend(first)
                    .SelectBodiesWithUnitedParametersInternal()
                    .AggregateInternal(aggregateSelector);

                return Expression.Lambda<Func<T, bool>>(expression, first.Parameters);
            }
        }
    }
}
