using NuggetMod.Helper;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Helper;

/// <summary>
/// Tests for the SafeDelegateHandle class
/// </summary>
public class SafeDelegateHandleTests
{
    [Fact]
    public void SafeDelegateHandle_Type_ShouldExist()
    {
        // Arrange & Act
        var type = typeof(SafeDelegateHandle);

        // Assert
        type.Should().NotBeNull();
    }

    [Fact]
    public void SafeDelegateHandle_Type_ShouldBeAccessible()
    {
        // Arrange & Act
        var type = typeof(SafeDelegateHandle);

        // Assert - verify the type exists and is properly defined
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
    }

    [Fact]
    public void SafeDelegateHandle_Constructor_ShouldBeInternal()
    {
        // Arrange
        var type = typeof(SafeDelegateHandle);
        var constructors = type.GetConstructors();

        // Assert - constructor should be internal
        constructors.Should().BeEmpty(); // No public constructors
    }
}
