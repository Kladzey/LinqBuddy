using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentAssertions;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class SelectorExtensionsTests
    {
        public static TheoryData<Expression<Func<int, string>>> ToPredicatesDictionaryShouldThrowInvalidOPerationExceptionOnWrongExpressionStructureTestCases =>
            new TheoryData<Expression<Func<int, string>>>
            {
                i => i.ToString(),
                i => i == 0 ? "zero" : i > 0 ? "positive" : "negative" + i.ToString(),
            };

        public static TheoryData<Expression<Func<int, string>>, Dictionary<string, Expression<Func<int, bool>>>> ToPredicatesDictionaryTestCases =>
            new TheoryData<Expression<Func<int, string>>, Dictionary<string, Expression<Func<int, bool>>>>
            {
                {
                    i => i == 0 ? "zero" : i > 0 ? "positive" : "negative",
                    new Dictionary<string, Expression<Func<int, bool>>>
                    {
                        { "zero", i => i == 0 },
                        { "positive", i => !(i == 0) && (i > 0) },
                        { "negative", i => !(i == 0) && !(i > 0) },
                    }
                },
                {
                    i => "only one",
                    new Dictionary<string, Expression<Func<int, bool>>>
                    {
                        { "only one", x => true },
                    }
                },
            };

        [Theory]
        [MemberData(nameof(ToPredicatesDictionaryShouldThrowInvalidOPerationExceptionOnWrongExpressionStructureTestCases))]
        public void ToPredicatesDictionaryShouldThrowInvalidOPerationExceptionOnWrongExpressionStructureTest(Expression<Func<int, string>> expression)
        {
            var act = expression.Invoking(e => e.ToPredicatesDictionary());
            act.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("The expression should be tree of conditions with constants as leafs.");
        }

        [Theory]
        [MemberData(nameof(ToPredicatesDictionaryTestCases))]
        public void ToPredicatesDictionaryTest(Expression<Func<int, string>> expression, Dictionary<string, Expression<Func<int, bool>>> expected)
        {
            var result = expression.ToPredicatesDictionary();
            result.Should().BeEquivalentTo(expected);
        }
    }
}
