using NuggetMod.Interface;
using NuggetMod.Native.Engine;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace NuggetMod.Helper;

/// <summary>
/// Safe handle wrapper for unmanaged string allocations.
/// Thread-safe and AOT-compatible.
/// </summary>
internal sealed class SafeStringHandle : SafeHandle
{
    private int _cachedValue;
    private bool _isStringBaseReference;

    /// <summary>
    /// Creates a new SafeStringHandle with an empty string.
    /// </summary>
    internal SafeStringHandle() : base(IntPtr.Zero, true) { }

    /// <summary>
    /// Creates a SafeStringHandle from an existing string handle value (string base reference).
    /// </summary>
    internal static SafeStringHandle FromStringBase(int value)
    {
        return new SafeStringHandle
        {
            _cachedValue = value,
            _isStringBaseReference = true,
            handle = IntPtr.Zero
        };
    }

    /// <summary>
    /// Creates a SafeStringHandle with a copy of the specified string.
    /// </summary>
    internal static SafeStringHandle FromString(string str)
    {
        var handle = new SafeStringHandle();
        if (!string.IsNullOrEmpty(str))
        {
            handle.handle = Marshal.StringToHGlobalAnsi(str);
            // 计算相对于StringBase的偏移量，检查溢出
            nint offset = handle.handle - MetaMod.GlobalVars.StringBase;
            // 在64位系统上，如果偏移量超出int范围，使用饱和值
            if (nint.Size == 8)
            {
                if (offset > int.MaxValue)
                    handle._cachedValue = int.MaxValue;
                else if (offset < int.MinValue)
                    handle._cachedValue = int.MinValue;
                else
                    handle._cachedValue = (int)offset;
            }
            else
            {
                handle._cachedValue = (int)offset;
            }
        }
        return handle;
    }

    /// <summary>
    /// Gets the string handle value for use with the game engine.
    /// </summary>
    public int Value => _cachedValue;

    /// <summary>
    /// Returns true if this handle owns the unmanaged memory.
    /// </summary>
    public override bool IsInvalid => _isStringBaseReference || handle == IntPtr.Zero;

    /// <summary>
    /// Releases the unmanaged string memory.
    /// </summary>
    protected override bool ReleaseHandle()
    {
        if (!_isStringBaseReference && handle != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(handle);
            handle = IntPtr.Zero;
        }
        return true;
    }

    /// <summary>
    /// Converts the handle to a managed string.
    /// </summary>
    public override string ToString()
    {
        if (_isStringBaseReference)
        {
            nint ptr = MetaMod.GlobalVars.StringBase + _cachedValue;
            return Marshal.PtrToStringUTF8(ptr) ?? string.Empty;
        }
        return handle != IntPtr.Zero ? Marshal.PtrToStringUTF8(handle) ?? string.Empty : string.Empty;
    }
}
