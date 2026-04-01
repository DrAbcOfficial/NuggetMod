namespace NuggetMod.Enum.Engine;

/// <summary>
/// Represents the type of a resource that needs to be precached or downloaded.
/// </summary>
public enum ResourceType
{
    /// <summary>
    /// Sound resource.
    /// </summary>
    Sound = 0,
    /// <summary>
    /// Skin resource.
    /// </summary>
    Skin,
    /// <summary>
    /// Model resource.
    /// </summary>
    Model,
    /// <summary>
    /// Decal resource.
    /// </summary>
    Decal,
    /// <summary>
    /// Generic resource.
    /// </summary>
    Generic,
    /// <summary>
    /// Event script resource.
    /// </summary>
    EventScript,
    /// <summary>
    /// World resource (fake type for world, is really t_model).
    /// </summary>
    World,
}
