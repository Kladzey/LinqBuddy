using System.Linq.Expressions;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// Default parameters.
    /// </summary>
    public static class Parameters
    {
        /// <summary>
        /// X parameter.
        /// </summary>
        /// <typeparam name="T">Type of parameter.</typeparam>
        /// <returns><see cref="ParameterExpression"/>.</returns>
        public static ParameterExpression X<T>()
        {
            return ParametersInstances<T>.X;
        }

        /// <summary>
        /// Y parameter.
        /// </summary>
        /// <typeparam name="T">Type of parameter.</typeparam>
        /// <returns><see cref="ParameterExpression"/>.</returns>
        public static ParameterExpression Y<T>()
        {
            return ParametersInstances<T>.Y;
        }

        /// <summary>
        /// Z parameter.
        /// </summary>
        /// <typeparam name="T">Type of parameter.</typeparam>
        /// <returns><see cref="ParameterExpression"/>.</returns>
        public static ParameterExpression Z<T>()
        {
            return ParametersInstances<T>.Z;
        }

        private static class ParametersInstances<T>
        {
            public static readonly ParameterExpression X = Expression.Parameter(typeof(T), "x");

            public static readonly ParameterExpression Y = Expression.Parameter(typeof(T), "y");

            public static readonly ParameterExpression Z = Expression.Parameter(typeof(T), "z");
        }
    }
}
