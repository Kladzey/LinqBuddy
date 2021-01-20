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
            var expressionAttribute = node.Member
                .GetCustomAttributes()
                .OfType<IExpressionProvider>()
                .FirstOrDefault();
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

            var expressionAttribute = node.Method
                .GetCustomAttributes()
                .OfType<IExpressionProvider>()
                .FirstOrDefault();
            if (expressionAttribute != null)
            {
                return VisitCallAttribute(node, expressionAttribute);
            }

            return base.VisitMethodCall(node);
        }

        private Expression VisitCallAttribute(MemberExpression node, IExpressionProvider expressionProvider)
        {
            return VisitCallExpressionAttribute(expressionProvider, node.Member, new[] { node.Expression });
        }

        private Expression VisitCallAttribute(MethodCallExpression node, IExpressionProvider expressionProvider)
        {
            return VisitCallExpressionAttribute(expressionProvider, node.Method, node.Arguments.Prepend(node.Object));
        }

        private Expression VisitCallExpressionAttribute(IExpressionProvider expressionProvider, MemberInfo memberInfo, IEnumerable<Expression> arguments)
        {
            var expression = expressionProvider.GetExpression(memberInfo);
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
                case MemberExpression {Member: FieldInfo fieldInfo, Expression: ConstantExpression constantExpression}:
                    calledExpression = (LambdaExpression)fieldInfo.GetValue(constantExpression.Value);
                    break;

                // static field
                case MemberExpression {Member: FieldInfo fieldInfo, Expression: null}:
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