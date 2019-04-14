using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Kladzey.LinqBuddy
{
    public static class SelectorExtensions
    {
        /// <summary>
        /// Converts conditional tree expression to dictionary of predicates.
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="expression">The conditional tree expression.</param>
        /// <returns>The dictionary of predicates.</returns>
        public static IDictionary<TOutput, Expression<Func<TInput, bool>>> ToPredicatesDictionary<TInput, TOutput>(this Expression<Func<TInput, TOutput>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var result = new Dictionary<TOutput, Expression<Func<TInput, bool>>>();

            Visit(expression.Body, null);

            if (typeof(TOutput).GetTypeInfo().IsEnum)
            {
                var values = Enum
                    .GetValues(typeof(TOutput))
                    .Cast<TOutput>()
                    .Where(v => result.ContainsKey(v));
                foreach (var value in values)
                {
                    result.Add(value, Predicates.False<TInput>());
                }
            }

            return result;

            void Visit(Expression node, Expression predicate)
            {
                switch (node.NodeType)
                {
                    case ExpressionType.Conditional when node is ConditionalExpression conditionalExpression:
                        if (predicate != null)
                        {
                            Visit(conditionalExpression.IfTrue, Expression.AndAlso(predicate, conditionalExpression.Test));
                            Visit(conditionalExpression.IfFalse, Expression.AndAlso(predicate, Expression.Not(conditionalExpression.Test)));
                        }
                        else
                        {
                            Visit(conditionalExpression.IfTrue, conditionalExpression.Test);
                            Visit(conditionalExpression.IfFalse, Expression.Not(conditionalExpression.Test));
                        }
                        break;

                    case ExpressionType.Constant when node is ConstantExpression constantExpression && constantExpression.Value != null:
                        result.Add(
                            (TOutput)constantExpression.Value,
                            predicate != null ? Expression.Lambda<Func<TInput, bool>>(predicate, expression.Parameters) : Predicates.True<TInput>());
                        break;

                    default:
                        throw new InvalidOperationException("The expression should be tree of conditions with constants as leafs.");
                }
            }
        }
    }
}
