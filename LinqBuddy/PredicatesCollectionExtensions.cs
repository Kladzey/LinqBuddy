using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Kladzey.LinqBuddy
{
    public static class PredicatesCollectionExtensions
    {
        public static Expression<Func<T, bool>> And<T>(this IEnumerable<Expression<Func<T, bool>>> predicates)
        {
            if (predicates == null)
            {
                throw new ArgumentNullException(nameof(predicates));
            }

            return Aggregate(predicates, Predicates.True<T>(), Expression.AndAlso);
        }

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
                    .ToEnumerable()
                    .Prepend(first)
                    .SelectBodiesWithUnitedParameters()
                    .Aggregate(aggregateSelector);

                return Expression.Lambda<Func<T, bool>>(expression, first.Parameters);
            }
        }
    }
}
