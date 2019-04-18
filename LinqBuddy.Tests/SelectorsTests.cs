using FluentAssertions;
using FluentAssertions.Execution;

namespace Kladzey.LinqBuddy.Tests
{
    public class SelectorsTests
    {
        public void PropertyTest()
        {
            // When
            var result = Selectors.Property<string, int>("Length");

            // Then
            using (new AssertionScope())
            {
                result.Should().Equal(x => x.Length);
                result.Call("123").Should().Be(3);
            }
        }
    }
}
