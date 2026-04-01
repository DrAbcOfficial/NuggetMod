using System.Runtime.InteropServices;

namespace NuggetMod.Native.Metamod;

/// <summary>
/// Native Meta Game DLL Functions
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeMetaGameDLLFunctions : INativeStruct
{
    internal nint dllapi_table;
    internal nint newapi_table;

    // 2022-07-02 Added by hzqst
    internal nint studio_blend_api;
}