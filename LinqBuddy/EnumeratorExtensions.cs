﻿using System;
using System.Collections;
using System.Collections.Generic;

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
            return new EnumerableAdapter<T>(enumerator ?? throw new ArgumentNullException(nameof(enumerator)));
        }

        /// <summary>
        /// <see cref="IEnumerable{T}"/> wrapper for <see cref="IEnumerator{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        public class EnumerableAdapter<T> : IEnumerable<T>, IDisposable
        {
            private readonly IEnumerator<T> _enumerator;

            private bool _isDisposed;

            internal EnumerableAdapter(IEnumerator<T> enumerator)
            {
                _enumerator = enumerator;
            }

            public void Dispose()
            {
                _isDisposed = true;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new EnumeratorWrapper(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new EnumeratorWrapper(this);
            }

            private struct EnumeratorWrapper : IEnumerator<T>
            {
                private readonly EnumerableAdapter<T> _enumerableAdapter;

                public EnumeratorWrapper(EnumerableAdapter<T> enumerableAdapter)
                {
                    _enumerableAdapter = enumerableAdapter;
                }

                public T Current => _enumerableAdapter._enumerator.Current;

                object IEnumerator.Current => ((IEnumerator)_enumerableAdapter._enumerator).Current;

                public void Dispose()
                {
                    _enumerableAdapter._isDisposed = true;
                }

                public bool MoveNext()
                {
                    if (_enumerableAdapter._isDisposed)
                    {
                        throw new ObjectDisposedException("This enumerator can be enumerated only once.", (Exception)null);
                    }

                    return _enumerableAdapter._enumerator.MoveNext();
                }

                public void Reset()
                {
                    throw new NotSupportedException();
                }
            }
        }
    }
}
