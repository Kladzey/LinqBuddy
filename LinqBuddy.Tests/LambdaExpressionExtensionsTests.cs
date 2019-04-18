using System;
using System.Linq.Expressions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class LambdaExpressionExtensionsTests
    {
        private static readonly Expression<Func<double, double>> sqr = x => x * x;

        [Fact]
        public void InlineCallsTest()
        {
            // Given
            Expression<Func<double, double, double>> length = (x, y) => Math.Sqrt(sqr.Call(x) + sqr.Call(y));
            Expression<Func<double, double, double, double, double>> distance = (x1, y1, x2, y2) => length.Call(x2 - x1, y2 - y1);

            // When
            var result = distance.InlineCalls();

            // Then
            using (new AssertionScope())
            {
                result.Should().Equal((x1, y1, x2, y2) => Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)));
                result.Call(1, -1, 4, 3).Should().BeApproximately(5, 1e-5);
            }
        }
    }
}
