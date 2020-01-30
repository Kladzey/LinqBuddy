using System;
using System.Linq.Expressions;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// Predicate extensions.
    /// </summary>
    public static class PredicateExtensions
    {
        /// <summary>
        /// And.
        /// </summary>
        /// <typeparam name="T">Type of argument.</typeparam>
        /// <param name="left">Left predicate.</param>
        /// <param name="right">Right predicate.</param>
        /// <returns>And combination of predicates.</returns>
        public static Expression<Func<T, bool>> And<T>(
            this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            var replaced = right.Body.ReplaceParameter(right.Parameters[0], left.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Body, replaced), left.Parameters);
        }

        /// <summary>
        /// Not.
        /// </summary>
        /// <typeparam name="T">Type of argument.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Negative predicate.</returns>
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return Expression.Lambda<Func<T, bool>>(Expression.Not(predicate.Body), predicate.Parameters);
        }

        /// <summary>
        /// Or.
        /// </summary>
        /// <typeparam name="T">Type of argument.</typeparam>
        /// <param name="left">Left predicate.</param>
        /// <param name="right">Right predicate.</param>
        /// <returns>Or combination of predicates.</returns>
        public static Expression<Func<T, bool>> Or<T>(
            this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            var replaced = right.Body.ReplaceParameter(right.Parameters[0], left.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left.Body, replaced), left.Parameters);
        }
    }
}
