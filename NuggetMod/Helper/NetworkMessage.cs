using NuggetMod.Enum.Engine;
using NuggetMod.Interface;
using NuggetMod.Wrapper.Common;
using NuggetMod.Wrapper.Engine;
using System.Runtime.CompilerServices;

namespace NuggetMod.Helper;
/// <summary>
/// Factory class for creating network messages.
/// Not thread-safe. Use one instance per message.
/// </summary>
public class NetworkMessage
{
    private bool _sent = false;

    /// <summary>
    /// Create a network message with all parameters.
    /// </summary>
    /// <param name="dest">message destination</param>
    /// <param name="type">message type</param>
    /// <param name="origin">message origin pos</param>
    /// <param name="target">message target</param>
    public NetworkMessage(MessageDestination dest, int type, Vector3f origin, Edict target)
    {
        MetaMod.EngineFuncs.MessageBegin(dest, type, origin, target);
    }
    /// <summary>
    /// Create a network message without origin.
    /// </summary>
    /// <param name="dest">message destination</param>
    /// <param name="type">message type</param>
    /// <param name="target">message target</param>
    public NetworkMessage(MessageDestination dest, int type, Edict target)
    {
        MetaMod.EngineFuncs.MessageBegin(dest, type, null, target);
    }
    /// <summary>
    /// Create a network message without target (PVS/PAS)
    /// </summary>
    /// <param name="dest">message destination</param>
    /// <param name="type">message type</param>
    /// <param name="origin">message origin pos</param>
    public NetworkMessage(MessageDestination dest, int type, Vector3f origin)
    {
        MetaMod.EngineFuncs.MessageBegin(dest, type, origin, null);
    }
    /// <summary>
    /// Create a network message with only destination and type (ALL/BROADCAST).
    /// </summary>
    /// <param name="dest">message destination</param>
    /// <param name="type">message type</param>
    public NetworkMessage(MessageDestination dest, int type)
    {
        MetaMod.EngineFuncs.MessageBegin(dest, type, null, null);
    }
    /// <summary>
    /// Write a byte to the message.
    /// </summary>
    /// <param name="value">value</param>
    /// <returns>this</returns>
    public NetworkMessage WriteByte(byte value)
    {
        MetaMod.EngineFuncs.WriteByte(value);
        return this;
    }
    /// <summary>
    /// Write a char to the message.
    /// </summary>
    /// <param name="value">value</param>
    /// <returns>this</returns>
    public NetworkMessage WriteChar(sbyte value)
    {
        MetaMod.EngineFuncs.WriteChar(value);
        return this;
    }
    /// <summary>
    /// Write a int16 to the message.
    /// </summary>
    /// <param name="value">value</param>
    /// <returns>this</returns>
    public NetworkMessage WriteShort(short value)
    {
        MetaMod.EngineFuncs.WriteShort(value);
        return this;
    }
    /// <summary>
    /// Write a int32 to the message.
    /// </summary>
    /// <param name="value">value</param>
    /// <returns>this</returns>
    public NetworkMessage WriteLong(int value)
    {
        MetaMod.EngineFuncs.WriteLong(value);
        return this;
    }
    /// <summary>
    /// Write a angle to the message.
    /// </summary>
    /// <param name="value">value</param>
    /// <returns>this</returns>
    public NetworkMessage WriteAngle(float value)
    {
        MetaMod.EngineFuncs.WriteAngle(value);
        return this;
    }
    /// <summary>
    /// Write a coord to the message.
    /// </summary>
    /// <param name="value">value</param>
    /// <returns>this</returns>
    public NetworkMessage WriteCoord(float value)
    {
        MetaMod.EngineFuncs.WriteCoord(value);
        return this;
    }
    /// <summary>
    /// Write a string to the message.
    /// </summary>
    /// <param name="value">value</param>
    /// <returns>this</returns>
    public NetworkMessage WriteString(string value)
    {
        MetaMod.EngineFuncs.WriteString(value);
        return this;
    }
    /// <summary>
    /// Write a entity to the message.
    /// </summary>
    /// <param name="value">value</param>
    /// <returns>this</returns>
    public NetworkMessage WriteEntity(Edict value)
    {
        int index = MetaMod.EngineFuncs.IndexOfEdict(value);
        MetaMod.EngineFuncs.WriteEntity(index);
        return this;
    }
    /// <summary>
    /// Write a float to the message.
    /// </summary>
    /// <param name="value">value</param>
    /// <returns>this</returns>
    public NetworkMessage WriteFloat(float value)
    {
        int i = Unsafe.As<float, int>(ref value);
        MetaMod.EngineFuncs.WriteLong(i);
        return this;
    }
    /// <summary>
    /// Write a vector(as 3 coord) to the message.
    /// </summary>
    /// <param name="value">value</param>
    /// <returns>this</returns>
    public NetworkMessage WriteVector(Vector3f value)
    {
        MetaMod.EngineFuncs.WriteCoord(value.X);
        MetaMod.EngineFuncs.WriteCoord(value.Y);
        MetaMod.EngineFuncs.WriteCoord(value.Z);
        return this;
    }
    /// <summary>
    /// Send the message.
    /// </summary>
    /// <exception cref="InvalidOperationException">networkmessage has already been sent</exception>
    public void Send()
    {
        if (_sent)
            throw new InvalidOperationException("NetworkMessage has already been sent.");
        _sent = true;
        MetaMod.EngineFuncs.MessageEnd();
    }
}
