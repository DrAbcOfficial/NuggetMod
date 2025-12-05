namespace NuggetMod.Enum.Engine;

/// <summary>
/// Represents the type of a resource that needs to be precached or downloaded.
/// </summary>
public enum ResourceType
{
    /// <summary>
    /// Sound resource.
    /// </summary>
    t_sound = 0,
    /// <summary>
    /// Skin resource.
    /// </summary>
    t_skin,
    /// <summary>
    /// Model resource.
    /// </summary>
    t_model,
    /// <summary>
    /// Decal resource.
    /// </summary>
    t_decal,
    /// <summary>
    /// Generic resource.
    /// </summary>
    t_generic,
    /// <summary>
    /// Event script resource.
    /// </summary>
    t_eventscript,
    /// <summary>
    /// World resource (fake type for world, is really t_model).
    /// </summary>
    t_world,
}
