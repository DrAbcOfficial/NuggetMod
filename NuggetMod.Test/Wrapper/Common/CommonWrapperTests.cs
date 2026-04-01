using NuggetMod.Wrapper.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Wrapper.Common;

/// <summary>
/// Tests for common wrapper classes
/// </summary>
public class CommonWrapperTests
{
    [Theory]
    [InlineData(typeof(ClientData))]
    [InlineData(typeof(EntityState))]
    [InlineData(typeof(WeaponData))]
    [InlineData(typeof(UserCmd))]
    public void WrapperTypes_ShouldExist(System.Type type)
    {
        // Assert
        type.Should().NotBeNull();
    }

    [Theory]
    [InlineData(typeof(ClientData))]
    [InlineData(typeof(EntityState))]
    [InlineData(typeof(WeaponData))]
    [InlineData(typeof(UserCmd))]
    public void WrapperTypes_ShouldImplementIDisposable(System.Type type)
    {
        // Assert
        type.Should().Implement<IDisposable>();
    }

    [Fact]
    public void EntityState_ShouldBeConstructible()
    {
        // Act
        var entityState = new EntityState();

        // Assert
        entityState.Should().NotBeNull();
        entityState.IsValid().Should().BeTrue();

        // Cleanup
        entityState.Dispose();
    }


}
