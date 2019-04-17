using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// Extensions for collections of expressions.
    /// </summary>
    public static class ExpressionsCollectionExtensions
    {
        /// <summary>
        /// Aggregate expressions.
        /// </summary>
        /// <param name="expressions">A sequence that contains expressions to be aggregated.</param>
        /// <param name="aggregateSelector">Selector what combines two expressions in one.</param>
        /// <returns>Aggregated expression.</returns>
        public static Expression Aggregate(this IEnumerable<Expression> expressions, Func<Expression, Expression, Expression> aggregateSelector)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException(nameof(expressions));
            }

            if (aggregateSelector == null)
            {
                throw new ArgumentNullException(nameof(aggregateSelector));
            }

            var stack = new Stack<Expression>();
            using (var enumerator = expressions.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new ArgumentException("Expressions is empty", nameof(expressions));
                }

                var first = enumerator.Current;
                stack.Push(first);
                var count = 1;
                while (enumerator.MoveNext())
                {
                    ++count;
                    stack.Push(enumerator.Current);

                    var countZeroBits = CountZeroBits(count);
                    for (var i = 0; i < countZeroBits; ++i)
                    {
                        AggregateLastTwo();
                    }
                }

                while (stack.Count > 1)
                {
                    AggregateLastTwo();
                }

                return stack.Pop();
            }

            void AggregateLastTwo()
            {
                var current = stack.Pop();
                var previous = stack.Pop();
                stack.Push(aggregateSelector(previous, current));
            }
        }

        private static int CountZeroBits(int number)
        {
            var result = 0;
            while ((number & 1) == 0)
            {
                number >>= 1;
                ++result;
            }

            return result;
        }
    }
}
