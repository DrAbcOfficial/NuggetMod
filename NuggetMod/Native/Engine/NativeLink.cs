using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native structure representing a doubly-linked list node.
/// Used for linking entities in the world BSP tree.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeLink : INativeStruct
{
    /// <summary>
    /// Pointer to the previous node in the linked list.
    /// </summary>
    internal nint prev;
    /// <summary>
    /// Pointer to the next node in the linked list.
    /// </summary>
    internal nint next;
}
