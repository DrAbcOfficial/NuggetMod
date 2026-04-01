using NuggetMod.Native.Common;
using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native structure representing global server variables.
/// Contains server state, timing, and trace result information.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeGlobalVars : INativeStruct
{
    /// <summary>
    /// Current server time in seconds.
    /// </summary>
    internal float time;
    /// <summary>
    /// Duration of current frame in seconds.
    /// </summary>
    internal float frametime;
    internal float force_retouch;
    internal NativeStringHandle mapname;
    internal NativeStringHandle startspot;
    internal float deathmatch;
    internal float coop;
    internal float teamplay;
    internal float serverflags;
    internal float found_secrets;
    internal NativeVector3f v_forward;
    internal NativeVector3f v_up;
    internal NativeVector3f v_right;
    internal float trace_allsolid;
    internal float trace_startsolid;
    internal float trace_fraction;
    internal NativeVector3f trace_endpos;
    internal NativeVector3f trace_plane_normal;
    internal float trace_plane_dist;
    internal nint trace_ent;
    internal float trace_inopen;
    internal float trace_inwater;
    internal int trace_hitgroup;
    internal int trace_flags;
    internal int msg_entity;
    internal int cdAudioTrack;
    internal int maxClients;
    internal int maxEntities;
    internal nint pStringBase;

    internal nint pSaveData;
    internal NativeVector3f vecLandmarkOffset;
}
