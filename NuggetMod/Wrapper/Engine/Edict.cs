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
    public int Free
    {
        get
        {
            unsafe
            {
                return NativePtr->free;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->free = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the serial number for this edict
    /// </summary>
    public int SerialNumber
    {
        get
        {
            unsafe
            {
                return NativePtr->serialnumber;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->serialnumber = value;
            }
        }
    }

    private Link? _area;
    
    /// <summary>
    /// Gets the area link for spatial partitioning
    /// </summary>
    public Link Area
    {
        get
        {
            unsafe
            {
                _area ??= new Link(&NativePtr->area);
                return _area;
            }
        }
    }

    /// <summary>
    /// Gets or sets the head node for BSP tree
    /// </summary>
    public int HeadNode
    {
        get
        {
            unsafe
            {
                return NativePtr->headnode;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->headnode = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the number of BSP leafs this entity touches
    /// </summary>
    public int NumLeafs
    {
        get
        {
            unsafe
            {
                return NativePtr->num_leafs;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->num_leafs = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the BSP leaf numbers this entity touches (max 48)
    /// </summary>
    public short[] LeafNums
    {
        get
        {
            unsafe
            {
                short[] leafs = new short[48];
                for (int i = 0; i < 48; i++)
                {
                    leafs[i] = NativePtr->leafnums[i];
                }
                return leafs;
            }
        }
        set
        {
            unsafe
            {
                int copyLength = Math.Min(value.Length, 48);
                for (int i = 0; i < copyLength; i++)
                {
                    NativePtr->leafnums[i] = value[i];
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets the time when this edict was freed
    /// </summary>
    public float FreeTime
    {
        get
        {
            unsafe
            {
                return NativePtr->freetime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->freetime = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pointer to private entity data (game-specific)
    /// </summary>
    public nint PrivateData
    {
        get
        {
            unsafe
            {
                return NativePtr->pvPrivateData;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pvPrivateData = value;
            }
        }
    }

    private Entvars? _entVars;
    /// <summary>
    /// Gets the entity variables (entvars) for this edict
    /// </summary>
    public Entvars EntVars
    {
        get
        {
            unsafe
            {
                _entVars ??= new Entvars(&NativePtr->v);
                return _entVars;
            }
        }
    }
}