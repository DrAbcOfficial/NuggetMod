using NuggetMod.Helper;
using NuggetMod.Native.Engine;
using NuggetMod.Wrapper.Common;

namespace NuggetMod.Wrapper.Engine;

/// <summary>
/// Represents global variables shared between the engine and game DLL
/// </summary>
public class GlobalVars : BaseNativeWrapper<NativeGlobalVars>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public GlobalVars() : base() { }

    internal unsafe GlobalVars(nint nativePtr) : this((NativeGlobalVars*)nativePtr) { }
    internal unsafe GlobalVars(NativeGlobalVars* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    /// <summary>
    /// Gets or sets the current game time in seconds
    /// </summary>
    public float Time
    {
        get
        {
            unsafe
            {
                return NativePtr->time;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->time = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the duration of the current frame in seconds
    /// </summary>
    public float Frametime
    {
        get
        {
            unsafe
            {
                return NativePtr->frametime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->frametime = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the force retouch value (forces entities to recheck touch)
    /// </summary>
    public float ForceRetouch
    {
        get
        {
            unsafe
            {
                return NativePtr->force_retouch;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->force_retouch = value;
            }
        }
    }

    private StringHandle? _mapname;
    /// <summary>
    /// Gets or sets the current map name
    /// </summary>
    public string MapName
    {
        get
        {
            unsafe
            {
                _mapname ??= new StringHandle(NativePtr->mapname);
                return _mapname.ToString();
            }
        }
        set
        {
            unsafe
            {
                _mapname ??= new StringHandle(value);
                NativePtr->mapname.value = _mapname.ToHandle();
            }
        }
    }

    private StringHandle? _startspot;
    /// <summary>
    /// Gets or sets the start spot name for player spawning
    /// </summary>
    public string StartSpot
    {
        get
        {
            unsafe
            {
                _startspot ??= new StringHandle(NativePtr->startspot);
                return _startspot.ToString();
            }
        }
        set
        {
            unsafe
            {
                _startspot ??= new StringHandle(value);
                NativePtr->startspot.value = _startspot.ToHandle();
            }
        }
    }

    /// <summary>
    /// Gets or sets whether deathmatch mode is enabled
    /// </summary>
    public float Deathmatch
    {
        get
        {
            unsafe
            {
                return NativePtr->deathmatch;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->deathmatch = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether cooperative mode is enabled
    /// </summary>
    public float Coop
    {
        get
        {
            unsafe
            {
                return NativePtr->coop;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->coop = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the teamplay mode value
    /// </summary>
    public float Teamplay
    {
        get
        {
            unsafe
            {
                return NativePtr->teamplay;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->teamplay = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets server flags
    /// </summary>
    public float Serverflags
    {
        get
        {
            unsafe
            {
                return NativePtr->serverflags;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->serverflags = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the number of secrets found
    /// </summary>
    public float FoundSecrets
    {
        get
        {
            unsafe
            {
                return NativePtr->found_secrets;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->found_secrets = value;
            }
        }
    }

    private Vector3f? _vForward;
    /// <summary>
    /// Gets the forward direction vector (calculated from angles)
    /// </summary>
    public Vector3f VForward
    {
        get
        {
            unsafe
            {
                _vForward ??= new Vector3f(&NativePtr->v_forward);
                return _vForward;
            }
        }
    }

    private Vector3f? _vUp;
    /// <summary>
    /// Gets the up direction vector (calculated from angles)
    /// </summary>
    public Vector3f VUp
    {
        get
        {
            unsafe
            {
                _vUp ??= new Vector3f(&NativePtr->v_up);
                return _vUp;
            }
        }
    }

    private Vector3f? _vRight;
    /// <summary>
    /// Gets the right direction vector (calculated from angles)
    /// </summary>
    public Vector3f VRight
    {
        get
        {
            unsafe
            {
                _vRight ??= new Vector3f(&NativePtr->v_right);
                return _vRight;
            }
        }
    }
    /// <summary>
    /// Trace all solid
    /// </summary>
    public float TraceAllSolid
    {
        get
        {
            unsafe
            {
                return NativePtr->trace_allsolid;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->trace_allsolid = value;
            }
        }
    }
    /// <summary>
    /// Global trace start solid
    /// </summary>
    public float TraceStartSolid
    {
        get
        {
            unsafe
            {
                return NativePtr->trace_startsolid;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->trace_startsolid = value;
            }
        }
    }
    /// <summary>
    /// Global trace fraction
    /// </summary>
    public float TraceFraction
    {
        get
        {
            unsafe
            {
                return NativePtr->trace_fraction;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->trace_fraction = value;
            }
        }
    }

    private Vector3f? _traceEndPos;
    /// <summary>
    /// Global trace end pos
    /// </summary>
    public Vector3f TraceEndPos
    {
        get
        {
            unsafe
            {
                _traceEndPos ??= new Vector3f(&NativePtr->trace_endpos);
                return _traceEndPos;
            }
        }
    }

    private Vector3f? _tracePlaneNormal;
    /// <summary>
    /// Global trace plane normal
    /// </summary>
    public Vector3f TracePlaneNormal
    {
        get
        {
            unsafe
            {
                _tracePlaneNormal ??= new Vector3f(&NativePtr->trace_plane_normal);
                return _tracePlaneNormal;
            }
        }
    }
    /// <summary>
    /// Trace plane dist
    /// </summary>
    public float TracePlaneDist
    {
        get
        {
            unsafe
            {
                return NativePtr->trace_plane_dist;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->trace_plane_dist = value;
            }
        }
    }
    private Edict? _traceEnt;
    /// <summary>
    /// Global trace ent
    /// </summary>
    public Edict TraceEnt
    {
        get
        {
            unsafe
            {
                _traceEnt ??= new Edict(NativePtr->trace_ent);
                return _traceEnt;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->trace_ent = value.GetNative();
            }
        }
    }
    /// <summary>
    /// global trace in open
    /// </summary>
    public float TraceInOpen
    {
        get
        {
            unsafe
            {
                return NativePtr->trace_inopen;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->trace_inopen = value;
            }
        }
    }
    /// <summary>
    /// global trace in water
    /// </summary>
    public float TraceInWater
    {
        get
        {
            unsafe
            {
                return NativePtr->trace_inwater;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->trace_inwater = value;
            }
        }
    }
    /// <summary>
    /// global trace hit group
    /// </summary>
    public int TraceHitgroup
    {
        get
        {
            unsafe
            {
                return NativePtr->trace_hitgroup;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->trace_hitgroup = value;
            }
        }
    }
    /// <summary>
    /// global trace flags
    /// </summary>
    public int TraceFlags
    {
        get
        {
            unsafe
            {
                return NativePtr->trace_flags;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->trace_flags = value;
            }
        }
    }
    /// <summary>
    /// global Message entity
    /// </summary>
    public int MsgEntity
    {
        get
        {
            unsafe
            {
                return NativePtr->msg_entity;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->msg_entity = value;
            }
        }
    }
    /// <summary>
    /// CD Audio track
    /// </summary>
    public int CdAudioTrack
    {
        get
        {
            unsafe
            {
                return NativePtr->cdAudioTrack;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->cdAudioTrack = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the maximum number of clients allowed on the server
    /// </summary>
    public int MaxClients
    {
        get
        {
            unsafe
            {
                return NativePtr->maxClients;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->maxClients = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the maximum number of entities
    /// </summary>
    public int MaxEntities
    {
        get
        {
            unsafe
            {
                return NativePtr->maxEntities;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->maxEntities = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the base pointer for string storage
    /// </summary>
    public nint StringBase
    {
        get
        {
            unsafe
            {
                return NativePtr->pStringBase;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pStringBase = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pointer to save data
    /// </summary>
    public nint SaveData
    {
        get
        {
            unsafe
            {
                return NativePtr->pSaveData;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->pSaveData = value;
            }
        }
    }

    private Vector3f? _vecLandmarkOffset;
    /// <summary>
    /// Gets the landmark offset for level transitions
    /// </summary>
    public Vector3f VecLandmarkOffset
    {
        get
        {
            unsafe
            {
                _vecLandmarkOffset ??= new Vector3f(&NativePtr->vecLandmarkOffset);
                return _vecLandmarkOffset;
            }
        }
    }
}