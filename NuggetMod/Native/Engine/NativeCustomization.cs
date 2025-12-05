using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native structure representing a player customization (e.g., custom spray decals, models).
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeCustomization : INativeStruct
{
    /// <summary>
    /// Whether this customization is in use.
    /// </summary>
    internal int bInUse;
    /// <summary>
    /// The resource for this customization.
    /// </summary>
    internal NativeResource resource;
    /// <summary>
    /// Whether the raw data has been translated into a useable format (e.g., raw decal .wad converted to texture).
    /// </summary>
    internal int bTranslated;
    /// <summary>
    /// Customization specific data 1.
    /// </summary>
    internal int nUserData1;
    /// <summary>
    /// Customization specific data 2.
    /// </summary>
    internal int nUserData2;
    /// <summary>
    /// Buffer that holds the data structure that references the data (e.g., the cachewad_t).
    /// </summary>
    internal nint pInfo;
    /// <summary>
    /// Buffer that holds the data for the customization (the raw .wad data).
    /// </summary>
    internal nint pBuffer;
    /// <summary>
    /// Pointer to next customization in chain.
    /// </summary>
    internal unsafe NativeCustomization* pNext;
}