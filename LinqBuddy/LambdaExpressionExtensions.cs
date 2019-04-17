using System.Linq.Expressions;
using Kladzey.LinqBuddy.Visitors;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// Lambda expressions extensions.
    /// </summary>
    public static partial class LambdaExpressionExtensions
    {
        /// <summary>
        /// Inline expressions calls.
        /// </summary>
        /// <typeparam name="TDelegate">The type of lambda expression delegate.</typeparam>
        /// <param name="expression">Expression where calls should be inlined.</param>
        /// <returns>Expression with inlined calls.</returns>
        public static Expression<TDelegate> InlineCalls<TDelegate>(this Expression<TDelegate> expression)
        {
            if (expression == null)
            {
                throw new System.ArgumentNullException(nameof(expression));
            }

            return (Expression<TDelegate>)InlineCallsVisitor.Instance.Visit(expression);
        }
    }
}
