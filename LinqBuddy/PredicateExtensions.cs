using System;
using System.Linq.Expressions;

namespace Kladzey.LinqBuddy
{
    public static class PredicateExtensions
    {
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
