using System;
using System.Linq.Expressions;

namespace Kladzey.LinqBuddy
{
    public static class Predicates
    {
        /// <summary>
        /// <code>x => false</code> predicate.
        /// </summary>
        /// <typeparam name="TInput">Type of parameter.</typeparam>
        /// <returns>Predicate.</returns>
        public static Expression<Func<TInput, bool>> False<TInput>()
        {
            return PredicatesInstances<TInput>.False;
        }

        /// <summary>
        /// <code>x => true</code> predicate.
        /// </summary>
        /// <typeparam name="TInput">Type of parameter.</typeparam>
        /// <returns>Predicate.</returns>
        public static Expression<Func<TInput, bool>> True<TInput>()
        {
            return PredicatesInstances<TInput>.True;
        }

        private static class PredicatesInstances<TInput>
        {
            public static readonly Expression<Func<TInput, bool>> False = Expression.Lambda<Func<TInput, bool>>(Constants.False, Parameters.X<TInput>());

            public static readonly Expression<Func<TInput, bool>> True = Expression.Lambda<Func<TInput, bool>>(Constants.True, Parameters.X<TInput>());
        }
    }
}
