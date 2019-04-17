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

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == nameof(LambdaExpressionExtensions.Call) && node.Method.DeclaringType == typeof(LambdaExpressionExtensions))
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
            return base.VisitMethodCall(node);
        }
    }
}
