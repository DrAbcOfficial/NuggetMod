using System.Runtime.InteropServices;

namespace NuggetMod.Native.Common;

/// <summary>
/// Native structure representing a user command from the client.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeUserCmd : INativeStruct
{
    /// <summary>
    /// Interpolation time on client in milliseconds.
    /// </summary>
    internal short lerp_msec;
    /// <summary>
    /// Duration in milliseconds of command.
    /// </summary>
    internal byte msec;
    /// <summary>
    /// Command view angles.
    /// </summary>
    internal NativeVector3f viewangles;

    /// <summary>
    /// Forward velocity.
    /// </summary>
    internal float forwardmove;
    /// <summary>
    /// Sideways velocity.
    /// </summary>
    internal float sidemove;
    /// <summary>
    /// Upward velocity.
    /// </summary>
    internal float upmove;
    /// <summary>
    /// Light level at spot where player is standing.
    /// </summary>
    internal byte lightlevel;
    /// <summary>
    /// Attack buttons pressed.
    /// </summary>
    internal ushort buttons;
    /// <summary>
    /// Impulse command issued.
    /// </summary>
    internal byte impulse;
    /// <summary>
    /// Current weapon ID selected.
    /// </summary>
    internal byte weaponselect;

    /// <summary>
    /// Experimental player impact index.
    /// </summary>
    internal int impact_index;
    /// <summary>
    /// Experimental player impact position.
    /// </summary>
    internal NativeVector3f impact_position;
}
