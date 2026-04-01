using NuggetMod.Native.Common;
using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine.PM;
/// <summary>
/// Native structure to player move trace
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativePMTrace : INativeStruct
{
    internal int allsolid;        // if true, plane is not valid
    internal int startsolid;          // if true, the initial point was in a solid area
    internal int inopen, inwater;  // End point is in empty space or in water
    internal float fraction;       // time completed, 1.0 = didn't hit anything
    internal NativeVector3f endpos;            // final position
    internal NativePMPlane plane;              // surface normal at impact
    internal int ent;              // entity at impact
    internal NativeVector3f deltavelocity;    // Change in player's velocity caused by impact.  
                                              // Only run on server.
    internal int hitgroup;
}
