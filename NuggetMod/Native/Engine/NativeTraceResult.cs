using NuggetMod.Native.Common;
using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native structure representing the result of a trace (ray cast) operation.
/// Contains information about what the trace hit and where.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeTraceResult : INativeStruct
{
    /// <summary>
    /// If true, the trace started and ended in solid (plane is not valid).
    /// </summary>
    internal int fAllSolid;
    /// <summary>
    /// If true, the initial point was in a solid area.
    /// </summary>
    internal int fStartSolid;
    /// <summary>
    /// If true, the trace is in open space.
    /// </summary>
    internal int fInOpen;
    /// <summary>
    /// If true, the trace is in water.
    /// </summary>
    internal int fInWater;
    /// <summary>
    /// Fraction of trace completed (1.0 = didn't hit anything).
    /// </summary>
    internal float flFraction;
    /// <summary>
    /// Final position of the trace.
    /// </summary>
    internal NativeVector3f vecEndPos;
    /// <summary>
    /// Distance along plane normal.
    /// </summary>
    internal float flPlaneDist;
    /// <summary>
    /// Surface normal at impact point.
    /// </summary>
    internal NativeVector3f vecPlaneNormal;
    /// <summary>
    /// Pointer to entity the surface is on.
    /// </summary>
    internal nint pHit;
    /// <summary>
    /// Hit group (0 = generic, non-zero is specific body part).
    /// </summary>
    internal int iHitgroup;
}
