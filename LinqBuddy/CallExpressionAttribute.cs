using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Kladzey.LinqBuddy
{
    /// <summary>
    /// Put this attribute on member if you want to replace it with expression.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class CallExpressionAttribute : Attribute
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="memberName">Name of member with expression. It should be public static filed or property.</param>
        /// <param name="type">Specify type if member is not in declaring type.</param>
        public CallExpressionAttribute(string memberName = null, Type type = null)
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
        public Type Type { get; }

        internal LambdaExpression GetExpression(MemberInfo memberInfo)
        {
            var type = Type ?? memberInfo.DeclaringType;
            var memberName = MemberName ?? (memberInfo.Name + "Expression");

            var typeInfo = type.GetTypeInfo();
            var fieldInfo = typeInfo.GetField(memberName, BindingFlags.Public | BindingFlags.Static);
            if (fieldInfo != null)
            {
                return (LambdaExpression)fieldInfo.GetValue(null);
            }
            var propertyInfo = typeInfo.GetProperty(memberName, BindingFlags.Public | BindingFlags.Static);
            if (propertyInfo != null)
            {
                return (LambdaExpression)propertyInfo.GetValue(null);
            }
            return null;
        }
    }
}
