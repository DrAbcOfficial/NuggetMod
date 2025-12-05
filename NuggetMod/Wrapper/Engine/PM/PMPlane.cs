using NuggetMod.Native.Engine.PM;
using NuggetMod.Wrapper.Common;

namespace NuggetMod.Wrapper.Engine.PM;

/// <summary>
/// Represents a plane used in player movement collision detection and clipping.
/// A plane is defined by a normal vector and a distance from the origin.
/// Used to clip player velocity against surfaces during movement.
/// </summary>
public class PMPlane : BaseNativeWrapper<NativePMPlane>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public PMPlane() : base() { }

    /// <summary>
    /// Initializes a new instance wrapping an existing native plane structure
    /// </summary>
    /// <param name="nativePtr">Pointer to the native plane structure</param>
    /// <param name="ownsPointer">Whether this instance owns the pointer and should free it on disposal</param>
    internal unsafe PMPlane(NativePMPlane* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    /// <summary>
    /// Cached normal vector instance
    /// </summary>
    private Vector3f? _normal;
    
    /// <summary>
    /// Gets or sets the plane's normal vector (unit vector perpendicular to the plane surface)
    /// </summary>
    public Vector3f Normal
    {
        get
        {
            unsafe
            {
                _normal ??= new Vector3f(&NativePtr->normal);
                return _normal;
            }
        }
        set
        {
            unsafe
            {
                // 拷贝值到非托管内存
                NativePtr->normal.x = value.X;
                NativePtr->normal.y = value.Y;
                NativePtr->normal.z = value.Z;
            }
        }
    }

    /// <summary>
    /// Gets or sets the distance from the origin to the plane along the normal vector
    /// </summary>
    public float Dist
    {
        get
        {
            unsafe
            {
                return NativePtr->dist;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->dist = value;
            }
        }
    }
}