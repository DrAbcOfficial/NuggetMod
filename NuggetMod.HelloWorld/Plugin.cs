using NuggetMod.Enum.Metamod;
using NuggetMod.Helper;
using NuggetMod.Interface;
using NuggetMod.Interface.Events;
using NuggetMod.Wrapper.Engine;
using NuggetMod.Wrapper.Metamod;

namespace NuggetMod.HelloWorld;

/// <summary>
/// Plugin entry point: the name must be Plugin and must inherit from the IPlugin interface.
/// </summary>
public class Plugin : IPlugin
{
    /// <summary>
    /// Plugin information: it is recommended to set it as static to maintain memory availability.
    /// </summary>
    private readonly static MetaPluginInfo _pluginInfo = new()
    {
        InterfaceVersion = InterfaceVersion.V5_16,
        Name = "HelloWorld",
        Version = "1.0",
        Author = "Dr.Abc",
        Date = "2026/4/1",
        LogTag = "HLWD",
        Url = "github.com",
        Loadable = PluginLoadTime.Anytime,
        Unloadable = PluginLoadTime.Anytime
    };

    public MetaPluginInfo GetPluginInfo()
    {
        return _pluginInfo;
    }

    public void MetaInit()
    {

    }

    public bool MetaQuery(InterfaceVersion interfaceVersion, MetaUtilFunctions pMetaUtilFuncs)
    {
        if (interfaceVersion != _pluginInfo.InterfaceVersion)
            return false;
        return true;
    }

    public bool MetaAttach(PluginLoadTime now, MetaGlobals pMGlobals, MetaGameDLLFunctions pGamedllFuncs)
    {
        CVar hello = new("hello", "World", CVar.FCVAR.Server);
        hello.RegisterWith(MetaMod.EngineFuncs);
        DLLEvents dLLEvents = new();
        dLLEvents.ServerActivate += (pEdictList, edictCount, clientMax) =>
        {
            MetaMod.EngineFuncs.ServerPrint($"Hello, {hello.Str}!\n");
            return MetaResult.Override;
        };
        MetaMod.RegisterEventsSafely(new EventRegistrationBuilder().WithEntityApi(dLLEvents));
        return true;
    }

    public bool MetaDetach(PluginLoadTime now, PluginUnloadReason reason)
    {
        return true;
    }
}