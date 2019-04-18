using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// Selectors.
    /// </summary>
    public static class Selectors
    {
        /// <summary>
        /// Create selector of property.
        /// </summary>
        /// <typeparam name="T">Type of argument.</typeparam>
        /// <typeparam name="TResult">Type of property.</typeparam>
        /// <param name="propertyName">Property name.</param>
        /// <returns>Property selector.</returns>
        public static Expression<Func<T, TResult>> Property<T, TResult>(string propertyName)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            var propertyInfo = typeof(T).GetRuntimeProperty(propertyName);
            if (propertyInfo == null)
            {
                throw new InvalidOperationException($"Property \"{propertyName}\" is not found in type \"{typeof(T).FullName}\".");
            }
            return PropertyInternal<T, TResult>(propertyInfo);
        }

        /// <summary>
        /// Create selector of property.
        /// </summary>
        /// <typeparam name="T">Type of argument.</typeparam>
        /// <typeparam name="TResult">Type of property.</typeparam>
        /// <param name="propertyInfo">Property info.</param>
        /// <returns>Property selector.</returns>
        public static Expression<Func<T, TResult>> Property<T, TResult>(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            return PropertyInternal<T, TResult>(propertyInfo);
        }

        private static Expression<Func<T, TResult>> PropertyInternal<T, TResult>(PropertyInfo propertyInfo)
        {
            var parameter = Parameters.X<T>();
            var property = Expression.Property(parameter, propertyInfo);
            return Expression.Lambda<Func<T, TResult>>(property, parameter);
        }
    }
}
