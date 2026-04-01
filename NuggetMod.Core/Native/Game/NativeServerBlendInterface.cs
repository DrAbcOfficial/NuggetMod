using System.Runtime.InteropServices;

namespace NuggetMod.Native.Game;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal delegate void NativeSV_StudioSetupBonesDelegate(
       nint pModel,
       float frame,
       int sequence,
       nint angles,
       nint origin,
       nint pcontroller,
       nint pblending,
       int iBone,
       nint pEdict
   );

/// <summary>
/// Native Blend Interface
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeServerBlendInterface : INativeStruct
{
    internal int version;
    internal NativeSV_StudioSetupBonesDelegate? pfnSV_StudioSetupBones;
}
