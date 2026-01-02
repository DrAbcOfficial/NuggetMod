using NuggetMod.Interface;
using NuggetMod.Wrapper.Engine;

namespace NuggetMod.Helper;

/// <summary>
/// utility helper functions
/// </summary>
public class Utility
{
    private const int MaxPlayers = 33;
    private const int FirstPlayerIndex = 1;

    /// <summary>
    /// get all player list
    /// </summary>
    /// <returns>player list</returns>
    public static List<Edict> GetAllPlayers()
    {
        List<Edict> edicts = [];
        for (int i = FirstPlayerIndex; i <= MaxPlayers; i++)
        {
            var edict = MetaMod.EngineFuncs.PEntityOfEntIndex(i);
            if (edict != null)
            {
                edicts.Add(edict);
            }
        }
        return edicts;
    }
}
