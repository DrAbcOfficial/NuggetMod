using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native structure representing key-value data for entity spawning.
/// Used to pass entity properties from map files to the game DLL.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeKeyValueData : INativeStruct
{
    /// <summary>
    /// Entity class name (input).
    /// </summary>
    internal nint szClassName;
    /// <summary>
    /// Name of the key (input).
    /// </summary>
    internal nint szKeyName;
    /// <summary>
    /// Value of the key (input).
    /// </summary>
    internal nint szValue;
    /// <summary>
    /// DLL sets to true if key-value pair was understood (output).
    /// </summary>
    internal int fHandled;
}
