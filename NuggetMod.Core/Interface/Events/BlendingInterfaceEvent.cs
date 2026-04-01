using NuggetMod.Enum.Metamod;
using NuggetMod.Wrapper.Common;
using NuggetMod.Wrapper.Engine;

namespace NuggetMod.Interface.Events;

#region Delegates
/// <summary>
/// Delegate for studio model bone setup.
/// </summary>
public delegate MetaResult SV_StudioSetupBonesDelegate(nint pModel, float frame, int sequence, Vector3f angles, Vector3f origin, nint pcontroller, nint pblending, int iBone, Edict pEdict);
#endregion

/// <summary>
/// Provides events for server blending interface functions.
/// </summary>
public class BlendingInterfaceEvent
{
    /// <summary>
    /// Gets or sets the blending interface version.
    /// </summary>
    public int Version { get; set; }
    /// <summary>
    /// Event for studio model bone setup.
    /// </summary>
    public event SV_StudioSetupBonesDelegate? SV_StudioSetupBones;
    internal void InvokeSV_StudioSetupBones(nint pModel, float frame, int sequence, Vector3f angles, Vector3f origin, nint pcontroller, nint pblending, int iBone, Edict pEdict)
    {
        var result = SV_StudioSetupBones?.Invoke(pModel, frame, sequence, angles, origin, pcontroller, pblending, iBone, pEdict);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal bool IsSV_StudioSetupBonesNull => SV_StudioSetupBones == null;
}
