using NuggetMod.Enum.Metamod;
using NuggetMod.Wrapper.Metamod;
namespace NuggetMod.Interface;

/// <summary>
/// Interface for MetaMod plugin implementation
/// </summary>
public interface IPlugin
{
    /// <summary>
    /// Gets the plugin information
    /// </summary>
    /// <returns>Plugin metadata</returns>
    public MetaPluginInfo GetPluginInfo();
    
    /// <summary>
    /// Initializes the plugin
    /// </summary>
    public void MetaInit();
    
    /// <summary>
    /// Queries the plugin for compatibility and initialization
    /// </summary>
    /// <param name="interfaceVersion">MetaMod interface version</param>
    /// <param name="pMetaUtilFuncs">MetaMod utility functions</param>
    /// <returns>True if the plugin can load successfully</returns>
    public bool MetaQuery(InterfaceVersion interfaceVersion, MetaUtilFunctions pMetaUtilFuncs);
    
    /// <summary>
    /// Attaches the plugin to the game
    /// </summary>
    /// <param name="now">Current plugin load time</param>
    /// <param name="pMGlobals">MetaMod global variables</param>
    /// <param name="pGamedllFuncs">Game DLL functions</param>
    /// <returns>True if attachment was successful</returns>
    public bool MetaAttach(PluginLoadTime now, MetaGlobals pMGlobals, MetaGameDLLFunctions pGamedllFuncs);
    
    /// <summary>
    /// Detaches the plugin from the game
    /// </summary>
    /// <param name="now">Current plugin load time</param>
    /// <param name="reason">Reason for unloading</param>
    /// <returns>True if detachment was successful</returns>
    public bool MetaDetach(PluginLoadTime now, PluginUnloadReason reason);
}
