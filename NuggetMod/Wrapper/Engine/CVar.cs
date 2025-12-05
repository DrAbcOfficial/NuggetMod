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
    internal unsafe CVar(nint ptr) : this((NativeCVar*)ptr) { }
    internal unsafe CVar(NativeCVar* native) : base(native) { }
    /// <summary>
    /// Gets or sets the console variable name
    /// </summary>
    public string Name
    {
        get
        {
            unsafe
            {
                return Marshal.PtrToStringUTF8(NativePtr->name) ?? string.Empty;
            }
        }
        set
        {
            unsafe
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(value + '\0');
                Marshal.Copy(bytes, 0, NativePtr->name, bytes.Length);
            }

        }
    }

    /// <summary>
    /// Gets or sets the console variable string value
    /// </summary>
    public string Str
    {
        get
        {
            unsafe
            {
                return Marshal.PtrToStringUTF8(NativePtr->str) ?? string.Empty;
            }
        }
        set
        {
            unsafe
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(value + '\0');
                Marshal.Copy(bytes, 0, NativePtr->str, bytes.Length);
            }

        }
    }

    /// <summary>
    /// Gets or sets the console variable flags
    /// </summary>
    public int Flags
    {
        get
        {
            unsafe
            {
                return NativePtr->flags;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->flags = value;
            }
        }
    }

    /// <summary>
    /// Tests if a specific flag is set
    /// </summary>
    /// <param name="flag">Flag to test</param>
    /// <returns>True if flag is set</returns>
    public bool TestFlag(FCVAR flag)
    {
        return (Flags & (int)flag) != 0;
    }

    /// <summary>
    /// Sets a specific flag
    /// </summary>
    /// <param name="flag">Flag to set</param>
    public void SetFlag(FCVAR flag)
    {
        Flags |= (int)flag;
    }

    /// <summary>
    /// Removes a specific flag
    /// </summary>
    /// <param name="flag">Flag to remove</param>
    public void RemoveFlag(FCVAR flag)
    {
        Flags &= ~(int)flag;
    }

    /// <summary>
    /// Gets or sets the console variable float value
    /// </summary>
    public float Value
    {
        get
        {
            unsafe
            {
                return NativePtr->value;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->value = value;
            }
        }
    }

    /// <summary>
    /// Gets the next console variable in the linked list
    /// </summary>
    public CVar? Next
    {
        get
        {
            unsafe
            {
                var nextPtr = (NativeCVar*)NativePtr->next;
                return nextPtr != null ? new CVar(nextPtr) : null;
            }
        }
    }
}
