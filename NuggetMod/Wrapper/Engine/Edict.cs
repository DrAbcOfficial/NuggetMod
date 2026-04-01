using NuggetMod.Native.Engine;

namespace NuggetMod.Wrapper.Engine;

/// <summary>
/// Represents an entity dictionary entry (edict) in the game engine
/// </summary>
public class Edict : BaseNativeWrapper<NativeEdict>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public Edict() : base() { }

    internal unsafe Edict(nint ptr) : this((NativeEdict*)ptr) { }
    internal unsafe Edict(NativeEdict* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    /// <summary>
    /// Gets or sets whether this edict slot is free
    /// </summary>
    public unsafe int Free
    {
        get => NativePtr->free;
        set => NativePtr->free = value;
    }

    /// <summary>
    /// Gets or sets the serial number for this edict
    /// </summary>
    public unsafe int SerialNumber
    {
        get => NativePtr->serialnumber;
        set => NativePtr->serialnumber = value;
    }

    private Link? _area;

    /// <summary>
    /// Gets the area link for spatial partitioning
    /// </summary>
    public unsafe Link Area => _area ??= new Link(&NativePtr->area);

    /// <summary>
    /// Gets or sets the head node for BSP tree
    /// </summary>
    public unsafe int HeadNode
    {
        get => NativePtr->headnode;
        set => NativePtr->headnode = value;
    }

    /// <summary>
    /// Gets or sets the number of BSP leafs this entity touches
    /// </summary>
    public unsafe int NumLeafs
    {
        get => NativePtr->num_leafs;
        set => NativePtr->num_leafs = value;
    }

    /// <summary>
    /// Gets or sets the BSP leaf numbers this entity touches (max 48)
    /// </summary>
    public unsafe short[] LeafNums
    {
        get
        {
            short[] leafs = new short[48];
            new ReadOnlySpan<short>(NativePtr->leafnums, 48).CopyTo(leafs);
            return leafs;
        }
        set
        {
            int copyLength = Math.Min(value.Length, 48);
            value.AsSpan(0, copyLength).CopyTo(new Span<short>(NativePtr->leafnums, 48));
        }
    }

    /// <summary>
    /// Gets or sets the time when this edict was freed
    /// </summary>
    public unsafe float FreeTime
    {
        get => NativePtr->freetime;
        set => NativePtr->freetime = value;
    }

    /// <summary>
    /// Gets or sets the pointer to private entity data (game-specific)
    /// </summary>
    public unsafe nint PrivateData
    {
        get => NativePtr->pvPrivateData;
        set => NativePtr->pvPrivateData = value;
    }

    private Entvars? _entVars;
    /// <summary>
    /// Gets the entity variables (entvars) for this edict
    /// </summary>
    public unsafe Entvars EntVars => _entVars ??= new Entvars(&NativePtr->v);
}