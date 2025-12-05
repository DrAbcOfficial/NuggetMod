namespace NuggetMod.Enum.NuggetMod;

/// <summary>
/// Specifies when a plugin can be loaded or unloaded.
/// </summary>
public enum PluginLoadTime
{
    /// <summary>
    /// Plugin should never be loaded.
    /// </summary>
    PT_NEVER = 0,
    /// <summary>
    /// Plugin should only be loaded/unloaded at initial HLDS execution.
    /// </summary>
    PT_STARTUP,
    /// <summary>
    /// Plugin can be loaded/unloaded between maps.
    /// </summary>
    PT_CHANGELEVEL,
    /// <summary>
    /// Plugin can be loaded/unloaded at any time.
    /// </summary>
    PT_ANYTIME,
    /// <summary>
    /// Plugin can be loaded/unloaded at any time, and can be "paused" during a map.
    /// </summary>
    PT_ANYPAUSE,
};
