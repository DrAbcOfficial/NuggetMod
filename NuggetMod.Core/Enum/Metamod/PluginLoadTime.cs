namespace NuggetMod.Enum.Metamod;

/// <summary>
/// Specifies when a plugin can be loaded or unloaded.
/// </summary>
public enum PluginLoadTime
{
    /// <summary>
    /// Plugin should never be loaded.
    /// </summary>
    Never = 0,
    /// <summary>
    /// Plugin should only be loaded/unloaded at initial HLDS execution.
    /// </summary>
    Startup,
    /// <summary>
    /// Plugin can be loaded/unloaded between maps.
    /// </summary>
    ChangeLevel,
    /// <summary>
    /// Plugin can be loaded/unloaded at any time.
    /// </summary>
    Anytime,
    /// <summary>
    /// Plugin can be loaded/unloaded at any time, and can be "paused" during a map.
    /// </summary>
    AnyPause,
};
