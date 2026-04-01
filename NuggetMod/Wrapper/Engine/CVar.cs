using NuggetMod.Native.Engine;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper.Engine;

/// <summary>
/// Represents a console variable (CVar)
/// </summary>
public class CVar : BaseNativeWrapper<NativeCVar>
{
    /// <summary>
    /// Console variable flags
    /// </summary>
    public enum FCVAR
    {
        /// <summary>No flags</summary>
        None = 0,
        /// <summary>Saved to config file</summary>
        Archive = 1 << 0,
        /// <summary>User info variable</summary>
        UserInfo = 1 << 1,
        /// <summary>Server variable</summary>
        Server = 1 << 2,
        /// <summary>External DLL variable</summary>
        ExternalDLL = 1 << 3,
        /// <summary>Client DLL variable</summary>
        ClientDLL = 1 << 4,
        /// <summary>
        /// Protected, will not show args in console
        /// </summary>
        Protected = 1 << 5,
        /// <summary>
        /// Single play only
        /// </summary>
        SinglePlayOnly = 1 << 6,
        /// <summary>
        /// Printable characters only
        /// </summary>
        PrintableOnly = 1 << 7,
        /// <summary>
        /// Won't log in console
        /// </summary>
        Unlogged = 1 << 8,
    }

    // Static dictionary to keep registered CVars alive and prevent GC collection
    // Key: CVar name, Value: CVar instance
    private static readonly Dictionary<string, CVar> s_registeredCVars = new();

    internal unsafe CVar(nint ptr) : this((NativeCVar*)ptr) { }
    internal unsafe CVar(NativeCVar* native) : base(native) { }

    /// <summary>
    /// Creates a new console variable. Use MetaMod.EngineFuncs.CVarRegister() or extension methods to register it with the engine.
    /// Important: The returned CVar must be kept alive (held in a static field or registered) to prevent GC from collecting it.
    /// </summary>
    /// <param name="name">The name of the cvar</param>
    /// <param name="defaultValue">The default string value</param>
    /// <param name="flags">CVar flags (e.g., FCVAR_ARCHIVE)</param>
    public unsafe CVar(string name, string defaultValue, FCVAR flags = FCVAR.None) : base()
    {
        NameString = name ?? throw new ArgumentNullException(nameof(name));

        // Allocate and set name
        var nameBytes = System.Text.Encoding.UTF8.GetBytes(name + '\0');
        nint namePtr = Marshal.AllocHGlobal(nameBytes.Length);
        Marshal.Copy(nameBytes, 0, namePtr, nameBytes.Length);

        // Allocate and set default value
        var valueBytes = System.Text.Encoding.UTF8.GetBytes(defaultValue + '\0');
        nint valuePtr = Marshal.AllocHGlobal(valueBytes.Length);
        Marshal.Copy(valueBytes, 0, valuePtr, valueBytes.Length);

        // Initialize the native structure
        NativePtr->name = namePtr;
        NativePtr->str = valuePtr;
        NativePtr->flags = (int)flags;
        NativePtr->value = float.TryParse(defaultValue, out float f) ? f : 0f;
        NativePtr->next = 0;
    }

    /// <summary>
    /// Creates a new console variable. Use MetaMod.EngineFuncs.CVarRegister() or extension methods to register it with the engine.
    /// Important: The returned CVar must be kept alive (held in a static field or registered) to prevent GC from collecting it.
    /// </summary>
    /// <param name="name">The name of the cvar</param>
    /// <param name="defaultValue">The default float value</param>
    /// <param name="flags">CVar flags (e.g., FCVAR_ARCHIVE)</param>
    public unsafe CVar(string name, float defaultValue, FCVAR flags = FCVAR.None) : this(name, defaultValue.ToString(), flags)
    {
    }

    /// <summary>
    /// Gets the CVar name (managed string, used for tracking registered CVars).
    /// </summary>
    internal string NameString { get; } = string.Empty;

    /// <summary>
    /// Internally registers this CVar in the static dictionary to prevent GC collection.
    /// Called by extension methods upon registration.
    /// </summary>
    internal void TrackRegistration()
    {
        lock (s_registeredCVars)
        {
            s_registeredCVars[NameString.ToLowerInvariant()] = this;
        }
    }

