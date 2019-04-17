using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class EnumeratorExtensionsTests
    {
        [Fact]
        public void AsEnumerableResultShouldNotAllowEnumerationAfterDisposeTest()
        {
            // Given
            using (var enumerator = Enumerable.Range(0, 10).GetEnumerator())
            {
                // When
                var result = enumerator.AsEnumerable();
                result.Dispose();
                var act = result.Invoking(r => r.ToList());

                // Then
                act.Should()
                    .Throw<ObjectDisposedException>()
                    .WithMessage("This enumerator can be enumerated only once.");
            }
        }

        [Fact]
        public void AsEnumerableResultShouldNotAllowMultipleEnumerationsTest()
        {
            // Given
            using (var enumerator = Enumerable.Range(0, 10).GetEnumerator())
            {
                // When
                var result = enumerator.AsEnumerable();
                var listResult = result.ToList();
                var act = result.Invoking(r => r.ToList());

                // Then
                using (new AssertionScope())
                {
                    act.Should()
                        .Throw<ObjectDisposedException>()
                        .WithMessage("This enumerator can be enumerated only once.");
                    listResult.Should().BeEquivalentTo(Enumerable.Range(0, 10));
                }
            }
        }

        [Fact]
        public void AsEnumerableTest()
        {
            // Given
            using (var enumerator = Enumerable.Range(0, 10).GetEnumerator())
            {
                // When
                var result = enumerator.AsEnumerable();

                // Then
                result.Should().BeEquivalentTo(Enumerable.Range(0, 10));
            }
        }

        private static IEnumerable<T> ToEnumerable<T>(IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
}
