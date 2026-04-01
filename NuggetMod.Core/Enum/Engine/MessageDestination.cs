namespace NuggetMod.Enum.Engine;

/// <summary>
/// Network message destination types.
/// </summary>
public enum MessageDestination
{
    /// <summary>
    /// unreliable to all
    /// </summary>
    Broadcast = 0,
    /// <summary>
    /// reliable to one (msg_entity)
    /// </summary>
    One = 1,
    /// <summary>
    /// reliable to all
    /// </summary>
    All = 2,
    /// <summary>
    /// write to the init string
    /// </summary>
    Init = 3,
    /// <summary>
    /// Ents in PVS of org
    /// </summary>
    PVS = 4,
    /// <summary>
    /// Ents in PAS of org
    /// </summary>
    PAS = 5,
    /// <summary>
    /// Reliable to PVS
    /// </summary>
    PVSReliable = 6,
    /// <summary>
    /// Reliable to PAS
    /// </summary>
    PASReliable = 7,
}
