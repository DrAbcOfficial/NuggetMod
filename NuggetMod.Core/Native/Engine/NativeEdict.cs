using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native structure representing an entity dictionary entry (edict).
/// Contains entity state and links to the world BSP tree.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeEdict : INativeStruct
{
    /// <summary>
    /// Whether the edict slot is free (0 = in use, non-zero = free).
    /// </summary>
    internal int free;
    /// <summary>
    /// Serial number for entity reuse detection.
    /// </summary>
    internal int serialnumber;
    /// <summary>
    /// Link to a division node or leaf in the BSP tree.
    /// </summary>
    internal NativeLink area;

    /// <summary>
    /// Head node for collision detection (-1 to use normal leaf check).
    /// </summary>
    internal int headnode;
    /// <summary>
    /// Number of leafs the entity touches.
    /// </summary>
    internal int num_leafs;
    /// <summary>
    /// Array of leaf numbers the entity touches (max 48).
    /// </summary>
    internal unsafe fixed short leafnums[48];

    /// <summary>
    /// Server time when the object was freed.
    /// </summary>
    internal float freetime;

    /// <summary>
    /// Pointer to private data allocated and freed by engine, used by game DLLs.
    /// </summary>
    internal nint pvPrivateData;

    /// <summary>
    /// Entity variables exported from the game DLL.
    /// </summary>
    internal NativeEntvars v;

    // other fields from progs come immediately after
}
