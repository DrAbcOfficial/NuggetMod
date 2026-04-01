using NuggetMod.Enum.Engine;
using System.Runtime.InteropServices;
namespace NuggetMod.Native.Engine;

/// <summary>
/// Native type discription
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NativeTypeDescription : INativeStruct
{
    internal FieldType fieldType;
    internal byte* fieldName;
    internal int fieldOffset;
    internal short fieldSize;
    internal short flags;
}
