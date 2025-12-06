using NuggetMod.Helper;
using NuggetMod.Native.Engine;
using NuggetMod.Wrapper.Common;

namespace NuggetMod.Wrapper.Engine;

/// <summary>
/// Represents entity variables (entvars) - the core data for each entity
/// </summary>
public class Entvars : BaseNativeWrapper<NativeEntvars>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public Entvars() : base() { }

    internal unsafe Entvars(NativeEntvars* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    private StringHandle? _classname;
    /// <summary>
    /// Gets or sets the entity classname (e.g., "player", "weapon_ak47")
    /// </summary>
    public string ClassName
    {
        get
        {
            unsafe
            {
                _classname ??= new StringHandle();
                _classname.SetHandle(NativePtr->classname.value);
                return _classname.ToString();
            }
        }
        set
        {
            unsafe
            {
                _classname ??= new StringHandle();
                _classname.SetString(value);
                NativePtr->classname.value = _classname.ToHandle();
            }
        }
    }

    private StringHandle? _globalname;
    /// <summary>
    /// Gets or sets the global entity name for cross-level persistence
    /// </summary>
    public string GlobalName
    {
        get
        {
            unsafe
            {
                _globalname ??= new StringHandle();
                _globalname.SetHandle(NativePtr->globalname.value);
                return _globalname.ToString();
            }
        }
        set
        {
            unsafe
            {
                _globalname ??= new StringHandle();
                _globalname.SetString(value);
                NativePtr->globalname.value = _globalname.ToHandle();
            }
        }
    }

    private Vector3f? _origin;
    /// <summary>
    /// Gets the entity origin position in world space
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

    private Vector3f? _oldorigin;
    /// <summary>
    /// Gets the previous frame's origin position
    /// </summary>
    public Vector3f OldOrigin
    {
        get
        {
            unsafe
            {
                _oldorigin ??= new Vector3f(&NativePtr->oldorigin);
                return _oldorigin;
            }
        }
    }

    private Vector3f? _velocity;
    /// <summary>
    /// Gets the entity velocity vector
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

    private Vector3f? _basevelocity;
    /// <summary>
    /// Gets the base velocity (from conveyor belts, moving platforms, etc.)
    /// </summary>
    public Vector3f BaseVelocity
    {
        get
        {
            unsafe
            {
                _basevelocity ??= new Vector3f(&NativePtr->basevelocity);
                return _basevelocity;
            }
        }
    }

    private Vector3f? _clbasevelocity;
    /// <summary>
    /// Gets the client-side base velocity
    /// </summary>
    public Vector3f ClBaseVelocity
    {
        get
        {
            unsafe
            {
                _clbasevelocity ??= new Vector3f(&NativePtr->clbasevelocity);
                return _clbasevelocity;
            }
        }
    }

    private Vector3f? _movedir;
    /// <summary>
    /// Gets the movement direction for entities with MOVETYPE_PUSH
    /// </summary>
    public Vector3f MoveDir
    {
        get
        {
            unsafe
            {
                _movedir ??= new Vector3f(&NativePtr->movedir);
                return _movedir;
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

    private Vector3f? _avelocity;
    /// <summary>
    /// Gets the angular velocity for rotating entities
    /// </summary>
    public Vector3f AVelocity
    {
        get
        {
            unsafe
            {
                _avelocity ??= new Vector3f(&NativePtr->avelocity);
                return _avelocity;
            }
        }
    }

    private Vector3f? _punchangle;
    /// <summary>
    /// Gets the view punch angle for weapon recoil
    /// </summary>
    public Vector3f PunchAngle
    {
        get
        {
            unsafe
            {
                _punchangle ??= new Vector3f(&NativePtr->punchangle);
                return _punchangle;
            }
        }
    }

    private Vector3f? _vAngle;
    /// <summary>
    /// Gets the view angles for players
    /// </summary>
    public Vector3f VAngle
    {
        get
        {
            unsafe
            {
                _vAngle ??= new Vector3f(&NativePtr->v_angle);
                return _vAngle;
            }
        }
    }

    private Vector3f? _endpos;
    /// <summary>
    /// Gets the end position for beams and projectiles
    /// </summary>
    public Vector3f EndPos
    {
        get
        {
            unsafe
            {
                _endpos ??= new Vector3f(&NativePtr->endpos);
                return _endpos;
            }
        }
    }

    private Vector3f? _startpos;
    /// <summary>
    /// Gets the start position for beams and projectiles
    /// </summary>
    public Vector3f StartPos
    {
        get
        {
            unsafe
            {
                _startpos ??= new Vector3f(&NativePtr->startpos);
                return _startpos;
            }
        }
    }

    /// <summary>
    /// Gets or sets the impact time for projectiles
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
    /// Gets or sets the start time for beams and projectiles
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
    /// Gets or sets whether to fix the player's view angles (0=no, 1=force, 2=add offset)
    /// </summary>
    public int FixAngle
    {
        get
        {
            unsafe
            {
                return NativePtr->fixangle;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fixangle = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the ideal pitch angle for AI
    /// </summary>
    public float IdealPitch
    {
        get
        {
            unsafe
            {
                return NativePtr->idealpitch;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->idealpitch = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pitch rotation speed
    /// </summary>
    public float PitchSpeed
    {
        get
        {
            unsafe
            {
                return NativePtr->pitch_speed;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pitch_speed = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the ideal yaw angle for AI
    /// </summary>
    public float IdealYaw
    {
        get
        {
            unsafe
            {
                return NativePtr->ideal_yaw;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->ideal_yaw = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the yaw rotation speed
    /// </summary>
    public float YawSpeed
    {
        get
        {
            unsafe
            {
                return NativePtr->yaw_speed;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->yaw_speed = value;
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

    private StringHandle? _model;
    /// <summary>
    /// Gets or sets the model file path
    /// </summary>
    public string Model
    {
        get
        {
            unsafe
            {
                _model ??= new StringHandle();
                _model.SetHandle(NativePtr->model.value);
                return _model.ToString();
            }
        }
        set
        {
            unsafe
            {
                _model ??= new StringHandle();
                _model.SetString(value);
                NativePtr->model.value = _model.ToHandle();
            }
        }
    }

    /// <summary>
    /// Gets or sets the view model index (first-person weapon model)
    /// </summary>
    public int ViewModel
    {
        get
        {
            unsafe
            {
                return NativePtr->viewmodel;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->viewmodel = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the weapon model index (third-person weapon model)
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

    private Vector3f? _absmin;
    /// <summary>
    /// Gets the absolute minimum bounding box coordinates in world space
    /// </summary>
    public Vector3f AbsMin
    {
        get
        {
            unsafe
            {
                _absmin ??= new Vector3f(&NativePtr->absmin);
                return _absmin;
            }
        }
    }

    private Vector3f? _absmax;
    /// <summary>
    /// Gets the absolute maximum bounding box coordinates in world space
    /// </summary>
    public Vector3f AbsMax
    {
        get
        {
            unsafe
            {
                _absmax ??= new Vector3f(&NativePtr->absmax);
                return _absmax;
            }
        }
    }

    private Vector3f? _mins;
    /// <summary>
    /// Gets the minimum bounding box coordinates relative to origin
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
    /// Gets the maximum bounding box coordinates relative to origin
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

    private Vector3f? _size;
    /// <summary>
    /// Gets the bounding box size (maxs - mins)
    /// </summary>
    public Vector3f Size
    {
        get
        {
            unsafe
            {
                _size ??= new Vector3f(&NativePtr->size);
                return _size;
            }
        }
    }

    /// <summary>
    /// Gets or sets the local time for entity animations
    /// </summary>
    public float LTime
    {
        get
        {
            unsafe
            {
                return NativePtr->ltime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->ltime = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the next time the entity will think
    /// </summary>
    public float NextThink
    {
        get
        {
            unsafe
            {
                return NativePtr->nextthink;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->nextthink = value;
            }
        }
    }


    /// <summary>
    /// Gets or sets the movement type (MOVETYPE_WALK, MOVETYPE_FLY, etc.)
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
    /// Gets or sets the solid type for collision (SOLID_NOT, SOLID_BBOX, etc.)
    /// </summary>
    public int Solid
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
    /// Gets or sets the model skin number
    /// </summary>
    public int Skin
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
    /// Gets or sets the model body group
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
    /// Gets or sets the visual effects flags (EF_BRIGHTFIELD, EF_DIMLIGHT, etc.)
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
    /// Gets or sets the gravity multiplier (1.0 = normal gravity)
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
    /// Gets or sets the friction multiplier
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
    /// Gets or sets the light level at the entity's position
    /// </summary>
    public int LightLevel
    {
        get
        {
            unsafe
            {
                return NativePtr->light_level;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->light_level = value;
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
    /// Gets or sets the gait (walking) animation sequence for players
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

    /// <summary>
    /// Gets or sets the current animation frame
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
    /// Gets or sets the animation time
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
    /// Gets or sets the animation playback rate
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
    /// Gets or sets the bone controller values (0-255) for model animation control
    /// </summary>
    public byte[] Controller
    {
        get
        {
            unsafe
            {
                byte[] controller = new byte[4];
                for (int i = 0; i < 4; i++)
                {
                    controller[i] = NativePtr->controller[i];
                }
                return controller;
            }
        }
        set
        {
            unsafe
            {
                int copyLength = Math.Min(value.Length, 4);
                for (int i = 0; i < copyLength; i++)
                {
                    NativePtr->controller[i] = value[i];
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets the animation blending values (0-255) for smooth animation transitions
    /// </summary>
    public byte[] Blending
    {
        get
        {
            unsafe
            {
                byte[] blending = new byte[2];
                for (int i = 0; i < 2; i++)
                {
                    blending[i] = NativePtr->blending[i];
                }
                return blending;
            }
        }
        set
        {
            unsafe
            {
                int copyLength = Math.Min(value.Length, 2);
                for (int i = 0; i < copyLength; i++)
                {
                    NativePtr->blending[i] = value[i];
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets the model scale multiplier (1.0 = normal size)
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
    /// Gets or sets the rendering mode (kRenderNormal, kRenderTransColor, kRenderGlow, etc.)
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
    /// Gets or sets the render amount/transparency (0-255, where 0 is fully transparent)
    /// </summary>
    public float RenderAmt
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

    private Vector3f? _rendercolor;
    /// <summary>
    /// Gets the render color (RGB values 0-255)
    /// </summary>
    public Vector3f RenderColor
    {
        get
        {
            unsafe
            {
                _rendercolor ??= new Vector3f(&NativePtr->rendercolor);
                return _rendercolor;
            }
        }
    }

    /// <summary>
    /// Gets or sets the render effects (kRenderFxNone, kRenderFxPulseSlow, kRenderFxGlowShell, etc.)
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
    /// Gets or sets the entity's current health points
    /// </summary>
    public float Health
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
    /// Gets or sets the player's frag count (kills minus suicides)
    /// </summary>
    public float Frags
    {
        get
        {
            unsafe
            {
                return NativePtr->frags;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->frags = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the weapon bitfield indicating which weapons the player owns
    /// </summary>
    public int Weapons
    {
        get
        {
            unsafe
            {
                return NativePtr->weapons;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->weapons = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the entity can take damage (DAMAGE_NO, DAMAGE_YES, DAMAGE_AIM)
    /// </summary>
    public float TakeDamage
    {
        get
        {
            unsafe
            {
                return NativePtr->takedamage;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->takedamage = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the dead flag status (DEAD_NO, DEAD_DYING, DEAD_DEAD, DEAD_RESPAWNABLE, DEAD_DISCARDBODY)
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

    private Vector3f? _viewOfs;
    /// <summary>
    /// Gets the view offset from the entity origin (eye position for players)
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
    /// Gets or sets the currently pressed button flags (IN_ATTACK, IN_JUMP, IN_DUCK, etc.)
    /// </summary>
    public int Button
    {
        get
        {
            unsafe
            {
                return NativePtr->button;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->button = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the impulse command number (used for special commands like flashlight toggle)
    /// </summary>
    public int Impulse
    {
        get
        {
            unsafe
            {
                return NativePtr->impulse;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->impulse = value;
            }
        }
    }

    private Edict? _chain;
    /// <summary>
    /// Gets or sets the next entity in a linked list chain
    /// </summary>
    public Edict? Chain
    {
        get
        {
            unsafe
            {
                if (NativePtr->chain == null)
                    return null;

                _chain ??= new Edict(NativePtr->chain);
                return _chain;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->chain = null;
                else
                    NativePtr->chain = (NativeEdict*)value.GetNative();
            }
        }
    }

    private Edict? _dmgInflictor;
    /// <summary>
    /// Gets or sets the entity that inflicted damage (e.g., the grenade that exploded)
    /// </summary>
    public Edict? DmgInflictor
    {
        get
        {
            unsafe
            {
                if (NativePtr->dmg_inflictor == null)
                    return null;

                _dmgInflictor ??= new Edict(NativePtr->dmg_inflictor);
                return _dmgInflictor;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->dmg_inflictor = null;
                else
                    NativePtr->dmg_inflictor = (NativeEdict*)value.GetNative();
            }
        }
    }

    private Edict? _enemy;
    /// <summary>
    /// Gets or sets the entity's current enemy target (used by AI)
    /// </summary>
    public Edict? Enemy
    {
        get
        {
            unsafe
            {
                if (NativePtr->enemy == null)
                    return null;

                _enemy ??= new Edict(NativePtr->enemy);
                return _enemy;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->enemy = null;
                else
                    NativePtr->enemy = (NativeEdict*)value.GetNative();
            }
        }
    }

    private Edict? _aiment;
    /// <summary>
    /// Gets or sets the entity to aim at (used for turrets and tracking entities)
    /// </summary>
    public Edict? Aiment
    {
        get
        {
            unsafe
            {
                if (NativePtr->aiment == null)
                    return null;

                _aiment ??= new Edict(NativePtr->aiment);
                return _aiment;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->aiment = null;
                else
                    NativePtr->aiment = (NativeEdict*)value.GetNative();
            }
        }
    }

    private Edict? _owner;
    /// <summary>
    /// Gets or sets the entity's owner (e.g., the player who threw a grenade)
    /// </summary>
    public Edict? Owner
    {
        get
        {
            unsafe
            {
                if (NativePtr->owner == null)
                    return null;

                _owner ??= new Edict(NativePtr->owner);
                return _owner;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->owner = null;
                else
                    NativePtr->owner = (NativeEdict*)value.GetNative();
            }
        }
    }

    private Edict? _groundEntity;
    /// <summary>
    /// Gets or sets the entity the player/entity is standing on (null if in air)
    /// </summary>
    public Edict? GroundEntity
    {
        get
        {
            unsafe
            {
                if (NativePtr->groundentity == null)
                    return null;

                _groundEntity ??= new Edict(NativePtr->groundentity);
                return _groundEntity;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->groundentity = null;
                else
                    NativePtr->groundentity = (NativeEdict*)value.GetNative();
            }
        }
    }

    /// <summary>
    /// Gets or sets the spawn flags from the map editor (entity-specific behavior flags)
    /// </summary>
    public int SpawnFlags
    {
        get
        {
            unsafe
            {
                return NativePtr->spawnflags;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->spawnflags = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity flags (FL_ONGROUND, FL_DUCKING, FL_SWIM, FL_FLY, etc.)
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
    /// Gets or sets the color map for player model coloring (top and bottom colors)
    /// </summary>
    public int ColorMap
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
    /// Gets or sets the team number (0 = no team, 1+ = team ID)
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
    /// Gets or sets the maximum health points for this entity
    /// </summary>
    public float MaxHealth
    {
        get
        {
            unsafe
            {
                return NativePtr->max_health;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->max_health = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time when the entity was last teleported
    /// </summary>
    public float TeleportTime
    {
        get
        {
            unsafe
            {
                return NativePtr->teleport_time;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->teleport_time = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the armor type (0 = no armor, 0.3 = light armor, 0.6 = heavy armor)
    /// </summary>
    public float ArmorType
    {
        get
        {
            unsafe
            {
                return NativePtr->armortype;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->armortype = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the armor points remaining
    /// </summary>
    public float ArmorValue
    {
        get
        {
            unsafe
            {
                return NativePtr->armorvalue;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->armorvalue = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the water level (0 = not in water, 1 = feet, 2 = waist, 3 = head underwater)
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
    /// Gets or sets the type of water the entity is in (CONTENTS_EMPTY, CONTENTS_WATER, CONTENTS_SLIME, CONTENTS_LAVA)
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

    private StringHandle? _target;
    /// <summary>
    /// Gets or sets the target entity name to trigger or interact with
    /// </summary>
    public string Target
    {
        get
        {
            unsafe
            {
                _target ??= new StringHandle(NativePtr->target);
                return _target.ToString();
            }
        }
        set
        {
            unsafe
            {
                _target ??= new StringHandle(value);
                NativePtr->target.value = _target.ToHandle();
            }
        }
    }

    private StringHandle? _targetname;
    /// <summary>
    /// Gets or sets the entity's unique name for targeting by other entities
    /// </summary>
    public string TargetName
    {
        get
        {
            unsafe
            {
                _targetname ??= new StringHandle(NativePtr->targetname);
                return _targetname.ToString();
            }
        }
        set
        {
            unsafe
            {
                _targetname ??= new StringHandle(value);
                NativePtr->targetname.value = _targetname.ToHandle();
            }
        }
    }

    private StringHandle? _netname;
    /// <summary>
    /// Gets or sets the network name (player name or entity identifier)
    /// </summary>
    public string NetName
    {
        get
        {
            unsafe
            {
                _netname ??= new StringHandle(NativePtr->netname);
                return _netname.ToString();
            }
        }
        set
        {
            unsafe
            {
                _netname ??= new StringHandle(value);
                NativePtr->netname.value = _netname.ToHandle();
            }
        }
    }

    private StringHandle? _message;
    /// <summary>
    /// Gets or sets the message string (used for displaying text or entity-specific data)
    /// </summary>
    public string Message
    {
        get
        {
            unsafe
            {
                _message ??= new StringHandle(NativePtr->message);
                return _message.ToString();
            }
        }
        set
        {
            unsafe
            {
                _message ??= new StringHandle(value);
                NativePtr->message.value = _message.ToHandle();
            }
        }
    }

    /// <summary>
    /// Gets or sets the damage taken in the last frame
    /// </summary>
    public float DmgTake
    {
        get
        {
            unsafe
            {
                return NativePtr->dmg_take;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->dmg_take = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the damage absorbed by armor in the last frame
    /// </summary>
    public float DmgSave
    {
        get
        {
            unsafe
            {
                return NativePtr->dmg_save;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->dmg_save = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the damage amount this entity inflicts
    /// </summary>
    public float Dmg
    {
        get
        {
            unsafe
            {
                return NativePtr->dmg;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->dmg = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time when damage was last dealt
    /// </summary>
    public float DmgTime
    {
        get
        {
            unsafe
            {
                return NativePtr->dmgtime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->dmgtime = value;
            }
        }
    }

    private StringHandle? _noise;
    /// <summary>
    /// Gets or sets the sound file path for the entity's primary sound
    /// </summary>
    public string Noise
    {
        get
        {
            unsafe
            {
                _noise ??= new StringHandle(NativePtr->noise);
                return _noise.ToString();
            }
        }
        set
        {
            unsafe
            {
                _noise ??= new StringHandle(value);
                NativePtr->noise.value = _noise.ToHandle();
            }
        }
    }

    private StringHandle? _noise1;
    /// <summary>
    /// Gets or sets the sound file path for the entity's secondary sound
    /// </summary>
    public string Noise1
    {
        get
        {
            unsafe
            {
                _noise1 ??= new StringHandle(NativePtr->noise1);
                return _noise1.ToString();
            }
        }
        set
        {
            unsafe
            {
                _noise1 ??= new StringHandle(value);
                NativePtr->noise.value = _noise1.ToHandle();
            }
        }
    }

    private StringHandle? _noise2;
    /// <summary>
    /// Gets or sets the sound file path for the entity's tertiary sound
    /// </summary>
    public string Noise2
    {
        get
        {
            unsafe
            {
                _noise2 ??= new StringHandle(NativePtr->noise2);
                return _noise2.ToString();
            }
        }
        set
        {
            unsafe
            {
                _noise2 ??= new StringHandle(value);
                NativePtr->noise2.value = _noise2.ToHandle();
            }
        }
    }

    private StringHandle? _noise3;
    /// <summary>
    /// Gets or sets the sound file path for the entity's quaternary sound
    /// </summary>
    public string Noise3
    {
        get
        {
            unsafe
            {
                _noise3 ??= new StringHandle(NativePtr->noise3);
                return _noise3.ToString();
            }
        }
        set
        {
            unsafe
            {
                _noise3 ??= new StringHandle(value);
                NativePtr->noise3.value = _noise3.ToHandle();
            }
        }
    }


    /// <summary>
    /// Gets or sets the entity's movement speed
    /// </summary>
    public float Speed
    {
        get
        {
            unsafe
            {
                return NativePtr->speed;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->speed = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time when the entity runs out of air (for drowning)
    /// </summary>
    public float AirFinished
    {
        get
        {
            unsafe
            {
                return NativePtr->air_finished;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->air_finished = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time when pain sound can be played again
    /// </summary>
    public float PainFinished
    {
        get
        {
            unsafe
            {
                return NativePtr->pain_finished;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pain_finished = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time when radiation suit protection expires
    /// </summary>
    public float RadsuitFinished
    {
        get
        {
            unsafe
            {
                return NativePtr->radsuit_finished;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->radsuit_finished = value;
            }
        }
    }

    private Edict? _pContainingEntity;
    /// <summary>
    /// Gets or sets the edict that contains these entvars (back-pointer to parent edict)
    /// </summary>
    public Edict? PContainingEntity
    {
        get
        {
            unsafe
            {
                if (NativePtr->pContainingEntity == null)
                    return null;

                _pContainingEntity ??= new Edict(NativePtr->pContainingEntity);
                return _pContainingEntity;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->pContainingEntity = null;
                else
                    NativePtr->pContainingEntity = (NativeEdict*)value.GetNative();
            }
        }
    }

    /// <summary>
    /// Gets or sets the player class (used in team-based games like TFC)
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
    /// Gets or sets the field of view angle in degrees (default is 90)
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
    /// Gets or sets the weapon animation sequence to play
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

    /// <summary>
    /// Gets or sets the milliseconds to push the player movement
    /// </summary>
    public int Pushmsec
    {
        get
        {
            unsafe
            {
                return NativePtr->pushmsec;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pushmsec = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the player is currently ducking/crouching
    /// </summary>
    public bool BInDuck
    {
        get
        {
            unsafe
            {
                return NativePtr->bInDuck != 0;
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
    /// Gets or sets the time for the next footstep sound
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
    /// Gets or sets the time for swimming sound effects
    /// </summary>
    public int FlSwimTime
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
    /// Gets or sets the time tracking for duck/crouch animation
    /// </summary>
    public int FlDuckTime
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
    /// Gets or sets the falling velocity for calculating fall damage
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
    /// Gets or sets the game state (used for special game modes or entity states)
    /// </summary>
    public int GameState
    {
        get
        {
            unsafe
            {
                return NativePtr->gamestate;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->gamestate = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the button flags from the previous frame (for detecting button press/release)
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
    /// Gets or sets the group info for entity collision filtering
    /// </summary>
    public int GroupInfo
    {
        get
        {
            unsafe
            {
                return NativePtr->groupinfo;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->groupinfo = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the first custom integer field for mod-specific data
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
    /// Gets or sets the second custom integer field for mod-specific data
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
    /// Gets or sets the third custom integer field for mod-specific data
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
    /// Gets or sets the fourth custom integer field for mod-specific data
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
    /// Gets or sets the first custom float field for mod-specific data
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
    /// Gets or sets the second custom float field for mod-specific data
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
    /// Gets or sets the third custom float field for mod-specific data
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
    /// Gets or sets the fourth custom float field for mod-specific data
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
    /// Gets the first custom vector field for mod-specific data
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
    /// Gets the second custom vector field for mod-specific data
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
    /// Gets the third custom vector field for mod-specific data
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
    /// Gets the fourth custom vector field for mod-specific data
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

    private Edict? _eUser1;
    /// <summary>
    /// Gets or sets the first custom entity field for mod-specific data
    /// </summary>
    public Edict? EUser1
    {
        get
        {
            unsafe
            {
                if (NativePtr->euser1 == null)
                    return null;

                _eUser1 ??= new Edict(NativePtr->euser1);
                return _eUser1;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->euser1 = null;
                else
                    NativePtr->euser1 = (NativeEdict*)value.GetNative();
            }
        }
    }

    private Edict? _eUser2;
    /// <summary>
    /// Gets or sets the second custom entity field for mod-specific data
    /// </summary>
    public Edict? EUser2
    {
        get
        {
            unsafe
            {
                if (NativePtr->euser2 == null)
                    return null;

                _eUser2 ??= new Edict(NativePtr->euser2);
                return _eUser2;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->euser2 = null;
                else
                    NativePtr->euser2 = (NativeEdict*)value.GetNative();
            }
        }
    }

    private Edict? _eUser3;
    /// <summary>
    /// Gets or sets the third custom entity field for mod-specific data
    /// </summary>
    public Edict? EUser3
    {
        get
        {
            unsafe
            {
                if (NativePtr->euser3 == null)
                    return null;

                _eUser3 ??= new Edict(NativePtr->euser3);
                return _eUser3;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->euser3 = null;
                else
                    NativePtr->euser3 = (NativeEdict*)value.GetNative();
            }
        }
    }

    private Edict? _eUser4;
    /// <summary>
    /// Gets or sets the fourth custom entity field for mod-specific data
    /// </summary>
    public Edict? EUser4
    {
        get
        {
            unsafe
            {
                if (NativePtr->euser4 == null)
                    return null;

                _eUser4 ??= new Edict(NativePtr->euser4);
                return _eUser4;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->euser4 = null;
                else
                    NativePtr->euser4 = (NativeEdict*)value.GetNative();
            }
        }
    }
}