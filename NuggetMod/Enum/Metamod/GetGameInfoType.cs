namespace NuggetMod.Enum.NuggetMod;

/// <summary>
/// Specifies the type of game information to retrieve via GetGameInfo.
/// </summary>
public enum GetGameInfoType
{
    /// <summary>
    /// Game name.
    /// </summary>
    GINFO_NAME = 0,
    /// <summary>
    /// Game description.
    /// </summary>
    GINFO_DESC,
    /// <summary>
    /// Game directory path.
    /// </summary>
    GINFO_GAMEDIR,
    /// <summary>
    /// Full path to the game DLL.
    /// </summary>
    GINFO_DLL_FULLPATH,
    /// <summary>
    /// Filename of the game DLL.
    /// </summary>
    GINFO_DLL_FILENAME,
    /// <summary>
    /// Full path to the real game DLL (unwrapped).
    /// </summary>
    GINFO_REALDLL_FULLPATH,
}
