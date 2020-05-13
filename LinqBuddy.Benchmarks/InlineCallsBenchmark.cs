using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BenchmarkDotNet.Attributes;
using Kladzey.LinqBuddy;

namespace LinqBuddy.Benchmarks
{
    public class InlineCallsBenchmark
    {
        public InlineCallsBenchmark()
        {
        }

        [ParamsSource(nameof(ExpressionValues))]
        public Expression<Func<double, double, double, double, double>> Expression { get; set; }

        public IEnumerable<Expression<Func<double, double, double, double, double>>> ExpressionValues
        {
            get
            {
                Expression<Func<double, double>> sqr = x => x * x;
                Expression<Func<double, double, double>> length = (x, y) => Math.Sqrt(sqr.Call(x) + sqr.Call(y));
                yield return (x1, y1, x2, y2) => length.Call(x2 - x1, y2 - y1);
            }
        }

        [Benchmark]
        public Expression<Func<double, double, double, double, double>> LinqBuddyInlineCalls()
        {
            return Expression.InlineCalls();
        }
    }
}