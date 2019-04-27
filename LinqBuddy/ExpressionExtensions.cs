using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kladzey.LinqBuddy.Visitors;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// General expression extensions.
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Inline expressions calls.
        /// </summary>
        /// <param name="expression">Expression where calls should be inlined.</param>
        /// <returns>Expression with inlined calls.</returns>
        public static Expression InlineCalls(this Expression expression)
        {
            return InlineCallsVisitor.Instance.Visit(expression);
        }

        /// <summary>
        /// Replace parameter <paramref name="oldExpression"/> by <paramref name="newExpression"/>.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="oldExpression">The parameter to be replaced.</param>
        /// <param name="newExpression">The expression to replace all occurrences of <paramref name="oldExpression"/>.</param>
        /// <returns>New expression with applied replacement.</returns>
        public static Expression ReplaceParameter(
            this Expression expression,
            ParameterExpression oldExpression,
            Expression newExpression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (oldExpression == null)
            {
                throw new ArgumentNullException(nameof(oldExpression));
            }

            if (newExpression == null)
            {
                throw new ArgumentNullException(nameof(newExpression));
            }

            var visitor = new ReplaceParameterVisitor(oldExpression, newExpression);
            return visitor.Visit(expression);
        }

        /// <summary>
        /// Replace multiple parameters by items in <paramref name="newExpressions"/>.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="newExpressions">The dictionary with replacements.</param>
        /// <returns>New expression with applied replacement.</returns>
        public static Expression ReplaceParameters(
            this Expression expression,
            IReadOnlyDictionary<ParameterExpression, Expression> newExpressions)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (newExpressions == null)
            {
                throw new ArgumentNullException(nameof(newExpressions));
            }

            var visitor = new ReplaceParametersVisitor(newExpressions);
            return visitor.Visit(expression);
        }

        /// <summary>
        /// Replace multiple parameters by items in <paramref name="newExpressions"/>.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="parameters"></param>
        /// <param name="replacements"></param>
        /// <returns>New expression with applied replacement.</returns>
        public static Expression ReplaceParameters(
            this Expression expression,
            IEnumerable<ParameterExpression> parameters,
            IEnumerable<Expression> replacements)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (replacements == null)
            {
                throw new ArgumentNullException(nameof(replacements));
            }

            var newExpressions = new Dictionary<ParameterExpression, Expression>();
            using (var parametersEnumerator = parameters.GetEnumerator())
            using (var replacementsEnumerator = replacements.GetEnumerator())
            {
                var parametersMoveNext = parametersEnumerator.MoveNext();
                var replacementsMoveNext = replacementsEnumerator.MoveNext();
                while (parametersMoveNext && replacementsMoveNext)
                {
                    newExpressions.Add(parametersEnumerator.Current, replacementsEnumerator.Current);
                    parametersMoveNext = parametersEnumerator.MoveNext();
                    replacementsMoveNext = replacementsEnumerator.MoveNext();
                }
                if (parametersMoveNext != replacementsMoveNext)
                {
                    throw new InvalidOperationException("The number of replacements is not equal to the number of parameters.");
                }
            }

            return new ReplaceParametersVisitor(newExpressions).Visit(expression);
        }
    }
}
