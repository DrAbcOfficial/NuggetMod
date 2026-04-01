using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuggetMod.Enum.Common;

/// <summary>
/// edict->solid values
/// NOTE: Some movetypes will cause collisions independent of SOLID_NOT/SOLID_TRIGGER when the entity moves
/// SOLID only effects OTHER entities colliding with this one when they move - UGH!
/// </summary>
public enum Solid
{
    /// <summary>
    /// no interaction with other objects
    /// </summary>
    Not = 0,
    /// <summary>
    /// touch on edge, but not blocking
    /// </summary>
    Trigger = 1,
    /// <summary>
    /// touch on edge, block
    /// </summary>
    BBox = 2,
    /// <summary>
    /// touch on edge, but not an onground
    /// </summary>
    SlideBox = 3,
    /// <summary>
    /// bsp clip, touch on edge, block
    /// </summary>
    Bsp = 4
}
