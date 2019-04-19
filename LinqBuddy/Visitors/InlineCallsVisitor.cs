using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Kladzey.LinqBuddy.Visitors
{
    internal class InlineCallsVisitor : ExpressionVisitor
    {
        public static readonly InlineCallsVisitor Instance = new InlineCallsVisitor();

        private InlineCallsVisitor()
        {
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            var expressionAttribute = node.Member.GetCustomAttribute<CallAttribute>();
            if (expressionAttribute != null)
            {
                return VisitCallAttribute(node, expressionAttribute);
            }

            return base.VisitMember(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == nameof(LambdaExpressionExtensions.Call) &&
                node.Method.DeclaringType == typeof(LambdaExpressionExtensions))
            {
                return VisitExpressionCall(node);
            }

            var expressionAttribute = node.Method.GetCustomAttribute<CallAttribute>();
            if (expressionAttribute != null)
            {
                return VisitCallAttribute(node, expressionAttribute);
            }

            return base.VisitMethodCall(node);
        }

        private Expression VisitCallAttribute(MemberExpression node,
            CallAttribute expressionAttribute)
        {
            var expression = expressionAttribute.GetExpression(node.Member.DeclaringType);
            if (expression == null)
            {
                throw new InvalidOperationException("Expression is not found.");
            }

            if (expression.Parameters.Count != 1)
            {
                throw new InvalidOperationException("Expression has invalid amount of parameters.");
            }

            return Visit(expression.Body.ReplaceParameter(expression.Parameters[0], node.Expression));
        }

        private Expression VisitCallAttribute(MethodCallExpression node, CallAttribute expressionAttribute)
        {
            var expression = expressionAttribute.GetExpression(node.Method.DeclaringType);
            if (expression == null)
            {
                throw new InvalidOperationException("Expression is not found.");
            }

            if (expression.Parameters.Count != node.Arguments.Count + 1)
            {
                throw new InvalidOperationException("Expression has invalid amount of parameters.");
            }

            return Visit(
                expression.Body.ReplaceParameters(
                    expression.Parameters.ZipToDictionary(node.Arguments.Prepend(node.Object))));
        }

        private Expression VisitExpressionCall(MethodCallExpression node)
        {
            LambdaExpression calledExpression;
            switch (node.Arguments[0])
            {
                case MemberExpression memberExpression
                    when memberExpression.Member is FieldInfo fieldInfo && memberExpression.Expression is ConstantExpression constantExpression:
                    calledExpression = (LambdaExpression)fieldInfo.GetValue(constantExpression.Value);
                    break;

                case MemberExpression memberExpression
                    when memberExpression.Member is FieldInfo fieldInfo && memberExpression.Expression is null:
                    calledExpression = (LambdaExpression)fieldInfo.GetValue(null);
                    break;

                default:
                    throw new NotSupportedException("Only captured fields are supported.");
            }

            var replacement = calledExpression.Parameters.ZipToDictionary(node.Arguments.Skip(1));
            return Visit(calledExpression.Body.ReplaceParameters(replacement));
        }
    }
}
