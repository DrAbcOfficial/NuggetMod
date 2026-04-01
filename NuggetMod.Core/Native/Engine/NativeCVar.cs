using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native structure representing a console variable (cvar).
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeCVar : INativeStruct
{
    /// <summary>
    /// Pointer to the cvar name string.
    /// </summary>
    internal nint name;
    /// <summary>
    /// Pointer to the cvar string value.
    /// </summary>
    internal nint str;
    /// <summary>
    /// Cvar flags (e.g., FCVAR_ARCHIVE, FCVAR_SERVER).
    /// </summary>
    internal int flags;
    /// <summary>
    /// Numeric value of the cvar.
    /// </summary>
    internal float value;
    /// <summary>
    /// Pointer to the next cvar in the linked list.
    /// </summary>
    internal nint next;
}
