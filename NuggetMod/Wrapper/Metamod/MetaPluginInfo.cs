using NuggetMod.Enum.Metamod;
using NuggetMod.Native.Metamod;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper.Metamod;

/// <summary>
/// Contains metadata information about a MetaMod plugin
/// </summary>
public class MetaPluginInfo : IDisposable
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
    private unsafe nint _nativePtr = nint.Zero;
    internal unsafe NativePluginInfo* NativePtr
    {
        get
        {
            if (_nativePtr == nint.Zero)
            {

                if (_nativePtr == nint.Zero)
                {
                    nint tempPtr = nint.Zero;
                    try
                    {
                        tempPtr = Marshal.AllocHGlobal(sizeof(NativePluginInfo));
                        var info = (NativePluginInfo*)tempPtr;

                        info->ifvers = Marshal.StringToHGlobalAnsi(GetInterfaceVersionString());
                        info->name = Marshal.StringToHGlobalAnsi(Name);
                        info->version = Marshal.StringToHGlobalAnsi(Version);
                        info->date = Marshal.StringToHGlobalAnsi(Date);
                        info->author = Marshal.StringToHGlobalAnsi(Author);
                        info->url = Marshal.StringToHGlobalAnsi(Url);
                        info->logtag = Marshal.StringToHGlobalAnsi(LogTag);
                        info->loadable = (int)Loadable;
                        info->unloadable = (int)Unloadable;

                        _nativePtr = tempPtr;
                    }
                    catch
                    {
                        if (tempPtr != nint.Zero)
                        {
                            var info = (NativePluginInfo*)tempPtr;
                            if (info->ifvers != nint.Zero)
                                Marshal.FreeHGlobal(info->ifvers);
                            if (info->name != nint.Zero)
                                Marshal.FreeHGlobal(info->name);
                            if (info->version != nint.Zero)
                                Marshal.FreeHGlobal(info->version);
                            if (info->date != nint.Zero)
                                Marshal.FreeHGlobal(info->date);
                            if (info->author != nint.Zero)
                                Marshal.FreeHGlobal(info->author);
                            if (info->url != nint.Zero)
                                Marshal.FreeHGlobal(info->url);
                            if (info->logtag != nint.Zero)
                                Marshal.FreeHGlobal(info->logtag);
                            Marshal.FreeHGlobal(tempPtr);
                        }
                        throw;
                    }
                }
            }
            return (NativePluginInfo*)_nativePtr;
        }
    }

    private bool _disposed = false;

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

    /// <summary>
    /// Releases the unmanaged memory allocated for this plugin info
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the unmanaged memory allocated for this plugin info
    /// </summary>
    /// <param name="disposing">True if called from Dispose, false if called from finalizer</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (_nativePtr != nint.Zero)
            {
                unsafe
                {
                    var info = (NativePluginInfo*)_nativePtr;
                    if (info->ifvers != nint.Zero)
                        Marshal.FreeHGlobal(info->ifvers);
                    if (info->name != nint.Zero)
                        Marshal.FreeHGlobal(info->name);
                    if (info->version != nint.Zero)
                        Marshal.FreeHGlobal(info->version);
                    if (info->date != nint.Zero)
                        Marshal.FreeHGlobal(info->date);
                    if (info->author != nint.Zero)
                        Marshal.FreeHGlobal(info->author);
                    if (info->url != nint.Zero)
                        Marshal.FreeHGlobal(info->url);
                    if (info->logtag != nint.Zero)
                        Marshal.FreeHGlobal(info->logtag);
                }
                Marshal.FreeHGlobal(_nativePtr);
                _nativePtr = nint.Zero;
            }
            _disposed = true;
        }
    }

    /// <summary>
    /// Finalizer to ensure unmanaged memory is released
    /// </summary>
    ~MetaPluginInfo()
    {
        Dispose(false);
    }
}
