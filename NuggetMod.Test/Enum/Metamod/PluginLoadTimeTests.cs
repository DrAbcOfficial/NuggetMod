using NuggetMod.Enum.Metamod;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Metamod;

/// <summary>
/// Tests for the PluginLoadTime enumeration
/// </summary>
public class PluginLoadTimeTests
{
    [Theory]
    [InlineData(PluginLoadTime.Never, 0)]
    [InlineData(PluginLoadTime.Startup, 1)]
    [InlineData(PluginLoadTime.ChangeLevel, 2)]
    [InlineData(PluginLoadTime.Anytime, 3)]
    [InlineData(PluginLoadTime.AnyPause, 4)]
    public void PluginLoadTime_ShouldHaveCorrectIntegerValue(PluginLoadTime time, int expectedValue)
    {
        // Assert
        ((int)time).Should().Be(expectedValue);
    }

    [Fact]
    public void PluginLoadTime_Never_ShouldBeDefault()
    {
        // Arrange & Act
        PluginLoadTime defaultValue = default;

        // Assert
        defaultValue.Should().Be(PluginLoadTime.Never);
    }

    [Fact]
    public void PluginLoadTime_ShouldHaveProgressiveValues()
    {
        // Arrange
        var values = System.Enum.GetValues<PluginLoadTime>();

        // Assert
        for (int i = 0; i < values.Length; i++)
        {
            ((int)values[i]).Should().Be(i);
        }
    }

    [Theory]
    [InlineData(PluginLoadTime.Startup, true)]
    [InlineData(PluginLoadTime.Anytime, true)]
    [InlineData(PluginLoadTime.Never, false)]
    public void PluginLoadTime_CanDetermineIfPluginCanLoadAtStartup(PluginLoadTime time, bool canLoadAtStartup)
    {
        // Act
        bool canLoad = time == PluginLoadTime.Startup || time == PluginLoadTime.Anytime;

        // Assert
        canLoad.Should().Be(canLoadAtStartup);
    }
}
