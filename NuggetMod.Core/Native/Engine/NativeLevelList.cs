using NuggetMod.Native.Common;
using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native level list
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeLevelList : INativeStruct
{
    internal unsafe fixed byte mapName[32];
    internal unsafe fixed byte landmarkName[32];
    internal unsafe NativeEdict* pentLandmark;
    internal NativeVector3f vecLandmarkOrigin;
}