    /// <summary>
    /// Releases unmanaged resources including string memory.
    /// </summary>
    protected override unsafe void Dispose(bool disposing)
    {
        if (NativePtr != null)
        {
            // Free name and value strings if they were allocated
            if (NativePtr->name != 0)
            {
                Marshal.FreeHGlobal(NativePtr->name);
                NativePtr->name = 0;
            }
            if (NativePtr->str != 0)
            {
                Marshal.FreeHGlobal(NativePtr->str);
                NativePtr->str = 0;
            }

            // Remove from registered dictionary
            lock (s_registeredCVars)
            {
                s_registeredCVars.Remove(NameString.ToLowerInvariant());
            }
        }

        base.Dispose(disposing);
    }
    /// <summary>
    /// Gets or sets the console variable name
    /// </summary>
    public unsafe string Name
    {
        get => Marshal.PtrToStringUTF8(NativePtr->name) ?? string.Empty;
        set
        {
            ArgumentNullException.ThrowIfNull(value);

            // 释放原有内存（如果不是由当前CVar分配的，则不应释放）
            // 这里假设setter只在新创建的CVar上调用
            var bytes = System.Text.Encoding.UTF8.GetBytes(value + '\0');
            nint newPtr = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, newPtr, bytes.Length);

            // 原子地更新指针
            nint oldPtr = NativePtr->name;
            NativePtr->name = newPtr;

            // 释放旧内存
            if (oldPtr != nint.Zero)
            {
                Marshal.FreeHGlobal(oldPtr);
            }
        }
    }

    /// <summary>
    /// Gets or sets the console variable string value
    /// </summary>
    public unsafe string Str
    {
        get => Marshal.PtrToStringUTF8(NativePtr->str) ?? string.Empty;
        set
        {
            ArgumentNullException.ThrowIfNull(value);

            // 分配新内存并复制数据
            var bytes = System.Text.Encoding.UTF8.GetBytes(value + '\0');
            nint newPtr = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, newPtr, bytes.Length);

            // 原子地更新指针
            nint oldPtr = NativePtr->str;
            NativePtr->str = newPtr;

            // 释放旧内存
            if (oldPtr != nint.Zero)
            {
                Marshal.FreeHGlobal(oldPtr);
            }

            // 更新float值
            NativePtr->value = float.TryParse(value, out float f) ? f : 0f;
        }
    }

    /// <summary>
    /// Gets or sets the console variable flags
    /// </summary>
    public unsafe int Flags
    {
        get => NativePtr->flags;
        set => NativePtr->flags = value;
    }

    /// <summary>
    /// Tests if a specific flag is set
    /// </summary>
    /// <param name="flag">Flag to test</param>
    /// <returns>True if flag is set</returns>
    public bool TestFlag(FCVAR flag) => (Flags & (int)flag) != 0;

    /// <summary>
    /// Sets a specific flag
    /// </summary>
    /// <param name="flag">Flag to set</param>
    public void SetFlag(FCVAR flag) => Flags |= (int)flag;

    /// <summary>
    /// Removes a specific flag
    /// </summary>
    /// <param name="flag">Flag to remove</param>
    public void RemoveFlag(FCVAR flag) => Flags &= ~(int)flag;

    /// <summary>
    /// Gets or sets the console variable float value
    /// </summary>
    public unsafe float Value
    {
        get => NativePtr->value;
        set => NativePtr->value = value;
    }

    /// <summary>
    /// Gets the next console variable in the linked list
    /// </summary>
    public unsafe CVar? Next
    {
        get
        {
            var nextPtr = (NativeCVar*)NativePtr->next;
            return nextPtr != null ? new CVar(nextPtr) : null;
        }
    }
}

/// <summary>
/// C# style extension methods for CVar registration
/// </summary>
public static class CVarExtensions
{
    /// <summary>
    /// Registers this CVar with the engine using fluent API style.
    /// The CVar is kept alive internally to prevent GC collection.
    /// </summary>
    /// <param name="cvar">The CVar to register</param>
    /// <param name="engineFuncs">Engine functions interface</param>
    /// <returns>The same CVar instance for method chaining</returns>
    public static CVar RegisterWith(this CVar cvar, EngineFuncs engineFuncs)
    {
        engineFuncs.CVarRegister(cvar);
        cvar.TrackRegistration(); // Keep alive to prevent GC
        return cvar;
    }

    /// <summary>
    /// Creates and registers a CVar in a single call.
    /// The CVar is kept alive internally to prevent GC collection.
    /// </summary>
    /// <param name="engineFuncs">Engine functions interface</param>
    /// <param name="name">The name of the cvar</param>
    /// <param name="defaultValue">The default string value</param>
    /// <param name="flags">CVar flags (e.g., FCVAR_ARCHIVE)</param>
    /// <returns>The registered CVar instance</returns>
    public static CVar CreateCVar(this EngineFuncs engineFuncs, string name, string defaultValue, CVar.FCVAR flags = CVar.FCVAR.None)
    {
        var cvar = new CVar(name, defaultValue, flags);
        engineFuncs.CVarRegister(cvar);
        cvar.TrackRegistration(); // Keep alive to prevent GC
        return cvar;
    }

    /// <summary>
    /// Creates and registers a CVar in a single call.
    /// The CVar is kept alive internally to prevent GC collection.
    /// </summary>
    /// <param name="engineFuncs">Engine functions interface</param>
    /// <param name="name">The name of the cvar</param>
    /// <param name="defaultValue">The default float value</param>
    /// <param name="flags">CVar flags (e.g., FCVAR_ARCHIVE)</param>
    /// <returns>The registered CVar instance</returns>
    public static CVar CreateCVar(this EngineFuncs engineFuncs, string name, float defaultValue, CVar.FCVAR flags = CVar.FCVAR.None)
    {
        var cvar = new CVar(name, defaultValue, flags);
        engineFuncs.CVarRegister(cvar);
        cvar.TrackRegistration(); // Keep alive to prevent GC
        return cvar;
    }
}
