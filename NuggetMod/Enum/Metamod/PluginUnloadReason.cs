namespace NuggetMod.Enum.Metamod;

/// <summary>
/// Specifies the reason why a plugin is being unloaded.
/// </summary>
public enum PluginUnloadReason
{
    /// <summary>
    /// No reason specified.
    /// </summary>
    Null = 0,
    /// <summary>
    /// Plugin was deleted from plugins.ini.
    /// </summary>
    IniDeleted,
    /// <summary>
    /// File on disk is newer than last load.
    /// </summary>
    FileNewer,
    /// <summary>
    /// Requested by server/console command.
    /// </summary>
    Command,
    /// <summary>
    /// Forced by server/console command.
    /// </summary>
    CommandForce,
    /// <summary>
    /// Delayed from previous request; can't tell origin (only used for 'real_reason' on MPlugin::unload()).
    /// </summary>
    Delayed,
    /// <summary>
    /// Requested by plugin function call.
    /// </summary>
    Plugin,
    /// <summary>
    /// Forced by plugin function call.
    /// </summary>
    PluginForce,
    /// <summary>
    /// Forced unload by reload() (only used internally for 'meta reload').
    /// </summary>
    Reload,
    /// <summary>
    /// Server is shutting down.
    /// </summary>
    Shutdown,
};
