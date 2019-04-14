using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kladzey.LinqBuddy.Visitors
{
    internal class ReplaceParametersVisitor : ExpressionVisitor
    {
        private readonly IReadOnlyDictionary<ParameterExpression, Expression> _newExpressions;

        public ReplaceParametersVisitor(IReadOnlyDictionary<ParameterExpression, Expression> newExpressions)
        {
            _newExpressions = newExpressions;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _newExpressions.TryGetValue(node, out var newExpression) ? newExpression : base.VisitParameter(node);
        }
    }
}
