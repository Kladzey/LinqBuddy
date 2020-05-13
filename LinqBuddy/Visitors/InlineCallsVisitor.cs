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
            var expressionAttribute = node.Member.GetCustomAttribute<CallExpressionAttribute>();
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

            var expressionAttribute = node.Method.GetCustomAttribute<CallExpressionAttribute>();
            if (expressionAttribute != null)
            {
                return VisitCallAttribute(node, expressionAttribute);
            }

            return base.VisitMethodCall(node);
        }

        private Expression VisitCallAttribute(MemberExpression node, CallExpressionAttribute callExpressionAttribute)
        {
            return VisitCallExpressionAttribute(callExpressionAttribute, node.Member, new[] { node.Expression });
        }

        private Expression VisitCallAttribute(MethodCallExpression node, CallExpressionAttribute callExpressionAttribute)
        {
            return VisitCallExpressionAttribute(callExpressionAttribute, node.Method, node.Arguments.Prepend(node.Object));
        }

        private Expression VisitCallExpressionAttribute(CallExpressionAttribute callExpressionAttribute, MemberInfo memberInfo, IEnumerable<Expression> arguments)
        {
            var expression = callExpressionAttribute.GetExpression(memberInfo);
            if (expression == null)
            {
                throw new InvalidOperationException("Expression is not found.");
            }

            return Visit(expression.Body.ReplaceParameters(expression.Parameters, arguments));
        }

        private Expression VisitExpressionCall(MethodCallExpression node)
        {
            LambdaExpression calledExpression;
            switch (node.Arguments[0])
            {
                // variable
                case MemberExpression memberExpression
                    when memberExpression.Member is FieldInfo fieldInfo && memberExpression.Expression is ConstantExpression constantExpression:
                    calledExpression = (LambdaExpression)fieldInfo.GetValue(constantExpression.Value);
                    break;

                // static field
                case MemberExpression memberExpression
                    when memberExpression.Member is FieldInfo fieldInfo && memberExpression.Expression is null:
                    calledExpression = (LambdaExpression)fieldInfo.GetValue(null);
                    break;

                default:
                    calledExpression = Expression.Lambda<Func<LambdaExpression>>(node.Arguments[0]).Compile().Invoke();
                    break;
            }

            return Visit(calledExpression.Body.ReplaceParameters(calledExpression.Parameters, node.Arguments.Skip(1)));
        }
    }
}