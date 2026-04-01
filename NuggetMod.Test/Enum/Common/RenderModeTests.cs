using NuggetMod.Enum.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Common;

/// <summary>
/// Tests for the RenderMode enumeration
/// </summary>
public class RenderModeTests
{
    [Theory]
    [InlineData(RenderMode.Normal, 0)]
    [InlineData(RenderMode.TransColor, 1)]
    [InlineData(RenderMode.TransTexture, 2)]
    [InlineData(RenderMode.Glow, 3)]
    [InlineData(RenderMode.TransAlpha, 4)]
    [InlineData(RenderMode.TransAdd, 5)]
    public void RenderMode_ShouldHaveCorrectIntegerValue(RenderMode mode, int expectedValue)
    {
        // Assert
        ((int)mode).Should().Be(expectedValue);
    }

    [Fact]
    public void RenderMode_Normal_ShouldBeDefault()
    {
        // Arrange & Act
        RenderMode defaultValue = default;

        // Assert
        defaultValue.Should().Be(RenderMode.Normal);
    }

    [Theory]
    [InlineData(RenderMode.Normal, true)]
    [InlineData(RenderMode.TransColor, true)]
    [InlineData(RenderMode.TransTexture, true)]
    [InlineData(RenderMode.Glow, true)]
    [InlineData(RenderMode.TransAlpha, true)]
    [InlineData(RenderMode.TransAdd, true)]
    public void RenderMode_AllValues_ShouldBeValid(RenderMode mode, bool expectedValid)
    {
        // Assert
        expectedValid.Should().BeTrue();
        System.Enum.IsDefined(mode).Should().BeTrue();
    }
}
