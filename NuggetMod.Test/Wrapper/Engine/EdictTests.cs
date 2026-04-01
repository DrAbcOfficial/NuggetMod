using NuggetMod.Wrapper.Engine;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Wrapper.Engine;

/// <summary>
/// Tests for the Edict class
/// </summary>
public class EdictTests
{
    [Fact]
    public void Edict_Type_ShouldExist()
    {
        // Arrange & Act
        var type = typeof(Edict);

        // Assert
        type.Should().NotBeNull();
    }

    [Fact]
    public void Edict_ShouldBeConstructible()
    {
        // Act
        var edict = new Edict();

        // Assert
        edict.Should().NotBeNull();
        edict.IsValid().Should().BeTrue();

        // Cleanup
        edict.Dispose();
    }

    [Fact]
    public void Edict_ShouldImplementIDisposable()
    {
        // Arrange & Act
        var type = typeof(Edict);

        // Assert
        type.Should().Implement<IDisposable>();
    }

    [Fact]
    public void Edict_Dispose_ShouldWork()
    {
        // Arrange
        var edict = new Edict();

        // Act
        edict.Dispose();

        // Assert
        edict.IsValid().Should().BeFalse();
    }
}
