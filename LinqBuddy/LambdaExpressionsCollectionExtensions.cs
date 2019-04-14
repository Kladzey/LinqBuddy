using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kladzey.LinqBuddy
{
    public static class LambdaExpressionsCollectionExtensions
    {
        public static IEnumerable<Expression> SelectBodiesWithUnitedParameters<T1, TResult>(this IEnumerable<Expression<Func<T1, TResult>>> expressions)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException(nameof(expressions));
            }

            using (var enumerator = expressions.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    yield break;
                }

                var firstParameters = enumerator.Current.Parameters[0];
                yield return enumerator.Current.Body;
                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current.Body
                        .ReplaceParameter(enumerator.Current.Parameters[0], firstParameters);
                }
            }
        }
    }
}
