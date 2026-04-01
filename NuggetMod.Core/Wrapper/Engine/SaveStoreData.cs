using NuggetMod.Native.Engine;
using NuggetMod.Wrapper.Common;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper.Engine;

/// <summary>
/// Represents save/restore data for game state persistence
/// </summary>
public class SaveStoreData : BaseNativeWrapper<NativeSaveStoreData>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public SaveStoreData() : base() { }

    internal unsafe SaveStoreData(NativeSaveStoreData* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    /// <summary>
    /// Gets or sets the base pointer to save data
    /// </summary>
    public nint BaseData
    {
        get
        {
            unsafe
            {
                return (nint)NativePtr->pBaseData;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pBaseData = (byte*)value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the current pointer within save data
    /// </summary>
    public nint CurrentData
    {
        get
        {
            unsafe
            {
                return (nint)NativePtr->pCurrentData;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pCurrentData = (byte*)value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the current size of save data
    /// </summary>
    public int Size
    {
        get
        {
            unsafe
            {
                return NativePtr->size;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->size = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the total buffer size allocated for save data
    /// </summary>
    public int BufferSize
    {
        get
        {
            unsafe
            {
                return NativePtr->bufferSize;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->bufferSize = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the size of each token
    /// </summary>
    public int TokenSize
    {
        get
        {
            unsafe
            {
                return NativePtr->tokenSize;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->tokenSize = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the number of tokens
    /// </summary>
    public int TokenCount
    {
        get
        {
            unsafe
            {
                return NativePtr->tokenCount;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->tokenCount = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pointer to token array
    /// </summary>
    public nint Tokens
    {
        get
        {
            unsafe
            {
                return (nint)NativePtr->pTokens;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pTokens = (byte**)value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the current index in the entity table
    /// </summary>
    public int CurrentIndex
    {
        get
        {
            unsafe
            {
                return NativePtr->currentIndex;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->currentIndex = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the number of entries in the entity table
    /// </summary>
    public int TableCount
    {
        get
        {
            unsafe
            {
                return NativePtr->tableCount;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->tableCount = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the number of level connections
    /// </summary>
    public int ConnectionCount
    {
        get
        {
            unsafe
            {
                return NativePtr->connectionCount;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->connectionCount = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pointer to the entity table
    /// </summary>
    public nint EntityTable
    {
        get
        {
            unsafe
            {
                return (nint)NativePtr->pTable;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pTable = (NativeEntityTable*)value;
            }
        }
    }

    private IReadOnlyList<LevelList>? _levelList;
    /// <summary>
    /// Gets the list of level transitions (16 entries)
    /// </summary>
    public IReadOnlyList<LevelList> LevelList
    {
        get
        {
            unsafe
            {
                if (_levelList == null)
                {
                    var list = new List<LevelList>() {
                        new(&NativePtr->levelList0),
                        new(&NativePtr->levelList1),
                        new(&NativePtr->levelList2),
                        new(&NativePtr->levelList3),
                        new(&NativePtr->levelList4),
                        new(&NativePtr->levelList5),
                        new(&NativePtr->levelList6),
                        new(&NativePtr->levelList7),
                        new(&NativePtr->levelList8),
                        new(&NativePtr->levelList9),
                        new(&NativePtr->levelList10),
                        new(&NativePtr->levelList11),
                        new(&NativePtr->levelList12),
                        new(&NativePtr->levelList13),
                        new(&NativePtr->levelList14),
                        new(&NativePtr->levelList15)
                    };
                    _levelList = list.AsReadOnly();
                }
                return _levelList;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether to use a landmark for level transitions
    /// </summary>
    public int UseLandmark
    {
        get
        {
            unsafe
            {
                return NativePtr->fUseLandmark;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fUseLandmark = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the landmark name for level transitions
    /// </summary>
    public string LandmarkName
    {
        get
        {
            unsafe
            {
                return Marshal.PtrToStringUTF8((nint)NativePtr->szLandmarkName)?.TrimEnd('\0') ?? string.Empty;
            }
        }
        set
        {
            unsafe
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(value);
                for (int i = 0; i < 20; i++)
                {
                    NativePtr->szLandmarkName[i] = i < bytes.Length ? bytes[i] : (byte)0;
                }
            }
        }
    }

    private Vector3f? _vecLandmarkOffset;
    /// <summary>
    /// Gets the landmark offset vector for level transitions
    /// </summary>
    public Vector3f VecLandmarkOffset
    {
        get
        {
            unsafe
            {
                _vecLandmarkOffset ??= new Vector3f(&NativePtr->vecLandmarkOffset);
                return _vecLandmarkOffset;
            }
        }
    }

    /// <summary>
    /// Gets or sets the game time when the save was created
    /// </summary>
    public float Time
    {
        get
        {
            unsafe
            {
                return NativePtr->time;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->time = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the current map name
    /// </summary>
    public string CurrentMapName
    {
        get
        {
            unsafe
            {
                return Marshal.PtrToStringUTF8((nint)NativePtr->szCurrentMapName)?.TrimEnd('\0') ?? string.Empty;
            }
        }
        set
        {
            unsafe
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(value);
                for (int i = 0; i < 32; i++)
                {
                    NativePtr->szCurrentMapName[i] = i < bytes.Length ? bytes[i] : (byte)0;
                }
            }
        }
    }
}