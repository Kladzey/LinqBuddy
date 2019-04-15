using System.Linq;
using System.Linq.Expressions;
using Kladzey.LinqBuddy.Tests.TestUtils;

namespace Kladzey.LinqBuddy.Tests
{
    internal static class FluentAssertionsExtensions
    {
        public static ExpressionAssertions<TDelegate> Should<TDelegate>(this Expression<TDelegate> instance)
        {
            return new ExpressionAssertions<TDelegate>(instance);
        }

        public static QueryableAssertions<T> Should<T>(this IQueryable<T> instance)
        {
            return new QueryableAssertions<T>(instance);
        }
    }
}
