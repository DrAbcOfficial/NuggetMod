using NuggetMod.Interface;
using NuggetMod.Native.Engine;
using NuggetMod.Helper;

namespace NuggetMod.Helper;

/// <summary>
/// Handles string references in the game engine's string pool.
/// Thread-safe and AOT-compatible implementation using SafeHandle.
/// </summary>
public sealed class StringHandle : IDisposable
{
    private SafeStringHandle _safeHandle;

    /// <summary>
    /// Initializes a new empty instance.
    /// </summary>
    internal StringHandle()
    {
        _safeHandle = new SafeStringHandle();
    }

    /// <summary>
    /// Initializes a new instance from a native string handle.
    /// </summary>
    internal StringHandle(NativeStringHandle str)
    {
        _safeHandle = SafeStringHandle.FromStringBase(str.value);
    }

    /// <summary>
    /// Initializes a new instance with a string value.
    /// </summary>
    /// <param name="str">String to store</param>
    public StringHandle(string str)
    {
        _safeHandle = SafeStringHandle.FromString(str);
    }

    /// <summary>
    /// Sets the handle from an existing string base reference (no memory ownership).
    /// </summary>
    internal void SetHandle(int handle)
    {
        _safeHandle.Dispose();
        _safeHandle = SafeStringHandle.FromStringBase(handle);
    }

    /// <summary>
    /// Sets the string value.
    /// </summary>
    /// <param name="str">String to set</param>
    public void SetString(string str)
    {
        _safeHandle.Dispose();
        _safeHandle = SafeStringHandle.FromString(str);
    }

    /// <summary>
    /// Converts the string handle to a string.
    /// </summary>
    /// <returns>String value</returns>
    public override string ToString() => _safeHandle.ToString();

    /// <summary>
    /// Gets the handle value for use with the game engine.
    /// </summary>
    internal int ToHandle() => _safeHandle.Value;

    /// <summary>
    /// Releases resources used by the StringHandle.
    /// </summary>
    public void Dispose()
    {
        _safeHandle.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Finalizer to ensure unmanaged memory is released.
    /// </summary>
    ~StringHandle()
    {
        Dispose();
    }
}
