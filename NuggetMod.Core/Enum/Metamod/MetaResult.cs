namespace NuggetMod.Enum.Metamod;

/// <summary>
/// Flags returned by a plugin's API function.
/// NOTE: order is crucial, as greater/less comparisons are made.
/// </summary>
public enum MetaResult
{
    /// <summary>
    /// Result not set.
    /// </summary>
    UnSet = 0,
    /// <summary>
    /// Plugin didn't take any action.
    /// </summary>
    Ignored,
    /// <summary>
    /// Plugin did something, but real function should still be called.
    /// </summary>
    Handled,
    /// <summary>
    /// Call real function, but use my return value.
    /// </summary>
    Override,
    /// <summary>
    /// Skip real function; use my return value.
    /// </summary>
    SuperCEDE,
}
