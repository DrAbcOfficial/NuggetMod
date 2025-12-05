using NuggetMod.Enum.NuggetMod;
using NuggetMod.Native.Engine.PM;
using NuggetMod.Wrapper.Common;
using System.Text;

namespace NuggetMod.Wrapper.Engine.PM;

/// <summary>
/// Represents player movement state and parameters
/// </summary>
public class PlayerMove : BaseNativeWrapper<NativePlayerMove>
{
    internal unsafe PlayerMove(nint ptr) : base((NativePlayerMove*)ptr) { }
    
    /// <summary>
    /// Gets or sets the player index
    /// </summary>
    public int PlayerIndex
    {
        get
        {
            unsafe
            {
                return NativePtr->player_index;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->player_index = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether this is running on the server
    /// </summary>
    public bool Server
    {
        get
        {
            unsafe
            {
                return NativePtr->server == 1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->server = value ? 1 : 0;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether this is a multiplayer game
    /// </summary>
    public bool Multiplayer
    {
        get
        {
            unsafe
            {
                return NativePtr->multiplayer == 1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->multiplayer = value ? 1 : 0;
            }
        }
    }

    /// <summary>
    /// Gets or sets the current game time
    /// </summary>
    public float Time
    {
        get
        {
            unsafe
            {
                return NativePtr->time;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->time = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the duration of the current frame
    /// </summary>
    public float FrameTime
    {
        get
        {
            unsafe
            {
                return NativePtr->frametime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->frametime = value;
            }
        }
    }

    private Vector3f? _forward;
    /// <summary>
    /// Gets the forward direction vector
    /// </summary>
    public Vector3f Forward
    {
        get
        {
            unsafe
            {
                _forward ??= new Vector3f(&NativePtr->forward);
                return _forward;
            }
        }
    }

    private Vector3f? _right;
    /// <summary>
    /// Gets the right direction vector
    /// </summary>
    public Vector3f Right
    {
        get
        {
            unsafe
            {
                _right ??= new Vector3f(&NativePtr->right);
                return _right;
            }
        }
    }

    private Vector3f? _up;
    /// <summary>
    /// Gets the up direction vector
    /// </summary>
    public Vector3f Up
    {
        get
        {
            unsafe
            {
                _up ??= new Vector3f(&NativePtr->up);
                return _up;
            }
        }
    }

    private Vector3f? _origin;
    /// <summary>
    /// Gets the player origin position
    /// </summary>
    public Vector3f Origin
    {
        get
        {
            unsafe
            {
                _origin ??= new Vector3f(&NativePtr->origin);
                return _origin;
            }
        }
    }

    private Vector3f? _angles;
    /// <summary>
    /// Gets the player view angles
    /// </summary>
    public Vector3f Angles
    {
        get
        {
            unsafe
            {
                _angles ??= new Vector3f(&NativePtr->angles);
                return _angles;
            }
        }
    }

    private Vector3f? _oldAngles;
    /// <summary>
    /// Gets the previous frame's view angles
    /// </summary>
    public Vector3f OldAngles
    {
        get
        {
            unsafe
            {
                _oldAngles ??= new Vector3f(&NativePtr->oldangles);
                return _oldAngles;
            }
        }
    }

    private Vector3f? _velocity;
    /// <summary>
    /// Gets the player velocity
    /// </summary>
    public Vector3f Velocity
    {
        get
        {
            unsafe
            {
                _velocity ??= new Vector3f(&NativePtr->velocity);
                return _velocity;
            }
        }
    }

    private Vector3f? _moveDir;
    /// <summary>
    /// Gets the movement direction
    /// </summary>
    public Vector3f MoveDir
    {
        get
        {
            unsafe
            {
                _moveDir ??= new Vector3f(&NativePtr->movedir);
                return _moveDir;
            }
        }
    }

    private Vector3f? _baseVelocity;
    /// <summary>
    /// Gets the base velocity (from conveyor belts, etc.)
    /// </summary>
    public Vector3f BaseVelocity
    {
        get
        {
            unsafe
            {
                _baseVelocity ??= new Vector3f(&NativePtr->basevelocity);
                return _baseVelocity;
            }
        }
    }

    private Vector3f? _viewOfs;
    /// <summary>
    /// Gets the view offset from the player origin
    /// </summary>
    public Vector3f ViewOfs
    {
        get
        {
            unsafe
            {
                _viewOfs ??= new Vector3f(&NativePtr->view_ofs);
                return _viewOfs;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time spent ducking
    /// </summary>
    public float DuckTime
    {
        get
        {
            unsafe
            {
                return NativePtr->flDuckTime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->flDuckTime = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the player is currently ducking
    /// </summary>
    public bool InDuck
    {
        get
        {
            unsafe
            {
                return NativePtr->bInDuck == 1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->bInDuck = value ? 1 : 0;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time when the next footstep sound should play
    /// </summary>
    public int FlTimeStepSound
    {
        get
        {
            unsafe
            {
                return NativePtr->flTimeStepSound;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->flTimeStepSound = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets which foot to use for the next footstep (0 = right, 1 = left)
    /// </summary>
    public int IStepLeft
    {
        get
        {
            unsafe
            {
                return NativePtr->iStepLeft;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iStepLeft = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the velocity at which the player is falling (used for fall damage calculation)
    /// </summary>
    public float FlFallVelocity
    {
        get
        {
            unsafe
            {
                return NativePtr->flFallVelocity;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->flFallVelocity = value;
            }
        }
    }

    /// <summary>
    /// Gets the view punch angle (weapon recoil, damage feedback)
    /// </summary>
    private Vector3f? _punchAngle;
    
    /// <summary>
    /// Gets the view punch angle (weapon recoil, damage feedback)
    /// </summary>
    public Vector3f PunchAngle
    {
        get
        {
            unsafe
            {
                _punchAngle ??= new Vector3f(&NativePtr->punchangle);
                return _punchAngle;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time spent swimming (used for swim sound timing)
    /// </summary>
    public float FlSwimTime
    {
        get
        {
            unsafe
            {
                return NativePtr->flSwimTime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->flSwimTime = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time when the next primary attack can occur
    /// </summary>
    public float FlNextPrimaryAttack
    {
        get
        {
            unsafe
            {
                return NativePtr->flNextPrimaryAttack;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->flNextPrimaryAttack = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity effects flags (EF_BRIGHTFIELD, EF_MUZZLEFLASH, etc.)
    /// </summary>
    public int Effects
    {
        get
        {
            unsafe
            {
                return NativePtr->effects;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->effects = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the player flags (FL_ONGROUND, FL_DUCKING, FL_WATERJUMP, FL_FROZEN, etc.)
    /// </summary>
    public int Flags
    {
        get
        {
            unsafe
            {
                return NativePtr->flags;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->flags = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the hull size to use for collision detection (0=point, 1=human, 2=large, 3=head)
    /// </summary>
    public int UseHull
    {
        get
        {
            unsafe
            {
                return NativePtr->usehull;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->usehull = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the gravity multiplier for this player (1.0 = normal gravity)
    /// </summary>
    public float Gravity
    {
        get
        {
            unsafe
            {
                return NativePtr->gravity;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->gravity = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the friction multiplier for this player (1.0 = normal friction)
    /// </summary>
    public float Friction
    {
        get
        {
            unsafe
            {
                return NativePtr->friction;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->friction = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the button state from the previous frame (for detecting button press/release)
    /// </summary>
    public int OldButtons
    {
        get
        {
            unsafe
            {
                return NativePtr->oldbuttons;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->oldbuttons = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time when water jump ends (prevents movement control during water jump)
    /// </summary>
    public float WaterJumpTime
    {
        get
        {
            unsafe
            {
                return NativePtr->waterjumptime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->waterjumptime = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the player is dead
    /// </summary>
    public bool Dead
    {
        get
        {
            unsafe
            {
                return NativePtr->dead == 1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->dead = value ? 1 : 0;
            }
        }
    }

    /// <summary>
    /// Gets or sets the dead flag state (DEAD_NO, DEAD_DYING, DEAD_DEAD, DEAD_RESPAWNABLE)
    /// </summary>
    public int DeadFlag
    {
        get
        {
            unsafe
            {
                return NativePtr->deadflag;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->deadflag = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the player is in spectator mode
    /// </summary>
    public int Spectator
    {
        get
        {
            unsafe
            {
                return NativePtr->spectator;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->spectator = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the player's movement type (MOVETYPE_WALK, MOVETYPE_NOCLIP, MOVETYPE_FLY, etc.)
    /// </summary>
    public int MoveType
    {
        get
        {
            unsafe
            {
                return NativePtr->movetype;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->movetype = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity index the player is standing on (-1 if not on ground)
    /// </summary>
    public int OnGround
    {
        get
        {
            unsafe
            {
                return NativePtr->onground;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->onground = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the water level (0=not in water, 1=feet, 2=waist, 3=head underwater)
    /// </summary>
    public int WaterLevel
    {
        get
        {
            unsafe
            {
                return NativePtr->waterlevel;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->waterlevel = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the type of water the player is in (CONTENTS_WATER, CONTENTS_SLIME, CONTENTS_LAVA)
    /// </summary>
    public int WaterType
    {
        get
        {
            unsafe
            {
                return NativePtr->watertype;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->watertype = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the water level from the previous frame (for detecting water entry/exit)
    /// </summary>
    public int OldWaterLevel
    {
        get
        {
            unsafe
            {
                return NativePtr->oldwaterlevel;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->oldwaterlevel = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the name of the texture the player is standing on
    /// </summary>
    public string SzTextureName
    {
        get
        {
            unsafe
            {
                byte[] buffer = new byte[256];
                fixed (byte* managedPtr = buffer)
                {
                    byte* nativePtr = NativePtr->sztexturename;
                    for (int i = 0; i < 256; i++)
                    {
                        managedPtr[i] = nativePtr[i];
                    }
                }
                return Encoding.UTF8.GetString(buffer);
            }
        }
        set
        {
            unsafe
            {
                ArgumentNullException.ThrowIfNull(value);
                byte[] bytes = Encoding.UTF8.GetBytes(value);
                if (bytes.Length > 256)
                    throw new ArgumentOutOfRangeException(nameof(value), "Texture name length cannot exceed 256 bytes");
                for (int i = 0; i < 256; i++)
                {
                    NativePtr->sztexturename[i] = i < bytes.Length ? bytes[i] : (byte)0;
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets the material type of the texture the player is standing on (for footstep sounds)
    /// </summary>
    public byte ChTextureType
    {
        get
        {
            unsafe
            {
                return NativePtr->chtexturetype;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->chtexturetype = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the maximum movement speed for the player
    /// </summary>
    public float MaxSpeed
    {
        get
        {
            unsafe
            {
                return NativePtr->maxspeed;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->maxspeed = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the client-side maximum speed (can be different from server maxspeed)
    /// </summary>
    public float ClientMaxSpeed
    {
        get
        {
            unsafe
            {
                return NativePtr->clientmaxspeed;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->clientmaxspeed = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined integer variable 1
    /// </summary>
    public int IUser1
    {
        get
        {
            unsafe
            {
                return NativePtr->iuser1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iuser1 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined integer variable 2 (game-specific usage)
    /// </summary>
    public int IUser2
    {
        get
        {
            unsafe
            {
                return NativePtr->iuser2;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iuser2 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined integer variable 3 (game-specific usage)
    /// </summary>
    public int IUser3
    {
        get
        {
            unsafe
            {
                return NativePtr->iuser3;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iuser3 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined integer variable 4 (game-specific usage)
    /// </summary>
    public int IUser4
    {
        get
        {
            unsafe
            {
                return NativePtr->iuser4;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iuser4 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined float variable 1 (game-specific usage)
    /// </summary>
    public float FUser1
    {
        get
        {
            unsafe
            {
                return NativePtr->fuser1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fuser1 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined float variable 2 (game-specific usage)
    /// </summary>
    public float FUser2
    {
        get
        {
            unsafe
            {
                return NativePtr->fuser2;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fuser2 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined float variable 3 (game-specific usage)
    /// </summary>
    public float FUser3
    {
        get
        {
            unsafe
            {
                return NativePtr->fuser3;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fuser3 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined float variable 4 (game-specific usage)
    /// </summary>
    public float FUser4
    {
        get
        {
            unsafe
            {
                return NativePtr->fuser4;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fuser4 = value;
            }
        }
    }

    /// <summary>
    /// Gets user-defined vector variable 1 (game-specific usage)
    /// </summary>
    private Vector3f? _vUser1;
    
    /// <summary>
    /// Gets user-defined vector variable 1 (game-specific usage)
    /// </summary>
    public Vector3f VUser1
    {
        get
        {
            unsafe
            {
                _vUser1 ??= new Vector3f(&NativePtr->vuser1);
                return _vUser1;
            }
        }
    }

    /// <summary>
    /// Gets user-defined vector variable 2 (game-specific usage)
    /// </summary>
    private Vector3f? _vUser2;
    
    /// <summary>
    /// Gets user-defined vector variable 2 (game-specific usage)
    /// </summary>
    public Vector3f VUser2
    {
        get
        {
            unsafe
            {
                _vUser2 ??= new Vector3f(&NativePtr->vuser2);
                return _vUser2;
            }
        }
    }

    /// <summary>
    /// Gets user-defined vector variable 3 (game-specific usage)
    /// </summary>
    private Vector3f? _vUser3;
    
    /// <summary>
    /// Gets user-defined vector variable 3 (game-specific usage)
    /// </summary>
    public Vector3f VUser3
    {
        get
        {
            unsafe
            {
                _vUser3 ??= new Vector3f(&NativePtr->vuser3);
                return _vUser3;
            }
        }
    }

    /// <summary>
    /// Gets user-defined vector variable 4 (game-specific usage)
    /// </summary>
    private Vector3f? _vUser4;
    
    /// <summary>
    /// Gets user-defined vector variable 4 (game-specific usage)
    /// </summary>
    public Vector3f VUser4
    {
        get
        {
            unsafe
            {
                _vUser4 ??= new Vector3f(&NativePtr->vuser4);
                return _vUser4;
            }
        }
    }

    /// <summary>
    /// Gets or sets the number of physical entities for collision detection
    /// </summary>
    public int NumPhysEnt
    {
        get
        {
            unsafe
            {
                return NativePtr->numphysent;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->numphysent = value;
            }
        }
    }
}