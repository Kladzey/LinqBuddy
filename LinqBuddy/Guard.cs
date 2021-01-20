using System;

namespace Kladzey.LinqBuddy
{
    internal static class Guard
    {
        public static T ArgumentItemCannotBeNull<T>(this T item, string paramName )
        {
            return item ??
                   throw new ArgumentException(
                       "Value cannot contain null.",
                       paramName);
        }
    }
}