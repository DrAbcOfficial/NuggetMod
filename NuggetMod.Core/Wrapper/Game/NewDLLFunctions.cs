using NuggetMod.Native.Game;
using NuggetMod.Wrapper.Engine;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper.Game;

/// <summary>
/// Wrapper for new DLL functions (extended game DLL API)
/// </summary>
public class NewDLLFunctions(nint ptr) : BaseFunctionWrapper<NativeNewDllFuncs>(ptr)
{
    /// <summary>
    /// Called right before the object's memory is freed. Calls its destructor.
    /// </summary>
    /// <param name="pEnt">Entity being freed</param>
    public void OnFreeEntPrivateData(Edict pEnt)
    {
        if (Base.pfnOnFreeEntPrivateData == null)
        {
            throw new NullReferenceException($"{nameof(Base.pfnOnFreeEntPrivateData)} is null"!);
        }
        Base.pfnOnFreeEntPrivateData(pEnt.GetNative());
    }
    
    /// <summary>
    /// Called when the game is shutting down
    /// </summary>
    public void GameShutdown()
    {
        if (Base.pfnGameShutdown == null)
        {
            throw new NullReferenceException($"{nameof(Base.pfnGameShutdown)} is null"!);
        }
        Base.pfnGameShutdown();
    }
    /// <summary>
    /// Determines if two entities should collide with each other
    /// </summary>
    /// <param name="pentTouched">First entity</param>
    /// <param name="pentOther">Second entity</param>
    /// <returns>Non-zero if entities should collide, zero otherwise</returns>
    public int ShouldCollide(Edict pentTouched, Edict pentOther)
    {
        if (Base.pfnShouldCollide == null)
        {
            throw new NullReferenceException($"{nameof(Base.pfnShouldCollide)} is null"!);
        }
        return Base.pfnShouldCollide(pentTouched.GetNative(), pentOther.GetNative());
    }
    
    /// <summary>
    /// Called when a client cvar value is received (Added 2005/08/11)
    /// </summary>
    /// <param name="pEnt">Player entity</param>
    /// <param name="value">Cvar value received from the client</param>
    public void CvarValue(Edict pEnt, string value)
    {
        if (Base.pfnCvarValue == null)
        {
            throw new NullReferenceException($"{nameof(Base.pfnCvarValue)} is null"!);
        }
        nint ns = Marshal.StringToHGlobalAnsi(value);
        Base.pfnCvarValue(pEnt.GetNative(), ns);
        Marshal.FreeHGlobal(ns);
    }
    
    /// <summary>
    /// Called when a client cvar value is received with request ID (Added 2005/11/21).
    /// Value is "Bad CVAR request" on failure (user not connected or cvar does not exist).
    /// Value is "Bad Player" if invalid player edict.
    /// </summary>
    /// <param name="pEnt">Player entity</param>
    /// <param name="requestID">Request ID from the query</param>
    /// <param name="cvarName">Name of the cvar queried</param>
    /// <param name="value">Cvar value received from the client</param>
    public void CvarValue2(Edict pEnt, int requestID, string cvarName, string value)
    {
        if (Base.pfnCvarValue2 == null)
        {
            throw new NullReferenceException($"{nameof(Base.pfnCvarValue2)} is null"!);
        }
        nint ns1 = Marshal.StringToHGlobalAnsi(cvarName);
        nint ns2 = Marshal.StringToHGlobalAnsi(value);
        Base.pfnCvarValue2(pEnt.GetNative(), requestID, ns1, ns2);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
    }
}
