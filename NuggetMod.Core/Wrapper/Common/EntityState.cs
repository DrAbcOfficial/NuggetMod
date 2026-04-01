using NuggetMod.Native.Common;

namespace NuggetMod.Wrapper.Common;

/// <summary>
/// Represents the network state of an entity
/// </summary>
public class EntityState : BaseNativeWrapper<NativeEntityState>
{
    internal unsafe EntityState(nint ptr) : this((NativeEntityState*)ptr) { }
    internal unsafe EntityState(NativeEntityState* nativePtr, bool ownsPointer = false) : base(nativePtr, ownsPointer) { }
    
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public EntityState() : base() { }

    /// <summary>
    /// Gets or sets the entity type
    /// </summary>
    public int EntityType
    {
        get
        {
            unsafe
            {
                return NativePtr->entityType;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->entityType = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity number
    /// </summary>
    public int Number
    {
        get
        {
            unsafe
            {
                return NativePtr->number;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->number = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the message time for network synchronization
    /// </summary>
    public float MsgTime
    {
        get
        {
            unsafe
            {
                return NativePtr->msg_time;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->msg_time = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the message number for delta compression
    /// </summary>
    public int MessageNum
    {
        get
        {
            unsafe
            {
                return NativePtr->messagenum;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->messagenum = value;
            }
        }
    }

    private Vector3f? _origin;
    /// <summary>
    /// Gets the entity origin position
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
    /// Gets the entity angles (pitch, yaw, roll)
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

    /// <summary>
    /// Gets or sets the model index
    /// </summary>
    public int ModelIndex
    {
        get
        {
            unsafe
            {
                return NativePtr->modelindex;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->modelindex = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the animation sequence number
    /// </summary>
    public int Sequence
    {
        get
        {
            unsafe
            {
                return NativePtr->sequence;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->sequence = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the animation frame
    /// </summary>
    public float Frame
    {
        get
        {
            unsafe
            {
                return NativePtr->frame;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->frame = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the color map for player models
    /// </summary>
    public int Colormap
    {
        get
        {
            unsafe
            {
                return NativePtr->colormap;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->colormap = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the model skin number
    /// </summary>
    public short Skin
    {
        get
        {
            unsafe
            {
                return NativePtr->skin;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->skin = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the solid type for collision
    /// </summary>
    public short Solid
    {
        get
        {
            unsafe
            {
                return NativePtr->solid;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->solid = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the visual effects flags
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
    /// Gets or sets the model scale multiplier
    /// </summary>
    public float Scale
    {
        get
        {
            unsafe
            {
                return NativePtr->scale;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->scale = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity flags
    /// </summary>
    public byte EFlags
    {
        get
        {
            unsafe
            {
                return NativePtr->eflags;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->eflags = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the render mode (normal, additive, etc.)
    /// </summary>
    public int RenderMode
    {
        get
        {
            unsafe
            {
                return NativePtr->rendermode;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->rendermode = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the render amount (transparency level)
    /// </summary>
    public int RenderAmt
    {
        get
        {
            unsafe
            {
                return NativePtr->renderamt;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->renderamt = value;
            }
        }
    }

    /// <summary>
    /// Gets the render color (RGB)
    /// </summary>
    public Color24 RenderColor
    {
        get
        {
            unsafe
            {
                return new Color24(NativePtr->rendercolor);
            }
        }
    }

    /// <summary>
    /// Gets or sets the render effects
    /// </summary>
    public int RenderFx
    {
        get
        {
            unsafe
            {
                return NativePtr->renderfx;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->renderfx = value;
            }
        }
    }
    /// <summary>
    /// Gets or sets the movement type identifier for the object.
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
    /// Get studio model animate time
    /// </summary>
    public float AnimTime
    {
        get
        {
            unsafe
            {
                return NativePtr->animtime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->animtime = value;
            }
        }
    }
    /// <summary>
    /// Get studio model frame rate
    /// </summary>
    public float FrameRate
    {
        get
        {
            unsafe
            {
                return NativePtr->framerate;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->framerate = value;
            }
        }
    }
    /// <summary>
    /// Get studio model body
    /// </summary>

    public int Body
    {
        get
        {
            unsafe
            {
                return NativePtr->body;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->body = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the bone controller values (4 bytes)
    /// </summary>
    public byte[] Controller
    {
        get
        {
            unsafe
            {
                byte[] controller = new byte[4];
                fixed (byte* ptr = controller)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        ptr[i] = NativePtr->controller[i];
                    }
                }
                return controller;
            }
        }
        set
        {
            unsafe
            {
                if (value.Length != 4)
                    throw new ArgumentException("Controller array must be 4 bytes long", nameof(value));

                fixed (byte* ptr = value)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        NativePtr->controller[i] = ptr[i];
                    }
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets the animation blending values (4 bytes)
    /// </summary>
    public byte[] Blending
    {
        get
        {
            unsafe
            {
                byte[] blending = new byte[4];
                fixed (byte* ptr = blending)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        ptr[i] = NativePtr->blending[i];
                    }
                }
                return blending;
            }
        }
        set
        {
            unsafe
            {
                if (value.Length != 4)
                    throw new ArgumentException("Blending array must be 4 bytes long", nameof(value));

                fixed (byte* ptr = value)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        NativePtr->blending[i] = ptr[i];
                    }
                }
            }
        }
    }

    private Vector3f? _velocity;
    /// <summary>
    /// Gets the entity velocity
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

    private Vector3f? _mins;
    /// <summary>
    /// Gets the minimum bounding box coordinates
    /// </summary>
    public Vector3f Mins
    {
        get
        {
            unsafe
            {
                _mins ??= new Vector3f(&NativePtr->mins);
                return _mins;
            }
        }
    }

    private Vector3f? _maxs;
    /// <summary>
    /// Gets the maximum bounding box coordinates
    /// </summary>
    public Vector3f Maxs
    {
        get
        {
            unsafe
            {
                _maxs ??= new Vector3f(&NativePtr->maxs);
                return _maxs;
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity this entity is aiming at
    /// </summary>
    public int AimEnt
    {
        get
        {
            unsafe
            {
                return NativePtr->aiment;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->aiment = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the owner entity index
    /// </summary>
    public int Owner
    {
        get
        {
            unsafe
            {
                return NativePtr->owner;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->owner = value;
            }
        }
    }
    /// <summary>
    /// Get move friction
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
    /// Get gravity
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
    /// Team, for Team Death match
    /// </summary>
    public int Team
    {
        get
        {
            unsafe
            {
                return NativePtr->team;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->team = value;
            }
        }
    }
    /// <summary>
    /// Player class
    /// </summary>
    public int PlayerClass
    {
        get
        {
            unsafe
            {
                return NativePtr->playerclass;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->playerclass = value;
            }
        }
    }
    /// <summary>
    /// Health
    /// </summary>
    public int Health
    {
        get
        {
            unsafe
            {
                return NativePtr->health;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->health = value;
            }
        }
    }
    /// <summary>
    /// Is spectator
    /// </summary>
    public bool Spectator
    {
        get
        {
            unsafe
            {
                return NativePtr->spectator == 1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->spectator = value ? 1 : 0;
            }
        }
    }
    /// <summary>
    /// Weapon model index
    /// </summary>
    public int WeaponModel
    {
        get
        {
            unsafe
            {
                return NativePtr->weaponmodel;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->weaponmodel = value;
            }
        }
    }
    /// <summary>
    /// Gait sequence, for studio model blend
    /// </summary>
    public int GaitSequence
    {
        get
        {
            unsafe
            {
                return NativePtr->gaitsequence;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->gaitsequence = value;
            }
        }
    }

    private Vector3f? _baseVelocity;
    /// <summary>
    /// Base veloctiy
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
    /// <summary>
    /// Use hull
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
    /// Old pressed buttons
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
    /// Is on ground or not
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
    /// Step left
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
    /// Fall velocity
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
    /// FOV
    /// </summary>
    public float Fov
    {
        get
        {
            unsafe
            {
                return NativePtr->fov;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fov = value;
            }
        }
    }
    /// <summary>
    /// Weapon animation index
    /// </summary>
    public int WeaponAnim
    {
        get
        {
            unsafe
            {
                return NativePtr->weaponanim;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->weaponanim = value;
            }
        }
    }

    private Vector3f? _startPos;
    /// <summary>
    /// Beam or laser start position
    /// </summary>
    public Vector3f StartPos
    {
        get
        {
            unsafe
            {
                _startPos ??= new Vector3f(&NativePtr->startpos);
                return _startPos;
            }
        }
    }

    private Vector3f? _endPos;
    /// <summary>
    /// Beam or laser end position
    /// </summary>
    public Vector3f EndPos
    {
        get
        {
            unsafe
            {
                _endPos ??= new Vector3f(&NativePtr->endpos);
                return _endPos;
            }
        }
    }
    /// <summary>
    /// Impact time
    /// </summary>
    public float ImpactTime
    {
        get
        {
            unsafe
            {
                return NativePtr->impacttime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->impacttime = value;
            }
        }
    }
    /// <summary>
    /// Start time
    /// </summary>
    public float StartTime
    {
        get
        {
            unsafe
            {
                return NativePtr->starttime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->starttime = value;
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
    /// Gets or sets user-defined integer variable 2
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
    /// Gets or sets user-defined integer variable 3
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
    /// Gets or sets user-defined integer variable 4
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
    /// Gets or sets user-defined float variable 1
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
    /// Gets or sets user-defined float variable 2
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
    /// Gets or sets user-defined float variable 3
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
    /// Gets or sets user-defined float variable 4
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

    
    private Vector3f? _vUser1;
    /// <summary>
    /// Gets user-defined vector variable 1
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

    
    private Vector3f? _vUser2;
    /// <summary>
    /// Gets user-defined vector variable 2
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

    
    private Vector3f? _vUser3;
    /// <summary>
    /// Gets user-defined vector variable 3
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

    
    private Vector3f? _vUser4;
    /// <summary>
    /// Gets user-defined vector variable 4
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
}