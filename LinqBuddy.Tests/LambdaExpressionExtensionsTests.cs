using System;
using System.Linq.Expressions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class LambdaExpressionExtensionsTests
    {
        public static readonly Expression<Func<TestObject, int, int>> TestObjectCallxpression = (t, i) => t.Sum + i;
        private static readonly Expression<Func<double, double>> sqr = x => x * x;

        [Fact]
        public void InlineCallsTest()
        {
            // Given
            Expression<Func<double, double, double>> length = (x, y) => Math.Sqrt(sqr.Call(x) + sqr.Call(y));
            Expression<Func<double, double, double, double, double>> distance = (x1, y1, x2, y2) =>
                length.Call(x2 - x1, y2 - y1);

            // When
            var result = distance.InlineCalls();

            // Then
            using (new AssertionScope())
            {
                result.Should().Equal((x1, y1, x2, y2) => Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)));
                result.Call(1, -1, 4, 3).Should().BeApproximately(5, 1e-5);
            }
        }

        [Fact]
        public void InlineCallsWithCallAttributeShouldThrowExceptionIfExpressionIsNotFoundTest()
        {
            // Given
            Expression<Func<int>> expression = () => new TestObject().NotFound;

            // When
            Action act = () => expression.InlineCalls();

            // Then
            act.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Expression is not found.");
        }

        [Fact]
        public void InlineCallsWithCallAttributeShouldThrowExceptionIfParametersAreWrongTest()
        {
            // Given
            Expression<Func<int>> expression = () => new TestObject().InvalidParameters;

            // When
            Action act = () => expression.InlineCalls();

            // Then
            act.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("The number of replacements is not equal to the number of parameters.");
        }

        [Fact]
        public void InlineCallsWithCallAttributeTest()
        {
            // Given
            Expression<Func<int, int, int, int>> expression = (x, y, z) => new TestObject { X = x, Y = y }.Call(z);

            // When
            var result = expression.InlineCalls();

            // Then
            using (new AssertionScope())
            {
                result.Should()
                    .Equal((x, y, z) => new TestObject { X = x, Y = y }.X + new TestObject { X = x, Y = y }.Y + z);
                result.Call(1, 2, 3).Should().Be(6);
            }
        }

        public class TestObject
        {
            public static readonly Expression<Func<TestObject, int>> SumExpression = t => t.X + t.Y;

            [CallExpression(nameof(TestObjectCallxpression), typeof(LambdaExpressionExtensionsTests))]
            public int InvalidParameters => throw new NotSupportedException();

            [CallExpression("NotFound")]
            public int NotFound => throw new NotSupportedException();

            [CallExpression]
            public int Sum => throw new NotSupportedException();

            public int X { get; set; }

            public int Y { get; set; }

            [CallExpression(nameof(TestObjectCallxpression), typeof(LambdaExpressionExtensionsTests))]
            public int Call(int i) => throw new NotSupportedException();
        }
    }
}
