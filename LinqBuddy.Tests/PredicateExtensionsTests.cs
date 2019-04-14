using System;
using System.Linq.Expressions;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class PredicateExtensionsTests
    {
        public static TheoryData<Expression<Func<int, bool>>, Expression<Func<int, bool>>, Expression<Func<int, bool>>>
            AndTestCases =>
            new TheoryData<Expression<Func<int, bool>>, Expression<Func<int, bool>>, Expression<Func<int, bool>>>
            {
                {
                    x => x != 1,
                    y => y != 2,
                    x => x != 1 && x != 2
                },
            };

        [Theory]
        [MemberData(nameof(AndTestCases))]
        public void AndTest(Expression<Func<int, bool>> left, Expression<Func<int, bool>> right,
            Expression<Func<int, bool>> expected)
        {
            var result = left.And(right);
            result.Should().Equal(expected);
        }
    }
}
