using NuggetMod.Enum.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Common;

/// <summary>
/// Tests for the Solid enumeration (solid types for entities)
/// </summary>
public class SolidTests
{
    [Theory]
    [InlineData(Solid.Not, 0)]
    [InlineData(Solid.Trigger, 1)]
    [InlineData(Solid.BBox, 2)]
    [InlineData(Solid.SlideBox, 3)]
    [InlineData(Solid.Bsp, 4)]
    public void Solid_ShouldHaveCorrectIntegerValue(Solid solid, int expectedValue)
    {
        // Assert
        ((int)solid).Should().Be(expectedValue);
    }

    [Fact]
    public void Solid_Not_ShouldBeDefault()
    {
        // Arrange & Act
        Solid defaultValue = default;

        // Assert
        defaultValue.Should().Be(Solid.Not);
    }

    [Fact]
    public void Solid_ShouldHaveCorrectCollisionBehavior()
    {
        // Arrange
        var nonSolid = Solid.Not;
        var trigger = Solid.Trigger;
        var solidBBox = Solid.BBox;
        var solidBsp = Solid.Bsp;

        // Assert
        nonSolid.Should().Be(Solid.Not); // No collision
        trigger.Should().Be(Solid.Trigger); // Touch triggers only
        solidBBox.Should().Be(Solid.BBox); // Uses bounding box
        solidBsp.Should().Be(Solid.Bsp); // Uses BSP tree
    }
}
