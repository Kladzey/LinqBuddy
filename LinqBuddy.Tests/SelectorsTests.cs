using System;
using System.Reflection;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Kladzey.LinqBuddy.Tests
{
    public class SelectorsTests
    {
        [Fact]
        public void PropertyByPropertNameSHouldThrowExceptionIfNameIsWrongTest()
        {
            // When
            Action act = () => Selectors.Property<string, int>("qwe");

            // Then
            act.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Property \"qwe\" is not found in type \"System.String\".");
        }

        [Fact]
        public void PropertyByPropertyInfoTest()
        {
            // Given
            var propertyInfo = typeof(string).GetRuntimeProperty("Length");

            // When
            var result = Selectors.Property<string, int>(propertyInfo);

            // Then
            using (new AssertionScope())
            {
                result.Should().Equal(x => x.Length);
                result.Call("123").Should().Be(3);
            }
        }

        [Fact]
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
