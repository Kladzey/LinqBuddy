using System.Linq.Expressions;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// Constant expressions.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// False constant expression.
        /// </summary>
        public static readonly ConstantExpression False = Expression.Constant(false, typeof(bool));

        /// <summary>
        /// Null constant expression.
        /// </summary>
        public static readonly ConstantExpression Null = Expression.Constant(null, typeof(object));

        /// <summary>
        /// True constant expression.
        /// </summary>
        public static readonly ConstantExpression True = Expression.Constant(true, typeof(bool));

        /// <summary>
        /// Get constant expression with default value for type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Constant expression with default value.</returns>
        public static ConstantExpression Default<T>()
        {
            return ConstantsInstances<T>.Default;
        }

        private static class ConstantsInstances<T>
        {
            public static readonly ConstantExpression Default = Expression.Constant(default(T), typeof(T));
        }
    }
}
