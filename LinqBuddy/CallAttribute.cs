using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// Put this attribute on member if you want to replace it with expression.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class CallAttribute : Attribute
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="memberName">Name of member with expression. It should be public static filed or property.</param>
        /// <param name="type">Specify type if member is not in declaring type.</param>
        public CallAttribute(string memberName, Type type = null)
        {
            MemberName = memberName;
            Type = type;
        }

        /// <summary>
        /// Name of member with expression.
        /// </summary>
        public string MemberName { get; }

        /// <summary>
        /// Type what contains member.
        /// </summary>
        public Type Type { get;  }

        /// <summary>
        /// Get expression.
        /// </summary>
        /// <param name="declaringType">Declaring type.</param>
        /// <returns>Lambda expression. <code>null</code> if expression is not found.</returns>
        public LambdaExpression GetExpression(Type declaringType)
        {
            var type = Type ?? declaringType;
            var typeInfo = type.GetTypeInfo();
            var fieldInfo = typeInfo.GetField(MemberName, BindingFlags.Public | BindingFlags.Static);
            if (fieldInfo != null)
            {
                return (LambdaExpression)fieldInfo.GetValue(null);
            }
            var propertyInfo = typeInfo.GetProperty(MemberName, BindingFlags.Public | BindingFlags.Static);
            if (propertyInfo != null)
            {
                return (LambdaExpression)propertyInfo.GetValue(null);
            }
            return null;
        }
    }
}
