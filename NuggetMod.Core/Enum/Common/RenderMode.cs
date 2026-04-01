using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuggetMod.Enum.Common;

/// <summary>
/// Render mode
/// </summary>
public enum RenderMode
{
    /// <summary>
    /// src
    /// </summary>
    Normal,
    /// <summary>
    /// c*a+dest*(1-a)
    /// </summary>
    TransColor,
    /// <summary>
    /// src*a+dest*(1-a)
    /// </summary>
    TransTexture,
    /// <summary>
    /// src*a+dest -- No Z buffer checks
    /// </summary>
    Glow,
    /// <summary>
    /// src*srca+dest*(1-srca)
    /// </summary>
    TransAlpha,
    /// <summary>
    /// src*a+dest
    /// </summary>
    TransAdd,
}
