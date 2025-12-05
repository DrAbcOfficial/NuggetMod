using System.Runtime.InteropServices;

namespace NuggetMod.Native.Common;

/// <summary>
/// Native structure representing a network address.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeNetAdr : INativeStruct
{
    /// <summary>
    /// Network address type.
    /// </summary>
    internal int type;
    /// <summary>
    /// IP address (4 bytes).
    /// </summary>
    internal unsafe fixed byte ip[4];
    /// <summary>
    /// IPX address (10 bytes).
    /// </summary>
    internal unsafe fixed byte ipx[10];
    /// <summary>
    /// Network port number.
    /// </summary>
    internal ushort port;
}
