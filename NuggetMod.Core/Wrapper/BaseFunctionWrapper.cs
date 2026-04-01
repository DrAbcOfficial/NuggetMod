using NuggetMod.Native;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper;

/// <summary>
/// Base class for function table wrappers
/// </summary>
/// <typeparam name="T">Native structure type containing function pointers</typeparam>
public abstract class BaseFunctionWrapper<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> where T : INativeStruct
{
    /// <summary>
    /// Managed memory structure
    /// </summary>
    public unsafe T Base { get; private set; }

    internal BaseFunctionWrapper(nint nativePtr)
    {
        Base = Marshal.PtrToStructure<T>(nativePtr) ?? throw new ArgumentNullException(nameof(nativePtr), "Function ptr is NULL!");
    }
}
