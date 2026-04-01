namespace NuggetMod.Enum.Common;

/// <summary>
/// RenderFX
/// </summary>
public enum RenderFX
{
    /// <summary>
    /// kRenderFxNone
    /// </summary>
    None = 0,
    /// <summary>
    /// kRenderFxPulseSlow
    /// </summary>
    PulseSlow,
    /// <summary>
    /// kRenderFxPulseFast
    /// </summary>
    PulseFast,
    /// <summary>
    /// kRenderFxPulseSlowWide
    /// </summary>
    PulseSlowWide,
    /// <summary>
    /// kRenderFxPulseFastWide
    /// </summary>
    PulseFastWide,
    /// <summary>
    /// kRenderFxFadeSlow
    /// </summary>
    FadeSlow,
    /// <summary>
    /// kRenderFxFadeFast
    /// </summary>
    FadeFast,
    /// <summary>
    /// kRenderFxSolidSlow
    /// </summary>
    SolidSlow,
    /// <summary>
    /// kRenderFxSolidFast
    /// </summary>
    SolidFast,
    /// <summary>
    /// kRenderFxStrobeSlow
    /// </summary>
    StrobeSlow,
    /// <summary>
    /// kRenderFxStrobeFast
    /// </summary>
    StrobeFast,
    /// <summary>
    /// kRenderFxStrobeFaster
    /// </summary>
    StrobeFaster,
    /// <summary>
    /// kRenderFxFlickerSlow
    /// </summary>
    FlickerSlow,
    /// <summary>
    /// kRenderFxFlickerFast
    /// </summary>
    FlickerFast,
    /// <summary>
    /// kRenderFxNoDissipation
    /// </summary>
    NoDissipation,
    /// <summary>
    /// Distort/scale/translate flicker
    /// </summary>
    Distort,
    /// <summary>
    /// kRenderFxDistort + distance fade
    /// </summary>
    Hologram,
    /// <summary>
    /// kRenderAmt is the player index
    /// </summary>
    DeadPlayer,
    /// <summary>
    /// Scale up really big!
    /// </summary>
    Explode,
    /// <summary>
    /// Glowing Shell
    /// </summary>
    GlowShell,
    /// <summary>
    /// Keep this sprite from getting very small (SPRITES only!)
    /// </summary>
    ClampMinScale,
    /// <summary>
    /// CTM !!!CZERO added to tell the studiorender that the value in iuser2 is a lightmultiplier
    /// </summary>
    LightMultiplier,
}
