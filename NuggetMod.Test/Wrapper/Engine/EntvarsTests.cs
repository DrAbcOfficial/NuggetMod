using NuggetMod.Wrapper.Engine;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Wrapper.Engine;

/// <summary>
/// Tests for the Entvars class
/// </summary>
public class EntvarsTests
{
    [Fact]
    public void Entvars_Type_ShouldExist()
    {
        // Arrange & Act
        var type = typeof(Entvars);

        // Assert
        type.Should().NotBeNull();
    }

    [Fact]
    public void Entvars_ShouldBeConstructible()
    {
        // Act
        var entvars = new Entvars();

        // Assert
        entvars.Should().NotBeNull();
        entvars.IsValid().Should().BeTrue();

        // Cleanup
        entvars.Dispose();
    }

    [Fact]
    public void Entvars_ShouldImplementIDisposable()
    {
        // Arrange & Act
        var type = typeof(Entvars);

        // Assert
        type.Should().Implement<IDisposable>();
    }
}
