using NuggetMod.Native.Metamod;
using NuggetMod.Wrapper.Game;

namespace NuggetMod.Wrapper.Metamod;

/// <summary>
/// Wrapper for game DLL function tables accessible through MetaMod
/// </summary>
public class MetaGameDLLFunctions : BaseFunctionWrapper<NativeMetaGameDLLFunctions>
{
    /// <summary>
    /// Gets the DLL functions table
    /// </summary>
    public DLLFunctions? DllFuncs;
    
    /// <summary>
    /// Gets the new DLL functions table
    /// </summary>
    public NewDLLFunctions? NewDllFuncs;
    
    /// <summary>
    /// Gets the server blending interface
    /// </summary>
    public ServerBlendInterface? ServerBlendInterface;
    internal MetaGameDLLFunctions(nint ptr) : base(ptr)
    {
        DllFuncs = new(Base.dllapi_table);
        NewDllFuncs = new(Base.newapi_table);
        ServerBlendInterface = new(Base.studio_blend_api);
    }
}
