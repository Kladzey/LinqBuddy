using System.Linq.Expressions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class ParametersTests
    {
        [Fact]
        public void ParametersTest()
        {
            using (new AssertionScope())
            {
                Parameters.X<string>().Should().BeEquivalentTo(Expression.Parameter(typeof(string), "x"));
                Parameters.Y<int>().Should().BeEquivalentTo(Expression.Parameter(typeof(int), "y"));
                Parameters.Z<object>().Should().BeEquivalentTo(Expression.Parameter(typeof(object), "z"));
            }
        }
    }
}
