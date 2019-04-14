using System;
using System.Collections.Generic;
using System.Linq;

namespace Kladzey.LinqBuddy
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Perform action on sequence, if it's not empty.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence.</param>
        /// <param name="action">The action.</param>
        /// <returns>Returns <code>true</code> if the sequence is not empty.</returns>
        public static bool DoIfNotEmpty<TSource>(
            this IEnumerable<TSource> source,
            Action<IEnumerable<TSource>> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (source is IReadOnlyCollection<TSource> collection)
            {
                if (collection.Count == 0)
                {
                    return false;
                }
                action(collection);
                return true;
            }
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    using (var enumerableAdapter = enumerator.ToEnumerable())
                    {
                        action(enumerableAdapter.Prepend(enumerator.Current));
                    }

                    return true;
                }
            }
            return false;
        }
    }
}
