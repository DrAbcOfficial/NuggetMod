using NuggetMod.Enum.NuggetMod;
using NuggetMod.Native.Metamod;
using NuggetMod.Wrapper.Engine;
using NuggetMod.Wrapper.Metamod;
using System.Runtime.InteropServices;

namespace NuggetMod.Interface;

/// <summary>
/// Base class for plugin entry point implementation
/// </summary>
public abstract class PluginEntry
{
    /// <summary>
    /// The plugin interface implementation
    /// </summary>
    protected static IPlugin? Interface;
    
    /// <summary>
    /// Gets the plugin interface instance
    /// </summary>
    /// <returns>The plugin interface</returns>
    /// <exception cref="NullReferenceException">Thrown when Interface is null</exception>
    public static IPlugin GetPluginInterface()
    {
        if (Interface == null)
            throw new NullReferenceException(nameof(Interface));
        return Interface;
    }
    
    /// <summary>
    /// Gets the plugin information
    /// </summary>
    /// <returns>Plugin metadata</returns>
    /// <exception cref="NullReferenceException">Thrown when Interface is null</exception>
    public static MetaPluginInfo GetPluginInfo()
    {
        if (Interface == null)
            throw new NullReferenceException(nameof(Interface));
        return Interface.GetPluginInfo();
    }

    /// <summary>
    /// Native function called by the engine to provide function pointers.
    /// Initializes engine functions and global variables.
    /// </summary>
    /// <param name="pengfuncsFromEngine">Pointer to engine functions table.</param>
    /// <param name="pGlobals">Pointer to global variables structure.</param>
    protected static void Native_GiveFnptrsToDll(nint pengfuncsFromEngine, nint pGlobals)
    {
        EngineFuncs engineFuncs = new(pengfuncsFromEngine);
        GlobalVars globalVars = new(pGlobals);
        MetaMod._engineFuncs = engineFuncs;
        MetaMod._globalVars = globalVars;
    }

    /// <summary>
    /// Native function called by Metamod to initialize the plugin.
    /// </summary>
    protected static void Native_Meta_Init()
    {

    }

    /// <summary>
    /// Native function called by Metamod to query plugin information.
    /// </summary>
    /// <param name="interfaceVersion">Pointer to interface version string.</param>
    /// <param name="plinfo">Pointer to plugin info structure pointer.</param>
    /// <param name="pMetaUtilFuncs">Pointer to Metamod utility functions.</param>
    /// <returns>1 if successful, 0 otherwise.</returns>
    protected static int Native_Meta_Query(nint interfaceVersion, nint plinfo, nint pMetaUtilFuncs)
    {
        string? version = Marshal.PtrToStringAnsi(interfaceVersion) ?? throw new Exception("Interface version is null");
        var ifver = version switch
        {
            "1" => InterfaceVersion.V1,
            "2" => InterfaceVersion.V2,
            "3" => InterfaceVersion.V3,
            "4" => InterfaceVersion.V4,
            "5" => InterfaceVersion.V5,
            "5:1" => InterfaceVersion.V5_1,
            "5:2" => InterfaceVersion.V5_2,
            "5:3" => InterfaceVersion.V5_3,
            "5:4" => InterfaceVersion.V5_4,
            "5:5" => InterfaceVersion.V5_5,
            "5:6" => InterfaceVersion.V5_6,
            "5:7" => InterfaceVersion.V5_7,
            "5:8" => InterfaceVersion.V5_8,
            "5:9" => InterfaceVersion.V5_9,
            "5:10" => InterfaceVersion.V5_10,
            "5:11" => InterfaceVersion.V5_11,
            "5:12" => InterfaceVersion.V5_12,
            "5:13" => InterfaceVersion.V5_13,
            "5:14" => InterfaceVersion.V5_14,
            "5:15" => InterfaceVersion.V5_15,
            "5:16" => InterfaceVersion.V5_16,
            _ => throw new Exception("Unknown interface version"),
        };

        var pinterface = GetPluginInterface();
        var pinfo = GetPluginInfo();
        MetaMod._pluginInfo = pinfo;
        MetaMod._metaUtilFuncs = new MetaUtilFunctions(pMetaUtilFuncs);
        bool result = pinterface.Meta_Query(ifver, MetaMod.MetaUtilFuncs);
        unsafe
        {
            nint ptr = Marshal.AllocHGlobal(sizeof(NativePluginInfo));
            *(NativePluginInfo**)plinfo = (NativePluginInfo*)ptr;
            (*(NativePluginInfo**)plinfo)->ifvers = Marshal.StringToHGlobalAnsi(pinfo.GetInterfaceVersionString());
            (*(NativePluginInfo**)plinfo)->name = Marshal.StringToHGlobalAnsi(pinfo.Name);
            (*(NativePluginInfo**)plinfo)->version = Marshal.StringToHGlobalAnsi(pinfo.Version);
            (*(NativePluginInfo**)plinfo)->date = Marshal.StringToHGlobalAnsi(pinfo.Date);
            (*(NativePluginInfo**)plinfo)->author = Marshal.StringToHGlobalAnsi(pinfo.Author);
            (*(NativePluginInfo**)plinfo)->url = Marshal.StringToHGlobalAnsi(pinfo.Url);
            (*(NativePluginInfo**)plinfo)->logtag = Marshal.StringToHGlobalAnsi(pinfo.LogTag);
            (*(NativePluginInfo**)plinfo)->loadable = (int)pinfo.Loadable;
            (*(NativePluginInfo**)plinfo)->unloadable = (int)pinfo.Unloadable;
            pinfo.NavitePtr = ptr;
        }
        return result ? 1 : 0;
    }

