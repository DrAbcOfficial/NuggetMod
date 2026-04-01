using System.Runtime.InteropServices;

namespace NuggetMod.Native.Game;

/// <summary>
/// Native structure representing parameters for HUD text messages.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeHudParams : INativeStruct
{
    /// <summary>
    /// X-coordinate for the HUD text (0.0 to 1.0, -1 for center).
    /// </summary>
    internal float x;
    /// <summary>
    /// Y-coordinate for the HUD text (0.0 to 1.0, -1 for center).
    /// </summary>
    internal float y;
    /// <summary>
    /// Effect type (e.g., fade in/out, pulsate, etc.).
    /// </summary>
    internal int effect;

    /// <summary>
    /// Red component of the first color (0-255).
    /// </summary>
    internal byte r1;
    /// <summary>
    /// Green component of the first color (0-255).
    /// </summary>
    internal byte g1;
    /// <summary>
    /// Blue component of the first color (0-255).
    /// </summary>
    internal byte b1;
    /// <summary>
    /// Alpha component of the first color (0-255).
    /// </summary>
    internal byte a1;

    /// <summary>
    /// Red component of the second color (0-255).
    /// </summary>
    internal byte r2;
    /// <summary>
    /// Green component of the second color (0-255).
    /// </summary>
    internal byte g2;
    /// <summary>
    /// Blue component of the second color (0-255).
    /// </summary>
    internal byte b2;
    /// <summary>
    /// Alpha component of the second color (0-255).
    /// </summary>
    internal byte a2;

    /// <summary>
    /// Time to fade in (seconds).
    /// </summary>
    internal float fadeinTime;
    /// <summary>
    /// Time to fade out (seconds).
    /// </summary>
    internal float fadeoutTime;
    /// <summary>
    /// Time to hold the text on screen (seconds).
    /// </summary>
    internal float holdTime;
    /// <summary>
    /// Time for special effects (seconds).
    /// </summary>
    internal float fxTime;
    /// <summary>
    /// Channel for the HUD text (1-4).
    /// </summary>
    internal int channel;
};