using NuggetMod.Native.Common;
using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native save data
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NativeSaveStoreData : INativeStruct
{
    internal byte* pBaseData;        // Start of all entity save data
    internal byte* pCurrentData; // Current buffer pointer for sequential access
    internal int size;           // Current data size
    internal int bufferSize;     // Total space for data
    internal int tokenSize;      // Size of the linear list of tokens
    internal int tokenCount;     // Number of elements in the pTokens table
    internal byte** pTokens;     // Hash table of entity strings (sparse)
    internal int currentIndex;   // Holds a global entity table ID
    internal int tableCount;     // Number of elements in the entity table
    internal int connectionCount;// Number of elements in the levelList[]
    internal NativeEntityTable* pTable;        // Array of ENTITYTABLE elements (1 for each entity)

    internal NativeLevelList levelList0;     // List of connections from this level
    internal NativeLevelList levelList1;
    internal NativeLevelList levelList2;
    internal NativeLevelList levelList3;
    internal NativeLevelList levelList4;
    internal NativeLevelList levelList5;
    internal NativeLevelList levelList6;
    internal NativeLevelList levelList7;
    internal NativeLevelList levelList8;
    internal NativeLevelList levelList9;
    internal NativeLevelList levelList10;
    internal NativeLevelList levelList11;
    internal NativeLevelList levelList12;
    internal NativeLevelList levelList13;
    internal NativeLevelList levelList14;
    internal NativeLevelList levelList15;

    // smooth transition
    internal int fUseLandmark;
    internal fixed byte szLandmarkName[20];// landmark we'll spawn near in next level
    internal NativeVector3f vecLandmarkOffset;// for landmark transitions
    internal float time;
    internal fixed byte szCurrentMapName[32];	// To check global entities
}
