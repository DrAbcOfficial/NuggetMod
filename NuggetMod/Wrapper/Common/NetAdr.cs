using NuggetMod.Native.Common;
using System.Net;

namespace NuggetMod.Wrapper.Common;

/// <summary>
/// Represents a network address
/// </summary>
public class NetAdr : BaseNativeWrapper<NativeNetAdr>
{
    internal unsafe NetAdr(nint ptr) : base((NativeNetAdr*)ptr) { }
    
    /// <summary>
    /// Defines network address types
    /// </summary>
    public enum NetAdrType
    {
        /// <summary>Unused address</summary>
        NA_UNUSED,
        /// <summary>Loopback address</summary>
        NA_LOOPBACK,
        /// <summary>Broadcast address</summary>
        NA_BROADCAST,
        /// <summary>IP address</summary>
        NA_IP,
        /// <summary>IPX address</summary>
        NA_IPX,
        /// <summary>IPX broadcast address</summary>
        NA_BROADCAST_IPX,
    }

    /// <summary>
    /// Gets or sets the network address type
    /// </summary>
    public NetAdrType Type
    {
        get
        {
            unsafe
            {
                return (NetAdrType)NativePtr->type;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->type = (int)value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the IP address (IPv4)
    /// </summary>
    public IPAddress IPAddress
    {
        get
        {
            unsafe
            {
                byte[] ipCopy = new byte[4];
                for (int i = 0; i < 4; i++)
                {
                    ipCopy[i] = NativePtr->ip[i];
                }
                return new IPAddress(ipCopy);
            }
        }
        set
        {
            unsafe
            {
                byte[] ip = value.GetAddressBytes();
                for (int i = 0; i < 4; i++)
                {
                    NativePtr->ip[i] = ip[i];
                }
            }
        }
    }
    
    /// <summary>
    /// Gets or sets the IPX address (10 bytes)
    /// </summary>
    public byte[] Ipx
    {
        get
        {
            unsafe
            {
                byte[] ipxCopy = new byte[10];
                for (int i = 0; i < 10; i++)
                {
                    ipxCopy[i] = NativePtr->ipx[i];
                }
                return ipxCopy;
            }
        }
        set
        {
            unsafe
            {
                ArgumentNullException.ThrowIfNull(value);
                if (value.Length != 10)
                    throw new ArgumentOutOfRangeException(nameof(value), "IPX address must be 10 bytes long");

                for (int i = 0; i < 10; i++)
                {
                    NativePtr->ipx[i] = value[i];
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets the network port number
    /// </summary>
    public ushort Port
    {
        get
        {
            unsafe
            {
                return NativePtr->port;
            }
        }
        set
        {
            unsafe
            {
                NativePtr->port = value;
            }
        }
    }
}
