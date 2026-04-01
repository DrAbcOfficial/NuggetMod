namespace NuggetMod.Enum.Common;

/// <summary>
///  edict->deadflag values
/// </summary>
public enum DeadFlag
{
    /// <summary>
    /// alive
    /// </summary>
    No = 0,
    /// <summary>
    /// playing death animation or still falling off of a ledge waiting to hit ground
    /// </summary>
    Dying = 1,
    /// <summary>
    /// dead. lying still.
    /// </summary>
    Dead = 2,
    /// <summary>
    /// Respawnable
    /// </summary>
    Respawnable = 3,
    /// <summary>
    /// DiscardBody
    /// </summary>
    DiscardBody = 4,
}
