using System;
using System.Collections.Generic;
using Kladzey.LinqBuddy.Adapters;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// Enumerator extensions.
    /// </summary>
    public static class EnumeratorExtensions
    {
        /// <summary>
        /// Create <see cref="IEnumerable{T}"/> wrapper for <see cref="IEnumerator{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="enumerator">The enumerator to wrap.</param>
        /// <returns><see cref="EnumerableAdapter{T}"/>.</returns>
        public static EnumerableAdapter<T> AsEnumerable<T>(this IEnumerator<T> enumerator)
        {
            if (enumerator == null)
            {
                throw new ArgumentNullException(nameof(enumerator));
            }

            return enumerator.AsEnumerableInternal();
        }

        internal static EnumerableAdapter<T> AsEnumerableInternal<T>(this IEnumerator<T> enumerator)
        {
            return new EnumerableAdapter<T>(enumerator);
        }
    }
}
