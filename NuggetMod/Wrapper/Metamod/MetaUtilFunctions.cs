using NuggetMod.Enum.Metamod;
using NuggetMod.Interface;
using NuggetMod.Native.Engine;
using NuggetMod.Native.Game;
using NuggetMod.Native.Metamod;
using NuggetMod.Wrapper.Engine;
using NuggetMod.Wrapper.Game;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper.Metamod;

/// <summary>
/// Wrapper for MetaMod utility functions
/// </summary>
public class MetaUtilFunctions(nint ptr) : BaseFunctionWrapper<NativeMetaUtilFunctions>(ptr)
{
    /// <summary>
    /// Logs a message to the console
    /// </summary>
    /// <param name="fmt">Format string</param>
    /// <param name="parm">Format parameters</param>
    public void LogConsole(string fmt, params string[] parm)
    {
        string str = string.Format(fmt, parm);
        nint strptr = Marshal.StringToHGlobalAnsi(str);
        unsafe
        {
            Base.pfnLogConsole((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, (byte*)strptr);
        }
        Marshal.FreeHGlobal(strptr);
    }

    /// <summary>
    /// Logs a general message
    /// </summary>
    /// <param name="fmt">Format string</param>
    /// <param name="parm">Format parameters</param>
    public void LogMessage(string fmt, params string[] parm)
    {
        string str = string.Format(fmt, parm);
        nint strptr = Marshal.StringToHGlobalAnsi(str);
        unsafe
        {
            Base.pfnLogMessage((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, (byte*)strptr);
        }
        Marshal.FreeHGlobal(strptr);
    }

    /// <summary>
    /// Logs an error message
    /// </summary>
    /// <param name="fmt">Format string</param>
    /// <param name="parm">Format parameters</param>
    public void LogError(string fmt, params string[] parm)
    {
        string str = string.Format(fmt, parm);
        nint strptr = Marshal.StringToHGlobalAnsi(str);
        unsafe
        {
            Base.pfnLogError((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, (byte*)strptr);
        }
        Marshal.FreeHGlobal(strptr);
    }

    /// <summary>
    /// Logs a developer message (only shown when developer mode is enabled).
    /// </summary>
    /// <param name="fmt">Format string.</param>
    /// <param name="parm">Format parameters.</param>
    public void LogDeveloper(string fmt, params string[] parm)
    {
        string str = string.Format(fmt, parm);
        nint strptr = Marshal.StringToHGlobalAnsi(str);
        unsafe
        {
            Base.pfnLogDeveloper((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, (byte*)strptr);
        }
        Marshal.FreeHGlobal(strptr);
    }

    /// <summary>
    /// Displays a centered message to all players.
    /// </summary>
    /// <param name="fmt">Format string.</param>
    /// <param name="parm">Format parameters.</param>
    public void CenterSay(string fmt, params string[] parm)
    {
        string str = string.Format(fmt, parm);
        nint strptr = Marshal.StringToHGlobalAnsi(str);
        unsafe
        {
            Base.pfnCenterSay((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, (byte*)strptr);
        }
        Marshal.FreeHGlobal(strptr);
    }

    /// <summary>
    /// Displays a centered message to all players with custom HUD parameters.
    /// </summary>
    /// <param name="hudParams">HUD display parameters.</param>
    /// <param name="fmt">Format string.</param>
    /// <param name="parm">Format parameters.</param>
    public void CenterSayPams(HudParams hudParams, string fmt, params string[] parm)
    {
        string str = string.Format(fmt, parm);
        nint strptr = Marshal.StringToHGlobalAnsi(str);
        unsafe
        {
            Base.pfnCenterSayParms((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, *((NativeHudParams*)hudParams.GetNative()), (byte*)strptr);
        }
        Marshal.FreeHGlobal(strptr);
    }

    /// <summary>
    /// Calls a game entity function by name.
    /// </summary>
    /// <param name="entStr">Entity classname string.</param>
    /// <param name="pev">Entity variables.</param>
    public void CallGameEntity(string entStr, Entvars pev)
    {
        nint strptr = Marshal.StringToHGlobalAnsi(entStr);
        unsafe
        {
            Base.pfnCallGameEntity((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, (byte*)strptr, (NativeEntvars*)pev.GetNative());
        }
        Marshal.FreeHGlobal(strptr);
    }

    /// <summary>
    /// Gets the user message ID by name.
    /// </summary>
    /// <param name="msgname">Message name.</param>
    /// <param name="size">Output parameter for message size.</param>
    /// <returns>Message ID, or 0 if not found.</returns>
    public int GetUserMessageId(string msgname, out int size)
    {
        nint temp = Marshal.AllocHGlobal(sizeof(int));
        nint strptr = Marshal.StringToHGlobalAnsi(msgname);
        int result = 0;
        unsafe
        {
            result = Base.pfnGetUserMsgID((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, (byte*)strptr, (int*)temp);
        }
        size = Marshal.ReadInt32(temp);
        Marshal.FreeHGlobal(strptr);
        Marshal.FreeHGlobal(temp);
        return result;
    }

    /// <summary>
    /// Gets the user message name by ID.
    /// </summary>
    /// <param name="msgid">Message ID.</param>
    /// <param name="size">Output parameter for message size.</param>
    /// <returns>Message name, or empty string if not found.</returns>
    public string GetUserMessageName(int msgid, out int size)
    {
        nint temp = Marshal.AllocHGlobal(sizeof(int));
        nint result = nint.Zero;
        unsafe
        {
            result = Base.pfnGetUserMsgName((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, msgid, (int*)temp);
        }
        string? str = Marshal.PtrToStringUTF8(result);
        size = Marshal.ReadInt32(temp);
        Marshal.FreeHGlobal(temp);
        return str ?? string.Empty;
    }

    /// <summary>
    /// Gets the plugin's file path.
    /// </summary>
    /// <returns>Plugin file path.</returns>
    public string GetPluginPath()
    {
        nint result = nint.Zero;
        unsafe
        {
            result = Base.pfnGetPluginPath((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr);
        }
        string? str = Marshal.PtrToStringUTF8(result);
        return str ?? string.Empty;
    }

    /// <summary>
    /// Gets game information by type.
    /// </summary>
    /// <param name="type">Type of game information to retrieve.</param>
    /// <returns>Game information string.</returns>
    public string GetGameInfo(GetGameInfoType type)
    {
        nint result = nint.Zero;
        unsafe
        {
            result = Base.pfnGetGameInfo((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, type);
        }
        string? str = Marshal.PtrToStringUTF8(result);
        return str ?? string.Empty;
    }

    /// <summary>
    /// Loads a plugin dynamically.
    /// </summary>
    /// <param name="cmdline">Plugin command line (path and parameters).</param>
    /// <param name="now">Current load time.</param>
    /// <param name="pluginHandle">Output parameter for plugin handle.</param>
    /// <returns>True if successful, false otherwise.</returns>
    public bool LoadPlugin(string cmdline, PluginLoadTime now, out nint pluginHandle)
    {
        nint strptr = Marshal.StringToHGlobalAnsi(cmdline);
        int res = 0;
        unsafe
        {
            res = Base.pfnLoadPlugin((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, (byte*)strptr, now, out pluginHandle);
        }
        Marshal.FreeHGlobal(strptr);
        return res != 0;
    }

    /// <summary>
    /// Unloads a plugin by command line.
    /// </summary>
    /// <param name="cmdline">Plugin command line.</param>
    /// <param name="now">Current load time.</param>
    /// <param name="reason">Reason for unloading.</param>
    /// <returns>True if successful, false otherwise.</returns>
    public bool UnloadPlugin(string cmdline, PluginLoadTime now, PluginUnloadReason reason)
    {
        nint strptr = Marshal.StringToHGlobalAnsi(cmdline);
        int res = 0;
        unsafe
        {
            res = Base.pfnUnloadPlugin((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, (byte*)strptr, now, reason);
        }
        Marshal.FreeHGlobal(strptr);
        return res != 0;
    }

    /// <summary>
    /// Unloads a plugin by handle.
    /// </summary>
    /// <param name="handle">Plugin handle.</param>
    /// <param name="now">Current load time.</param>
    /// <param name="reason">Reason for unloading.</param>
    /// <returns>True if successful, false otherwise.</returns>
    public bool UnloadPluginByHandle(nint handle, PluginLoadTime now, PluginUnloadReason reason)
    {
        int res = 0;
        unsafe
        {
            res = Base.pfnUnloadPluginByHandle((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, handle, now, reason);
        }
        return res != 0;
    }

    /// <summary>
    /// Checks if a client cvar query is in progress for a player.
    /// </summary>
    /// <param name="player">Player entity.</param>
    /// <returns>Cvar name being queried, or empty string if none.</returns>
    public string IsQueryingClientCVar(Edict player)
    {
        nint result = nint.Zero;
        unsafe
        {
            result = Base.pfnIsQueryingClientCvar((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr, (NativeEdict*)player.GetNative());
        }
        return Marshal.PtrToStringUTF8(result) ?? string.Empty;
    }

    /// <summary>
    /// Creates a unique request ID for client cvar queries.
    /// </summary>
    /// <returns>Unique request ID.</returns>
    public int MakeRequestID()
    {
        int res = 0;
        unsafe
        {
            res = Base.pfnMakeRequestID((NativePluginInfo*)MetaMod.PluginInfo.NavitePtr);
        }
        return res;
    }

    /// <summary>
    /// Gets hook tables for engine and DLL functions (TODO: Finish implementation).
    /// </summary>
    /// <param name="peng">Engine functions output.</param>
    /// <param name="pdll">DLL functions output.</param>
    /// <param name="pnewdll">New DLL functions output.</param>
    public void GetHookTables(/*out*/ EngineFuncs peng, /*out*/ int pdll, /*out*/ int pnewdll)
    {

    }

    /// <summary>
    /// Gets the base address of a module by its handle.
    /// </summary>
    /// <param name="handle">Module handle.</param>
    /// <returns>Base address of the module.</returns>
    public nint GetModuleBaseByHandle(nint handle)
    {
        return Base.pfnGetModuleBaseByHandle(handle);
    }

    /// <summary>
    /// Gets the module handle by module name.
    /// </summary>
    /// <param name="modulename">Name of the module.</param>
    /// <returns>Module handle, or zero if not found.</returns>
    public nint GetModuleHandle(string modulename)
    {
        nint strptr = Marshal.StringToHGlobalAnsi(modulename);
        nint result = nint.Zero;
        unsafe
        {
            result = Base.pfnGetModuleHandle((byte*)strptr);
        }
        Marshal.FreeHGlobal(strptr);
        return result;
    }

    /// <summary>
    /// Gets the base address of a module by its name.
    /// </summary>
    /// <param name="name">Name of the module.</param>
    /// <returns>Base address of the module.</returns>
    public nint GetModuleBaseByName(string name)
    {
        nint strptr = Marshal.StringToHGlobalAnsi(name);
        nint result = nint.Zero;
        unsafe
        {
            result = Base.pfnGetModuleBaseByName((byte*)strptr);
        }
        Marshal.FreeHGlobal(strptr);
        return result;
    }

    /// <summary>
    /// Gets the size of a loaded module image.
    /// </summary>
    /// <param name="imageBase">Base address of the module image.</param>
    /// <returns>Size of the module image in bytes.</returns>
    public uint GetImageSize(nint imageBase)
    {
        return Base.pfnGetImageSize(imageBase);
    }

    /// <summary>
    /// Checks if an address is within the range of a module.
    /// </summary>
    /// <param name="lpAddress">Address to check.</param>
    /// <param name="lpModuleBase">Base address of the module.</param>
    /// <returns>True if the address is within the module range, false otherwise.</returns>
    public bool IsAddressInModuleRange(nint lpAddress, nint lpModuleBase)
    {
        return Base.pfnIsAddressInModuleRange(lpAddress, lpModuleBase) == 1;
    }

    /// <summary>
    /// Gets the handle of the game DLL module.
    /// </summary>
    /// <returns>Game DLL module handle.</returns>
    public nint GetGameDllHandle()
    {
        return Base.pfnGetGameDllHandle();
    }

    /// <summary>
    /// Gets the base address of the game DLL.
    /// </summary>
    /// <returns>Game DLL base address.</returns>
    public nint GetGameDllBase()
    {
        return Base.pfnGetGameDllBase();
    }

    /// <summary>
    /// Gets the handle of the engine module.
    /// </summary>
    /// <returns>Engine module handle.</returns>
    public nint GetEngineHandle()
    {
        return Base.pfnGetEngineHandle();
    }

    /// <summary>
    /// Gets the base address of the engine module.
    /// </summary>
    /// <returns>Engine base address.</returns>
    public nint GetEngineBase()
    {
        return Base.pfnGetEngineBase();
    }

    /// <summary>
    /// Gets the end address of the engine module.
    /// </summary>
    /// <returns>Engine end address.</returns>
    public nint GetEngineEnd()
    {
        return Base.pfnGetEngineEnd();
    }

    /// <summary>
    /// Gets the base address of the engine code section.
    /// </summary>
    /// <returns>Engine code section base address.</returns>
    public nint GetEngineCodeBase()
    {
        return Base.pfnGetEngineCodeBase();
    }

    /// <summary>
    /// Gets the end address of the engine code section.
    /// </summary>
    /// <returns>Engine code section end address.</returns>
    public nint GetEngineCodeEnd()
    {
        return Base.pfnGetEngineCodeEnd();
    }

    /// <summary>
    /// Checks if a pointer is a valid code pointer within the engine.
    /// </summary>
    /// <param name="ptr">Pointer to check.</param>
    /// <returns>True if the pointer is valid engine code, false otherwise.</returns>
    public bool IsValidCodePointerInEngine(nint ptr)
    {
        return Base.pfnIsValidCodePointerInEngine(ptr) == 1;
    }

    /// <summary>
    /// Removes a previously installed hook.
    /// </summary>
    /// <param name="pHook">Hook to remove.</param>
    /// <returns>True if successful, false otherwise.</returns>
    public bool UnHook(Hook pHook)
    {
        bool res = false;
        unsafe
        {
            res = Base.pfnUnHook(*(NativeHook*)pHook.GetNative()) == 1;
        }
        return res;
    }

    /// <summary>
    /// Installs an inline hook to redirect function execution.
    /// </summary>
    /// <param name="pOldFuncAddr">Address of the original function.</param>
    /// <param name="pNewFuncAddr">Address of the new function.</param>
    /// <param name="pOrigialCall">Output parameter for the original call address.</param>
    /// <param name="bTranscation">Whether to use transaction-based hooking.</param>
    /// <returns>Hook structure representing the installed hook.</returns>
    public Hook InlineHook(nint pOldFuncAddr, nint pNewFuncAddr, out nint pOrigialCall, bool bTranscation)
    {
        nint ptr = nint.Zero;
        unsafe
        {
            ptr = (nint)Base.pfnInlineHook(pOldFuncAddr, pNewFuncAddr, out pOrigialCall, bTranscation);
            return new Hook((NativeHook*)ptr);
        }
    }

    /// <summary>
    /// Gets the address of the next call instruction from a given address.
    /// </summary>
    /// <param name="pAddress">Starting address to search from.</param>
    /// <param name="dwCout">Number of call instructions to skip.</param>
    /// <returns>Address of the next call instruction.</returns>
    public nint GetNextCallAddr(nint pAddress, int dwCout)
    {
        return Base.pfnGetNextCallAddr(pAddress, dwCout);
    }

    /// <summary>
    /// Searches for a byte pattern in memory (forward search).
    /// </summary>
    /// <param name="pStartSearch">Starting address for the search.</param>
    /// <param name="dwSearchLen">Length of memory to search in bytes.</param>
    /// <param name="szPattern">Byte pattern to search for.</param>
    /// <param name="dwPatternLen">Length of the pattern in bytes.</param>
    /// <returns>Address where the pattern was found, or zero if not found.</returns>
    public nint SearchPattern(nint pStartSearch, uint dwSearchLen, byte[] szPattern, uint dwPatternLen)
    {
        nint result = nint.Zero;
        unsafe
        {
            fixed (byte* pPattern = szPattern)
            {
                result = Base.pfnSearchPattern(pStartSearch, dwSearchLen, pPattern, dwPatternLen);
            }
        }
        return result;
    }

    /// <summary>
    /// Searches for a byte pattern in memory (reverse search).
    /// </summary>
    /// <param name="pStartSearch">Starting address for the search.</param>
    /// <param name="dwSearchLen">Length of memory to search in bytes.</param>
    /// <param name="szPattern">Byte pattern to search for.</param>
    /// <param name="dwPatternLen">Length of the pattern in bytes.</param>
    /// <returns>Address where the pattern was found, or zero if not found.</returns>
    public nint ReverseSearchPattern(nint pStartSearch, uint dwSearchLen, byte[] szPattern, uint dwPatternLen)
    {
        nint result = nint.Zero;
        unsafe
        {
            fixed (byte* pPattern = szPattern)
            {
                result = Base.pfnReverseSearchPattern(pStartSearch, dwSearchLen, pPattern, dwPatternLen);
            }
        }
        return result;
    }

    /// <summary>
    /// Disassembles a single instruction at the specified address.
    /// </summary>
    /// <param name="address">Address of the instruction to disassemble.</param>
    /// <param name="fnDisasmSingleCallback">Callback function for processing the disassembled instruction.</param>
    /// <param name="context">User-defined context data passed to the callback.</param>
    /// <returns>Length of the disassembled instruction in bytes.</returns>
    public int DisasmSingleInstruction(nint address, DisasmSingleCallbackDelegate fnDisasmSingleCallback, nint context)
    {
        nint ptr = Marshal.GetFunctionPointerForDelegate(fnDisasmSingleCallback);
        return Base.pfnDisasmSingleInstruction(address, ptr, context); ;
    }

    /// <summary>
    /// Disassembles a range of instructions.
    /// </summary>
    /// <param name="disasmBase">Base address to start disassembly.</param>
    /// <param name="disasmSize">Size of the memory range to disassemble.</param>
    /// <param name="fnDisasmCallback">Callback function for processing each disassembled instruction.</param>
    /// <param name="depth">Recursion depth for following branches.</param>
    /// <param name="context">User-defined context data passed to the callback.</param>
    /// <returns>True if successful, false otherwise.</returns>
    public bool DisasmRange(nint disasmBase, uint disasmSize, DisasmCallbackDelegate fnDisasmCallback, int depth, nint context)
    {
        nint ptr = Marshal.GetFunctionPointerForDelegate(fnDisasmCallback);
        return Base.pfnDisasmRanges(disasmBase, disasmSize, ptr, depth, context) == 1;
    }

    /// <summary>
    /// Searches backwards to find the beginning of a function.
    /// </summary>
    /// <param name="searchBegin">Address to start searching backwards from.</param>
    /// <param name="searchSize">Maximum distance to search backwards.</param>
    /// <returns>Address of the function beginning, or zero if not found.</returns>
    public nint ReverseSearchFunctionBegin(nint searchBegin, uint searchSize)
    {
        return Base.pfnReverseSearchFunctionBegin(searchBegin, searchSize);
    }

    /// <summary>
    /// Searches backwards to find the beginning of a function with a custom callback.
    /// </summary>
    /// <param name="searchBegin">Address to start searching backwards from.</param>
    /// <param name="searchSize">Maximum distance to search backwards.</param>
    /// <param name="findAddressCallback">Callback function to validate potential function beginnings.</param>
    /// <returns>Address of the function beginning, or zero if not found.</returns>
    public nint ReverseSearchFuntionBeginEx(nint searchBegin, uint searchSize, FindAddressCallbackDelegate findAddressCallback)
    {
        nint ptr = Marshal.GetFunctionPointerForDelegate(findAddressCallback);
        return Base.pfnReverseSearchFunctionBeginEx(searchBegin, searchSize, ptr);
    }

    /// <summary>
    /// Closes a module handle obtained from GetModuleHandle.
    /// </summary>
    /// <param name="hModule">Module handle to close.</param>
    public void CloseModuleHandle(nint hModule)
    {
        Base.pfnCloseModuleHandle(hModule);
    }

    /// <summary>
    /// Loads a dynamic library into the process.
    /// </summary>
    /// <param name="szModuleName">Name or path of the module to load.</param>
    /// <returns>Module handle, or zero if loading failed.</returns>
    public nint LoadLibrary(string szModuleName)
    {
        nint strptr = Marshal.StringToHGlobalAnsi(szModuleName);
        nint result = nint.Zero;
        unsafe
        {
            result = Base.pfnLoadLibrary((byte*)strptr);
        }
        Marshal.FreeHGlobal(strptr);
        return result;
    }

    /// <summary>
    /// Frees a loaded dynamic library.
    /// </summary>
    /// <param name="hModule">Module handle to free.</param>
    public void FreeLibrary(nint hModule)
    {
        Base.pfnFreeLibrary(hModule);
    }

    /// <summary>
    /// Gets the address of an exported function from a module.
    /// </summary>
    /// <param name="hModule">Module handle.</param>
    /// <param name="szProcName">Name of the exported function.</param>
    /// <returns>Function address, or zero if not found.</returns>
    public nint GetProcAddress(nint hModule, string szProcName)
    {
        nint strptr = Marshal.StringToHGlobalAnsi(szProcName);
        nint result = nint.Zero;
        unsafe
        {
            result = Base.pfnGetProcAddress(hModule, (byte*)strptr);
        }
        Marshal.FreeHGlobal(strptr);
        return result;
    }

    /// <summary>
    /// Gets the server-side studio blending interface.
    /// </summary>
    /// <returns>Server studio blending interface.</returns>
    public ServerBlendInterface GetServerStudioBlendInterface()
    {
        nint ptr = nint.Zero;
        unsafe
        {
            ptr = (nint)Base.pfnGetServerStudioBlendInterface();
        }
        return new ServerBlendInterface(ptr);
    }

    /// <summary>
    /// Gets the engine-side studio blending interface.
    /// </summary>
    /// <returns>Engine studio blending interface.</returns>
    public ServerBlendInterface GetEngineStudioBlendInterface()
    {
        nint ptr = nint.Zero;
        unsafe
        {
            ptr = (nint)Base.pfnGetServerStudioBlendInterface();
        }
        return new ServerBlendInterface(ptr);
    }

    /// <summary>
    /// Gets the engine studio API interface.
    /// </summary>
    /// <returns>Engine studio API interface.</returns>
    public ServerStudioAPI GetEngineStudioAPI()
    {
        nint ptr = nint.Zero;
        unsafe
        {
            ptr = (nint)Base.pfnGetEngineStudioAPI();
        }
        return new ServerStudioAPI(ptr);
    }

    /// <summary>
    /// Gets the rotation matrix used for studio model rendering.
    /// </summary>
    /// <returns>Pointer to the rotation matrix.</returns>
    public nint GetRotationMatrix() => Base.pfnGetRotationMatrix();
    
    /// <summary>
    /// Gets the bone matrix used for studio model rendering.
    /// </summary>
    /// <returns>Pointer to the bone matrix.</returns>
    public nint GetBoneMatrix() => Base.pfnGetBoneMatrix();

    /// <summary>
    /// Gets the engine type identifier string.
    /// </summary>
    /// <returns>Engine type string (e.g., "GoldSrc", "Source").</returns>
    public string GetEngineType()
    {
        string? str = string.Empty;
        unsafe
        {
            str = Marshal.PtrToStringUTF8((nint)Base.pfnGetEngineType());
        }
        return str ?? string.Empty;
    }
}
