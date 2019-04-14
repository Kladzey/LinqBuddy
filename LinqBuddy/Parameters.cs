using System.Linq.Expressions;

namespace Kladzey.LinqBuddy
{
    public static class Parameters
    {
        public static ParameterExpression X<T>()
        {
            return ParametersInstances<T>.X;
        }

        public static ParameterExpression Y<T>()
        {
            return ParametersInstances<T>.Y;
        }

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
