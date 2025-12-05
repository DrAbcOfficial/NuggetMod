using NuggetMod.Enum.NuggetMod;
using NuggetMod.Native.Engine;
using NuggetMod.Native.Game;
using System.Runtime.InteropServices;

namespace NuggetMod.Native.Metamod;
/// <summary>
/// Native MetaMod utility functions structure containing function pointers for MetaMod plugin utilities.
/// Provides logging, plugin management, module inspection, hooking, and disassembly capabilities.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeMetaUtilFunctions : INativeStruct
{
    /// <summary>Function pointer for logging to console</summary>
    internal LogDelegate pfnLogConsole;
    /// <summary>Function pointer for logging messages</summary>
    internal LogDelegate pfnLogMessage;
    /// <summary>Function pointer for logging errors</summary>
    internal LogDelegate pfnLogError;
    /// <summary>Function pointer for logging developer messages</summary>
    internal LogDeveloperDelegate pfnLogDeveloper;
    /// <summary>Function pointer for displaying centered HUD messages</summary>
    internal LogDelegate pfnCenterSay;
    /// <summary>Function pointer for displaying centered HUD messages with parameters</summary>
    internal CenterSayParmsDelegate pfnCenterSayParms;
    /// <summary>Function pointer for displaying centered HUD messages with variable arguments</summary>
    internal CenterSayVarargsDelegate pfnCenterSayVarargs;
    /// <summary>Function pointer for calling game entity functions</summary>
    internal CallGameEntityDelegate pfnCallGameEntity;
    /// <summary>Function pointer for getting user message ID by name</summary>
    internal GetUserMsgIDDelegate pfnGetUserMsgID;
    /// <summary>Function pointer for getting user message name by ID</summary>
    internal GetUserMsgNameDelegate pfnGetUserMsgName;
    /// <summary>Function pointer for getting plugin file path</summary>
    internal GetPluginPathDelegate pfnGetPluginPath;
    /// <summary>Function pointer for getting game information</summary>
    internal GetGameInfoDelegate pfnGetGameInfo;
    /// <summary>Function pointer for loading a plugin</summary>
    internal LoadPluginDelegate pfnLoadPlugin;
    /// <summary>Function pointer for unloading a plugin by command line</summary>
    internal UnloadPluginDelegate pfnUnloadPlugin;
    /// <summary>Function pointer for unloading a plugin by handle</summary>
    internal UnloadPluginByHandleDelegate pfnUnloadPluginByHandle;
    /// <summary>Function pointer for checking if querying client cvar</summary>
    internal IsQueryingClientCvarDelegate pfnIsQueryingClientCvar;
    /// <summary>Function pointer for making a request ID</summary>
    internal MakeRequestIDDelegate pfnMakeRequestID;
    /// <summary>Function pointer for getting hook tables</summary>
    internal GetHookTablesDelegate pfnGetHookTables;
    /// <summary>Function pointer for getting module base by handle</summary>
    internal GetModuleBaseByHandleDelegate pfnGetModuleBaseByHandle;
    /// <summary>Function pointer for getting module handle by name</summary>
    internal GetModuleHandleDelegate pfnGetModuleHandle;
    /// <summary>Function pointer for getting module base by name</summary>
    internal GetModuleBaseByNameDelegate pfnGetModuleBaseByName;
    /// <summary>Function pointer for getting image size</summary>
    internal GetImageSizeDelegate pfnGetImageSize;
    /// <summary>Function pointer for checking if address is in module range</summary>
    internal IsAddressInModuleRangeDelegate pfnIsAddressInModuleRange;
    /// <summary>Function pointer for getting game DLL handle</summary>
    internal GetGameDllHandleDelegate pfnGetGameDllHandle;
    /// <summary>Function pointer for getting game DLL base address</summary>
    internal GetGameDllBaseDelegate pfnGetGameDllBase;
    /// <summary>Function pointer for getting engine handle</summary>
    internal GetEngineHandleDelegate pfnGetEngineHandle;
    /// <summary>Function pointer for getting engine base address</summary>
    internal GetEngineBaseDelegate pfnGetEngineBase;
    /// <summary>Function pointer for getting engine end address</summary>
    internal GetEngineEndDelegate pfnGetEngineEnd;
    /// <summary>Function pointer for getting engine code base address</summary>
    internal GetEngineCodeBaseDelegate pfnGetEngineCodeBase;
    /// <summary>Function pointer for getting engine code end address</summary>
    internal GetEngineCodeEndDelegate pfnGetEngineCodeEnd;
    /// <summary>Function pointer for checking if pointer is valid code in engine</summary>
    internal IsValidCodePointerInEngineDelegate pfnIsValidCodePointerInEngine;
    /// <summary>Function pointer for removing hooks</summary>
    internal UnHookDelegate pfnUnHook;
    /// <summary>Function pointer for creating inline hooks</summary>
    internal InlineHookDelegate pfnInlineHook;
    /// <summary>Function pointer for getting next call address</summary>
    internal GetNextCallAddrDelegate pfnGetNextCallAddr;
    /// <summary>Function pointer for searching byte patterns</summary>
    internal SearchPatternDelegate pfnSearchPattern;
    /// <summary>Function pointer for reverse searching byte patterns</summary>
    internal ReverseSearchPatternDelegate pfnReverseSearchPattern;
    /// <summary>Function pointer for disassembling single instruction</summary>
    internal DisasmSingleInstructionDelegate pfnDisasmSingleInstruction;
    /// <summary>Function pointer for disassembling instruction ranges</summary>
    internal DisasmRangesDelegate pfnDisasmRanges;
    /// <summary>Function pointer for reverse searching function begin</summary>
    internal ReverseSearchFunctionBeginDelegate pfnReverseSearchFunctionBegin;
    /// <summary>Function pointer for reverse searching function begin with callback</summary>
    internal ReverseSearchFunctionBeginExDelegate pfnReverseSearchFunctionBeginEx;
    /// <summary>Function pointer for closing module handle</summary>
    internal CloseModuleHandleDelegate pfnCloseModuleHandle;
    /// <summary>Function pointer for loading library</summary>
    internal LoadLibraryDelegate pfnLoadLibrary;
    /// <summary>Function pointer for freeing library</summary>
    internal FreeLibraryDelegate pfnFreeLibrary;
    /// <summary>Function pointer for getting procedure address</summary>
    internal GetProcAddressDelegate pfnGetProcAddress;
    /// <summary>Function pointer for getting server studio blend interface</summary>
    internal GetServerStudioBlendInterfaceDelegate pfnGetServerStudioBlendInterface;
    /// <summary>Function pointer for getting engine studio blend interface</summary>
    internal GetEngineStudioBlendInterfaceDelegate pfnGetEngineStudioBlendInterface;
    /// <summary>Function pointer for getting engine studio API</summary>
    internal GetEngineStudioAPIDelegate pfnGetEngineStudioAPI;
    /// <summary>Function pointer for getting rotation matrix</summary>
    internal GetRotationMatrixDelegate pfnGetRotationMatrix;
    /// <summary>Function pointer for getting bone matrix</summary>
    internal GetBoneMatrixDelegate pfnGetBoneMatrix;
    /// <summary>Function pointer for getting engine type</summary>
    internal GetEngineTypeDelegate pfnGetEngineType;

#pragma warning disable CS8500 // 这会获取托管类型的地址、获取其大小或声明指向它的指针
    /// <summary>
    /// Delegate for logging messages
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void LogDelegate(NativePluginInfo* plid, byte* fmt);

    /// <summary>
    /// Delegate for logging developer messages (only shown when developer mode is enabled)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void LogDeveloperDelegate(NativePluginInfo* plid, byte* fmt);

    /// <summary>
    /// Delegate for displaying centered HUD messages with parameters
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void CenterSayParmsDelegate(NativePluginInfo* plid, NativeHudParams tparms, byte* fmt);

    /// <summary>
    /// Delegate for displaying centered HUD messages with variable arguments
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void CenterSayVarargsDelegate(NativePluginInfo* plid, NativeHudParams tparms, byte* fmt, nint va_list);

    /// <summary>
    /// Delegate for calling game entity spawn functions
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int CallGameEntityDelegate(NativePluginInfo* plid, byte* entStr, NativeEntvars* pev);

    /// <summary>
    /// Delegate for getting user message ID by name
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int GetUserMsgIDDelegate(NativePluginInfo* plid, byte* msgname, int* size);

    /// <summary>
    /// Delegate for getting user message name by ID
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate nint GetUserMsgNameDelegate(NativePluginInfo* plid, int msgid, int* size);

    /// <summary>
    /// Delegate for getting plugin file path
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate nint GetPluginPathDelegate(NativePluginInfo* plid);

    /// <summary>
    /// Delegate for getting game information by tag
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate nint GetGameInfoDelegate(NativePluginInfo* plid, GetGameInfoType tag);

    /// <summary>
    /// Delegate for loading a plugin dynamically
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int LoadPluginDelegate(NativePluginInfo* plid, byte* cmdline, PluginLoadTime now, out nint plugin_handle);

    /// <summary>
    /// Delegate for unloading a plugin by command line
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int UnloadPluginDelegate(NativePluginInfo* plid, byte* cmdline, PluginLoadTime now, PluginUnloadReason reason);

    /// <summary>
    /// Delegate for unloading a plugin by its handle
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int UnloadPluginByHandleDelegate(NativePluginInfo* plid, nint plugin_handle, PluginLoadTime now, PluginUnloadReason reason);

    /// <summary>
    /// Delegate for checking if currently querying a client's cvar
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate nint IsQueryingClientCvarDelegate(NativePluginInfo* plid, NativeEdict* player);

    /// <summary>
    /// Delegate for generating a unique request ID
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int MakeRequestIDDelegate(NativePluginInfo* plid);

    /// <summary>
    /// Delegate for getting hook function tables (engine, DLL, and new DLL functions)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void GetHookTablesDelegate(NativePluginInfo* plid, out NativeEngineFuncs* peng, out NativeDllFuncs* pdll, out NativeNewDllFuncs* pnewdll);

    /// <summary>
    /// Delegate for getting module base address by handle (Added 2022-07 by hzqst)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint GetModuleBaseByHandleDelegate(nint hModule);

    /// <summary>
    /// Delegate for getting module handle by name
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate nint GetModuleHandleDelegate(byte* szModuleName);

    /// <summary>
    /// Delegate for getting module base address by name
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate nint GetModuleBaseByNameDelegate(byte* szModuleName);

    /// <summary>
    /// Delegate for getting image size of a module
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate uint GetImageSizeDelegate(nint imageBase);

    /// <summary>
    /// Delegate for checking if an address is within a module's range
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int IsAddressInModuleRangeDelegate(nint lpAddress, nint lpModuleBase);

    /// <summary>
    /// Delegate for getting game DLL module handle
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint GetGameDllHandleDelegate();

    /// <summary>
    /// Delegate for getting game DLL base address
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint GetGameDllBaseDelegate();

    /// <summary>
    /// Delegate for getting engine module handle
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint GetEngineHandleDelegate();

    /// <summary>
    /// Delegate for getting engine base address
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint GetEngineBaseDelegate();

    /// <summary>
    /// Delegate for getting engine end address
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint GetEngineEndDelegate();

    /// <summary>
    /// Delegate for getting engine code section base address
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint GetEngineCodeBaseDelegate();

    /// <summary>
    /// Delegate for getting engine code section end address
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint GetEngineCodeEndDelegate();

    /// <summary>
    /// Delegate for checking if a pointer is valid code in engine
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int IsValidCodePointerInEngineDelegate(nint ptr);

    /// <summary>
    /// Delegate for removing a hook
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int UnHookDelegate(NativeHook pHook);

    /// <summary>
    /// Delegate for creating an inline hook
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate NativeHook* InlineHookDelegate(nint pOldFuncAddr, nint pNewFuncAddr, out nint pOrginalCall, bool bTranscation);

    /// <summary>
    /// Delegate for getting the next call instruction address
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint GetNextCallAddrDelegate(nint pAddress, int dwCount);

    /// <summary>
    /// Delegate for searching a byte pattern in memory
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate nint SearchPatternDelegate(nint pStartSearch, uint dwSearchLen, byte* pPattern, uint dwPatternLen);

    /// <summary>
    /// Delegate for reverse searching a byte pattern in memory
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate nint ReverseSearchPatternDelegate(nint pStartSearch, uint dwSearchLen, byte* pPattern, uint dwPatternLen);

    /// <summary>
    /// Delegate for disassembling a single instruction
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int DisasmSingleInstructionDelegate(nint address, nint fnDisasmSingleCallback, nint context);

    /// <summary>
    /// Delegate for disassembling a range of instructions
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int DisasmRangesDelegate(nint disasmBase, uint disasmSize, nint fnDisasmCallback, int depth, nint context);

    /// <summary>
    /// Delegate for reverse searching function beginning
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint ReverseSearchFunctionBeginDelegate(nint searchBegin, uint searchSize);

    /// <summary>
    /// Delegate for reverse searching function beginning with callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint ReverseSearchFunctionBeginExDelegate(nint searchBegin, uint searchSize, nint fnFindAddressCallback);

    /// <summary>
    /// Delegate for closing a module handle
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void CloseModuleHandleDelegate(nint hModule);

    /// <summary>
    /// Delegate for loading a library/module
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate nint LoadLibraryDelegate(byte* szModuleName);

    /// <summary>
    /// Delegate for freeing a loaded library/module
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void FreeLibraryDelegate(nint hModule);

    /// <summary>
    /// Delegate for getting procedure address from a module
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate nint GetProcAddressDelegate(nint hModule, byte* szProcName);

    /// <summary>
    /// Delegate for getting server studio blend interface
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate NativeServerBlendInterface* GetServerStudioBlendInterfaceDelegate();

    /// <summary>
    /// Delegate for getting engine studio blend interface
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate NativeServerBlendInterface* GetEngineStudioBlendInterfaceDelegate();

    /// <summary>
    /// Delegate for getting engine studio API
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate NativeServerStudioAPI* GetEngineStudioAPIDelegate();

    /// <summary>
    /// Delegate for getting rotation matrix pointer
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint GetRotationMatrixDelegate();

    /// <summary>
    /// Delegate for getting bone matrix pointer
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint GetBoneMatrixDelegate();

    /// <summary>
    /// Delegate for getting engine type string (Added 2024-10 by hzqst)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate byte* GetEngineTypeDelegate();
#pragma warning restore CS8500 // 这会获取托管类型的地址、获取其大小或声明指向它的指针
}

#region Delegate For Delegate

/// <summary>
/// Callback delegate for single instruction disassembly
/// </summary>
/// <param name="inst">Pointer to the instruction structure</param>
/// <param name="address">Address of the instruction</param>
/// <param name="instLen">Length of the instruction in bytes</param>
/// <param name="context">User-defined context pointer</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void DisasmSingleCallbackDelegate(nint inst, nint address, uint instLen, nint context);

/// <summary>
/// Callback delegate for range disassembly
/// </summary>
/// <param name="inst">Pointer to the instruction structure</param>
/// <param name="address">Address of the instruction</param>
/// <param name="instLen">Length of the instruction in bytes</param>
/// <param name="instCount">Instruction count in the current sequence</param>
/// <param name="depth">Current recursion depth</param>
/// <param name="context">User-defined context pointer</param>
/// <returns>Non-zero to continue disassembly, zero to stop</returns>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate int DisasmCallbackDelegate(nint inst, nint address, uint instLen, int instCount, int depth, nint context);

/// <summary>
/// Callback delegate for finding function addresses
/// </summary>
/// <param name="address">Address to evaluate</param>
/// <returns>Non-zero if address is valid function begin, zero otherwise</returns>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate int FindAddressCallbackDelegate(nint address);
#endregion