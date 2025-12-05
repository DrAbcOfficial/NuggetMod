using NuggetMod.Enum.NuggetMod;
using NuggetMod.Wrapper.Engine;

namespace NuggetMod.Interface.Events;

#region new dll functions
/// <summary>
/// Delegate for entity private data cleanup.
/// </summary>
public delegate MetaResult OnFreeEntPrivateDataDelegate(Edict pEnt);
/// <summary>
/// Delegate for game shutdown.
/// </summary>
public delegate MetaResult GameShutdownDelegate();
/// <summary>
/// Delegate for collision detection between entities.
/// </summary>
public delegate (MetaResult, int) ShouldCollideDelegate(Edict pentTouched, Edict pentOther);
/// <summary>
/// Delegate for client cvar value query response.
/// </summary>
public delegate MetaResult CvarValueDelegate(Edict pEnt, string value);
/// <summary>
/// Delegate for client cvar value query response with request ID.
/// </summary>
public delegate MetaResult CvarValue2Delegate(Edict pEnt, int requestID, string cvarName, string value);
#endregion

/// <summary>
/// Provides events for new game DLL functions that can be hooked by plugins.
/// </summary>
public class NewDLLEvents
{
    #region new dll functions
    public event OnFreeEntPrivateDataDelegate? OnFreeEntPrivateData;
    public event GameShutdownDelegate? GameShutdown;
    public event ShouldCollideDelegate? ShouldCollide;
    public event CvarValueDelegate? CvarValue;
    public event CvarValue2Delegate? CvarValue2;
    #endregion

    #region Invoker
    internal void InvokeOnFreeEntPrivateData(Edict pEnt)
    {
        var result = OnFreeEntPrivateData?.Invoke(pEnt);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeGameShutdown()
    {
        var result = GameShutdown?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal int InvokeShouldCollide(Edict pentTouched, Edict pentOther)
    {
        var result = ShouldCollide?.Invoke(pentTouched, pentOther);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeCvarValue(Edict pEnt, string value)
    {
        var result = CvarValue?.Invoke(pEnt, value);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeCvarValue2(Edict pEnt, int requestID, string cvarName, string value)
    {
        var result = CvarValue2?.Invoke(pEnt, requestID, cvarName, value);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    #endregion

    #region Null Checker
    internal bool IsOnFreeEntPrivateDataNull => OnFreeEntPrivateData == null;
    internal bool IsGameShutdownNull => GameShutdown == null;
    internal bool IsShouldCollideNull => ShouldCollide == null;
    internal bool IsCvarValueNull => CvarValue == null;
    internal bool IsCvarValue2Null => CvarValue2 == null;
    #endregion
}