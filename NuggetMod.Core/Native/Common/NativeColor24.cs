using System.Runtime.InteropServices;

namespace NuggetMod.Native.Common
{
    /// <summary>
    /// Native structure representing a 24-bit RGB color.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeColor24 : INativeStruct
    {
        /// <summary>
        /// Red component (0-255).
        /// </summary>
        internal byte r;
        /// <summary>
        /// Green component (0-255).
        /// </summary>
        internal byte g;
        /// <summary>
        /// Blue component (0-255).
        /// </summary>
        internal byte b;
    }
}
