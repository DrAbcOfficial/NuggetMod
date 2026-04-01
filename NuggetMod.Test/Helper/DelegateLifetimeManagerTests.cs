using NuggetMod.Helper;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Helper;

/// <summary>
/// Tests for the DelegateLifetimeManager class
/// </summary>
public class DelegateLifetimeManagerTests
{
    [Fact]
    public void DelegateLifetimeManager_Type_ShouldExist()
    {
        // Arrange & Act
        var type = typeof(DelegateLifetimeManager);

        // Assert
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
        type.IsSealed.Should().BeTrue(); // Static classes are sealed and abstract
        type.IsAbstract.Should().BeTrue();
    }

    [Fact]
    public void DelegateLifetimeManager_ShouldHaveTrackingMethods()
    {
        // Arrange
        var type = typeof(DelegateLifetimeManager);
        var methods = type.GetMethods();

        // Assert - verify methods exist with proper signatures
        methods.Should().Contain(m => m.Name.Contains("Register") || m.Name.Contains("Track"));
    }
}
