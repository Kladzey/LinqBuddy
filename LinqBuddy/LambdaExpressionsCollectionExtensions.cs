using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// Extensions for collections of lambda expressions.
    /// </summary>
    public static class LambdaExpressionsCollectionExtensions
    {
        /// <summary>
        /// Select bodies of expressions with parameters replacement to one set.
        /// </summary>
        /// <typeparam name="TDelegate">Type of delegate.</typeparam>
        /// <param name="expressions">Sequence of expressions.</param>
        /// <returns>Bodies of expressions with parameters replacement to one set.</returns>
        public static IEnumerable<Expression> SelectBodiesWithUnitedParameters<TDelegate>(this IEnumerable<Expression<TDelegate>> expressions)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException(nameof(expressions));
            }

            return expressions.SelectBodiesWithUnitedParametersInternal();
        }

        internal static IEnumerable<Expression> SelectBodiesWithUnitedParametersInternal<TDelegate>(this IEnumerable<Expression<TDelegate>> expressions)
        {
            using var enumerator = expressions.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                yield break;
            }

            var firstItem = enumerator.Current.ArgumentItemCannotBeNull(nameof(expressions));
            var firstParameters = firstItem.Parameters;
            yield return firstItem.Body;
                
            while (enumerator.MoveNext())
            {
                var currentItem = enumerator.Current.ArgumentItemCannotBeNull(nameof(expressions));
                yield return currentItem.Body.ReplaceParameters(currentItem.Parameters, firstParameters);
            }
        }
    }
}
