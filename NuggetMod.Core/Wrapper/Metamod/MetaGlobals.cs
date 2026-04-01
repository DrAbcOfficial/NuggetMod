using NuggetMod.Enum.Metamod;
using NuggetMod.Native.Metamod;

namespace NuggetMod.Wrapper.Metamod
{
    /// <summary>
    /// Wrapper for MetaMod global variables
    /// </summary>
    public class MetaGlobals : BaseNativeWrapper<NativeMetaGlobals>
    {
        internal unsafe MetaGlobals(NativeMetaGlobals* ptr) : base(ptr) { }
        internal unsafe MetaGlobals(nint ptr) : this((NativeMetaGlobals*)ptr) { }

        /// <summary>
        /// Gets or sets the plugin's return result flag
        /// </summary>
        public MetaResult Result
        {
            get
            {
                unsafe
                {
                    return NativePtr->mres;
                }
            }
            set
            {
                unsafe
                {
                    NativePtr->mres = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the previous result value
        /// </summary>
        public MetaResult PreverseResult
        {
            get
            {
                unsafe
                {
                    return NativePtr->prev_mres;
                }
            }
            set
            {
                unsafe
                {
                    NativePtr->prev_mres = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the current status of the plugin execution
        /// </summary>
        public MetaResult Status
        {
            get
            {
                unsafe
                {
                    return NativePtr->status;
                }
            }
            set
            {
                unsafe
                {
                    NativePtr->status = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the original return value from the hooked function
        /// </summary>
        public nint OriginReturn
        {
            get
            {
                unsafe
                {
                    return NativePtr->orig_ret;
                }
            }
            set
            {
                unsafe
                {
                    NativePtr->orig_ret = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the override return value to replace the original return
        /// </summary>
        public nint OverrideReturn
        {
            get
            {
                unsafe
                {
                    return NativePtr->override_ret;
                }
            }
            set
            {
                unsafe
                {
                    NativePtr->override_ret = value;
                }
            }
        }

        /// <summary>
        /// Gets the original return value casted to the specified unmanaged type
        /// </summary>
        /// <typeparam name="T">unmanaged type</typeparam>
        /// <returns>value</returns>
        public T GetOriginalReturn<T>() where T : unmanaged
        {
            unsafe
            {
                return *((T*)(NativePtr->orig_ret));
            }
        }
        /// <summary>
        /// Sets the override return value to the specified unmanaged type
        /// </summary>
        /// <typeparam name="T">unmanaged type</typeparam>
        /// <param name="value">value</param>
        /// <exception cref="InvalidOperationException">null override_ret</exception>
        public void SetOverrideReturn<T>(T value) where T : unmanaged
        {
            unsafe
            {
                if (NativePtr->override_ret == nint.Zero)
                {
                    throw new InvalidOperationException("Override return pointer is null.");
                }
                *((T*)(NativePtr->override_ret)) = value;
            }
        }

        /// <summary>
        /// Gets the override return value casted to the specified unmanaged type
        /// </summary>
        /// <typeparam name="T">unmanaged type</typeparam>
        /// <returns>value</returns>
        public T GetOverrideReturn<T>() where T : unmanaged
        {
            unsafe
            {
                return *((T*)(NativePtr->override_ret));
            }
        }

        /// <summary>
        /// Sets the override return value to the specified unmanaged type
        /// </summary>
        /// <typeparam name="T">unmanaged type</typeparam>
        /// <param name="value">value</param>
        /// <exception cref="InvalidOperationException">null override_ret</exception>
        public void SetOriginReturn<T>(T value) where T : unmanaged
        {
            unsafe
            {
                if (NativePtr->orig_ret == nint.Zero)
                {
                    throw new InvalidOperationException("Original return pointer is null.");
                }
                *((T*)(NativePtr->orig_ret)) = value;
            }
        }
    }
}