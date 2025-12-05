using System.Runtime.InteropServices;

namespace NuggetMod.Native.NuggetMod;

/// <summary>
/// Native structure representing plugin information for Metamod.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct NativePluginInfo : INativeStruct
{
    /// <summary>
    /// Pointer to meta_interface version string.
    /// </summary>
    internal nint ifvers;
    /// <summary>
    /// Pointer to full name of plugin.
    /// </summary>
    internal nint name;
    /// <summary>
    /// Pointer to version string.
    /// </summary>
    internal nint version;
    /// <summary>
    /// Pointer to date string.
    /// </summary>
    internal nint date;
    /// <summary>
    /// Pointer to author name/email.
    /// </summary>
    internal nint author;
    /// <summary>
    /// Pointer to URL string.
    /// </summary>
    internal nint url;
    /// <summary>
    /// Pointer to log message prefix (unused right now).
    /// </summary>
    internal nint logtag;
    /// <summary>
    /// When the plugin can be loaded (PluginLoadTime enum value).
    /// </summary>
    internal int loadable;
    /// <summary>
    /// When the plugin can be unloaded (PluginLoadTime enum value).
    /// </summary>
    internal int unloadable;
};