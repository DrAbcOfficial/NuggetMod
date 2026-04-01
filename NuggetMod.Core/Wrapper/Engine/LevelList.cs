using NuggetMod.Native.Engine;
using NuggetMod.Wrapper;
using NuggetMod.Wrapper.Common;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper.Engine;

/// <summary>
/// Represents a level/map list entry
/// </summary>
public class LevelList : BaseNativeWrapper<NativeLevelList>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public LevelList() : base() { }

    internal unsafe LevelList(NativeLevelList* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    /// <summary>
    /// Gets or sets the map name for this level transition
    /// </summary>
    public unsafe string MapName
    {
        get => Marshal.PtrToStringAnsi((nint)NativePtr->mapName)?.TrimEnd('\0') ?? string.Empty;
        set
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            for (int i = 0; i < 32; i++)
            {
                NativePtr->mapName[i] = i < bytes.Length ? bytes[i] : (byte)0;
            }
        }
    }

    /// <summary>
    /// Gets or sets the landmark name for this level transition
    /// </summary>
    public unsafe string LandmarkName
    {
        get => Marshal.PtrToStringAnsi((nint)NativePtr->landmarkName)?.TrimEnd('\0') ?? string.Empty;
        set
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            for (int i = 0; i < 32; i++)
            {
                NativePtr->landmarkName[i] = i < bytes.Length ? bytes[i] : (byte)0;
            }
        }
    }

    private Edict? _pentlandmark;
    /// <summary>
    /// Gets or sets the landmark entity for this level transition
    /// </summary>
    public unsafe Edict PentLandmark
    {
        get => _pentlandmark ??= new Edict(NativePtr->pentLandmark);
        set => NativePtr->pentLandmark = (NativeEdict*)value.GetNative();
    }

    private Vector3f? _vecLandmarkOrigin;
    /// <summary>
    /// Gets the landmark origin position
    /// </summary>
    public unsafe Vector3f VecLandmarkOrigin =>
        _vecLandmarkOrigin ??= new Vector3f(&NativePtr->vecLandmarkOrigin);
}