    /// <summary>
    /// Native function called by Metamod to attach the plugin.
    /// Sets up function tables and hooks.
    /// </summary>
    /// <param name="now">Current plugin load time.</param>
    /// <param name="pFunctionTable">Pointer to function table to fill.</param>
    /// <param name="pMGlobals">Pointer to Metamod globals.</param>
    /// <param name="pGamedllFuncs">Pointer to game DLL functions.</param>
    /// <returns>1 if successful, 0 otherwise.</returns>
    protected static unsafe int Native_Meta_Attach(PluginLoadTime now, nint pFunctionTable, nint pMGlobals, nint pGamedllFuncs)
    {
        MetaGlobals metaGlobals = new(pMGlobals);
        MetaGameDLLFunctions gameDllFuncs = new(pGamedllFuncs);
        MetaMod._metaGlobals = metaGlobals;
        MetaMod._gameDllFuncs = gameDllFuncs;
        var pinterface = GetPluginInterface();
        bool result = pinterface.Meta_Attach(now, metaGlobals, gameDllFuncs);


        // Local method: Convert managed delegate to function pointer and write to host memory (by field offset)
        static void WriteDelegateField<TDelegate>(nint basePtr, string fieldName, TDelegate? del) where TDelegate : Delegate
        {
            nint offset = Marshal.OffsetOf<NativeMetaFuncs>(fieldName);
            nint dest = (nint)(basePtr + offset.ToInt64());
            nint fp = del == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(del);
            Marshal.WriteIntPtr(dest, fp);
        }
        NativeMetaFuncs funcs = MetaMod.GetNative();
        // 替换调用方式，显式指定委托类型
        WriteDelegateField(pFunctionTable, "pfnGetEntityAPI", funcs.pfnGetEntityAPI);
        WriteDelegateField(pFunctionTable, "pfnGetEntityAPI_Post", funcs.pfnGetEntityAPI_Post);
        WriteDelegateField(pFunctionTable, "pfnGetEntityAPI2", funcs.pfnGetEntityAPI2);
        WriteDelegateField(pFunctionTable, "pfnGetEntityAPI2_Post", funcs.pfnGetEntityAPI2_Post);
        WriteDelegateField(pFunctionTable, "pfnGetNewDLLFunctions", funcs.pfnGetNewDLLFunctions);
        WriteDelegateField(pFunctionTable, "pfnGetNewDLLFunctions_Post", funcs.pfnGetNewDLLFunctions_Post);
        WriteDelegateField(pFunctionTable, "pfnGetEngineFunctions", funcs.pfnGetEngineFunctions);
        WriteDelegateField(pFunctionTable, "pfnGetEngineFunctions_Post", funcs.pfnGetEngineFunctions_Post);
        WriteDelegateField(pFunctionTable, "pfnGetStudioBlendingInterface", funcs.pfnGetStudioBlendingInterface);
        WriteDelegateField(pFunctionTable, "pfnGetStudioBlendingInterface_Post", funcs.pfnGetStudioBlendingInterface_Post);
        return result ? 1 : 0;
    }

    /// <summary>
    /// Native function called by Metamod to detach the plugin.
    /// Cleans up resources and unhooks functions.
    /// </summary>
    /// <param name="now">Current plugin load time.</param>
    /// <param name="reason">Reason for unloading.</param>
    /// <returns>1 if successful, 0 otherwise.</returns>
    protected static int Native_Meta_Detach(PluginLoadTime now, PluginUnloadReason reason)
    {
        var pinterface = GetPluginInterface();
        bool result = pinterface.Meta_Detach(now, reason);
        return result ? 1 : 0;
    }
}