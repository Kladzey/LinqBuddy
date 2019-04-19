using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class EnumerableExtensionsTests
    {
        public static TheoryData<IEnumerable<int>> DoIfNotEmptyShouldReturnFalseTestCases =>
            new TheoryData<IEnumerable<int>> {
                Enumerable.Empty<int>(),
                Array.Empty<int>(),
            };

        [Fact]
        public void DoIfNotEmptyEnumerableShouldNotBeUsableOutsideActionTest()
        {
            // Given
            var source = Enumerable.Range(0, 5);

            // When
            var act = source.Invoking(s => {
                IEnumerable<int> resultList = null;
                s.DoIfNotEmpty(s2 => resultList = s2);
                var t = resultList.ToList();
            });

            // Then
            act.Should()
                .Throw<ObjectDisposedException>()
                .WithMessage("This enumerator can be enumerated only once.");
        }

        [Fact]
        public void DoIfNotEmptyForCollectionTest()
        {
            // Given
            var source = Enumerable.Range(0, 5).ToList();

            // When
            List<int> resultList = null;
            var result = source.DoIfNotEmpty(s => resultList = s.ToList());

            // Then
            using (new AssertionScope())
            {
                result.Should().BeTrue();
                resultList.Should().Equal(source);
            }
        }

        [Theory]
        [MemberData(nameof(DoIfNotEmptyShouldReturnFalseTestCases))]
        public void DoIfNotEmptyShouldReturnFalseTest(IEnumerable<int> source)
        {
            // When
            List<int> resultList = null;
            var result = source.DoIfNotEmpty(s => resultList = s.ToList());

            // Then
            using (new AssertionScope())
            {
                result.Should().BeFalse();
                resultList.Should().BeNull();
            }
        }

        [Fact]
        public void DoIfNotEmptyTest()
        {
            // Given
            var sourceData = Enumerable.Range(0, 5).ToList();

            var source = Mock.Of<IEnumerable<int>>(s => s.GetEnumerator() == ((IEnumerable<int>)sourceData).GetEnumerator());

            // When
            List<int> resultList = null;
            var result = source.DoIfNotEmpty(s => resultList = s.ToList());

            // Then
            using (new AssertionScope())
            {
                result.Should().BeTrue();
                resultList.Should().Equal(sourceData);
            }

            Mock.Get(source).Verify(s => s.GetEnumerator(), Times.Once);
        }
    }
}
