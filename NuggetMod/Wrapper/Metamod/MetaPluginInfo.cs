using NuggetMod.Enum.NuggetMod;

namespace NuggetMod.Wrapper.Metamod;

/// <summary>
/// Contains metadata information about a MetaMod plugin
/// </summary>
public class MetaPluginInfo
{
    /// <summary>
    /// MetaMod interface version
    /// </summary>
    public required InterfaceVersion InterfaceVersion;
    
    /// <summary>
    /// Full name of the plugin
    /// </summary>
    public required string Name;
    
    /// <summary>
    /// Plugin version string
    /// </summary>
    public required string Version;
    
    /// <summary>
    /// Plugin release date
    /// </summary>
    public required string Date;
    
    /// <summary>
    /// Author name and/or email
    /// </summary>
    public required string Author;
    
    /// <summary>
    /// Plugin URL
    /// </summary>
    public required string Url;
    
    /// <summary>
    /// Log message prefix
    /// </summary>
    public required string LogTag;
    
    /// <summary>
    /// When the plugin can be loaded
    /// </summary>
    public required PluginLoadTime Loadable;
    
    /// <summary>
    /// When the plugin can be unloaded
    /// </summary>
    public required PluginLoadTime Unloadable;

    internal nint NavitePtr;

    /// <summary>
    /// Gets the interface version as a string
    /// </summary>
    /// <returns>Interface version string (e.g., "5:13")</returns>
    public string GetInterfaceVersionString()
    {
        string str = InterfaceVersion.ToString();
        str = str[1..].Replace('_', ':');
        return str;
    }
}
