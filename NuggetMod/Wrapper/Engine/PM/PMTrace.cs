using NuggetMod.Native.Engine.PM;
using NuggetMod.Wrapper.Common;

namespace NuggetMod.Wrapper.Engine.PM;

/// <summary>
/// Represents a trace result for player movement
/// </summary>
public class PMTrace : BaseNativeWrapper<NativePMTrace>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public PMTrace() : base() { }

    internal unsafe PMTrace(NativePMTrace* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    private Vector3f? _endpos;
    
    /// <summary>
    /// Gets the trace end position
    /// </summary>
    public Vector3f EndPos
    {
        get
        {
            unsafe
            {
                _endpos ??= new Vector3f(&NativePtr->endpos);
                return _endpos;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->endpos.x = value.X;
                NativePtr->endpos.y = value.Y;
                NativePtr->endpos.z = value.Z;
            }
        }
    }

    private PMPlane? _plane;

    /// <summary>
    /// Gets the plane information at the hit point
    /// </summary>
    public PMPlane Plane
    {
        get
        {
            unsafe
            {
                _plane ??= new PMPlane(&NativePtr->plane);
                return _plane;
            }
        }
    }

    private Vector3f? _deltavelocity;
    /// <summary>
    /// Gets or sets the change in velocity caused by the collision
    /// </summary>
    public Vector3f DeltAVelocity
    {
        get
        {
            unsafe
            {
                _deltavelocity ??= new Vector3f(&NativePtr->deltavelocity);
                return _deltavelocity;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->deltavelocity.x = value.X;
                NativePtr->deltavelocity.y = value.Y;
                NativePtr->deltavelocity.z = value.Z;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the trace is completely in solid
    /// </summary>
    public bool AllSolid
    {
        get
        {
            unsafe
            {
                return NativePtr->allsolid == 1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->allsolid = value ? 1 : 0;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the trace started in solid
    /// </summary>
    public bool StartSolid
    {
        get
        {
            unsafe
            {
                return NativePtr->startsolid == 1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->startsolid = value ? 1 : 0;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the trace is in open space
    /// </summary>
    public bool InOpen
    {
        get
        {
            unsafe
            {
                return NativePtr->inopen == 1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->inopen = value ? 1 : 0;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the trace is in water
    /// </summary>
    public bool InWater
    {
        get
        {
            unsafe
            {
                return NativePtr->inwater == 1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->inwater = value ? 1 : 0;
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
                return NativePtr->fraction;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fraction = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity index that was hit
    /// </summary>
    public int Ent
    {
        get
        {
            unsafe
            {
                return NativePtr->ent;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->ent = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the hitgroup (head, chest, legs, etc.)
    /// </summary>
    public int HitGroup
    {
        get
        {
            unsafe
            {
                return NativePtr->hitgroup;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->hitgroup = value;
            }
        }
    }
}