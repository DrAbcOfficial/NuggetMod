using NuggetMod.Interface;
using NuggetMod.Wrapper.Engine;

namespace NuggetMod.Helper;

/// <summary>
/// utility helper functions
/// </summary>
public static class Utility
{
    private const int MaxPlayers = 33;
    private const int FirstPlayerIndex = 1;

    /// <summary>
    /// get all player list
    /// </summary>
    /// <returns>player list</returns>
    public static List<Edict> GetAllPlayers() =>
        [.. Enumerable.Range(FirstPlayerIndex, MaxPlayers - FirstPlayerIndex + 1)
            .Select(i => MetaMod.EngineFuncs.PEntityOfEntIndex(i))
            .Where(e => e != null)
            .Cast<Edict>()];
}
