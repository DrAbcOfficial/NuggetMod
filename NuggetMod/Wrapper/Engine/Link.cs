using NuggetMod.Native.Engine;
using NuggetMod.Wrapper;

namespace NuggetMod.Wrapper.Engine;

/// <summary>
/// Represents a linked list node for spatial partitioning
/// </summary>
public class Link : BaseNativeWrapper<NativeLink>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public Link() : base() { }

    internal unsafe Link(NativeLink* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    /// <summary>
    /// Gets or sets the pointer to the previous link in the list
    /// </summary>
    public unsafe nint Prev
    {
        get => NativePtr->prev;
        set => NativePtr->prev = value;
    }

    /// <summary>
    /// Gets or sets the pointer to the next link in the list
    /// </summary>
    public unsafe nint Next
    {
        get => NativePtr->next;
        set => NativePtr->next = value;
    }
}