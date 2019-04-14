using System.Linq.Expressions;

namespace Kladzey.LinqBuddy.Visitors
{
    internal class ReplaceParameterVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _source;
        private readonly Expression _target;

        public ReplaceParameterVisitor(ParameterExpression source, Expression target)
        {
            _source = source;
            _target = target;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == _source ? _target : base.VisitParameter(node);
        }
    }
}
