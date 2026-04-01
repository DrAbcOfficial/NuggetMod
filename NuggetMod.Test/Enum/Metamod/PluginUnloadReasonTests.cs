using NuggetMod.Enum.Metamod;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Metamod;

/// <summary>
/// Tests for the PluginUnloadReason enumeration
/// </summary>
public class PluginUnloadReasonTests
{
    [Theory]
    [InlineData(PluginUnloadReason.Null, 0)]
    [InlineData(PluginUnloadReason.IniDeleted, 1)]
    [InlineData(PluginUnloadReason.FileNewer, 2)]
    [InlineData(PluginUnloadReason.Command, 3)]
    [InlineData(PluginUnloadReason.CommandForce, 4)]
    [InlineData(PluginUnloadReason.Delayed, 5)]
    [InlineData(PluginUnloadReason.Plugin, 6)]
    [InlineData(PluginUnloadReason.PluginForce, 7)]
    [InlineData(PluginUnloadReason.Reload, 8)]
    [InlineData(PluginUnloadReason.Shutdown, 9)]
    public void PluginUnloadReason_ShouldHaveCorrectIntegerValue(PluginUnloadReason reason, int expectedValue)
    {
        // Assert
        ((int)reason).Should().Be(expectedValue);
    }

    [Fact]
    public void PluginUnloadReason_Null_ShouldBeDefault()
    {
        // Arrange & Act
        PluginUnloadReason defaultValue = default;

        // Assert
        defaultValue.Should().Be(PluginUnloadReason.Null);
    }

    [Theory]
    [InlineData(PluginUnloadReason.Shutdown, true)]
    [InlineData(PluginUnloadReason.IniDeleted, true)]
    [InlineData(PluginUnloadReason.Command, false)]
    public void PluginUnloadReason_CanIdentifyUnplannedUnload(PluginUnloadReason reason, bool isUnplanned)
    {
        // Act
        bool unplanned = reason == PluginUnloadReason.Shutdown ||
                        reason == PluginUnloadReason.IniDeleted;

        // Assert
        unplanned.Should().Be(isUnplanned);
    }

    [Theory]
    [InlineData(PluginUnloadReason.FileNewer, true)]
    [InlineData(PluginUnloadReason.Reload, false)]
    public void PluginUnloadReason_CanIdentifyFileRelatedUnload(PluginUnloadReason reason, bool isFileRelated)
    {
        // Act
        bool fileRelated = reason == PluginUnloadReason.FileNewer;

        // Assert
        fileRelated.Should().Be(isFileRelated);
    }
}
