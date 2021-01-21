using System.Linq.Expressions;
using System.Reflection;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// Expression provider interface.
    /// </summary>
    public interface IExpressionProvider
    {
        /// <summary>
        /// Get expression.
        /// </summary>
        /// <param name="memberInfo">Member info.</param>
        /// <returns>Expression or <value>null</value> when expression is not found.</returns>
        LambdaExpression? GetExpression(MemberInfo memberInfo);
    }
}