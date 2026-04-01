using NuggetMod.Enum.Metamod;
using NuggetMod.Interface;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NuggetMod.HelloWorld;

public class NativeEntry : PluginEntry
{
    static NativeEntry()
    {
        Interface = new Plugin();
    }
    [UnmanagedCallersOnly(EntryPoint = "GiveFnptrsToDll")]
    public static void UnmanagedGiveFnptrsToDll(nint pengfuncsFromEngine, nint pGlobals)
    {
        Native_GiveFnptrsToDll(pengfuncsFromEngine, pGlobals);
    }
    [UnmanagedCallersOnly(EntryPoint = "Meta_Init", CallConvs = [typeof(CallConvCdecl)])]
    public static void UnmanagedMeta_Init()
    {
        Native_Meta_Init();
    }
    [UnmanagedCallersOnly(EntryPoint = "Meta_Query", CallConvs = [typeof(CallConvCdecl)])]
    public static int UnmanagedMeta_Query(nint interfaceVersion, nint plinfo, nint pMetaUtilFuncs)
    {
        return Native_Meta_Query(interfaceVersion, plinfo, pMetaUtilFuncs);
    }
    [UnmanagedCallersOnly(EntryPoint = "Meta_Attach", CallConvs = [typeof(CallConvCdecl)])]
    public static int UnmanagedMeta_Attach(PluginLoadTime now, nint pFunctionTable, nint pMGlobals, nint pGamedllFuncs)
    {
        return Native_Meta_Attach(now, pFunctionTable, pMGlobals, pGamedllFuncs);
    }
    [UnmanagedCallersOnly(EntryPoint = "Meta_Detach", CallConvs = [typeof(CallConvCdecl)])]
    public static int UnmanagedMeta_Detach(PluginLoadTime now, PluginUnloadReason reason)
    {
        return Native_Meta_Detach(now, reason);
    }
}