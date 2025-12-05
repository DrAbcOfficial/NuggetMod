using System.Runtime.InteropServices;

namespace NuggetMod.Native.Common;

/// <summary>
/// Native structure representing weapon data sent to the client.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeWeaponData : INativeStruct
{
    /// <summary>
    /// Weapon ID.
    /// </summary>
    internal int m_iId;
    /// <summary>
    /// Current ammunition in clip.
    /// </summary>
    internal int m_iClip;

    /// <summary>
    /// Time until next primary attack.
    /// </summary>
    internal float m_flNextPrimaryAttack;
    /// <summary>
    /// Time until next secondary attack.
    /// </summary>
    internal float m_flNextSecondaryAttack;
    /// <summary>
    /// Time until weapon idle animation.
    /// </summary>
    internal float m_flTimeWeaponIdle;

    /// <summary>
    /// Whether weapon is reloading.
    /// </summary>
    internal int m_fInReload;
    /// <summary>
    /// Whether weapon is in special reload state.
    /// </summary>
    internal int m_fInSpecialReload;
    /// <summary>
    /// Time until next reload.
    /// </summary>
    internal float m_flNextReload;
    /// <summary>
    /// Pump time for shotgun-style weapons.
    /// </summary>
    internal float m_flPumpTime;
    /// <summary>
    /// Reload time duration.
    /// </summary>
    internal float m_fReloadTime;

    /// <summary>
    /// Aimed damage value.
    /// </summary>
    internal float m_fAimedDamage;
    /// <summary>
    /// Time until next aim bonus.
    /// </summary>
    internal float m_fNextAimBonus;
    /// <summary>
    /// Whether weapon is zoomed.
    /// </summary>
    internal int m_fInZoom;
    /// <summary>
    /// Current weapon state.
    /// </summary>
    internal int m_iWeaponState;

    /// <summary>
    /// Custom integer value 1 for mods.
    /// </summary>
    internal int iuser1;
    /// <summary>
    /// Custom integer value 2 for mods.
    /// </summary>
    internal int iuser2;
    /// <summary>
    /// Custom integer value 3 for mods.
    /// </summary>
    internal int iuser3;
    /// <summary>
    /// Custom integer value 4 for mods.
    /// </summary>
    internal int iuser4;
    /// <summary>
    /// Custom float value 1 for mods.
    /// </summary>
    internal float fuser1;
    /// <summary>
    /// Custom float value 2 for mods.
    /// </summary>
    internal float fuser2;
    /// <summary>
    /// Custom float value 3 for mods.
    /// </summary>
    internal float fuser3;
    /// <summary>
    /// Custom float value 4 for mods.
    /// </summary>
    internal float fuser4;
}
