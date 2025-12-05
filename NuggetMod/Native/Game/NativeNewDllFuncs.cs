using System.Runtime.InteropServices;

namespace NuggetMod.Native.Game;

internal delegate void NativeOnFreeEntPrivateDataDelegate(nint pEnt);
internal delegate void NativeGameShutdownDelegate();
internal delegate int NativeShouldCollideDelegate(nint pentTouched, nint pentOther);
internal delegate void NativeCvarValueDelegate(nint pEnt, nint value);
internal delegate void NativeCvarValue2Delegate(nint pEnt, int requestID, nint cvarName, nint value);

/// <summary>
/// Native New DLL Functions
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeNewDllFuncs : INativeStruct
{
    // Called right before the object's memory is freed. 
    // Calls its destructor.
    internal NativeOnFreeEntPrivateDataDelegate? pfnOnFreeEntPrivateData;
    internal NativeGameShutdownDelegate? pfnGameShutdown;
    internal NativeShouldCollideDelegate? pfnShouldCollide;
    // Added 2005/08/11 (no SDK update):
    internal NativeCvarValueDelegate? pfnCvarValue;
    // Added 2005/11/21 (no SDK update):
    //    value is "Bad CVAR request" on failure (i.e that user is not connected or the cvar does not exist).
    //    value is "Bad Player" if invalid player edict.
    internal NativeCvarValue2Delegate? pfnCvarValue2;
}
