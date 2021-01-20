using System;
using System.Linq;
using Kladzey.LinqBuddy.Visitors;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// IQueryable extensions.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Inline expressions calls in query.
        /// </summary>
        /// <typeparam name="T">The type of the data in the query.</typeparam>
        /// <param name="source">Query to inline.</param>
        /// <returns>Query with inlined calls.</returns>
        public static IQueryable<T> InlineCalls<T>(this IQueryable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return (IQueryable<T>)source.Provider.CreateQuery(
                InlineCallsVisitor.Instance.Visit(source.Expression) ??
                throw new InvalidOperationException("Cannot create expression."));
        }
    }
}
