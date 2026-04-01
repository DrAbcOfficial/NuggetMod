namespace NuggetMod.Enum.Common;

/// <summary>
/// Defines file consistency enforcement types for client-server synchronization
/// </summary>
public enum ForceType
{
    /// <summary>
    /// File on client must exactly match server's file
    /// </summary>
    ExactFile,
    
    /// <summary>
    /// For model files only, the geometry must fit in the same bounding box
    /// </summary>
    ModelSameBounds,
    
    /// <summary>
    /// For model files only, the geometry must fit in the specified bounding box
    /// </summary>
    ModelSpecifyBounds,
    
    /// <summary>
    /// For Steam model files only, the geometry must fit in the specified bounding box (if the file is available)
    /// </summary>
    ModelSpecifyBoundsIfAvailable,
}
