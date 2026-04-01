namespace NuggetMod.Enum.Common;

/// <summary>
/// edict->flags
/// </summary>
[Flags]
public enum Flags
{
    /// <summary>
    /// Changes the SV_Movestep() behavior to not need to be on ground
    /// </summary>
    Fly = (1 << 0),
    /// <summary>
    /// Changes the SV_Movestep() behavior to not need to be on ground (but stay in water)
    /// </summary>
    Swim = (1 << 1),
    /// <summary>
    /// Conveyor
    /// </summary>
    Conveyor = (1 << 2),
    /// <summary>
    /// This Entity Is a net Client(Player)
    /// </summary>
    Client = (1 << 3),
    /// <summary>
    /// This entity in water
    /// </summary>
    InWater = (1 << 4),
    /// <summary>
    /// This entity is a monster
    /// </summary>
    Monster = (1 << 5),
    /// <summary>
    /// This entity in godmode
    /// </summary>
    Godmode = (1 << 6),
    /// <summary>
    /// Monster will ignore this
    /// </summary>
    NoTarget = (1 << 7),
    /// <summary>
    /// Don't send entity to local host, it's predicting this entity itself
    /// </summary>
    SkipLocalhost = (1 << 8),
    /// <summary>
    /// At rest / on the ground
    /// </summary>
    OnGround = (1 << 9),
    /// <summary>
    /// not all corners are valid
    /// </summary>
    PartialGround = (1 << 10),
    /// <summary>
    /// player jumping out of water
    /// </summary>
    WaterJump = (1 << 11),
    /// <summary>
    /// Player is frozen for 3rd person camera
    /// </summary>
    Frozen = (1 << 12),
    /// <summary>
    /// JAC: fake client, simulated server side; don't send network messages to them
    /// </summary>
    FakeClient = (1 << 13),
    /// <summary>
    ///  Player flag -- Player is fully crouched
    /// </summary>
    Ducking = (1 << 14),
    /// <summary>
    /// Apply floating force to this entity when in water
    /// </summary>
    Float = (1 << 15),
    /// <summary>
    /// worldgraph has this ent listed as something that blocks a connection
    /// </summary>
    Graphed = (1 << 16),

    /// <summary>
    /// UNDONE: Do we need these?
    /// </summary>
    ImmuneWater = (1 << 17),
    /// <summary>
    /// UNDONE: Do we need these?
    /// </summary>
    ImmuneSlime = (1 << 18),
    /// <summary>
    /// UNDONE: Do we need these?
    /// </summary>
    ImmuneLava = (1 << 19),
    /// <summary>
    /// This is a spectator proxy
    /// </summary>
    Proxy = (1 << 20),
    /// <summary>
    /// Brush model flag -- call think every frame regardless of nextthink - ltime (for constantly changing velocity/path)
    /// </summary>
    AlwaysThink = (1 << 21),
    /// <summary>
    /// Base velocity has been applied this frame (used to convert base velocity into momentum)
    /// </summary>
    BaseVelocity = (1 << 22),
    /// <summary>
    ///  Only collide in with monsters who have FL_MONSTERCLIP set
    /// </summary>
    MonsterClip = (1 << 23),
    /// <summary>
    /// Player is _controlling_ a train, so movement commands should be ignored on client during prediction.
    /// </summary>
    OnTrain = (1 << 24),
    /// <summary>
    /// Not moveable/removeable brush entity (really part of the world, but represented as an entity for transparency or something)
    /// </summary>
    WorldBrush = (1 << 25),
    /// <summary>
    /// This client is a spectator, don't run touch functions, etc.
    /// </summary>
    Spectator = (1 << 26),
    /// <summary>
    /// This is a custom entity
    /// </summary>
    CustomEntity = (1 << 29),
    /// <summary>
    /// This entity is marked for death -- This allows the engine to kill ents at the appropriate time
    /// </summary>
    KillMe = (1 << 30),
    /// <summary>
    /// Entity is dormant, no updates to client
    /// </summary>
    Dormant = (1 << 31)
}
