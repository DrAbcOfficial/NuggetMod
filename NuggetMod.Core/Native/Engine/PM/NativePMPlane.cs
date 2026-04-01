using NuggetMod.Native.Common;
using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine.PM;
/// <summary>
/// native structure representing a plane in 3D space for collision detection.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativePMPlane : INativeStruct
{
    internal NativeVector3f normal;
    internal float dist;
}
