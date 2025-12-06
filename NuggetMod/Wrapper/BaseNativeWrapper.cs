using NuggetMod.Native;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper;

/// <summary>
/// Base class for unmanaged structure wrappers
/// </summary>
/// <typeparam name="T">Unmanaged structure type</typeparam>
public abstract class BaseNativeWrapper<T> : IDisposable where T : unmanaged, INativeStruct
{
    /// <summary>
    /// Unmanaged memory pointer
    /// </summary>
    protected unsafe T* NativePtr { get; private set; }

    /// <summary>
    /// Indicates whether this wrapper owns the pointer (whether it needs to be freed)
    /// </summary>
    private readonly bool _ownsPointer;

    /// <summary>
    /// Constructor (wraps an existing unmanaged pointer)
    /// </summary>
    /// <param name="nativePtr">Unmanaged structure pointer</param>
    /// <param name="ownsPointer">Whether this wrapper owns the pointer</param>
    internal unsafe BaseNativeWrapper(T* nativePtr, bool ownsPointer = false)
    {
        NativePtr = nativePtr;
        _ownsPointer = ownsPointer;
    }

    /// <summary>
    /// Constructor (allocates new unmanaged memory)
    /// </summary>
    public BaseNativeWrapper()
    {
        unsafe
        {
            NativePtr = (T*)Marshal.AllocHGlobal(sizeof(T));
        }
        _ownsPointer = true;
    }

    /// <summary>
    /// Gets the raw pointer
    /// </summary>
    /// <returns>Unmanaged pointer</returns>
    public nint GetNative()
    {
        unsafe
        {
            return (nint)NativePtr;
        }
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    public void Dispose()
    {
        unsafe
        {
            if (NativePtr != null && _ownsPointer)
            {
                Marshal.FreeHGlobal((nint)NativePtr);
                NativePtr = null;
            }
        }
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Checks if the native pointer is valid
    /// </summary>
    /// <returns>True if the pointer is not null</returns>
    public bool IsValid()
    {
        unsafe
        {
            return NativePtr != null;
        }
    }
}