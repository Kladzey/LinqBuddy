using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kladzey.LinqBuddy.Visitors;

namespace Kladzey.LinqBuddy
{
    public static class ExpressionExtensions
    {
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
    }
}
