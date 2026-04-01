namespace NuggetMod.Enum.Metamod;

/// <summary>
/// Specifies the type of game information to retrieve via GetGameInfo.
/// </summary>
public enum GetGameInfoType
{
    /// <summary>
    /// Game name.
    /// </summary>
    Name = 0,
    /// <summary>
    /// Game description.
    /// </summary>
    Description,
    /// <summary>
    /// Game directory path.
    /// </summary>
    GameDirectory,
    /// <summary>
    /// Full path to the game DLL.
    /// </summary>
    DLLFullPath,
    /// <summary>
    /// Filename of the game DLL.
    /// </summary>
    DLLFileName,
    /// <summary>
    /// Full path to the real game DLL (unwrapped).
    /// </summary>
    RealDLLFullPath,
}
