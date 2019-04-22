using System;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class LambdaExpressionsCollectionExtensionsTests
    {
        [Fact]
        public void SelectBodiesWithUnitedParametersTest()
        {
            var expressions = new Expression<Func<string, int>>[]
            {
                x => x.Length,
                y => y.Length + 1,
                z => 2,
            };
            var parameters = expressions[0].Parameters;

            var result = expressions.SelectBodiesWithUnitedParameters().ToList();

            result
                .Select(e => Expression.Lambda<Func<string, int>>(e, parameters).Call("test"))
                .Should()
                .Equal(4, 5, 2);
        }
    }
}
