using System.Runtime.InteropServices;

namespace NuggetMod.Native.Common;

/// <summary>
/// Native structure representing a CRC32 checksum value.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeCRC32 : INativeStruct
{
    /// <summary>
    /// The CRC32 checksum value.
    /// </summary>
    internal ulong value;
}
