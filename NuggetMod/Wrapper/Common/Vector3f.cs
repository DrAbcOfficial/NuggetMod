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

    // Common vector constants for game development
    private static readonly Vector3f _zero = new(0, 0, 0);
    private static readonly Vector3f _one = new(1, 1, 1);
    private static readonly Vector3f _up = new(0, 0, 1);
    private static readonly Vector3f _down = new(0, 0, -1);
    private static readonly Vector3f _forward = new(1, 0, 0);
    private static readonly Vector3f _back = new(-1, 0, 0);
    private static readonly Vector3f _left = new(0, 1, 0);
    private static readonly Vector3f _right = new(0, -1, 0);

    /// <summary>
    /// Zero Vector (0,0,0)
    /// </summary>
    public static Vector3f Zero => _zero;

    /// <summary>
    /// One Vector (1,1,1)
    /// </summary>
    public static Vector3f One => _one;

    /// <summary>
    /// Up Vector (0,0,1) - Z is up in GoldSrc
    /// </summary>
    public static Vector3f Up => _up;

    /// <summary>
    /// Down Vector (0,0,-1)
    /// </summary>
    public static Vector3f Down => _down;

    /// <summary>
    /// Forward Vector (1,0,0)
    /// </summary>
    public static Vector3f Forward => _forward;

    /// <summary>
    /// Back Vector (-1,0,0)
    /// </summary>
    public static Vector3f Back => _back;

    /// <summary>
    /// Left Vector (0,1,0)
    /// </summary>
    public static Vector3f Left => _left;

    /// <summary>
    /// Right Vector (0,-1,0)
    /// </summary>
    public static Vector3f Right => _right;

    /// <summary>
    /// Calculates the distance between two vectors
    /// </summary>
    public static float Distance(Vector3f a, Vector3f b)
    {
        float dx = a.X - b.X;
        float dy = a.Y - b.Y;
        float dz = a.Z - b.Z;
        return MathF.Sqrt(dx * dx + dy * dy + dz * dz);
    }

    /// <summary>
    /// Calculates the squared distance between two vectors (faster than Distance)
    /// </summary>
    public static float DistanceSqr(Vector3f a, Vector3f b)
    {
        float dx = a.X - b.X;
        float dy = a.Y - b.Y;
        float dz = a.Z - b.Z;
        return dx * dx + dy * dy + dz * dz;
    }

    /// <summary>
    /// Linearly interpolates between two vectors
    /// </summary>
    public static Vector3f Lerp(Vector3f a, Vector3f b, float t)
    {
        return new Vector3f(
            a.X + (b.X - a.X) * t,
            a.Y + (b.Y - a.Y) * t,
            a.Z + (b.Z - a.Z) * t
        );
    }
}
