using System.Linq.Expressions;
using Kladzey.LinqBuddy.Visitors;

namespace Kladzey.LinqBuddy
{
    public static partial class LambdaExpressionExtensions
    {
        public static Expression<TDelegate> InlineCalls<TDelegate>(this Expression<TDelegate> expression)
        {
            return Expression.Lambda<TDelegate>(InlineCallsVisitor.Instance.Visit(expression.Body), expression.Parameters);
        }
    }
}
