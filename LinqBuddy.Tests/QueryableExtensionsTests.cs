using System;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class QueryableExtensionsTests
    {
        [Fact]
        public void InlineCallsTest()
        {
            // Given
            Expression<Func<int, bool>> startPredicate = i => i >= 2;
            Expression<Func<int, bool>> finishPredicate = j => j <= 4;
            var query = Enumerable
                .Range(1, 10)
                .AsQueryable()
                .Where(k => startPredicate.Call(k) && finishPredicate.Call(k));

            // When
            var result = query.InlineCalls();

            // Then
            using (new AssertionScope())
            {
                result
                    .Should()
                    .Equal(
                        Enumerable
                            .Range(1, 10)
                            .AsQueryable()
                            .Where(k => k >= 2 && k <= 4));

                result.AsEnumerable().Should().BeEquivalentTo(2, 3, 4);
            }
        }
    }
}
