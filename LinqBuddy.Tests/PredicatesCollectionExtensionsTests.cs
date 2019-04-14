using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class PredicatesCollectionExtensionsTests
    {
        public static TheoryData<IEnumerable<Expression<Func<int, bool>>>, Expression<Func<int, bool>>> AndTestCases =>
            new TheoryData<IEnumerable<Expression<Func<int, bool>>>, Expression<Func<int, bool>>>
            {
                {
                    Enumerable.Empty<Expression<Func<int, bool>>>(),
                    x => true
                },
                {
                    new Expression<Func<int, bool>>[]
                    {
                        x => x != 1,
                    },
                    x => x != 1
                },
                {
                    new Expression<Func<int, bool>>[]
                    {
                        x => x != 1,
                        y => y != 2,
                    },
                    x => x != 1 && x != 2
                },
                {
                    new Expression<Func<int, bool>>[]
                    {
                        x => x != 1,
                        y => y != 2,
                        z => z != 3,
                    },
                    x => x != 1 && x != 2 && x != 3
                },
                {
                    new Expression<Func<int, bool>>[]
                    {
                        x => x != 1,
                        y => y != 2,
                        z => z != 3,
                        u => u != 4,
                    },
                    x => x != 1 && x != 2 && (x != 3 && x != 4)
                },
                {
                    new Expression<Func<int, bool>>[]
                    {
                        x => x != 1,
                        y => y != 2,
                        z => z != 3,
                        u => u != 4,
                        v => v != 5,
                    },
                    x => x != 1 && x != 2 && (x != 3 && x != 4) && x != 5
                },
            };

        public static TheoryData<IEnumerable<Expression<Func<int, bool>>>, Expression<Func<int, bool>>> OrTestCases =>
            new TheoryData<IEnumerable<Expression<Func<int, bool>>>, Expression<Func<int, bool>>>
            {
                {
                    Enumerable.Empty<Expression<Func<int, bool>>>(),
                    x => false
                },
                {
                    new Expression<Func<int, bool>>[]
                    {
                        x => x == 1,
                    },
                    x => x == 1
                },
                {
                    new Expression<Func<int, bool>>[]
                    {
                        x => x == 1,
                        y => y == 2,
                    },
                    x => x == 1 || x == 2
                },
                {
                    new Expression<Func<int, bool>>[]
                    {
                        x => x == 1,
                        y => y == 2,
                        z => z == 3,
                    },
                    x => x == 1 || x == 2 || x == 3
                },
                {
                    new Expression<Func<int, bool>>[]
                    {
                        x => x == 1,
                        y => y == 2,
                        z => z == 3,
                        u => u == 4,
                    },
                    x => x == 1 || x == 2 || (x == 3 || x == 4)
                },
                {
                    new Expression<Func<int, bool>>[]
                    {
                        x => x == 1,
                        y => y == 2,
                        z => z == 3,
                        u => u == 4,
                        v => v == 5,
                    },
                    x => x == 1 || x == 2 || (x == 3 || x == 4) || x == 5
                },
            };

        [Theory]
        [MemberData(nameof(AndTestCases))]
        public void AndTest(
            IEnumerable<Expression<Func<int, bool>>> predicates,
            Expression<Func<int, bool>> expected)
        {
            // When
            var result = predicates.And();

            // Then
            result.Should().Equal(expected);
        }

        [Theory]
        [MemberData(nameof(OrTestCases))]
        public void OrTest(
            IEnumerable<Expression<Func<int, bool>>> predicates,
            Expression<Func<int, bool>> expected)
        {
            // When
            var result = predicates.Or();

            // Then
            result.Should().Equal(expected);
        }
    }
}
