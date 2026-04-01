using NuggetMod.Native.Common;

namespace NuggetMod.Wrapper.Common;

/// <summary>
/// Represents a user command from client input
/// </summary>
public class UserCmd : BaseNativeWrapper<NativeUserCmd>
{
    internal unsafe UserCmd(nint ptr) : base((NativeUserCmd*)ptr) { }
    
    /// <summary>
    /// Gets or sets the lerp milliseconds for interpolation
    /// </summary>
    public short LerpMsec
    {
        get
        {
            unsafe
            {
                return NativePtr->lerp_msec;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->lerp_msec = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the milliseconds for this command
    /// </summary>
    public byte Msec
    {
        get
        {
            unsafe
            {
                return NativePtr->msec;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->msec = value;
            }
        }
    }

    private Vector3f? _viewangles;
    /// <summary>
    /// Gets the view angles (pitch, yaw, roll)
    /// </summary>
    public Vector3f ViewAngles
    {
        get
        {
            unsafe
            {
                _viewangles ??= new Vector3f(&NativePtr->viewangles);
                return _viewangles;
            }
        }
    }

    /// <summary>
    /// Gets or sets the forward movement speed
    /// </summary>
    public float ForwardMove
    {
        get
        {
            unsafe
            {
                return NativePtr->forwardmove;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->forwardmove = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the sideways movement speed
    /// </summary>
    public float SideMove
    {
        get
        {
            unsafe
            {
                return NativePtr->sidemove;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->sidemove = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the upward movement speed (jump/crouch)
    /// </summary>
    public float UpMove
    {
        get
        {
            unsafe
            {
                return NativePtr->upmove;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->upmove = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the light level at the player's position
    /// </summary>
    public byte LightLevel
    {
        get
        {
            unsafe
            {
                return NativePtr->lightlevel;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->lightlevel = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the button flags (attack, jump, duck, etc.)
    /// </summary>
    public ushort Buttons
    {
        get
        {
            unsafe
            {
                return NativePtr->buttons;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->buttons = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the impulse command number
    /// </summary>
    public byte Impulse
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

    /// <summary>
    /// Gets or sets the weapon selection
    /// </summary>
    public byte WeaponSelect
    {
        get
        {
            unsafe
            {
                return NativePtr->weaponselect;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->weaponselect = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the impact index for lag compensation
    /// </summary>
    public int ImpactIndex
    {
        get
        {
            unsafe
            {
                return NativePtr->impact_index;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->impact_index = value;
            }
        }
    }

    private Vector3f? _impact_position;
    /// <summary>
    /// Gets the impact position for lag compensation
    /// </summary>
    public Vector3f ImpactPosition
    {
        get
        {
            unsafe
            {
                _impact_position ??= new Vector3f(&NativePtr->impact_position);
            }
            return _impact_position;
        }
    }
}
