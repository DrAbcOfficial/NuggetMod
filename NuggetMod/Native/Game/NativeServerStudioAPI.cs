using System.Runtime.InteropServices;

namespace NuggetMod.Native.Game;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal delegate nint Mem_CallocDelegate(int number, uint size);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal delegate nint Cache_CheckDelegate(nint cacheUser);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate void LoadCacheFileDelegate(byte* path, nint cacheUser);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal delegate nint Mod_ExtradataDelegate(nint model);

/// <summary>
/// Native Server Studio API
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeServerStudioAPI : INativeStruct
{
    internal Mem_CallocDelegate Mem_Calloc;
    internal Cache_CheckDelegate Cache_Check;
    internal LoadCacheFileDelegate LoadCacheFile;
    internal Mod_ExtradataDelegate Mod_Extradata;
}
