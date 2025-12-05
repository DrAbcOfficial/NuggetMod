namespace NuggetMod.Enum.NuggetMod;

/// <summary>
/// Flags returned by a plugin's API function.
/// NOTE: order is crucial, as greater/less comparisons are made.
/// </summary>
public enum MetaResult
{
    /// <summary>
    /// Result not set.
    /// </summary>
    MRES_UNSET = 0,
    /// <summary>
    /// Plugin didn't take any action.
    /// </summary>
    MRES_IGNORED,
    /// <summary>
    /// Plugin did something, but real function should still be called.
    /// </summary>
    MRES_HANDLED,
    /// <summary>
    /// Call real function, but use my return value.
    /// </summary>
    MRES_OVERRIDE,
    /// <summary>
    /// Skip real function; use my return value.
    /// </summary>
    MRES_SUPERCEDE,
}
