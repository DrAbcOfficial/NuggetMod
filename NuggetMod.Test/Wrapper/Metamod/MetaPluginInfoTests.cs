using NuggetMod.Wrapper.Metamod;
using NuggetMod.Enum.Metamod;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Wrapper.Metamod;

/// <summary>
/// Tests for the MetaPluginInfo class
/// </summary>
public class MetaPluginInfoTests
{
    #region Initialization

    [Fact]
    public void Constructor_WithAllRequiredFields_ShouldCreateInstance()
    {
        // Act
        var info = CreateValidPluginInfo();

        // Assert
        info.Should().NotBeNull();
        info.Name.Should().Be("TestPlugin");
        info.Version.Should().Be("1.0.0");
    }

    [Fact]
    public void Properties_ShouldStoreValues()
    {
        // Arrange
        var info = new MetaPluginInfo
        {
            InterfaceVersion = InterfaceVersion.V5_13,
            Name = "TestPlugin",
            Version = "1.0.0",
            Date = "2024-01-01",
            Author = "TestAuthor",
            Url = "https://example.com",
            LogTag = "[TEST]",
            Loadable = PluginLoadTime.Anytime,
            Unloadable = PluginLoadTime.Anytime
        };

        // Assert
        info.InterfaceVersion.Should().Be(InterfaceVersion.V5_13);
        info.Name.Should().Be("TestPlugin");
        info.Version.Should().Be("1.0.0");
        info.Date.Should().Be("2024-01-01");
        info.Author.Should().Be("TestAuthor");
        info.Url.Should().Be("https://example.com");
        info.LogTag.Should().Be("[TEST]");
        info.Loadable.Should().Be(PluginLoadTime.Anytime);
        info.Unloadable.Should().Be(PluginLoadTime.Anytime);
    }

    #endregion

    #region GetInterfaceVersionString

    [Theory]
    [InlineData(InterfaceVersion.V1, "1")]
    [InlineData(InterfaceVersion.V5, "5")]
    [InlineData(InterfaceVersion.V5_10, "5:10")]
    [InlineData(InterfaceVersion.V5_13, "5:13")]
    public void GetInterfaceVersionString_ShouldReturnCorrectFormat(InterfaceVersion version, string expected)
    {
        // Arrange
        var info = new MetaPluginInfo
        {
            InterfaceVersion = version,
            Name = "Test",
            Version = "1.0",
            Date = "2024",
            Author = "Test",
            Url = "",
            LogTag = "",
            Loadable = PluginLoadTime.Anytime,
            Unloadable = PluginLoadTime.Anytime
        };

        // Act
        var result = info.GetInterfaceVersionString();

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region IDisposable

    [Fact]
    public void Dispose_ShouldNotThrow()
    {
        // Arrange
        var info = CreateValidPluginInfo();

        // Act & Assert
        info.Invoking(i => i.Dispose()).Should().NotThrow();
    }

    [Fact]
    public void Dispose_CalledMultipleTimes_ShouldNotThrow()
    {
        // Arrange
        var info = CreateValidPluginInfo();
        info.Dispose();

        // Act & Assert
        info.Invoking(i => i.Dispose()).Should().NotThrow();
    }

    [Fact]
    public void UsingStatement_ShouldWork()
    {
        // Act & Assert
        using (var info = CreateValidPluginInfo())
        {
            info.Should().NotBeNull();
            info.Name.Should().Be("TestPlugin");
        }
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void MetaPluginInfo_WithEmptyStrings_ShouldWork()
    {
        // Arrange
        var info = new MetaPluginInfo
        {
            InterfaceVersion = InterfaceVersion.V1,
            Name = "",
            Version = "",
            Date = "",
            Author = "",
            Url = "",
            LogTag = "",
            Loadable = PluginLoadTime.Never,
            Unloadable = PluginLoadTime.Never
        };

        // Assert
        info.Name.Should().BeEmpty();
        info.Version.Should().BeEmpty();
    }

    [Theory]
    [InlineData("Plugin Name With Spaces")]
    [InlineData("Plugin-Name-With-Dashes")]
    [InlineData("Plugin.Name.With.Dots")]
    [InlineData("Plugin_Name_With_Underscores")]
    public void MetaPluginInfo_WithVariousNameFormats_ShouldWork(string name)
    {
        // Arrange
        var info = new MetaPluginInfo
        {
            InterfaceVersion = InterfaceVersion.V1,
            Name = name,
            Version = "1.0",
            Date = "2024",
            Author = "Test",
            Url = "",
            LogTag = "",
            Loadable = PluginLoadTime.Anytime,
            Unloadable = PluginLoadTime.Anytime
        };

        // Assert
        info.Name.Should().Be(name);
    }

    #endregion

    #region Helper Methods

    private static MetaPluginInfo CreateValidPluginInfo()
    {
        return new MetaPluginInfo
        {
            InterfaceVersion = InterfaceVersion.V5_13,
            Name = "TestPlugin",
            Version = "1.0.0",
            Date = "2024-01-01",
            Author = "TestAuthor",
            Url = "https://example.com",
            LogTag = "[TEST]",
            Loadable = PluginLoadTime.Anytime,
            Unloadable = PluginLoadTime.Anytime
        };
    }

    #endregion
}
