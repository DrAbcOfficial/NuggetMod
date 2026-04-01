using NuggetMod.Native.Engine.PM;
using NuggetMod.Wrapper.Common;
using System.Text;

namespace NuggetMod.Wrapper.Engine.PM;

/// <summary>
/// Represents a physical entity for player movement collision detection
/// </summary>
public class PhySent : BaseNativeWrapper<NativePhySent>
{
    /// <summary>
    /// Gets the entity name
    /// </summary>
    public string Name
    {
        get
        {
            unsafe
            {
                byte[] buffer = new byte[32];
                for (int i = 0; i < 32; i++)
                {
                    buffer[i] = NativePtr->name[i];
                }
                return Encoding.UTF8.GetString(buffer);
            }
        }
        set
        {
            unsafe
            {
                ArgumentNullException.ThrowIfNull(value);
                byte[] buffer = Encoding.UTF8.GetBytes(value);
                if (buffer.Length > 32)
                    throw new ArgumentOutOfRangeException(nameof(value), "Name length cannot exceed 32 bytes");
                for (int i = 0; i < 32; i++)
                {
                    NativePtr->name[i] = i < buffer.Length ? buffer[i] : (byte)0;
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets whether this entity is a player (1 = player, 0 = not a player)
    /// </summary>
    public int Player
    {
        get
        {
            unsafe
            {
                return NativePtr->player;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->player = value;
            }
        }
    }

    /// <summary>
    /// Gets the entity's origin position in world space
    /// </summary>
    private Vector3f? _origin;
    
    /// <summary>
    /// Gets the entity's origin position in world space
    /// </summary>
    public Vector3f Origin
    {
        get
        {
            unsafe
            {
                _origin ??= new Vector3f(&NativePtr->origin);
                return _origin;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pointer to the entity's model structure
    /// </summary>
    public nint Model
    {
        get
        {
            unsafe
            {
                return NativePtr->model;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->model = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the pointer to the entity's studio model structure (for animated models)
    /// </summary>
    public nint StudioModel
    {
        get
        {
            unsafe
            {
                return NativePtr->studiomodel;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->studiomodel = value;
            }
        }
    }

    /// <summary>
    /// Gets the minimum bounds of the entity's bounding box (relative to origin)
    /// </summary>
    private Vector3f? _mins;
    
    /// <summary>
    /// Gets the minimum bounds of the entity's bounding box (relative to origin)
    /// </summary>
    public Vector3f Mins
    {
        get
        {
            unsafe
            {
                _mins ??= new Vector3f(&NativePtr->mins);
                return _mins;
            }
        }
    }

    /// <summary>
    /// Gets the maximum bounds of the entity's bounding box (relative to origin)
    /// </summary>
    private Vector3f? _maxs;
    
    /// <summary>
    /// Gets the maximum bounds of the entity's bounding box (relative to origin)
    /// </summary>
    public Vector3f Maxs
    {
        get
        {
            unsafe
            {
                _maxs ??= new Vector3f(&NativePtr->maxs);
                return _maxs;
            }
        }
    }

    /// <summary>
    /// Gets or sets additional entity information flags
    /// </summary>
    public int Info
    {
        get
        {
            unsafe
            {
                return NativePtr->info;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->info = value;
            }
        }
    }

    /// <summary>
    /// Gets the entity's rotation angles (pitch, yaw, roll)
    /// </summary>
    private Vector3f? _angles;
    
    /// <summary>
    /// Gets the entity's rotation angles (pitch, yaw, roll)
    /// </summary>
    public Vector3f Angles
    {
        get
        {
            unsafe
            {
                _angles ??= new Vector3f(&NativePtr->angles);
                return _angles;
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity's solid type (SOLID_NOT, SOLID_TRIGGER, SOLID_BBOX, SOLID_SLIDEBOX, SOLID_BSP)
    /// </summary>
    public int Solid
    {
        get
        {
            unsafe
            {
                return NativePtr->solid;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->solid = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity's skin index for model rendering
    /// </summary>
    public int Skin
    {
        get
        {
            unsafe
            {
                return NativePtr->skin;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->skin = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity's render mode (kRenderNormal, kRenderTransColor, kRenderTransTexture, etc.)
    /// </summary>
    public int RenderMode
    {
        get
        {
            unsafe
            {
                return NativePtr->rendermode;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->rendermode = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the current animation frame for the entity's model
    /// </summary>
    public float Frame
    {
        get
        {
            unsafe
            {
                return NativePtr->frame;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->frame = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the current animation sequence index for the entity's model
    /// </summary>
    public int Sequence
    {
        get
        {
            unsafe
            {
                return NativePtr->sequence;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->sequence = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the bone controller values for the entity's model (4 controllers)
    /// </summary>
    public byte[] Controller
    {
        get
        {
            unsafe
            {
                byte[] buffer = new byte[4];
                fixed (byte* managedPtr = buffer)
                {
                    byte* nativePtr = NativePtr->controller;
                    for (int i = 0; i < 4; i++)
                    {
                        managedPtr[i] = nativePtr[i];
                    }
                }
                return buffer;
            }
        }
        set
        {
            unsafe
            {
                ArgumentNullException.ThrowIfNull(value);
                if (value.Length > 4)
                    throw new ArgumentOutOfRangeException(nameof(value), "Controller length cannot exceed 4 bytes");
                for (int i = 0; i < 4; i++)
                {
                    NativePtr->controller[i] = i < value.Length ? value[i] : (byte)0;
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets the animation blending values for the entity's model (2 blending parameters)
    /// </summary>
    public byte[] Blending
    {
        get
        {
            unsafe
            {
                byte[] buffer = new byte[2];
                fixed (byte* managedPtr = buffer)
                {
                    byte* nativePtr = NativePtr->blending;
                    for (int i = 0; i < 2; i++)
                    {
                        managedPtr[i] = nativePtr[i];
                    }
                }
                return buffer;
            }
        }
        set
        {
            unsafe
            {
                ArgumentNullException.ThrowIfNull(value);
                if (value.Length > 2)
                    throw new ArgumentOutOfRangeException(nameof(value), "Blending length cannot exceed 2 bytes");
                for (int i = 0; i < 2; i++)
                {
                    NativePtr->blending[i] = i < value.Length ? value[i] : (byte)0;
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity's movement type (MOVETYPE_NONE, MOVETYPE_WALK, MOVETYPE_FLY, MOVETYPE_PUSH, etc.)
    /// </summary>
    public int MoveType
    {
        get
        {
            unsafe
            {
                return NativePtr->movetype;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->movetype = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the entity can take damage (DAMAGE_NO, DAMAGE_YES, DAMAGE_AIM)
    /// </summary>
    public int TakeDamage
    {
        get
        {
            unsafe
            {
                return NativePtr->takedamage;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->takedamage = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the blood decal type for this entity when damaged
    /// </summary>
    public int BloodDecal
    {
        get
        {
            unsafe
            {
                return NativePtr->blooddecal;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->blooddecal = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity's team number
    /// </summary>
    public int Team
    {
        get
        {
            unsafe
            {
                return NativePtr->team;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->team = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the entity's class number for game-specific classification
    /// </summary>
    public int ClassNumber
    {
        get
        {
            unsafe
            {
                return NativePtr->classnumber;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->classnumber = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined integer field 1 (game-specific usage)
    /// </summary>
    public int IUser1
    {
        get
        {
            unsafe
            {
                return NativePtr->iuser1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iuser1 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined integer field 2 (game-specific usage)
    /// </summary>
    public int IUser2
    {
        get
        {
            unsafe
            {
                return NativePtr->iuser2;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iuser2 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined integer field 3 (game-specific usage)
    /// </summary>
    public int IUser3
    {
        get
        {
            unsafe
            {
                return NativePtr->iuser3;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iuser3 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined integer field 4 (game-specific usage)
    /// </summary>
    public int IUser4
    {
        get
        {
            unsafe
            {
                return NativePtr->iuser4;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->iuser4 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined float field 1 (game-specific usage)
    /// </summary>
    public float FUser1
    {
        get
        {
            unsafe
            {
                return NativePtr->fuser1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fuser1 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined float field 2 (game-specific usage)
    /// </summary>
    public float FUser2
    {
        get
        {
            unsafe
            {
                return NativePtr->fuser2;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fuser2 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined float field 3 (game-specific usage)
    /// </summary>
    public float FUser3
    {
        get
        {
            unsafe
            {
                return NativePtr->fuser3;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fuser3 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets user-defined float field 4 (game-specific usage)
    /// </summary>
    public float FUser4
    {
        get
        {
            unsafe
            {
                return NativePtr->fuser4;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fuser4 = value;
            }
        }
    }

    /// <summary>
    /// Gets user-defined vector field 1 (game-specific usage)
    /// </summary>
    private Vector3f? _vuser1;
    
    /// <summary>
    /// Gets user-defined vector field 1 (game-specific usage)
    /// </summary>
    public Vector3f VUser1
    {
        get
        {
            unsafe
            {
                _vuser1 ??= new Vector3f(&NativePtr->vuser1);
                return _vuser1;
            }
        }
    }

    /// <summary>
    /// Gets user-defined vector field 2 (game-specific usage)
    /// </summary>
    private Vector3f? _vuser2;
    
    /// <summary>
    /// Gets user-defined vector field 2 (game-specific usage)
    /// </summary>
    public Vector3f VUser2
    {
        get
        {
            unsafe
            {
                _vuser2 ??= new Vector3f(&NativePtr->vuser2);
                return _vuser2;
            }
        }
    }

    /// <summary>
    /// Gets user-defined vector field 3 (game-specific usage)
    /// </summary>
    private Vector3f? _vuser3;
    
    /// <summary>
    /// Gets user-defined vector field 3 (game-specific usage)
    /// </summary>
    public Vector3f VUser3
    {
        get
        {
            unsafe
            {
                _vuser3 ??= new Vector3f(&NativePtr->vuser3);
                return _vuser3;
            }
        }
    }

    /// <summary>
    /// Gets user-defined vector field 4 (game-specific usage)
    /// </summary>
    private Vector3f? _vuser4;
    
    /// <summary>
    /// Gets user-defined vector field 4 (game-specific usage)
    /// </summary>
    public Vector3f VUser4
    {
        get
        {
            unsafe
            {
                _vuser4 ??= new Vector3f(&NativePtr->vuser4);
                return _vuser4;
            }
        }
    }
}