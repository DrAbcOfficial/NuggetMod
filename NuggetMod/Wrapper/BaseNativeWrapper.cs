using NuggetMod.Native;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper;

/// <summary>
/// Base class for unmanaged structure wrappers.
/// </summary>
/// <typeparam name="T">Unmanaged structure type</typeparam>
/// <remarks>
/// GC SAFETY WARNING:
/// This class manages unmanaged memory pointers. To prevent GC dangling pointer issues:
///
    /// 1. If this wrapper OWNS the pointer (ownsPointer=true):
    ///    - The wrapper instance MUST be kept alive as long as the native code might access the memory
    ///    - Use a static field or the provided <see cref="Helper.NativeObjectLifetimeManager"/> to keep references
    ///    - Always call Dispose() when done, or use 'using' statement
///
/// 2. If this wrapper does NOT own the pointer (ownsPointer=false, default):
///    - The underlying memory is managed elsewhere (typically by the game engine)
///    - This wrapper is just a "view" into existing memory
///    - Do NOT free the memory through this wrapper
///    - The wrapper can be safely discarded, but the underlying memory lifetime is NOT controlled by this wrapper
///
/// 3. For CVars and other objects registered with the engine:
///    - Use the static tracking mechanism (e.g., CVar.s_registeredCVars)
///    - Never allow these instances to be GC'd while the engine holds references
/// </remarks>
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
    /// Tracks if this wrapper has been disposed
    /// </summary>
    private bool _disposed;

    /// <summary>
    /// Constructor (wraps an existing unmanaged pointer).
    /// Use this when the memory is owned by the engine or another component.
    /// </summary>
    /// <param name="nativePtr">Unmanaged structure pointer</param>
    /// <param name="ownsPointer">Whether this wrapper owns the pointer and should free it on Dispose</param>
    /// <remarks>
    /// IMPORTANT: If ownsPointer=false (default), ensure the underlying memory remains valid
    /// for the lifetime of this wrapper instance.
    /// </remarks>
    internal unsafe BaseNativeWrapper(T* nativePtr, bool ownsPointer = false)
    {
        NativePtr = nativePtr;
        _ownsPointer = ownsPointer;
    }

    /// <summary>
    /// Finalizer to ensure unmanaged memory is released
    /// </summary>
    ~BaseNativeWrapper()
    {
        Dispose(false);
    }

    /// <summary>
    /// Constructor (allocates new unmanaged memory).
    /// Use this when the wrapper owns the memory.
    /// </summary>
    /// <remarks>
    /// WARNING: The created instance MUST be kept alive as long as the native code
    /// might access the allocated memory. Use static fields or NativeObjectLifetimeManager.
    /// </remarks>
    public BaseNativeWrapper()
    {
        unsafe
        {
            NativePtr = (T*)Marshal.AllocHGlobal(sizeof(T));
        }
        _ownsPointer = true;
    }

    /// <summary>
    /// Gets the raw pointer.
    /// </summary>
    /// <returns>Unmanaged pointer</returns>
    /// <exception cref="ObjectDisposedException">When the wrapper has been disposed</exception>
    public nint GetNative()
    {
        unsafe
        {
            ThrowIfDisposed();
            return (nint)NativePtr;
        }
    }

    /// <summary>
    /// Releases unmanaged resources.
    /// </summary>
    /// <remarks>
    /// WARNING: If this wrapper owns the pointer and is registered with the engine
    /// (e.g., a registered CVar), you must ensure the engine no longer references
    /// this memory before disposing!
    /// </remarks>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    /// <param name="disposing">True if called from Dispose, false if called from finalizer</param>
    protected virtual void Dispose(bool disposing)
    {
        unsafe
        {
            if (!_disposed && NativePtr != null && _ownsPointer)
            {
                Marshal.FreeHGlobal((nint)NativePtr);
                NativePtr = null;
                _disposed = true;
            }
        }
    }

    /// <summary>
    /// Checks if the native pointer is valid and the wrapper has not been disposed.
    /// </summary>
    /// <returns>True if the pointer is not null and not disposed</returns>
    public bool IsValid()
    {
        unsafe
        {
            return !_disposed && NativePtr != null;
        }
    }

    /// <summary>
    /// Checks if the wrapper has been disposed.
    /// </summary>
    public bool IsDisposed => _disposed;

    /// <summary>
    /// Throws ObjectDisposedException if the wrapper has been disposed.
    /// </summary>
    protected void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
    }

    /// <summary>
    /// Validates that this wrapper instance is still valid for use.
    /// Called automatically by GetNative() and should be called by property accessors.
    /// </summary>
    protected void ValidateState()
    {
        ThrowIfDisposed();
    }
}