namespace NuggetMod.Enum.Engine;

/// <summary>
/// Represents the data type of a field in entity save/restore operations.
/// </summary>
public enum FieldType
{
    /// <summary>
    /// Any floating point value.
    /// </summary>
    FIELD_FLOAT = 0,
    /// <summary>
    /// A string ID (return from ALLOC_STRING).
    /// </summary>
    FIELD_STRING,
    /// <summary>
    /// An entity offset (EOFFSET).
    /// </summary>
    FIELD_ENTITY,
    /// <summary>
    /// CBaseEntity pointer.
    /// </summary>
    FIELD_CLASSPTR,
    /// <summary>
    /// Entity handle.
    /// </summary>
    FIELD_EHANDLE,
    /// <summary>
    /// EVARS pointer.
    /// </summary>
    FIELD_EVARS,
    /// <summary>
    /// edict_t pointer.
    /// </summary>
    FIELD_EDICT,
    /// <summary>
    /// Any vector.
    /// </summary>
    FIELD_VECTOR,
    /// <summary>
    /// A world coordinate (these are fixed up across level transitions automatically).
    /// </summary>
    FIELD_POSITION_VECTOR,
    /// <summary>
    /// Arbitrary data pointer (deprecated, use an array of FIELD_CHARACTER instead).
    /// </summary>
    FIELD_POINTER,
    /// <summary>
    /// Any integer or enum.
    /// </summary>
    FIELD_INTEGER,
    /// <summary>
    /// A class function pointer (Think, Use, etc).
    /// </summary>
    FIELD_FUNCTION,
    /// <summary>
    /// Boolean value, implemented as an int, may be used as a hint for compression.
    /// </summary>
    FIELD_BOOLEAN,
    /// <summary>
    /// 2 byte integer.
    /// </summary>
    FIELD_SHORT,
    /// <summary>
    /// A single byte.
    /// </summary>
    FIELD_CHARACTER,
    /// <summary>
    /// A floating point time (these are fixed up automatically too).
    /// </summary>
    FIELD_TIME,
    /// <summary>
    /// Engine string that is a model name (needs precache).
    /// </summary>
    FIELD_MODELNAME,
    /// <summary>
    /// Engine string that is a sound name (needs precache).
    /// </summary>
    FIELD_SOUNDNAME,

    /// <summary>
    /// Total count of field types (MUST BE LAST).
    /// </summary>
    FIELD_TYPECOUNT,
}
