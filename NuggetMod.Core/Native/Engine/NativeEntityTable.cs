using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native entity table
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeEntityTable : INativeStruct
{
    internal int id;             // Ordinal ID of this entity (used for entity <--> pointer conversions)
    internal unsafe NativeEdict* pent;          // Pointer to the in-game entity

    internal int location;       // Offset from the base data of this entity
    internal int size;           // Byte size of this entity's data
    internal int flags;          // This could be a short -- bit mask of transitions that this entity is in the PVS of
    internal NativeStringHandle classname;		// entity class name
}