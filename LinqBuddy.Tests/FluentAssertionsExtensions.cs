using System.Linq.Expressions;
using Kladzey.LinqBuddy.Tests.TestUtils;

namespace Kladzey.LinqBuddy.Tests
{
    public static class FluentAssertionsExtensions
    {
        public static ExpressionAssertions<TDelegate> Should<TDelegate>(this Expression<TDelegate> instance)
        {
            return new ExpressionAssertions<TDelegate>(instance);
        }
    }
}
