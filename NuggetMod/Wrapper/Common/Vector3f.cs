using NuggetMod.Native.Common;

namespace NuggetMod.Wrapper.Common;

/// <summary>
/// Represents a 3D vector with float components
/// </summary>
public class Vector3f : BaseNativeWrapper<NativeVector3f>
{
    /// <summary>
    /// Initializes a new instance with specified coordinates
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="z">Z coordinate</param>
    public Vector3f(float x, float y, float z) : base()
    {
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public Vector3f() : base() { }
    internal unsafe Vector3f(nint ptr) : this((NativeVector3f*)ptr) { }
    internal unsafe Vector3f(NativeVector3f* nativePtr, bool ownsPointer = false) : base(nativePtr, ownsPointer){}

    /// <summary>
    /// X coordinate
    /// </summary>
    public float X
    {
        get
        {
            unsafe
            {
                return NativePtr->x;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->x = value;
            }
        }
    }

    /// <summary>
    /// Y coordinate
    /// </summary>
    public float Y
    {
        get
        {
            unsafe
            {
                return NativePtr->y;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->y = value;
            }
        }
    }

    /// <summary>
    /// Z coordinate
    /// </summary>
    public float Z
    {
        get
        {
            unsafe
            {
                return NativePtr->z;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->z = value;
            }
        }
    }

    private static readonly Vector3f _zero = new(0,0,0);
    /// <summary>
    /// Zero Vector (0,0,0)
    /// </summary>
    public static Vector3f Zero => _zero;
}
