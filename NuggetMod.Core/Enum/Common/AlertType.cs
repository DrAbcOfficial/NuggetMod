namespace NuggetMod.Enum.Common;

/// <summary>
/// Defines alert message types for the game engine
/// </summary>
public enum AlertType
{
    /// <summary>
    /// Notice message
    /// </summary>
    Notice,
    
    /// <summary>
    /// Console message (same as at_notice, but forces a ConPrintf, not a message box)
    /// </summary>
    Console,
    
    /// <summary>
    /// AI console message (same as at_console, but only shown if developer level is 2)
    /// </summary>
    DeveloperConsole,
    
    /// <summary>
    /// Warning message
    /// </summary>
    Warning,
    
    /// <summary>
    /// Error message
    /// </summary>
    Error,
    
    /// <summary>
    /// Logged message (server print to console, only in multiplayer games)
    /// </summary>
    Logged
}
