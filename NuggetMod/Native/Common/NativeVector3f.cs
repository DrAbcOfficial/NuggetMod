using System.Runtime.InteropServices;
namespace NuggetMod.Native.Common;

/// <summary>
/// Native structure representing a 3D vector with floating-point components.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeVector3f : INativeStruct
{
    /// <summary>
    /// X component of the vector.
    /// </summary>
    public float x;
    /// <summary>
    /// Y component of the vector.
    /// </summary>
    public float y;
    /// <summary>
    /// Z component of the vector.
    /// </summary>
    public float z;
}
