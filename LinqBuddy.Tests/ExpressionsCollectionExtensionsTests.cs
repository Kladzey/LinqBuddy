using System;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class ExpressionsCollectionExtensionsTests
    {
        [Fact]
        public static void AggregateShouldThrowExceptionOnEmptySequenceOfExpressionsTest()
        {
            // When
            Action act = () => Enumerable.Empty<Expression>().Aggregate(Expression.Add);

            // Then
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Expressions is empty.\r\nParameter name: expressions");
        }

        [Fact]
        public static void AggregateTest()
        {
            // Given
            var expressions = Enumerable.Range(1, 5).Select(i => Expression.Constant(i));

            // When
            var result = expressions.Aggregate(Expression.Add);

            // Then
            Expression.Lambda<Func<int>>(result)
                .Should()
                .Equal("() => (((1 + 2) + (3 + 4)) + 5)");
        }
    }
}
