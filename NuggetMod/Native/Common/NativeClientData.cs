using System.Runtime.InteropServices;

namespace NuggetMod.Native.Common;

/// <summary>
/// Native structure representing client-specific data sent to the client for prediction and rendering.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeClientData : INativeStruct
{
    /// <summary>
    /// Client origin position.
    /// </summary>
    internal NativeVector3f origin;
    /// <summary>
    /// Client velocity.
    /// </summary>
    internal NativeVector3f velocity;

    internal int viewmodel;
    internal NativeVector3f punchangle;
    internal int flags;
    internal int waterlevel;
    internal int watertype;
    internal NativeVector3f view_ofs;
    internal float health;

    internal int bInDuck;

    internal int weapons; // remove?

    internal int flTimeStepSound;
    internal int flDuckTime;
    internal int flSwimTime;
    internal int waterjumptime;

    internal float maxspeed;

    internal float fov;
    internal int weaponanim;

    internal int m_iId;
    internal int ammo_shells;
    internal int ammo_nails;
    internal int ammo_cells;
    internal int ammo_rockets;
    internal float m_flNextAttack;

    internal int tfstate;

    internal int pushmsec;

    internal int deadflag;

    internal unsafe fixed byte physinfo[256];

    // For mods
    internal int iuser1;
    internal int iuser2;
    internal int iuser3;
    internal int iuser4;
    internal float fuser1;
    internal float fuser2;
    internal float fuser3;
    internal float fuser4;
    internal NativeVector3f vuser1;
    internal NativeVector3f vuser2;
    internal NativeVector3f vuser3;
    internal NativeVector3f vuser4;
}
