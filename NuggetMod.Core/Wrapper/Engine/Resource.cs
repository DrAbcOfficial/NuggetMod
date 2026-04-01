using NuggetMod.Enum.Engine;
using NuggetMod.Native.Engine;
using System.Text;

namespace NuggetMod.Wrapper.Engine;

/// <summary>
/// Represents a game resource (model, sound, etc.)
/// </summary>
public class Resource : BaseNativeWrapper<NativeResource>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public Resource() : base() { }

    internal unsafe Resource(NativeResource* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    /// <summary>
    /// Gets or sets the resource file name
    /// </summary>
    public string FileName
    {
        get
        {
            unsafe
            {
                byte[] buffer = new byte[64];
                fixed (byte* unmanaged = buffer)
                {
                    for (int i = 0; i < 64; i++)
                    {
                        unmanaged[i] = NativePtr->szFileName[i];
                    }
                }
                return Encoding.UTF8.GetString(NativePtr->szFileName, Array.IndexOf(buffer, (byte)0));
            }
        }
        set
        {
            unsafe
            {
                byte[] bytes = Encoding.UTF8.GetBytes(value);
                int copyLength = Math.Min(bytes.Length, 63); // Reserve 1 byte for null terminator
                fixed (byte* pBytes = bytes)
                {
                    for (int i = 0; i < copyLength; i++)
                    {
                        NativePtr->szFileName[i] = pBytes[i];
                    }
                }
                NativePtr->szFileName[copyLength] = 0;
            }
        }
    }

    /// <summary>
    /// Gets or sets the resource type (model, sound, decal, etc.)
    /// </summary>
    public ResourceType Type
    {
        get
        {
            unsafe
            {
                return NativePtr->type;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->type = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the resource index
    /// </summary>
    public int Index
    {
        get
        {
            unsafe
            {
                return NativePtr->nIndex;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->nIndex = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the download size in bytes
    /// </summary>
    public int DownloadSize
    {
        get
        {
            unsafe
            {
                return NativePtr->nDownloadSize;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->nDownloadSize = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the resource flags
    /// </summary>
    public byte Flags
    {
        get
        {
            unsafe
            {
                return NativePtr->ucFlags;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->ucFlags = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the MD5 hash of the resource (16 bytes)
    /// </summary>
    public byte[] Md5Hash
    {
        get
        {
            unsafe
            {
                // Copy 16-byte MD5 hash
                byte[] hash = new byte[16];
                for (int i = 0; i < 16; i++)
                {
                    hash[i] = NativePtr->rgucMD5_hash[i];
                }
                return hash;
            }
        }
        set
        {
            unsafe
            {
                // Copy input MD5 hash (limit length to 16)
                int copyLength = Math.Min(value.Length, 16);
                for (int i = 0; i < copyLength; i++)
                {
                    NativePtr->rgucMD5_hash[i] = value[i];
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets the player number for player-specific resources
    /// </summary>
    public byte PlayerNum
    {
        get
        {
            unsafe
            {
                return NativePtr->playernum;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->playernum = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets reserved bytes (32 bytes)
    /// </summary>
    public byte[] Reserved
    {
        get
        {
            unsafe
            {
                // Copy 32-byte reserved data
                byte[] reserved = new byte[32];
                for (int i = 0; i < 32; i++)
                {
                    reserved[i] = NativePtr->rguc_reserved[i];
                }
                return reserved;
            }
        }
        set
        {
            unsafe
            {
                // Copy input reserved data (limit length to 32)
                int copyLength = Math.Min(value.Length, 32);
                for (int i = 0; i < copyLength; i++)
                {
                    NativePtr->rguc_reserved[i] = value[i];
                }
            }
        }
    }

    private Resource? _next;
    /// <summary>
    /// Gets or sets the next resource in the linked list
    /// </summary>
    public Resource? Next
    {
        get
        {
            unsafe
            {
                if (NativePtr->pNext == nint.Zero)
                    return null;

                _next ??= new Resource((NativeResource*)NativePtr->pNext);
                return _next;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->pNext = nint.Zero;
                else
                    NativePtr->pNext = (nint)value.NativePtr;
            }
        }
    }

    private Resource? _previous;
    /// <summary>
    /// Gets or sets the previous resource in the linked list
    /// </summary>
    public Resource? Previous
    {
        get
        {
            unsafe
            {
                if (NativePtr->pPrev == nint.Zero)
                    return null;
                _previous ??= new Resource((NativeResource*)NativePtr->pPrev);
                return _previous;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->pPrev = nint.Zero;
                else
                    NativePtr->pPrev = (nint)value.NativePtr;
            }
        }
    }
}