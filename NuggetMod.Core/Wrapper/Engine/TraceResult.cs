using NuggetMod.Native.Engine;
using NuggetMod.Wrapper.Common;

namespace NuggetMod.Wrapper.Engine;

/// <summary>
/// Represents the result of a trace/ray cast operation
/// </summary>
public class TraceResult : BaseNativeWrapper<NativeTraceResult>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public TraceResult() : base() { }

    internal unsafe TraceResult(nint ptr) : this((NativeTraceResult*)ptr) { }
    internal unsafe TraceResult(NativeTraceResult* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    /// <summary>
    /// Gets or sets whether the trace is completely in solid
    /// </summary>
    public int AllSolid
    {
        get
        {
            unsafe
            {
                return NativePtr->fAllSolid;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fAllSolid = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the trace started in solid
    /// </summary>
    public int StartSolid
    {
        get
        {
            unsafe
            {
                return NativePtr->fStartSolid;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fStartSolid = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the trace is in open space
    /// </summary>
    public int InOpen
    {
        get
        {
            unsafe
            {
                return NativePtr->fInOpen;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fInOpen = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the trace is in water
    /// </summary>
    public int InWater
    {
        get
        {
            unsafe
            {
                return NativePtr->fInWater;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fInWater = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the fraction of the trace completed (0.0 to 1.0)
    /// </summary>
    public float Fraction
    {
        get
        {
            unsafe
            {
                return NativePtr->flFraction;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->flFraction = value;
            }
        }
    }

    private Vector3f? _endPos;
    /// <summary>
    /// Gets the trace end position
    /// </summary>
    public Vector3f EndPos
    {
        get
        {
            unsafe
            {
                _endPos ??= new Vector3f(&NativePtr->vecEndPos);
                return _endPos;
            }
        }
    }

    /// <summary>
    /// Gets or sets the distance along the plane
    /// </summary>
    public float PlaneDist
    {
        get
        {
            unsafe
            {
                return NativePtr->flPlaneDist;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->flPlaneDist = value;
            }
        }
    }

    private Vector3f? _planeNormal;
    /// <summary>
    /// Gets the plane normal at the hit point
    /// </summary>
    public Vector3f PlaneNormal
    {
        get
        {
            unsafe
            {
                _planeNormal ??= new Vector3f(&NativePtr->vecPlaneNormal);
                return _planeNormal;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pointer to the entity that was hit
    /// </summary>
    public nint PHit
    {
        get
        {
            unsafe
            {
                return NativePtr->pHit;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pHit = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the hitgroup (head, chest, legs, etc.)
    /// </summary>
    public int Hitgroup
    {
        get
        {
            unsafe
            {
                return NativePtr->iHitgroup;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iHitgroup = value;
            }
        }
    }
}