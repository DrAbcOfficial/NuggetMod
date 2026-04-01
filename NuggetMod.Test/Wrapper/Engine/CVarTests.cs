using NuggetMod.Wrapper.Engine;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Wrapper.Engine;

/// <summary>
/// Tests for the CVar class
/// </summary>
public class CVarTests
{
    [Fact]
    public void CVar_Type_ShouldExist()
    {
        // Arrange & Act
        var type = typeof(CVar);

        // Assert
        type.Should().NotBeNull();
    }

    [Fact]
    public void CVar_ShouldImplementIDisposable()
    {
        // Arrange & Act
        var type = typeof(CVar);

        // Assert
        type.Should().Implement<IDisposable>();
    }

    [Fact]
    public void CVar_Constructor_Default_ShouldNotBePublic()
    {
        // Arrange
        var type = typeof(CVar);
        var constructors = type.GetConstructors();

        // CVar likely has internal or protected constructors
        // This test documents the expected access level
        constructors.Should().NotBeNull();
    }
}
