using NuggetMod.Native.Engine;

namespace NuggetMod.Wrapper.Engine;

/// <summary>
/// Represents player customization data (sprays, models, etc.)
/// </summary>
public class Customization : BaseNativeWrapper<NativeCustomization>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public Customization() : base() { }

    internal unsafe Customization(nint ptr) : this((NativeCustomization*)ptr) { }
    internal unsafe Customization(NativeCustomization* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    /// <summary>
    /// Gets or sets whether this customization slot is in use
    /// </summary>
    public bool InUse
    {
        get
        {
            unsafe
            {
                return NativePtr->bInUse == 1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->bInUse = value ? 1 : 0;
            }
        }
    }

    private Resource? _resource;
    /// <summary>
    /// Gets the resource information for this customization
    /// </summary>
    public Resource Resource
    {
        get
        {
            unsafe
            {
                _resource ??= new Resource(&NativePtr->resource);
                return _resource;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the customization has been translated/processed
    /// </summary>
    public bool Translated
    {
        get
        {
            unsafe
            {
                return NativePtr->bTranslated == 1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->bTranslated = value ? 1 : 0;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined data 1
    /// </summary>
    public int UserData1
    {
        get
        {
            unsafe
            {
                return NativePtr->nUserData1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->nUserData1 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined data 2
    /// </summary>
    public int UserData2
    {
        get
        {
            unsafe
            {
                return NativePtr->nUserData2;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->nUserData2 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pointer to additional info
    /// </summary>
    public nint Info
    {
        get
        {
            unsafe
            {
                return NativePtr->pInfo;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pInfo = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pointer to the data buffer
    /// </summary>
    public nint Buffer
    {
        get
        {
            unsafe
            {
                return NativePtr->pBuffer;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pBuffer = value;
            }
        }
    }

    private Customization? _next;
    /// <summary>
    /// Gets or sets the next customization in the linked list
    /// </summary>
    public Customization? Next
    {
        get
        {
            unsafe
            {
                if (NativePtr->pNext == null)
                    return null;

                _next ??= new Customization(NativePtr->pNext);
                return _next;
            }
        }
        set
        {
            unsafe
            {
                if (value == null)
                    NativePtr->pNext = (NativeCustomization*)nint.Zero;
                else
                    NativePtr->pNext = value.NativePtr;
            }
        }
    }
}