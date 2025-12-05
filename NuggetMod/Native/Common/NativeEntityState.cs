using System.Runtime.InteropServices;

namespace NuggetMod.Native.Common;

/// <summary>
/// Native structure representing entity state for network transmission.
/// Contains fields for delta compression and network synchronization.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeEntityState : INativeStruct
{
    /// <summary>
    /// Entity type identifier.
    /// </summary>
    internal int entityType;
    /// <summary>
    /// Index into cl_entities array for this entity.
    /// </summary>
    internal int number;
    internal float msg_time;

    // Message number last time the player/entity state was updated.
    internal int messagenum;

    // Fields which can be transitted and reconstructed over the network stream
    internal NativeVector3f origin;
    internal NativeVector3f angles;

    internal int modelindex;
    internal int sequence;
    internal float frame;
    internal int colormap;
    internal short skin;
    internal short solid;
    internal int effects;
    internal float scale;

    internal byte eflags;

    // Render information
    internal int rendermode;
    internal int renderamt;
    internal int rendercolor;
    internal int renderfx;

    internal int movetype;
    internal float animtime;
    internal float framerate;
    internal int body;

    internal unsafe fixed byte controller[4];
    internal unsafe fixed byte blending[4];
    internal NativeVector3f velocity;

    // Send bbox down to client for use during prediction.
    internal NativeVector3f mins;
    internal NativeVector3f maxs;

    internal int aiment;
    // If owned by a player, the index of that player ( for projectiles ).
    internal int owner;

    // Friction, for prediction.
    internal float friction;
    // Gravity multiplier
    internal float gravity;

    // PLAYER SPECIFIC
    internal int team;
    internal int playerclass;
    internal int health;
    internal int spectator;
    internal int weaponmodel;
    internal int gaitsequence;
    // If standing on conveyor, e.g.
    internal NativeVector3f basevelocity;
    // Use the crouched hull, or the regular player hull.
    internal int usehull;
    // Latched buttons last time state updated.
    internal int oldbuttons;
    // -1 = in air, else pmove entity number
    internal int onground;
    internal int iStepLeft;
    // How fast we are falling
    internal float flFallVelocity;

    internal float fov;
    internal int weaponanim;

    // Parametric movement overrides
    internal NativeVector3f startpos;
    internal NativeVector3f endpos;
    internal float impacttime;
    internal float starttime;

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
