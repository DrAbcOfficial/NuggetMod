namespace NuggetMod.Enum.NuggetMod;

/// <summary>
/// Specifies the reason why a plugin is being unloaded.
/// </summary>
public enum PluginUnloadReason
{
    /// <summary>
    /// No reason specified.
    /// </summary>
    PNL_NULL = 0,
    /// <summary>
    /// Plugin was deleted from plugins.ini.
    /// </summary>
    PNL_INI_DELETED,
    /// <summary>
    /// File on disk is newer than last load.
    /// </summary>
    PNL_FILE_NEWER,
    /// <summary>
    /// Requested by server/console command.
    /// </summary>
    PNL_COMMAND,
    /// <summary>
    /// Forced by server/console command.
    /// </summary>
    PNL_CMD_FORCED,
    /// <summary>
    /// Delayed from previous request; can't tell origin (only used for 'real_reason' on MPlugin::unload()).
    /// </summary>
    PNL_DELAYED,
    /// <summary>
    /// Requested by plugin function call.
    /// </summary>
    PNL_PLUGIN,
    /// <summary>
    /// Forced by plugin function call.
    /// </summary>
    PNL_PLG_FORCED,
    /// <summary>
    /// Forced unload by reload() (only used internally for 'meta reload').
    /// </summary>
    PNL_RELOAD,
    /// <summary>
    /// Server is shutting down.
    /// </summary>
    PNL_SHUTDOWN,
};
