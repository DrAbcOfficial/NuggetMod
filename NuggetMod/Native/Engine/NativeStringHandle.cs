using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native structure representing a handle to a string in the engine's string pool.
/// The value is an offset from the string base pointer.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeStringHandle : INativeStruct
{
    /// <summary>
    /// Offset value from the string base pointer.
    /// </summary>
    internal int value;
}
