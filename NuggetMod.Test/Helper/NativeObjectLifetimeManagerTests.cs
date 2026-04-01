using NuggetMod.Helper;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Helper;

/// <summary>
/// Tests for the NativeObjectLifetimeManager class
/// </summary>
public class NativeObjectLifetimeManagerTests
{
    [Fact]
    public void NativeObjectLifetimeManager_Type_ShouldExist()
    {
        // Arrange & Act
        var type = typeof(NativeObjectLifetimeManager);

        // Assert
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
        type.IsSealed.Should().BeTrue();
        type.IsAbstract.Should().BeTrue();
    }

    [Fact]
    public void NativeObjectLifetimeManager_ShouldHaveManagementMethods()
    {
        // Arrange
        var type = typeof(NativeObjectLifetimeManager);
        var methods = type.GetMethods();

        // Assert - verify at least some management methods exist
        methods.Should().Contain(m => m.Name.Contains("KeepAlive") || m.Name.Contains("Register"));
    }
}
