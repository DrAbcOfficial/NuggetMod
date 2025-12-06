namespace NuggetMod.Enum.Engine;

/// <summary>
/// Represents the data type of a field in entity save/restore operations.
/// </summary>
public enum FieldType
{
    /// <summary>
    /// Any floating point value.
    /// </summary>
    Float = 0,
    /// <summary>
    /// A string ID (return from ALLOC_STRING).
    /// </summary>
    String,
    /// <summary>
    /// An entity offset (EOFFSET).
    /// </summary>
    Entity,
    /// <summary>
    /// CBaseEntity pointer.
    /// </summary>
    ClassPointer,
    /// <summary>
    /// Entity handle.
    /// </summary>
    EHandle,
    /// <summary>
    /// EVARS pointer.
    /// </summary>
    EntityVars,
    /// <summary>
    /// edict_t pointer.
    /// </summary>
    Edict,
    /// <summary>
    /// Any vector.
    /// </summary>
    Vector,
    /// <summary>
    /// A world coordinate (these are fixed up across level transitions automatically).
    /// </summary>
    PositionVector,
    /// <summary>
    /// Arbitrary data pointer (deprecated, use an array of FIELD_CHARACTER instead).
    /// </summary>
    Pointer,
    /// <summary>
    /// Any integer or enum.
    /// </summary>
    Interger,
    /// <summary>
    /// A class function pointer (Think, Use, etc).
    /// </summary>
    Function,
    /// <summary>
    /// Boolean value, implemented as an int, may be used as a hint for compression.
    /// </summary>
    Boolean,
    /// <summary>
    /// 2 byte integer.
    /// </summary>
    Short,
    /// <summary>
    /// A single byte.
    /// </summary>
    Character,
    /// <summary>
    /// A floating point time (these are fixed up automatically too).
    /// </summary>
    Time,
    /// <summary>
    /// Engine string that is a model name (needs precache).
    /// </summary>
    ModelName,
    /// <summary>
    /// Engine string that is a sound name (needs precache).
    /// </summary>
    SoundName,

    /// <summary>
    /// Total count of field types (MUST BE LAST).
    /// </summary>
    TypeCount,
}
