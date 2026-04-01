namespace NuggetMod.Enum.Common;
/// <summary>
/// edict->movetype values
/// </summary>
public enum MoveType
{
    /// <summary>
    /// Never moves
    /// </summary>
    None = 0,
    /// <summary>
    /// Deprecated, never use
    /// </summary>
    AngleNoClip = 1,
    /// <summary>
    /// Deprecated, never use
    /// </summary>
    AngleClip = 2,
    /// <summary>
    /// Player only - moving on the ground
    /// </summary>
    Walk = 3,
    /// <summary>
    /// gravity, special edge handling -- monsters use this
    /// </summary>
    Step = 4,
    /// <summary>
    /// No gravity, but still collides with stuff
    /// </summary>
    Fly = 5,
    /// <summary>
    /// gravity/collisions
    /// </summary>
    Toss = 6,
    /// <summary>
    /// no clip to world, push and crush
    /// </summary>
    Push = 7,
    /// <summary>
    /// No gravity, no collisions, still do velocity/avelocity
    /// </summary>
    NoClip = 8,
    /// <summary>
    /// extra size to monsters
    /// </summary>
    FlyMissile = 9,
    /// <summary>
    /// Just like Toss, but reflect velocity when contacting surfaces
    /// </summary>
    Bounce = 10,
    /// <summary>
    /// bounce w/o gravity
    /// </summary>
    BounceMissile = 11,
    /// <summary>
    /// track movement of aiment
    /// </summary>
    Follow = 12,
    /// <summary>
    /// BSP model that needs physics/world collisions (uses nearest hull for world collision)
    /// </summary>
    PushStep = 13
}
