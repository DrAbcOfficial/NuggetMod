using System.Drawing;
using NuggetMod.Native.Game;

namespace NuggetMod.Wrapper.Game;

/// <summary>
/// Represents HUD (Heads-Up Display) parameters for displaying text on screen
/// </summary>
public class HudParams : BaseNativeWrapper<NativeHudParams>
{
    /// <summary>
    /// Initializes a new instance with default values
    /// </summary>
    public HudParams() : base() { }

    /// <summary>
    /// Wraps an existing native pointer to HudParams.
    /// Consistent with other wrappers' nint constructor pattern for easy creation from unmanaged callbacks.
    /// </summary>
    /// <param name="ptr">Unmanaged pointer to NativeHudParams</param>
    internal unsafe HudParams(nint ptr) : base((NativeHudParams*)ptr) { }

    internal unsafe HudParams(NativeHudParams* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

    /// <summary>
    /// Gets or sets the HUD position as a point
    /// </summary>
    public PointF Point
    {
        get
        {
            return new PointF(X, Y);
        }
        set
        {
            X = value.X;
            Y = value.Y;
        }
    }

    /// <summary>
    /// Gets or sets the X coordinate of the HUD element
    /// </summary>
    public float X
    {
        get
        {
            unsafe
            {
                return NativePtr->x;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->x = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the Y coordinate of the HUD element
    /// </summary>
    public float Y
    {
        get
        {
            unsafe
            {
                return NativePtr->y;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->y = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the visual effect type for the HUD element
    /// </summary>
    public int Effect
    {
        get
        {
            unsafe
            {
                return NativePtr->effect;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->effect = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the red component of the primary color
    /// </summary>
    public byte R1
    {
        get
        {
            unsafe
            {
                return NativePtr->r1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->r1 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the green component of the primary color
    /// </summary>
    public byte G1
    {
        get
        {
            unsafe
            {
                return NativePtr->g1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->g1 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the blue component of the primary color
    /// </summary>
    public byte B1
    {
        get
        {
            unsafe
            {
                return NativePtr->b1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->b1 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the alpha (transparency) component of the primary color
    /// </summary>
    public byte A1
    {
        get
        {
            unsafe
            {
                return NativePtr->a1;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->a1 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the primary color
    /// </summary>
    public Color Color1
    {
        get
        {
            return Color.FromArgb(A1, R1, G1, B1);
        }
        set
        {
            R1 = value.R;
            G1 = value.G;
            B1 = value.B;
            A1 = value.A;
        }
    }

    /// <summary>
    /// Gets or sets the red component of the secondary color
    /// </summary>
    public byte R2
    {
        get
        {
            unsafe
            {
                return NativePtr->r2;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->r2 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the green component of the secondary color
    /// </summary>
    public byte G2
    {
        get
        {
            unsafe
            {
                return NativePtr->g2;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->g2 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the blue component of the secondary color
    /// </summary>
    public byte B2
    {
        get
        {
            unsafe
            {
                return NativePtr->b2;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->b2 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the alpha (transparency) component of the secondary color
    /// </summary>
    public byte A2
    {
        get
        {
            unsafe
            {
                return NativePtr->a2;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->a2 = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the secondary color
    /// </summary>
    public Color Color2
    {
        get
        {
            return Color.FromArgb(A2, R2, G2, B2);
        }
        set
        {
            R2 = value.R;
            G2 = value.G;
            B2 = value.B;
            A2 = value.A;
        }
    }

    /// <summary>
    /// Gets or sets the fade-in duration in seconds
    /// </summary>
    public float FadeinTime
    {
        get
        {
            unsafe
            {
                return NativePtr->fadeinTime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fadeinTime = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the fade-out duration in seconds
    /// </summary>
    public float FadeoutTime
    {
        get
        {
            unsafe
            {
                return NativePtr->fadeoutTime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fadeoutTime = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the hold duration in seconds (how long the HUD element stays visible)
    /// </summary>
    public float HoldTime
    {
        get
        {
            unsafe
            {
                return NativePtr->holdTime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->holdTime = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the effect time parameter
    /// </summary>
    public float FxTime
    {
        get
        {
            unsafe
            {
                return NativePtr->fxTime;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->fxTime = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the HUD channel (allows multiple HUD messages on different channels)
    /// </summary>
    public int Channel
    {
        get
        {
            unsafe
            {
                return NativePtr->channel;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->channel = value;
            }
        }
    }
}