using System;
using System.Linq.Expressions;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class PredicateExtensionsTests
    {
        public static TheoryData<Expression<Func<int, bool>>, Expression<Func<int, bool>>, Expression<Func<int, bool>>> AndTestCases =>
            new TheoryData<Expression<Func<int, bool>>, Expression<Func<int, bool>>, Expression<Func<int, bool>>>
            {
                {
                    x => x != 1,
                    y => y != 2,
                    x => x != 1 && x != 2
                },
            };

        public static TheoryData<Expression<Func<int, bool>>, Expression<Func<int, bool>>> NotTestCases =>
            new TheoryData<Expression<Func<int, bool>>, Expression<Func<int, bool>>>
            {
                {
                    x => x == 1,
                    x => !(x == 1)
                },
            };

        public static TheoryData<Expression<Func<int, bool>>, Expression<Func<int, bool>>, Expression<Func<int, bool>>> OrTestCases =>
            new TheoryData<Expression<Func<int, bool>>, Expression<Func<int, bool>>, Expression<Func<int, bool>>>
            {
                {
                    x => x == 1,
                    y => y == 2,
                    x => x == 1 || x == 2
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

        [Theory]
        [MemberData(nameof(NotTestCases))]
        public void NotTest(Expression<Func<int, bool>> predicate, Expression<Func<int, bool>> expected)
        {
            var result = predicate.Not();
            result.Should().Equal(expected);
        }

        [Theory]
        [MemberData(nameof(OrTestCases))]
        public void OrTest(Expression<Func<int, bool>> left, Expression<Func<int, bool>> right,
            Expression<Func<int, bool>> expected)
        {
            var result = left.Or(right);
            result.Should().Equal(expected);
        }
    }
}