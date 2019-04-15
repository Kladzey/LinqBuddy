using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace Kladzey.LinqBuddy.Tests.TestUtils
{
    internal class QueryableAssertions<T> : ReferenceTypeAssertions<IQueryable<T>, QueryableAssertions<T>>
    {
        public QueryableAssertions(IQueryable<T> subject)
        {
            Subject = subject;
        }

        protected override string Identifier => "query";

        public AndConstraint<QueryableAssertions<T>> Equal(IQueryable<T> expected, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => Subject)
                .ForCondition(s => s.Expression.ToString() == expected.Expression.ToString())
                .FailWith("Expected {context:query} to equal {0}{reason}, but found {1}.", expected.Expression, Subject.Expression);

            return new AndConstraint<QueryableAssertions<T>>(this);
        }
    }
}
