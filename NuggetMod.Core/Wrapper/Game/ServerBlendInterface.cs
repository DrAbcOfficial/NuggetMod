using NuggetMod.Native.Game;

namespace NuggetMod.Wrapper.Game;

/// <summary>
/// Wrapper for server-side studio model blending interface
/// </summary>
public class ServerBlendInterface(nint ptr) : BaseFunctionWrapper<NativeServerBlendInterface>(ptr)
{
    /// <summary>
    /// Gets the interface version
    /// </summary>
    public int Version
    {
        get => Base.version;
    }

    /// <summary>
    /// Sets up bones for studio model rendering
    /// </summary>
    public void SV_SudioSetupBones(nint pModel, float frame, int sequence, nint angles, nint origin, nint pcontroller, nint pblending, int iBone, nint pEdict)
    {
        if (Base.pfnSV_StudioSetupBones == null)
            throw new NullReferenceException("SV_StudioSetupBones function pointer is null.");
        Base.pfnSV_StudioSetupBones(pModel, frame, sequence, angles, origin, pcontroller, pblending, iBone, pEdict);
    }
}
