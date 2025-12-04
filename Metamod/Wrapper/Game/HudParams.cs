using System.Drawing;
using Metamod.Native.Game;

namespace Metamod.Wrapper.Game;

public class HudParams : BaseNativeWrapper<NativeHudParams>
{
    public HudParams() : base() { }

    /// <summary>
    /// 使用现有的 native 指针包装一个 HudParams。
    /// 与其他 Wrapper 保持一致的 nint 构造方式，方便从非托管回调中创建包装对象。
    /// </summary>
    /// <param name="ptr">指向 NativeHudParams 的非托管指针。</param>
    internal unsafe HudParams(nint ptr) : base((NativeHudParams*)ptr) { }

    internal unsafe HudParams(NativeHudParams* nativePtr, bool ownsPointer = false)
        : base(nativePtr, ownsPointer) { }

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