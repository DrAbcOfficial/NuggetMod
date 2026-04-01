using NuggetMod.Interface;
using NuggetMod.Enum.Metamod;
using NuggetMod.Wrapper.Metamod;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Interface;

/// <summary>
/// Tests for the IPlugin interface
/// </summary>
public class IPluginTests
{
    // Test implementation of IPlugin
    private class TestPlugin : IPlugin
    {
        public bool MetaInitCalled { get; private set; }
        public bool MetaQueryCalled { get; private set; }
        public bool MetaAttachCalled { get; private set; }
        public bool MetaDetachCalled { get; private set; }
        public InterfaceVersion? LastQueryVersion { get; private set; }
        public PluginLoadTime? LastDetachTime { get; private set; }
        public PluginUnloadReason? LastDetachReason { get; private set; }

        public MetaPluginInfo GetPluginInfo()
        {
            return new MetaPluginInfo
            {
                InterfaceVersion = InterfaceVersion.V5_13,
                Name = "TestPlugin",
                Version = "1.0.0",
                Date = "2024-01-01",
                Author = "Test",
                Url = "",
                LogTag = "[TEST]",
                Loadable = PluginLoadTime.Anytime,
                Unloadable = PluginLoadTime.Anytime
            };
        }

        public void MetaInit()
        {
            MetaInitCalled = true;
        }

        public bool MetaQuery(InterfaceVersion interfaceVersion, NuggetMod.Wrapper.Metamod.MetaUtilFunctions pMetaUtilFuncs)
        {
            MetaQueryCalled = true;
            LastQueryVersion = interfaceVersion;
            return true;
        }

        public bool MetaAttach(PluginLoadTime now, NuggetMod.Wrapper.Metamod.MetaGlobals pMGlobals, NuggetMod.Wrapper.Metamod.MetaGameDLLFunctions pGamedllFuncs)
        {
            MetaAttachCalled = true;
            return true;
        }

        public bool MetaDetach(PluginLoadTime now, PluginUnloadReason reason)
        {
            MetaDetachCalled = true;
            LastDetachTime = now;
            LastDetachReason = reason;
            return true;
        }
    }

    [Fact]
    public void IPlugin_GetPluginInfo_ShouldReturnMetaPluginInfo()
    {
        // Arrange
        var plugin = new TestPlugin();

        // Act
        var info = plugin.GetPluginInfo();

        // Assert
        info.Should().NotBeNull();
        info.Name.Should().Be("TestPlugin");
    }

    [Fact]
    public void IPlugin_MetaInit_ShouldBeCallable()
    {
        // Arrange
        var plugin = new TestPlugin();

        // Act
        plugin.MetaInit();

        // Assert
        plugin.MetaInitCalled.Should().BeTrue();
    }

    [Fact]
    public void IPlugin_MetaQuery_ShouldReturnTrue_WhenCompatible()
    {
        // Arrange
        var plugin = new TestPlugin();

        // Act
        var result = plugin.MetaQuery(InterfaceVersion.V5_13, null!);

        // Assert
        result.Should().BeTrue();
        plugin.MetaQueryCalled.Should().BeTrue();
        plugin.LastQueryVersion.Should().Be(InterfaceVersion.V5_13);
    }

    [Fact]
    public void IPlugin_MetaAttach_ShouldReturnTrue_WhenSuccessful()
    {
        // Arrange
        var plugin = new TestPlugin();

        // Act
        var result = plugin.MetaAttach(PluginLoadTime.Startup, null!, null!);

        // Assert
        result.Should().BeTrue();
        plugin.MetaAttachCalled.Should().BeTrue();
    }

    [Fact]
    public void IPlugin_MetaDetach_ShouldReturnTrue_WhenSuccessful()
    {
        // Arrange
        var plugin = new TestPlugin();

        // Act
        var result = plugin.MetaDetach(PluginLoadTime.Anytime, PluginUnloadReason.Command);

        // Assert
        result.Should().BeTrue();
        plugin.MetaDetachCalled.Should().BeTrue();
        plugin.LastDetachTime.Should().Be(PluginLoadTime.Anytime);
        plugin.LastDetachReason.Should().Be(PluginUnloadReason.Command);
    }

    [Fact]
    public void IPlugin_FullLifecycle_ShouldExecuteAllMethods()
    {
        // Arrange
        var plugin = new TestPlugin();

        // Act - Simulate full plugin lifecycle
        var info = plugin.GetPluginInfo();
        var canLoad = plugin.MetaQuery(InterfaceVersion.V5_13, null!);
        plugin.MetaInit();
        var attached = plugin.MetaAttach(PluginLoadTime.Startup, null!, null!);
        var detached = plugin.MetaDetach(PluginLoadTime.Anytime, PluginUnloadReason.Shutdown);

        // Assert
        info.Should().NotBeNull();
        canLoad.Should().BeTrue();
        attached.Should().BeTrue();
        detached.Should().BeTrue();
        plugin.MetaInitCalled.Should().BeTrue();
        plugin.MetaAttachCalled.Should().BeTrue();
        plugin.MetaDetachCalled.Should().BeTrue();
    }
}
