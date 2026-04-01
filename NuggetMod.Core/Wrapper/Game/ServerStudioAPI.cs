using NuggetMod.Native.Game;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper.Game;

/// <summary>
/// Wrapper for server-side studio model API
/// </summary>
public class ServerStudioAPI(nint ptr) : BaseFunctionWrapper<NativeServerStudioAPI>(ptr)
{
    /// <summary>
    /// Allocates memory
    /// </summary>
    /// <param name="number">Number of elements</param>
    /// <param name="size">Size of each element</param>
    /// <returns>Pointer to allocated memory</returns>
    public nint MemCalloc(int number, uint size) => Base.Mem_Calloc(number, size);
    
    /// <summary>
    /// Checks cache validity
    /// </summary>
    /// <param name="cacheUser">Cache user pointer</param>
    /// <returns>Cache data pointer</returns>
    public nint CacheCheck(nint cacheUser) => Base.Cache_Check(cacheUser);
    
    /// <summary>
    /// Loads a cache file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="cacheUser">Cache user pointer</param>
    public void LoadCacheFile(string path, nint cacheUser)
    {
        nint ptr = Marshal.StringToHGlobalAnsi(path);
        unsafe
        {
            Base.LoadCacheFile((byte*)ptr, cacheUser);
        }
        Marshal.FreeHGlobal(ptr);
    }
    
    /// <summary>
    /// Gets extra data from a model
    /// </summary>
    /// <param name="model">Model pointer</param>
    /// <returns>Extra data pointer</returns>
    public nint ModExtradata(nint model) => Base.Mod_Extradata(model);
}
