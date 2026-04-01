using NuggetMod.Helper;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Helper;

/// <summary>
/// Tests for the SafeEventRegistration class
/// </summary>
public class SafeEventRegistrationTests
{
    [Fact]
    public void SafeEventRegistration_Type_ShouldExist()
    {
        // Arrange & Act
        var type = typeof(SafeEventRegistration);

        // Assert
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
    }

    [Fact]
    public void SafeEventRegistration_ShouldHaveRegisterMethod()
    {
        // Arrange
        var type = typeof(SafeEventRegistration);
        var methods = type.GetMethods();

        // Assert
        methods.Should().Contain(m => m.Name == "Register");
    }

    [Fact]
    public void SafeEventRegistration_ShouldHaveEventMethods()
    {
        // Arrange
        var type = typeof(SafeEventRegistration);
        var methods = type.GetMethods();

        // Assert - verify at least some event methods exist
        methods.Should().Contain(m => m.Name.Contains("Register") || m.Name.Contains("Event"));
    }

    [Fact]
    public void SafeEventRegistration_ShouldExist()
    {
        // Arrange & Act
        var type = typeof(SafeEventRegistration);

        // Assert
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
    }
}
