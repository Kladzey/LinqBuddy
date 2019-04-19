using System;
using System.Collections.Generic;
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

        private Expression VisitCallAttribute(MemberExpression node, CallAttribute expressionAttribute)
        {
            return VisitCallAttribute(expressionAttribute, node.Member.DeclaringType, new[] { node.Expression });
        }

        private Expression VisitCallAttribute(MethodCallExpression node, CallAttribute expressionAttribute)
        {
            return VisitCallAttribute(expressionAttribute, node.Method.DeclaringType, node.Arguments.Prepend(node.Object));
        }

        private Expression VisitCallAttribute(CallAttribute callAttribute, Type declaringType, IEnumerable<Expression> arguments)
        {
            var expression = callAttribute.GetExpression(declaringType);
            if (expression == null)
            {
                throw new InvalidOperationException("Expression is not found.");
            }

            var newExpressions = expression.Parameters.ZipToDictionary(arguments);

            if (expression.Parameters.Count != newExpressions.Count)
            {
                throw new InvalidOperationException("Expression has invalid amount of parameters.");
            }

            return Visit(expression.Body.ReplaceParameters(newExpressions));
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
