using NuggetMod.Native.Common;

namespace NuggetMod.Wrapper.Common;

/// <summary>
/// Represents client-specific data sent to the client
/// </summary>
public class ClientData : BaseNativeWrapper<NativeClientData>
{
    internal unsafe ClientData(nint ptr) : base((NativeClientData*)ptr) { }
    private Vector3f? _origin;
    
    /// <summary>
    /// Gets the client's origin position
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

    private Vector3f? _velocity;
    
    /// <summary>
    /// Gets the client's velocity.
    /// </summary>
    public Vector3f Veloctiy
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

    /// <summary>
    /// Gets or sets the view model index.
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

    private Vector3f? _punchAngle;
    
    /// <summary>
    /// Gets the punch angle (view kick from weapon recoil).
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
    /// Gets or sets the client flags (FL_ONGROUND, FL_DUCKING, etc.).
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
    /// Gets or sets the water level (0=not in water, 1=feet, 2=waist, 3=head).
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
    /// Gets or sets the water type (CONTENTS_WATER, CONTENTS_SLIME, CONTENTS_LAVA).
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

    private Vector3f? _viewOfs;
    
    /// <summary>
    /// Gets the view offset from origin (eye position).
    /// </summary>
    public Vector3f ViewOFS
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
    /// Gets or sets the client's health.
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
    /// Gets or sets whether the client is ducking.
    /// </summary>
    public bool InDuck
    {
        get
        {
            unsafe
            {
                return NativePtr->bInDuck > 0;
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
    /// Gets or sets the weapons bit mask.
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
    /// Gets or sets the time for next footstep sound.
    /// </summary>
    public int FLTimeStepSound
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
    /// Gets or sets the duck time.
    /// </summary>
    public int FLDuckTime
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
    /// Gets or sets the swim time.
    /// </summary>
    public int FLSwimTime
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
    /// Gets or sets the water jump time.
    /// </summary>
    public int WaterJumpTime
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
    /// Gets or sets the maximum speed.
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
    /// Gets or sets the field of view.
    /// </summary>
    public float FOV
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
    /// Gets or sets the weapon animation sequence.
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
    /// Gets or sets the weapon ID.
    /// </summary>
    public int Id
    {
        get
        {
            unsafe
            {
                return NativePtr->m_iId;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_iId = value;
            }
        }
    }
    /// <summary>
    /// Gets or sets the shell ammunition count.
    /// </summary>
    public int AmmoShells
    {
        get
        {
            unsafe
            {
                return NativePtr->ammo_shells;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->ammo_shells = value;
            }
        }
    }
    /// <summary>
    /// Gets or sets the nail ammunition count.
    /// </summary>
    public int AmmoNails
    {
        get
        {
            unsafe
            {
                return NativePtr->ammo_nails;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->ammo_nails = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the cell ammunition count.
    /// </summary>
    public int AmmoCells
    {
        get
        {
            unsafe
            {
                return NativePtr->ammo_cells;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->ammo_cells = value;
            }
        }
    }
    /// <summary>
    /// Gets or sets the rocket ammunition count.
    /// </summary>
    public int AmmoRockets
    {
        get
        {
            unsafe
            {
                return NativePtr->ammo_rockets;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->ammo_rockets = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time until next attack is allowed.
    /// </summary>
    public float NextAttack
    {
        get
        {
            unsafe
            {
                return NativePtr->m_flNextAttack;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_flNextAttack = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the Team Fortress state.
    /// </summary>
    public int TFState
    {
        get
        {
            unsafe
            {
                return NativePtr->tfstate;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->tfstate = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the push milliseconds for prediction.
    /// </summary>
    public int PushMSec
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
    /// Gets or sets the dead flag (0=alive, 1=dying, 2=dead, 3=respawnable).
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
    /// Gets or sets the physics info buffer (256 bytes).
    /// </summary>
    public byte[] Physinfo
    {
        get
        {
            unsafe
            {
                byte[] buffer = new byte[256];
                fixed (byte* managedPtr = buffer)
                {
                    byte* nativeBuffer = NativePtr->physinfo;
                    for (int i = 0; i < 256; i++)
                    {
                        managedPtr[i] = nativeBuffer[i];
                    }
                }
                return buffer;
            }
        }
        set
        {
            unsafe
            {
                ArgumentNullException.ThrowIfNull(value);
                if (value.Length > 256)
                    throw new ArgumentOutOfRangeException(nameof(value), "Array Length out of range(256)");
                byte* nativeBuffer = NativePtr->physinfo;
                for (int i = 0; i < 256; i++)
                {
                    nativeBuffer[i] = 0;
                }
                for (int i = 0; i < value.Length; i++)
                {
                    nativeBuffer[i] = value[i];
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets custom integer value 1 for mods.
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
    /// Gets or sets custom integer value 2 for mods.
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
    /// Gets or sets custom integer value 3 for mods.
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
    /// Gets or sets custom integer value 4 for mods.
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
    /// Gets or sets custom float value 1 for mods.
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
    /// Gets or sets custom float value 2 for mods.
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
    /// Gets or sets custom float value 3 for mods.
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
    /// Gets or sets custom float value 4 for mods.
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
    /// Gets custom vector value 1 for mods.
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
    /// Gets custom vector value 2 for mods.
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
    /// Gets custom vector value 3 for mods.
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
    /// Gets custom vector value 4 for mods.
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
