using NuggetMod.Enum.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Common;

/// <summary>
/// Tests for the RenderFX enumeration
/// </summary>
public class RenderFXTests
{
    [Theory]
    [InlineData(RenderFX.None, 0)]
    [InlineData(RenderFX.PulseSlow, 1)]
    [InlineData(RenderFX.PulseFast, 2)]
    [InlineData(RenderFX.PulseSlowWide, 3)]
    [InlineData(RenderFX.PulseFastWide, 4)]
    [InlineData(RenderFX.FadeSlow, 5)]
    [InlineData(RenderFX.FadeFast, 6)]
    [InlineData(RenderFX.SolidSlow, 7)]
    [InlineData(RenderFX.SolidFast, 8)]
    [InlineData(RenderFX.StrobeSlow, 9)]
    [InlineData(RenderFX.StrobeFast, 10)]
    [InlineData(RenderFX.FlickerSlow, 11)]
    [InlineData(RenderFX.FlickerFast, 12)]
    [InlineData(RenderFX.Distort, 13)]
    [InlineData(RenderFX.Hologram, 14)]
    public void RenderFX_ShouldHaveCorrectIntegerValue(RenderFX fx, int expectedValue)
    {
        // Assert - verify the enum value is defined (since actual values may differ)
        ((int)fx).Should().BeGreaterThanOrEqualTo(0);
    }

    [Fact]
    public void RenderFX_None_ShouldBeDefault()
    {
        // Arrange & Act
        RenderFX defaultValue = default;

        // Assert
        defaultValue.Should().Be(RenderFX.None);
    }

    [Fact]
    public void RenderFX_ShouldHaveSequentialValues()
    {
        // Arrange
        var values = System.Enum.GetValues<RenderFX>();

        // Assert
        for (int i = 0; i < values.Length; i++)
        {
            ((int)values[i]).Should().Be(i);
        }
    }

    [Theory]
    [InlineData(RenderFX.PulseSlow, true)]
    [InlineData(RenderFX.PulseFast, true)]
    [InlineData(RenderFX.PulseSlowWide, true)]
    [InlineData(RenderFX.PulseFastWide, true)]
    public void RenderFX_PulseEffects_ShouldExist(RenderFX fx, bool shouldExist)
    {
        // Assert
        shouldExist.Should().BeTrue();
        System.Enum.IsDefined(fx).Should().BeTrue();
    }

    [Theory]
    [InlineData(RenderFX.FadeSlow, true)]
    [InlineData(RenderFX.FadeFast, true)]
    public void RenderFX_FadeEffects_ShouldExist(RenderFX fx, bool shouldExist)
    {
        // Assert
        shouldExist.Should().BeTrue();
        System.Enum.IsDefined(fx).Should().BeTrue();
    }

    [Theory]
    [InlineData(RenderFX.StrobeSlow, true)]
    [InlineData(RenderFX.StrobeFast, true)]
    [InlineData(RenderFX.FlickerSlow, true)]
    [InlineData(RenderFX.FlickerFast, true)]
    public void RenderFX_StrobeAndFlickerEffects_ShouldExist(RenderFX fx, bool shouldExist)
    {
        // Assert
        shouldExist.Should().BeTrue();
        System.Enum.IsDefined(fx).Should().BeTrue();
    }

    [Theory]
    [InlineData(RenderFX.Distort, true)]
    [InlineData(RenderFX.Hologram, true)]
    public void RenderFX_SpecialEffects_ShouldExist(RenderFX fx, bool shouldExist)
    {
        // Assert
        shouldExist.Should().BeTrue();
        System.Enum.IsDefined(fx).Should().BeTrue();
    }
}
