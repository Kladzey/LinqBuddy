using FluentAssertions;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class PredicatesTests
    {
        public static TheoryData<object> TrueFalseTestCases => new TheoryData<object>
        {
            null,
            0,
            1,
            -1,
            "",
            new{ },
        };

        [Theory]
        [MemberData(nameof(TrueFalseTestCases))]
        public void FalseTest(object x)
        {
            var predicate = Predicates.False<object>();
            predicate.Compile().Invoke(x).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(TrueFalseTestCases))]
        public void TrueTest(object x)
        {
            var predicate = Predicates.True<object>();
            predicate.Compile().Invoke(x).Should().BeTrue();
        }
    }
}
