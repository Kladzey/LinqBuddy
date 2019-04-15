using System.Linq;
using Kladzey.LinqBuddy.Visitors;

namespace Kladzey.LinqBuddy
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> InlineCalls<T>(this IQueryable<T> source)
        {
            return (IQueryable<T>)source.Provider.CreateQuery(InlineCallsVisitor.Instance.Visit(source.Expression));
        }
    }
}
