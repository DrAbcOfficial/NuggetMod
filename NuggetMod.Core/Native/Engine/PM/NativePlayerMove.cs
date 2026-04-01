using NuggetMod.Native.Common;
using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine.PM;
/// <summary>
/// native structure representing player movement data for physics calculations.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativePlayerMove : INativeStruct
{
    internal int player_index;  // So we don't try to run the PM_CheckStuck nudging too quickly.
    internal int server;        // For debugging, are we running physics code on server side?

    internal int multiplayer;   // 1 == multiplayer server
    internal float time;          // realtime on host, for reckoning duck timing
    internal float frametime;       // Duration of this frame

    internal NativeVector3f forward, right, up; // Vectors for angles
                                                // player state
    internal NativeVector3f origin;        // Movement origin.
    internal NativeVector3f angles;        // Movement view angles.
    internal NativeVector3f oldangles;     // Angles before movement view angles were looked at.
    internal NativeVector3f velocity;      // Current movement direction.
    internal NativeVector3f movedir;       // For waterjumping, a forced forward velocity so we can fly over lip of ledge.
    internal NativeVector3f basevelocity;  // Velocity of the conveyor we are standing, e.g.

    // For ducking/dead
    internal NativeVector3f view_ofs;      // Our eye position.
    internal float flDuckTime;    // Time we started duck
    internal int bInDuck;       // In process of ducking or ducked already?

    // For walking/falling
    internal int flTimeStepSound;  // Next time we can play a step sound
    internal int iStepLeft;

    internal float flFallVelocity;
    internal NativeVector3f punchangle;

    internal float flSwimTime;

    internal float flNextPrimaryAttack;

    internal int effects;        // MUZZLE FLASH, e.g.

    internal int flags;         // FL_ONGROUND, FL_DUCKING, etc.
    internal int usehull;       // 0 = regular player hull, 1 = ducked player hull, 2 = point hull
    internal float gravity;       // Our current gravity and friction.
    internal float friction;
    internal int oldbuttons;    // Buttons last usercmd
    internal float waterjumptime; // Amount of time left in jumping out of water cycle.
    internal int dead;          // Are we a dead player?
    internal int deadflag;
    internal int spectator;     // Should we use spectator physics model?
    internal int movetype;      // Our movement type, NOCLIP, WALK, FLY

    internal int onground;
    internal int waterlevel;
    internal int watertype;
    internal int oldwaterlevel;

    internal unsafe fixed byte sztexturename[256];
    internal byte chtexturetype;

    internal float maxspeed;
    internal float clientmaxspeed; // Player specific maxspeed

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
    // world state
    // Number of entities to clip against.
    internal int numphysent;
    internal unsafe fixed byte physents[16384];
    
    // Number of movement entities (ladders)
    internal int nummoveent;
    internal unsafe fixed byte moveents[16384];
    
    // All things being rendered, for tracing against things you don't actually collide with
    internal int numvisent;
    internal unsafe fixed byte visents[16384];

    // input to run through physics.
    internal NativeUserCmd cmd;

    // Trace results for objects we collided with.
    internal int numtouch;
    internal unsafe fixed byte touchindex[1280];

    internal unsafe fixed byte physinfo[256]; // Physics info string

    internal nint movevars;
    internal unsafe fixed byte player_mins[48];
    internal unsafe fixed byte player_maxs[48];

    // Common functions
    internal nint PM_Info_ValueForKey;
    internal nint PM_Particle;
    internal nint PM_TestPlayerPosition;
    internal nint Con_NPrintf;
    internal nint Con_DPrintf;
    internal nint Con_Printf;
    internal nint Sys_FloatTime;
    internal nint PM_StuckTouch;
    internal nint PM_PointContents;
    internal nint PM_TruePointContents;
    internal nint PM_HullPointContents;
    internal nint PM_PlayerTrace;
    internal nint PM_TraceLine;
    internal nint RandomLong;
    internal nint RandomFloat;
    internal nint PM_GetModelType;
    internal nint PM_GetModelBounds;
    internal nint PM_HullForBsp;
    internal nint PM_TraceModel;
    internal nint COM_FileSize;
    internal nint COM_LoadFile;
    internal nint COM_FreeFile;
    internal nint memfgets;

    // Functions
    // Run functions for this frame?
    internal int runfuncs;
    internal nint PM_PlaySound;
    internal nint PM_TraceTexture;
    internal nint PM_PlaybackEventFull;

    internal nint PM_PlayerTraceEx;
    internal nint PM_TestPlayerPositionEx;
    internal nint PM_TraceLineEx;

}
