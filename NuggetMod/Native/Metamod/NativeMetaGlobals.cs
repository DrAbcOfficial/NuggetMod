using NuggetMod.Enum.NuggetMod;
using System.Runtime.InteropServices;

namespace NuggetMod.Native.NuggetMod;

/// <summary>
/// Native MetaMod Globals
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeMetaGlobals : INativeStruct
{
    internal MetaResult mres;          // writable; plugin's return flag
    internal MetaResult prev_mres;     // readable; return flag of the previous plugin called
    internal MetaResult status;        // readable; "highest" return flag so far
    internal nint orig_ret;         // readable; return value from "real" function
    internal nint override_ret;     // readable; return value from overriding/superceding plugin
}
