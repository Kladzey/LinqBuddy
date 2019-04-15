using System.Linq.Expressions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace Kladzey.LinqBuddy.Tests.TestUtils
{
    internal class ExpressionAssertions<TDelegate> : ReferenceTypeAssertions<Expression<TDelegate>, ExpressionAssertions<TDelegate>>
    {
        public ExpressionAssertions(Expression<TDelegate> subject)
        {
            Subject = subject;
        }

        protected override string Identifier => "expression";

        public AndConstraint<ExpressionAssertions<TDelegate>> Equal(Expression<TDelegate> expected, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => Subject)
                .ForCondition(s => s.ToString() == expected.ToString())
                .FailWith("Expected {context:expression} to equal {0}{reason}, but found {1}.", expected, Subject);

            return new AndConstraint<ExpressionAssertions<TDelegate>>(this);
        }
    }
}
