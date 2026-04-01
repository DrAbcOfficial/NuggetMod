using NuggetMod.Helper;
using NuggetMod.Native.Game;
using NuggetMod.Wrapper;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper.Game;

/// <summary>
/// Represents a game hook structure
/// </summary>
public class Hook : BaseNativeWrapper<NativeHook>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public Hook() : base() { }

    internal unsafe Hook(NativeHook* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    /// <summary>
    /// Gets or sets the hook type
    /// </summary>
    public int Type
    {
        get
        {
            unsafe
            {
                return NativePtr->iType;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iType = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the hook has been committed (activated)
    /// </summary>
    public int Committed
    {
        get
        {
            unsafe
            {
                return NativePtr->bCommitted;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->bCommitted = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the address of the original function being hooked
    /// </summary>
    public nint OldFuncAddr
    {
        get
        {
            unsafe
            {
                return NativePtr->pOldFuncAddr;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pOldFuncAddr = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the address of the new function to redirect to
    /// </summary>
    public nint NewFuncAddr
    {
        get
        {
            unsafe
            {
                return NativePtr->pNewFuncAddr;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pNewFuncAddr = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the address to call the original function
    /// </summary>
    public nint OriginalCall
    {
        get
        {
            unsafe
            {
                return NativePtr->pOrginalCall;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pOrginalCall = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pointer to the class instance (for virtual function hooks)
    /// </summary>
    public nint Class
    {
        get
        {
            unsafe
            {
                return NativePtr->pClass;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pClass = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the virtual table index (for virtual function hooks)
    /// </summary>
    public int TableIndex
    {
        get
        {
            unsafe
            {
                return NativePtr->iTableIndex;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iTableIndex = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the function index within the virtual table
    /// </summary>
    public int FuncIndex
    {
        get
        {
            unsafe
            {
                return NativePtr->iFuncIndex;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iFuncIndex = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the handle of the module containing the hooked function
    /// </summary>
    public nint ModuleHandle
    {
        get
        {
            unsafe
            {
                return NativePtr->hModule;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->hModule = value;
            }
        }
    }

    /// <summary>
    /// Gets the name of the module containing the hooked function
    /// </summary>
    public string ModuleName
    {
        get
        {
            unsafe
            {
                return Marshal.PtrToStringUTF8(NativePtr->pszModuleName) ?? string.Empty;
            }
        }
    }

    /// <summary>
    /// Gets the name of the hooked function
    /// </summary>
    public string FuncName
    {
        get
        {
            unsafe
            {
                return Marshal.PtrToStringUTF8(NativePtr->pszFuncName) ?? string.Empty;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pointer to the next hook in the chain
    /// </summary>
    public nint Next
    {
        get
        {
            unsafe
            {
                return NativePtr->pNext;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pNext = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets additional hook information pointer
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
}