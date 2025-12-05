using NuggetMod.Enum.Engine;
using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native structure representing a resource that needs to be downloaded or precached.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeResource : INativeStruct
{
    /// <summary>
    /// File name to download/precache (max 64 bytes).
    /// </summary>
    internal unsafe fixed byte szFileName[64];
    /// <summary>
    /// Resource type (t_sound, t_skin, t_model, t_decal, etc.).
    /// </summary>
    internal ResourceType type;
    /// <summary>
    /// Index for decals.
    /// </summary>
    internal int nIndex;
    /// <summary>
    /// Size in bytes if this must be downloaded.
    /// </summary>
    internal int nDownloadSize;
    /// <summary>
    /// Resource flags.
    /// </summary>
    internal byte ucFlags;

    /// <summary>
    /// MD5 hash to determine if we already have this resource (16 bytes).
    /// </summary>
    internal unsafe fixed byte rgucMD5_hash[16];
    /// <summary>
    /// Which player index this resource is associated with, if it's a custom resource.
    /// </summary>
    internal byte playernum;

    /// <summary>
    /// Reserved for future expansion (32 bytes).
    /// </summary>
    internal unsafe fixed byte rguc_reserved[32];
    /// <summary>
    /// Pointer to next resource in chain.
    /// </summary>
    internal nint pNext;
    /// <summary>
    /// Pointer to previous resource in chain.
    /// </summary>
    internal nint pPrev;
}
