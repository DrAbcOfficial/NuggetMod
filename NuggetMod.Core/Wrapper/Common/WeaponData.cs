using NuggetMod.Native.Common;

namespace NuggetMod.Wrapper.Common;

/// <summary>
/// Represents weapon data and state
/// </summary>
public class WeaponData : BaseNativeWrapper<NativeWeaponData>
{
    internal unsafe WeaponData(nint ptr) : base((NativeWeaponData*)ptr) { }
    
    /// <summary>
    /// Gets or sets the weapon ID
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
    /// Gets or sets the ammunition in the clip
    /// </summary>
    public int Clip
    {
        get
        {
            unsafe
            {
                return NativePtr->m_iClip;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_iClip = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time until next primary attack
    /// </summary>
    public float NextPrimaryAttack
    {
        get
        {
            unsafe
            {
                return NativePtr->m_flNextPrimaryAttack;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_flNextPrimaryAttack = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time until next secondary attack
    /// </summary>
    public float NextSecondaryAttack
    {
        get
        {
            unsafe
            {
                return NativePtr->m_flNextSecondaryAttack;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_flNextSecondaryAttack = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time until weapon idle animation
    /// </summary>
    public float TimeWeaponIdle
    {
        get
        {
            unsafe
            {
                return NativePtr->m_flTimeWeaponIdle;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_flTimeWeaponIdle = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the weapon is reloading
    /// </summary>
    public int InReload
    {
        get
        {
            unsafe
            {
                return NativePtr->m_fInReload;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_fInReload = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the weapon is in special reload (e.g., shotgun)
    /// </summary>
    public int InSpecialReload
    {
        get
        {
            unsafe
            {
                return NativePtr->m_fInSpecialReload;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_fInSpecialReload = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time until next reload
    /// </summary>
    public float NextReload
    {
        get
        {
            unsafe
            {
                return NativePtr->m_flNextReload;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_flNextReload = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pump time for pump-action weapons
    /// </summary>
    public float PumpTime
    {
        get
        {
            unsafe
            {
                return NativePtr->m_flPumpTime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_flPumpTime = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the reload time
    /// </summary>
    public float ReloadTime
    {
        get
        {
            unsafe
            {
                return NativePtr->m_fReloadTime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_fReloadTime = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the aimed damage multiplier
    /// </summary>
    public float AimedDamage
    {
        get
        {
            unsafe
            {
                return NativePtr->m_fAimedDamage;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_fAimedDamage = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the time until next aim bonus
    /// </summary>
    public float NextAimBonus
    {
        get
        {
            unsafe
            {
                return NativePtr->m_fNextAimBonus;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_fNextAimBonus = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the weapon is zoomed
    /// </summary>
    public int InZoom
    {
        get
        {
            unsafe
            {
                return NativePtr->m_fInZoom;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_fInZoom = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the weapon state
    /// </summary>
    public int WeaponState
    {
        get
        {
            unsafe
            {
                return NativePtr->m_iWeaponState;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->m_iWeaponState = value;
            }
        }
    }
    /// <summary>
    /// Custom integer value 1 for mods.
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
    /// Custom integer value 2 for mods.
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
    /// Custom integer value 3 for mods.
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
    /// Custom integer value 4 for mods.
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
    /// Custom float value 1 for mods.
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
    /// Custom float value 2 for mods.
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
    /// Custom float value 3 for mods.
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
    /// Custom float value 4 for mods.
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
}