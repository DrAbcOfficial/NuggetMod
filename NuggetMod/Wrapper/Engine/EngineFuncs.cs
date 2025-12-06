using NuggetMod.Enum.Common;
using NuggetMod.Enum.Engine;
using NuggetMod.Helper;
using NuggetMod.Native.Common;
using NuggetMod.Native.Engine;
using NuggetMod.Wrapper.Common;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper.Engine;

/// <summary>
/// Wrapper for engine function table providing access to engine API
/// </summary>
public class EngineFuncs(nint ptr) : BaseFunctionWrapper<NativeEngineFuncs>(ptr)
{
    /// <summary>
    /// Precaches a model file
    /// </summary>
    /// <param name="s">Model file path</param>
    public void PrecacheModel(string s)
    {
        nint ns = Marshal.StringToHGlobalAnsi(s);
        Base.pfnPrecacheModel(ns);
        Marshal.FreeHGlobal(ns);
    }

    /// <summary>
    /// Precaches a sound file
    /// </summary>
    /// <param name="s">Sound file path</param>
    public void PrecacheSound(string s)
    {
        nint ns = Marshal.StringToHGlobalAnsi(s);
        Base.pfnPrecacheSound(ns);
        Marshal.FreeHGlobal(ns);
    }

    /// <summary>
    /// Sets the model for an entity
    /// </summary>
    /// <param name="e">Entity to set model for</param>
    /// <param name="m">Model file path</param>
    public void SetModel(Edict e, string m)
    {
        nint ns = Marshal.StringToHGlobalAnsi(m);
        Base.pfnSetModel(e.GetPointer(), ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Gets the model index for a given model name
    /// </summary>
    /// <param name="m">Model name to look up</param>
    /// <returns>Model index number</returns>
    public int ModelIndex(string m)
    {
        nint ns = Marshal.StringToHGlobalAnsi(m);
        int ret = Base.pfnModelIndex(ns);
        Marshal.FreeHGlobal(ns);
        return ret;
    }
    /// <summary>
    /// Gets the number of frames in a model
    /// </summary>
    /// <param name="modelIndex">Model index to query</param>
    /// <returns>Number of animation frames in the model</returns>
    public int ModelFrames(int modelIndex) => Base.pfnModelFrames(modelIndex);
    /// <summary>
    /// Sets the bounding box size for an entity
    /// </summary>
    /// <param name="e">Entity to set size for</param>
    /// <param name="min">Minimum bounds vector (e.g., Vector(-1,-1,-1))</param>
    /// <param name="max">Maximum bounds vector (e.g., Vector(1, 1, 1))</param>
    public void SetSize(Edict e, Vector3f min, Vector3f max) => Base.pfnSetSize(e.GetPointer(), min.GetPointer(), max.GetPointer());
    /// <summary>
    /// Changes the current map/level
    /// </summary>
    /// <param name="s1">Map name to change to</param>
    /// <param name="s2">Landmark name for transition (optional)</param>
    public void ChangeLevel(string s1, string s2)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(s1);
        nint ns2 = Marshal.StringToHGlobalAnsi(s2);
        Base.pfnChangeLevel(ns1, ns2);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
    }

    /// <summary>
    /// Retrieves spawn parameters for an entity
    /// </summary>
    /// <param name="ent">Entity to get spawn parameters for</param>
    public void GetSpawnParms(Edict ent) => Base.pfnGetSpawnParms(ent.GetPointer());
    
    /// <summary>
    /// Saves spawn parameters for an entity
    /// </summary>
    /// <param name="ent">Entity to save spawn parameters for</param>
    public void SaveSpawnParms(Edict ent) => Base.pfnSaveSpawnParms(ent.GetPointer());
    
    /// <summary>
    /// Converts a direction vector to a yaw angle
    /// </summary>
    /// <param name="vec">Direction vector</param>
    /// <returns>Yaw angle in degrees</returns>
    public float VecToYaw(Vector3f vec) => Base.pfnVecToYaw(vec.GetPointer());
    
    /// <summary>
    /// Converts a direction vector to angle values
    /// </summary>
    /// <param name="vec">Direction vector</param>
    /// <param name="angles">Output angles (pitch, yaw, roll)</param>
    public void VecToAngles(Vector3f vec, Vector3f angles) => Base.pfnVecToAngles((nint)vec.GetPointer(), angles.GetPointer());
    
    /// <summary>
    /// Moves an entity towards a goal position
    /// </summary>
    /// <param name="ent">Entity to move</param>
    /// <param name="goal">Target position</param>
    /// <param name="dist">Distance to move</param>
    /// <param name="moveType">Type of movement</param>
    public void MoveToOrigin(Edict ent, Vector3f goal, float dist, int moveType) => Base.pfnMoveToOrigin(ent.GetPointer(), goal.GetPointer(), dist, moveType);
    
    /// <summary>
    /// Gradually changes an entity's yaw towards its ideal yaw
    /// </summary>
    /// <param name="edict">Entity to change yaw for</param>
    public void ChangeYaw(Edict edict) => Base.pfnChangeYaw(edict.GetPointer());
    
    /// <summary>
    /// Gradually changes an entity's pitch towards its ideal pitch
    /// </summary>
    /// <param name="ent">Entity to change pitch for</param>
    public void ChangePitch(Edict ent) => Base.pfnChangePitch(ent.GetPointer());
    /// <summary>
    /// Finds an entity by matching a field value
    /// </summary>
    /// <param name="e">Entity to start searching from (null to start from beginning)</param>
    /// <param name="field">Field name to search (e.g., "classname", "targetname")</param>
    /// <param name="value">Value to match</param>
    /// <returns>Found entity or null if not found</returns>
    public Edict FindEntityByString(Edict e, string field, string value)
    {
        unsafe
        {
            nint ns1 = Marshal.StringToHGlobalAnsi(field);
            nint ns2 = Marshal.StringToHGlobalAnsi(value);
            Edict ret = new((NativeEdict*)Base.pfnFindEntityByString(e.GetPointer(), ns1, ns2));
            Marshal.FreeHGlobal(ns1);
            Marshal.FreeHGlobal(ns2);
            return ret;
        }
    }
    /// <summary>
    /// Gets the illumination level at an entity's position
    /// </summary>
    /// <param name="ent">Entity to get illumination for</param>
    /// <returns>Illumination value (0-255)</returns>
    public int GetEntityIllum(Edict ent) => Base.pfnGetEntityIllum(ent.GetPointer());
    
    /// <summary>
    /// Finds entities within a spherical radius
    /// </summary>
    /// <param name="e">Entity to start searching from (null to start from beginning)</param>
    /// <param name="origin">Center point of the sphere</param>
    /// <param name="radius">Search radius</param>
    /// <returns>Found entity or null if no more entities</returns>
    public Edict FindEntityInSphere(Edict e, Vector3f origin, float radius)
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnFindEntityInSphere(e.GetPointer(), origin.GetPointer(), radius));
        }
    }
    /// <summary>
    /// Finds a client entity in the Potentially Visible Set of another entity
    /// </summary>
    /// <param name="e">Entity whose PVS to check</param>
    /// <returns>Client entity in PVS or null if none found</returns>
    public Edict FindClientInPVS(Edict e)
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnFindClientInPVS(e.GetPointer()));
        }
    }
    /// <summary>
    /// Gets entities in the Potentially Visible Set of an entity
    /// </summary>
    /// <param name="e">Entity whose PVS to check</param>
    /// <returns>Entity in PVS</returns>
    public Edict EntitiesInPVS(Edict e)
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnEntitiesInPVS(e.GetPointer()));
        }
    }
    /// <summary>
    /// Converts angles to global direction vectors (sets v_forward, v_right, v_up)
    /// </summary>
    /// <param name="vec">Angle vector (pitch, yaw, roll)</param>
    public void MakeVectors(Vector3f vec) => Base.pfnMakeVectors(vec.GetPointer());
    
    /// <summary>
    /// Converts angles to direction vectors
    /// </summary>
    /// <param name="vec">Angle vector (pitch, yaw, roll)</param>
    /// <param name="forward">Output forward vector</param>
    /// <param name="right">Output right vector</param>
    /// <param name="up">Output up vector</param>
    public void AngleVectors(Vector3f vec, Vector3f forward, Vector3f right, Vector3f up) => Base.pfnAngleVectors(vec.GetPointer(), forward.GetPointer(), right.GetPointer(), up.GetPointer());
    /// <summary>
    /// Creates a new entity
    /// </summary>
    /// <returns>Newly created entity</returns>
    public Edict CreateEntity()
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnCreateEntity());
        }
    }
    /// <summary>
    /// Removes an entity from the world
    /// </summary>
    /// <param name="e">Entity to remove</param>
    public void RemoveEntity(Edict e) => Base.pfnRemoveEntity(e.GetPointer());

    /// <summary>
    /// Creates a new entity with a specific class name
    /// </summary>
    /// <param name="className">Class name of the entity to create</param>
    /// <returns>Newly created entity</returns>
    public Edict CreateNamedEntity(string className)
    {
        StringHandle? _namedEntity = new(className);
        unsafe
        {
            return new((NativeEdict*)Base.pfnCreateNamedEntity(_namedEntity.ToHandle()));
        }
    }
    /// <summary>
    /// Makes an entity static (non-interactive, optimized for rendering)
    /// </summary>
    /// <param name="ent">Entity to make static</param>
    public void MakeStatic(Edict ent) => Base.pfnMakeStatic(ent.GetPointer());
    
    /// <summary>
    /// Checks if an entity is on the floor
    /// </summary>
    /// <param name="ent">Entity to check</param>
    /// <returns>Non-zero if entity is on floor, 0 otherwise</returns>
    public int EntIsOnFloor(Edict ent) => Base.pfnEntIsOnFloor(ent.GetPointer());
    
    /// <summary>
    /// Drops an entity to the floor
    /// </summary>
    /// <param name="ent">Entity to drop</param>
    /// <returns>-1 if entity is stuck in world, 0 if dropped successfully</returns>
    public int DropToFloor(Edict ent) => Base.pfnDropToFloor(ent.GetPointer());
    
    /// <summary>
    /// Moves an entity in a direction, checking for collisions
    /// </summary>
    /// <param name="ent">Entity to move</param>
    /// <param name="yaw">Direction to move in degrees</param>
    /// <param name="dist">Distance to move</param>
    /// <param name="mode">Walk mode flags</param>
    /// <returns>Non-zero if move was successful</returns>
    public int WalkMove(Edict ent, float yaw, float dist, int mode) => Base.pfnWalkMove(ent.GetPointer(), yaw, dist, mode);
    
    /// <summary>
    /// Sets the origin (position) of an entity
    /// </summary>
    /// <param name="ent">Entity to set origin for</param>
    /// <param name="origin">New origin position</param>
    public void SetOrigin(Edict ent, Vector3f origin) => Base.pfnSetOrigin(ent.GetPointer(), origin.GetPointer());
    /// <summary>
    /// Emits a sound from an entity
    /// </summary>
    /// <param name="ent">Entity to emit sound from</param>
    /// <param name="channel">Sound channel (CHAN_WEAPON, CHAN_VOICE, etc.)</param>
    /// <param name="sample">Sound file path</param>
    /// <param name="volume">Volume (0.0 to 1.0)</param>
    /// <param name="attenuation">Sound attenuation (distance falloff)</param>
    /// <param name="fFlags">Sound flags</param>
    /// <param name="pitch">Pitch (100 = normal)</param>
    public void EmitSound(Edict ent, int channel, string sample, float volume, float attenuation, int fFlags, int pitch)
    {
        nint ns = Marshal.StringToHGlobalAnsi(sample);
        Base.pfnEmitSound(ent.GetPointer(), channel, ns, volume, attenuation, fFlags, pitch);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Emits an ambient sound at a specific position
    /// </summary>
    /// <param name="ent">Entity associated with the sound</param>
    /// <param name="pos">Position to emit sound from</param>
    /// <param name="sample">Sound file path</param>
    /// <param name="volume">Volume (0.0 to 1.0)</param>
    /// <param name="attenuation">Sound attenuation (distance falloff)</param>
    /// <param name="fFlags">Sound flags</param>
    /// <param name="pitch">Pitch (100 = normal)</param>
    public void EmitAmbientSound(Edict ent, Vector3f pos, string sample, float volume, float attenuation, int fFlags, int pitch)
    {
        nint ns = Marshal.StringToHGlobalAnsi(sample);
        Base.pfnEmitAmbientSound(ent.GetPointer(), pos.GetPointer(), ns, volume, attenuation, fFlags, pitch);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Traces a line from one point to another, checking for collisions
    /// </summary>
    /// <param name="v1">Start position</param>
    /// <param name="v2">End position</param>
    /// <param name="fNoMonsters">Ignore monsters flag (0 = hit monsters, 1 = ignore monsters)</param>
    /// <param name="pentToSkip">Entity to skip during trace</param>
    /// <param name="ptr">Trace result output</param>
    public void TraceLine(Vector3f v1, Vector3f v2, int fNoMonsters, Edict pentToSkip, ref TraceResult ptr) =>
        Base.pfnTraceLine(v1.GetPointer(), v2.GetPointer(), fNoMonsters, pentToSkip.GetPointer(), ptr.GetPointer());
    
    /// <summary>
    /// Traces the trajectory of a tossed entity
    /// </summary>
    /// <param name="pent">Entity to trace</param>
    /// <param name="pentToIgnore">Entity to ignore during trace</param>
    /// <param name="ptr">Trace result output</param>
    public void TraceToss(Edict pent, Edict pentToIgnore, ref TraceResult ptr) =>
        Base.pfnTraceToss(pent.GetPointer(), pentToIgnore.GetPointer(), ptr.GetPointer());
    
    /// <summary>
    /// Traces using a monster's hull size
    /// </summary>
    /// <param name="pent">Monster entity</param>
    /// <param name="v1">Start position</param>
    /// <param name="v2">End position</param>
    /// <param name="fNoMonsters">Ignore monsters flag</param>
    /// <param name="pentToSkip">Entity to skip during trace</param>
    /// <param name="ptr">Trace result output</param>
    /// <returns>Non-zero if trace hit something</returns>
    public int TraceMonsterHull(Edict pent, Vector3f v1, Vector3f v2, int fNoMonsters, Edict pentToSkip, ref TraceResult ptr) =>
        Base.pfnTraceMonsterHull(pent.GetPointer(), v1.GetPointer(), v2.GetPointer(), fNoMonsters, pentToSkip.GetPointer(), ptr.GetPointer());
    
    /// <summary>
    /// Traces using a specific hull size
    /// </summary>
    /// <param name="v1">Start position</param>
    /// <param name="v2">End position</param>
    /// <param name="fNoMonsters">Ignore monsters flag</param>
    /// <param name="hullNumber">Hull number (0=point, 1=human, 2=large, 3=head)</param>
    /// <param name="pentToSkip">Entity to skip during trace</param>
    /// <param name="ptr">Trace result output</param>
    public void TraceHull(Vector3f v1, Vector3f v2, int fNoMonsters, int hullNumber, Edict pentToSkip, ref TraceResult ptr) =>
        Base.pfnTraceHull(v1.GetPointer(), v2.GetPointer(), fNoMonsters, hullNumber, pentToSkip.GetPointer(), ptr.GetPointer());
    
    /// <summary>
    /// Traces against a specific model
    /// </summary>
    /// <param name="v1">Start position</param>
    /// <param name="v2">End position</param>
    /// <param name="hullNumber">Hull number to use</param>
    /// <param name="pent">Entity with model to trace against</param>
    /// <param name="ptr">Trace result output</param>
    public void TraceModel(Vector3f v1, Vector3f v2, int hullNumber, Edict pent, ref TraceResult ptr) =>
        Base.pfnTraceModel(v1.GetPointer(), v2.GetPointer(), hullNumber, pent.GetPointer(), ptr.GetPointer());
    /// <summary>
    /// Gets the texture name at a trace hit point
    /// </summary>
    /// <param name="pTextureEntity">Entity to trace against</param>
    /// <param name="v1">Start position</param>
    /// <param name="v2">End position</param>
    /// <returns>Texture name at hit point</returns>
    public string TraceTexture(Edict pTextureEntity, Vector3f v1, Vector3f v2)
    {
        nint ptr = Base.pfnTraceTexture(pTextureEntity.GetPointer(), v1.GetPointer(), v2.GetPointer());
        return Marshal.PtrToStringUTF8(ptr) ?? string.Empty;
    }
    /// <summary>
    /// Traces using a spherical shape
    /// </summary>
    /// <param name="v1">Start position</param>
    /// <param name="v2">End position</param>
    /// <param name="fNoMonsters">Ignore monsters flag</param>
    /// <param name="radius">Sphere radius</param>
    /// <param name="pentToSkip">Entity to skip during trace</param>
    /// <param name="ptr">Trace result output</param>
    public void TraceSphere(Vector3f v1, Vector3f v2, int fNoMonsters, float radius, Edict pentToSkip, ref TraceResult ptr) =>
        Base.pfnTraceSphere(v1.GetPointer(), v2.GetPointer(), fNoMonsters, radius, pentToSkip.GetPointer(), ptr.GetPointer());
    
    /// <summary>
    /// Gets the aim vector for auto-aim
    /// </summary>
    /// <param name="ent">Entity to get aim for</param>
    /// <param name="speed">Projectile speed for aim prediction</param>
    /// <param name="vec">Output aim vector</param>
    public void GetAimVector(Edict ent, float speed, ref Vector3f vec) => Base.pfnGetAimVector(ent.GetPointer(), speed, vec.GetPointer());
    /// <summary>
    /// Queues a server command to be executed
    /// </summary>
    /// <param name="str">Command string to execute</param>
    public void ServerCommand(string str)
    {
        nint ns = Marshal.StringToHGlobalAnsi(str);
        Base.pfnServerCommand(ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Executes all queued server commands
    /// </summary>
    public void ServerExecute() => Base.pfnServerExecute();
    
    /// <summary>
    /// Executes a command on a client
    /// </summary>
    /// <param name="ent">Client entity</param>
    /// <param name="str">Command string to execute</param>
    public void ClientCommand(Edict ent, string str)
    {
        nint ns = Marshal.StringToHGlobalAnsi(str);
        Base.pfnClientCommand(ent.GetPointer(), ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Creates a particle effect
    /// </summary>
    /// <param name="org">Origin position of the effect</param>
    /// <param name="dir">Direction vector for particles</param>
    /// <param name="color">Particle color</param>
    /// <param name="count">Number of particles</param>
    public void ParticleEffect(Vector3f org, Vector3f dir, float color, float count) => Base.pfnParticleEffect(org.GetPointer(), dir.GetPointer(), color, count);
    
    /// <summary>
    /// Sets a light style for dynamic lighting
    /// </summary>
    /// <param name="style">Light style index</param>
    /// <param name="val">Light pattern string (a=dark, z=bright)</param>
    public void LightStyle(int style, string val)
    {
        nint ns = Marshal.StringToHGlobalAnsi(val);
        Base.pfnLightStyle(style, ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Gets the index of a decal by name
    /// </summary>
    /// <param name="name">Decal name</param>
    /// <returns>Decal index</returns>
    public int DecalIndex(string name)
    {
        nint ns = Marshal.StringToHGlobalAnsi(name);
        int res = Base.pfnDecalIndex(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    /// <summary>
    /// Gets the contents type at a point (water, solid, empty, etc.)
    /// </summary>
    /// <param name="vec">Point to check</param>
    /// <returns>Contents type constant</returns>
    public int PointContents(Vector3f vec) => Base.pfnPointContents(vec.GetPointer());
    
    /// <summary>
    /// Begins a network message
    /// </summary>
    /// <param name="msg_dest">Message destination (MSG_BROADCAST, MSG_ONE, etc.)</param>
    /// <param name="msg_type">Message type ID</param>
    /// <param name="pOrigin">Origin for PVS/PAS filtering (can be null)</param>
    /// <param name="ed">Target client entity (for MSG_ONE) (can be null)</param>
    public void MessageBegin(MessageDestination msg_dest, int msg_type, Vector3f? pOrigin, Edict? ed)
    {
        Base.pfnMessageBegin((int)msg_dest, msg_type, pOrigin?.GetPointer() ?? nint.Zero, ed?.GetPointer() ?? nint.Zero);
    }
    
    /// <summary>
    /// Ends and sends the current network message
    /// </summary>
    public void MessageEnd() => Base.pfnMessageEnd();
    
    /// <summary>
    /// Writes a byte value to the current message
    /// </summary>
    /// <param name="iValue">Byte value (0-255)</param>
    public void WriteByte(int iValue) => Base.pfnWriteByte(iValue);
    
    /// <summary>
    /// Writes a char value to the current message
    /// </summary>
    /// <param name="iValue">Char value (-128 to 127)</param>
    public void WriteChar(int iValue) => Base.pfnWriteChar(iValue);
    
    /// <summary>
    /// Writes a short value to the current message
    /// </summary>
    /// <param name="iValue">Short value (-32768 to 32767)</param>
    public void WriteShort(int iValue) => Base.pfnWriteShort(iValue);
    
    /// <summary>
    /// Writes a long value to the current message
    /// </summary>
    /// <param name="iValue">Long value</param>
    public void WriteLong(int iValue) => Base.pfnWriteLong(iValue);
    
    /// <summary>
    /// Writes an angle value to the current message
    /// </summary>
    /// <param name="flValue">Angle in degrees</param>
    public void WriteAngle(float flValue) => Base.pfnWriteAngle(flValue);
    
    /// <summary>
    /// Writes a coordinate value to the current message
    /// </summary>
    /// <param name="flValue">Coordinate value</param>
    public void WriteCoord(float flValue) => Base.pfnWriteCoord(flValue);
    
    /// <summary>
    /// Writes a string to the current message
    /// </summary>
    /// <param name="sz">String value</param>
    public void WriteString(string sz)
    {
        nint ns = Marshal.StringToHGlobalAnsi(sz);
        Base.pfnWriteString(ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Writes an entity index to the current message
    /// </summary>
    /// <param name="iValue">Entity index</param>
    public void WriteEntity(int iValue) => Base.pfnWriteEntity(iValue);
    
    /// <summary>
    /// Registers a console variable (cvar)
    /// </summary>
    /// <param name="cvar">CVar structure to register</param>
    public void CVarRegister(CVar cvar) => Base.pfnCVarRegister(cvar.GetPointer());
    
    /// <summary>
    /// Gets the float value of a console variable
    /// </summary>
    /// <param name="szVarName">Variable name</param>
    /// <returns>Float value of the cvar</returns>
    public float CVarGetFloat(string szVarName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szVarName);
        float res = Base.pfnCVarGetFloat(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    /// <summary>
    /// Gets the string value of a console variable
    /// </summary>
    /// <param name="szVarName">Variable name</param>
    /// <returns>String value of the cvar</returns>
    public string CVarGetString(string szVarName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szVarName);
        nint res = Base.pfnCVarGetString(ns);
        Marshal.FreeHGlobal(ns);
        return Marshal.PtrToStringUTF8(res) ?? string.Empty;
    }
    /// <summary>
    /// Sets the float value of a console variable
    /// </summary>
    /// <param name="szVarName">Variable name</param>
    /// <param name="flValue">New float value</param>
    public void CVarSetFloat(string szVarName, float flValue)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szVarName);
        Base.pfnCVarSetFloat(ns, flValue);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Sets the string value of a console variable
    /// </summary>
    /// <param name="szVarName">Variable name</param>
    /// <param name="szValue">New string value</param>
    public void CVarSetString(string szVarName, string szValue)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(szVarName);
        nint ns2 = Marshal.StringToHGlobalAnsi(szValue);
        Base.pfnCVarSetString(ns1, ns2);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
    }
    /// <summary>
    /// Prints an alert message to the console
    /// </summary>
    /// <param name="atype">Alert type (at_notice, at_console, at_aiconsole, at_warning, at_error, at_logged)</param>
    /// <param name="szFmt">Message format string</param>
    public void AlertMessage(AlertType atype, string szFmt)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szFmt);
        Base.pfnAlertMessage((int)atype, ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Writes formatted text to a file handle
    /// </summary>
    /// <param name="pFile">File handle pointer</param>
    /// <param name="szFmt">Format string</param>
    /// <param name="p">Format arguments</param>
    public void EngineFprintf(nint pFile, string szFmt, params string[] p)
    {
        nint ns = Marshal.StringToHGlobalAnsi(string.Format(szFmt, p));
        Base.pfnEngineFprintf(pFile, ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Allocates private data for an entity
    /// </summary>
    /// <param name="ed">Entity to allocate data for</param>
    /// <param name="size">Size of private data in bytes</param>
    /// <returns>Pointer to allocated private data</returns>
    public nint PvAllocEntPrivateData(Edict ed, int size) => Base.pfnPvAllocEntPrivateData(ed.GetPointer(), size);
    
    /// <summary>
    /// Gets the private data pointer for an entity
    /// </summary>
    /// <param name="ed">Entity to get private data from</param>
    /// <returns>Pointer to entity's private data</returns>
    public nint PvEntPrivateData(Edict ed) => Base.pfnPvEntPrivateData(ed.GetPointer());
    
    /// <summary>
    /// Frees the private data for an entity
    /// </summary>
    /// <param name="ed">Entity to free private data for</param>
    public void FreeEntPrivateData(Edict ed) => Base.pfnFreeEntPrivateData(ed.GetPointer());
    /// <summary>
    /// Gets a string from the string pool by index
    /// </summary>
    /// <param name="iString">String index</param>
    /// <returns>String value</returns>
    public string SzFromIndex(int iString)
    {
        nint ns = Base.pfnSzFromIndex(iString);
        return Marshal.PtrToStringUTF8(ns) ?? string.Empty;
    }
    /// <summary>
    /// Allocates a string in the string pool
    /// </summary>
    /// <param name="szValue">String to allocate</param>
    /// <returns>String index in the pool</returns>
    public int AllocString(string szValue)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szValue);
        return Base.pfnAllocString(ns);
    }
    /// <summary>
    /// Gets the entity variables (entvars) for an entity
    /// </summary>
    /// <param name="pEdict">Entity to get variables from</param>
    /// <returns>Entity variables structure</returns>
    public Entvars GetVarsOfEnt(Edict pEdict)
    {
        unsafe
        {
             return new((NativeEntvars*)Base.pfnGetVarsOfEnt(pEdict.GetPointer()));
        }
    }
    /// <summary>
    /// Gets an entity from an entity offset
    /// </summary>
    /// <param name="iEntOffset">Entity offset</param>
    /// <returns>Entity at the offset</returns>
    public Edict PEntityOfEntOffset(int iEntOffset)
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnPEntityOfEntOffset(iEntOffset));
        }
    }
    /// <summary>
    /// Gets the entity offset from an entity pointer
    /// </summary>
    /// <param name="pEdict">Entity to get offset from</param>
    /// <returns>Entity offset</returns>
    public int EntOffsetOfPEntity(Edict pEdict) => Base.pfnEntOffsetOfPEntity(pEdict.GetPointer());
    
    /// <summary>
    /// Gets the index of an entity
    /// </summary>
    /// <param name="pEdict">Entity to get index from</param>
    /// <returns>Entity index (1-based)</returns>
    public int IndexOfEdict(Edict pEdict) => Base.pfnIndexOfEdict(pEdict.GetPointer());
    /// <summary>
    /// Gets an entity from an entity index
    /// </summary>
    /// <param name="iEntIndex">Entity index (1-based)</param>
    /// <returns>Entity at the index</returns>
    public Edict PEntityOfEntIndex(int iEntIndex)
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnPEntityOfEntIndex(iEntIndex));
        }
    }
    /// <summary>
    /// Finds an entity by its entity variables pointer
    /// </summary>
    /// <param name="pvars">Entity variables to search for</param>
    /// <returns>Entity with matching entvars</returns>
    public Edict FindEntityByVars(Entvars pvars)
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnFindEntityByVars(pvars.GetPointer()));
        }
    }
    /// <summary>
    /// Gets the model pointer for an entity
    /// </summary>
    /// <param name="pEdict">Entity to get model from</param>
    /// <returns>Pointer to model data</returns>
    public nint GetModelPtr(Edict pEdict) => Base.pfnGetModelPtr(pEdict.GetPointer());
    
    /// <summary>
    /// Registers a user message for network communication
    /// </summary>
    /// <param name="pszName">Message name</param>
    /// <param name="iSize">Message size in bytes (-1 for variable size)</param>
    /// <returns>Message ID</returns>
    public int RegUserMsg(string pszName, int iSize)
    {
        nint ns = Marshal.StringToHGlobalAnsi(pszName);
        int res = Base.pfnRegUserMsg(ns, iSize);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    /// <summary>
    /// Automatically moves an entity based on its animation
    /// </summary>
    /// <param name="ent">Entity to move</param>
    /// <param name="flTime">Time delta</param>
    public void AnimationAutomove(Edict ent, float flTime) => Base.pfnAnimationAutomove(ent.GetPointer(), flTime);
    
    /// <summary>
    /// Gets the position and angles of a bone in a model
    /// </summary>
    /// <param name="ent">Entity with the model</param>
    /// <param name="iBone">Bone index</param>
    /// <param name="origin">Output bone position</param>
    /// <param name="angles">Output bone angles</param>
    public void GetBonePosition(Edict ent, int iBone, ref Vector3f origin, ref Vector3f angles) => Base.pfnGetBonePosition(ent.GetPointer(), iBone, origin.GetPointer(), angles.GetPointer());
    /// <summary>
    /// Gets a function address from a function name
    /// </summary>
    /// <param name="pName">Function name</param>
    /// <returns>Function address</returns>
    public uint FunctionFromName(string pName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(pName);
        uint res = Base.pfnFunctionFromName(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    /// <summary>
    /// Gets the function name from a function address
    /// </summary>
    /// <param name="function">Function address</param>
    /// <returns>Function name</returns>
    public string NameForFunction(uint function) => Marshal.PtrToStringUTF8(Base.pfnNameForFunction(function)) ?? string.Empty;
    /// <summary>
    /// Prints a message to a client's console
    /// </summary>
    /// <param name="ent">Client entity</param>
    /// <param name="ptype">Print type (print_console, print_center, print_chat)</param>
    /// <param name="szMsg">Message to print</param>
    public void ClientPrintf(Edict ent, PrintType ptype, string szMsg)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szMsg);
        Base.pfnClientPrintf(ent.GetPointer(), (int)ptype, ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Prints a message to the server console
    /// </summary>
    /// <param name="msg">Message to print</param>
    public void ServerPrint(string msg)
    {
        nint nmsg = Marshal.StringToHGlobalAnsi(msg);
        Base.pfnServerPrint(nmsg);
        Marshal.FreeHGlobal(nmsg);
    }
    /// <summary>
    /// Gets all command arguments as a single string
    /// </summary>
    /// <returns>Command arguments string</returns>
    public string Cmd_Args() => Marshal.PtrToStringUTF8(Base.pfnCmd_Args()) ?? string.Empty;
    
    /// <summary>
    /// Gets a specific command argument by index
    /// </summary>
    /// <param name="argc">Argument index (0 = command name)</param>
    /// <returns>Argument string</returns>
    public string Cmd_Argv(int argc) => Marshal.PtrToStringUTF8(Base.pfnCmd_Argv(argc)) ?? string.Empty;
    
    /// <summary>
    /// Gets the number of command arguments
    /// </summary>
    /// <returns>Argument count</returns>
    public int Cmd_Argc() => Base.pfnCmd_Argc();
    /// <summary>
    /// Gets the position and angles of a model attachment point
    /// </summary>
    /// <param name="ent">Entity with the model</param>
    /// <param name="iAttachment">Attachment index</param>
    /// <param name="origin">Output attachment position</param>
    /// <param name="angles">Output attachment angles</param>
    public void GetAttachment(Edict ent, int iAttachment, ref Vector3f origin, ref Vector3f angles) =>
        Base.pfnGetAttachment(ent.GetPointer(), iAttachment, origin.GetPointer(), angles.GetPointer());
    
    /// <summary>
    /// Initializes a CRC32 checksum
    /// </summary>
    /// <param name="pulCRC">CRC32 structure to initialize</param>
    public void CRC32_Init(CRC32 pulCRC) => Base.pfnCRC32_Init(pulCRC.GetPointer());
    
    /// <summary>
    /// Processes a buffer for CRC32 checksum calculation
    /// </summary>
    /// <param name="pulCRC">CRC32 structure</param>
    /// <param name="buffer">Buffer pointer</param>
    /// <param name="len">Buffer length</param>
    public void CRC32_ProcessBuffer(CRC32 pulCRC, nint buffer, int len) =>
        Base.pfnCRC32_ProcessBuffer(pulCRC.GetPointer(), buffer, len);
    
    /// <summary>
    /// Processes a single byte for CRC32 checksum calculation
    /// </summary>
    /// <param name="pulCRC">CRC32 structure</param>
    /// <param name="ch">Byte to process</param>
    public void CRC32_ProcessByte(CRC32 pulCRC, byte ch) =>
        Base.pfnCRC32_ProcessByte(pulCRC.GetPointer(), ch);
    /// <summary>
    /// Finalizes a CRC32 checksum calculation
    /// </summary>
    /// <param name="pulCRC">CRC32 structure</param>
    /// <returns>Final CRC32 value</returns>
    public CRC32 CRC32_Final(CRC32 pulCRC)
    {
        NativeCRC32 crc = new()
        {
            value = pulCRC.Value
        };
        crc = Base.pfnCRC32_Final(crc);
        CRC32 ret = new(crc);
        return ret;
    }
    /// <summary>
    /// Generates a random integer within a range
    /// </summary>
    /// <param name="lLow">Minimum value (inclusive)</param>
    /// <param name="lHigh">Maximum value (inclusive)</param>
    /// <returns>Random integer</returns>
    public int RandomLong(int lLow, int lHigh) => Base.pfnRandomLong(lLow, lHigh);
    
    /// <summary>
    /// Generates a random float within a range
    /// </summary>
    /// <param name="flLow">Minimum value</param>
    /// <param name="flHigh">Maximum value</param>
    /// <returns>Random float</returns>
    public float RandomFloat(float flLow, float flHigh) => Base.pfnRandomFloat(flLow, flHigh);
    
    /// <summary>
    /// Sets the view entity for a client (camera)
    /// </summary>
    /// <param name="ent">Client entity</param>
    /// <param name="viewent">Entity to view from</param>
    public void SetView(Edict ent, Edict viewent) => Base.pfnSetView(ent.GetPointer(), viewent.GetPointer());
    
    /// <summary>
    /// Gets the current server time
    /// </summary>
    /// <returns>Server time in seconds</returns>
    public float Time() => Base.pfnTime();
    
    /// <summary>
    /// Sets the crosshair angle for a client
    /// </summary>
    /// <param name="ent">Client entity</param>
    /// <param name="pitch">Pitch angle</param>
    /// <param name="yaw">Yaw angle</param>
    public void CrosshairAngle(Edict ent, float pitch, float yaw) => Base.pfnCrosshairAngle(ent.GetPointer(), pitch, yaw);
    /// <summary>
    /// Loads a file into memory
    /// </summary>
    /// <param name="filename">File path to load</param>
    /// <param name="pLength">Output file length</param>
    /// <returns>Pointer to file data (must be freed with FreeFile)</returns>
    public nint LoadFileForMe(string filename, out int pLength)
    {
        nint ns = Marshal.StringToHGlobalAnsi(filename);
        nint nl = Marshal.AllocHGlobal(sizeof(int));
        nint res = Base.pfnLoadFileForMe(ns, nl);
        Marshal.FreeHGlobal(ns);
        pLength = Marshal.ReadInt32(nl);
        Marshal.FreeHGlobal(nl);
        return res;
    }
    /// <summary>
    /// Frees memory allocated by LoadFileForMe
    /// </summary>
    /// <param name="buffer">Buffer pointer to free</param>
    public void FreeFile(nint buffer) => Base.pfnFreeFile(buffer);
    
    /// <summary>
    /// Marks the end of a server loading section
    /// </summary>
    /// <param name="szSectionName">Section name</param>
    public void EndSection(string szSectionName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szSectionName);
        Base.pfnEndSection(ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Compares the modification times of two files
    /// </summary>
    /// <param name="filename1">First file path</param>
    /// <param name="filename2">Second file path</param>
    /// <param name="iCompare">Output comparison result (0=equal, -1=file1 older, 1=file1 newer)</param>
    /// <returns>1 on success, 0 on failure</returns>
    public int CompareFileTime(string filename1, string filename2, out int iCompare)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(filename1);
        nint ns2 = Marshal.StringToHGlobalAnsi(filename2);
        nint ni = Marshal.AllocHGlobal(sizeof(int));
        int res = Base.pfnCompareFileTime(ns1, ns2, ni);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
        iCompare = Marshal.ReadInt32(ni);
        Marshal.FreeHGlobal(ni);
        return res;
    }
    /// <summary>
    /// Gets the game directory name
    /// </summary>
    /// <returns>Game directory (e.g., "valve", "cstrike")</returns>
    public string GetGameDir()
    {
        nint ns = Marshal.AllocHGlobal(sizeof(byte) * 256);
        Base.pfnGetGameDir(ns);
        string res = Marshal.PtrToStringUTF8(ns) ?? string.Empty;
        Marshal.FreeHGlobal(ns);
        return res;
    }
    /// <summary>
    /// Registers a console variable (alternative to CVarRegister)
    /// </summary>
    /// <param name="cvar">CVar structure to register</param>
    public void CVar_RegisterVariable(CVar cvar) => Base.pfnCvar_RegisterVariable(cvar.GetPointer());
    
    /// <summary>
    /// Fades a client's sound volume
    /// </summary>
    /// <param name="ent">Client entity</param>
    /// <param name="fadePercent">Target volume percentage</param>
    /// <param name="fadeOutSeconds">Fade out duration</param>
    /// <param name="holdTime">Hold duration at target volume</param>
    /// <param name="fadeInSeconds">Fade in duration</param>
    public void FadeClientVolume(Edict ent, int fadePercent, int fadeOutSeconds, int holdTime, int fadeInSeconds) =>
        Base.pfnFadeClientVolume(ent.GetPointer(), fadePercent, fadeOutSeconds, holdTime, fadeInSeconds);
    
    /// <summary>
    /// Sets the maximum movement speed for a client
    /// </summary>
    /// <param name="ent">Client entity</param>
    /// <param name="fNewMaxspeed">New maximum speed</param>
    public void SetClientMaxspeed(Edict ent, float fNewMaxspeed) => Base.pfnSetClientMaxspeed(ent.GetPointer(), fNewMaxspeed);
    /// <summary>
    /// Creates a fake client (bot)
    /// </summary>
    /// <param name="netname">Bot's network name</param>
    /// <returns>Fake client entity</returns>
    public Edict CreateFakeClient(string netname)
    {
        unsafe
        {
            nint ns = Marshal.StringToHGlobalAnsi(netname);
            Edict ret = new((NativeEdict*)Base.pfnCreateFakeClient(ns));
            Marshal.FreeHGlobal(ns);
            return ret;
        }
    }
    /// <summary>
    /// Runs player movement for a fake client (bot)
    /// </summary>
    /// <param name="fakeClient">Fake client entity</param>
    /// <param name="viewangles">View angles</param>
    /// <param name="forwardmove">Forward movement (-400 to 400)</param>
    /// <param name="sidemove">Side movement (-400 to 400)</param>
    /// <param name="upmove">Up movement (jump/duck)</param>
    /// <param name="buttons">Button flags</param>
    /// <param name="impulse">Impulse command</param>
    /// <param name="msec">Milliseconds for this frame</param>
    public void RunPlayerMove(Edict fakeClient, Vector3f viewangles, float forwardmove, float sidemove, float upmove, ushort buttons, byte impulse, byte msec) =>
        Base.pfnRunPlayerMove(fakeClient.GetPointer(), viewangles.GetPointer(), forwardmove, sidemove, upmove, buttons, impulse, msec);
    
    /// <summary>
    /// Gets the total number of entities in the world
    /// </summary>
    /// <returns>Entity count</returns>
    public int NumberOfEntities() => Base.pfnNumberOfEntities();
    /// <summary>
    /// Gets the info key buffer for an entity
    /// </summary>
    /// <param name="ent">Entity to get info buffer from</param>
    /// <returns>Info buffer string</returns>
    public string GetInfoKeyBuffer(Edict ent) => Marshal.PtrToStringUTF8(Base.pfnGetInfoKeyBuffer(ent.GetPointer())) ?? string.Empty;
    
    /// <summary>
    /// Gets a value from an info key buffer
    /// </summary>
    /// <param name="infobuffer">Info buffer string</param>
    /// <param name="key">Key name to look up</param>
    /// <returns>Key value</returns>
    public string InfoKeyValue(string infobuffer, string key)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(infobuffer);
        nint ns2 = Marshal.StringToHGlobalAnsi(key);
        nint res = Base.pfnInfoKeyValue(ns1, ns2);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
        return Marshal.PtrToStringUTF8(res) ?? string.Empty;
    }
    /// <summary>
    /// Sets a key-value pair in an info buffer
    /// </summary>
    /// <param name="infobuffer">Info buffer string (modified)</param>
    /// <param name="key">Key name</param>
    /// <param name="value">Value to set</param>
    public void SetKeyValue(ref string infobuffer, string key, string value)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(infobuffer);
        nint ns2 = Marshal.StringToHGlobalAnsi(key);
        nint ns3 = Marshal.StringToHGlobalAnsi(value);
        Base.pfnSetKeyValue(ns1, ns2, ns3);
        infobuffer = Marshal.PtrToStringUTF8(ns1) ?? string.Empty;
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
        Marshal.FreeHGlobal(ns3);
    }
    /// <summary>
    /// Sets a key-value pair in a client's info buffer
    /// </summary>
    /// <param name="clientIndex">Client index</param>
    /// <param name="infobuffer">Info buffer string</param>
    /// <param name="key">Key name</param>
    /// <param name="value">Value to set</param>
    public void SetClientKeyValue(int clientIndex, string infobuffer, string key, string value)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(infobuffer);
        nint ns2 = Marshal.StringToHGlobalAnsi(key);
        nint ns3 = Marshal.StringToHGlobalAnsi(value);
        Base.pfnSetClientKeyValue(clientIndex, ns1, ns2, ns3);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
        Marshal.FreeHGlobal(ns3);
    }
    /// <summary>
    /// Checks if a map file is valid and exists
    /// </summary>
    /// <param name="filename">Map filename</param>
    /// <returns>True if map is valid</returns>
    public bool IsMapValid(string filename)
    {
        nint ns = Marshal.StringToHGlobalAnsi(filename);
        int res = Base.pfnIsMapValid(ns);
        Marshal.FreeHGlobal(ns);
        return res != 0;
    }
    /// <summary>
    /// Creates a static decal in the world
    /// </summary>
    /// <param name="origin">Decal position</param>
    /// <param name="decalIndex">Decal index</param>
    /// <param name="entityIndex">Entity to apply decal to</param>
    /// <param name="modelIndex">Model index</param>
    public void StaticDecal(Vector3f origin, int decalIndex, int entityIndex, int modelIndex) =>
        Base.pfnStaticDecal(origin.GetPointer(), decalIndex, entityIndex, modelIndex);
    
    /// <summary>
    /// Precaches a generic file
    /// </summary>
    /// <param name="s">File path to precache</param>
    public void PrecacheGeneric(string s)
    {
        nint ns = Marshal.StringToHGlobalAnsi(s);
        Base.pfnPrecacheGeneric(ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Gets a player's user ID
    /// </summary>
    /// <param name="e">Player entity</param>
    /// <returns>User ID</returns>
    public int GetPlayerUserId(Edict e) => Base.pfnGetPlayerUserId(e.GetPointer());
    
    /// <summary>
    /// Builds a sound message for network transmission
    /// </summary>
    /// <param name="entity">Entity emitting the sound</param>
    /// <param name="channel">Sound channel</param>
    /// <param name="sample">Sound file path</param>
    /// <param name="volume">Volume (0.0 to 1.0)</param>
    /// <param name="attenuation">Sound attenuation</param>
    /// <param name="fFlags">Sound flags</param>
    /// <param name="pitch">Pitch (100 = normal)</param>
    /// <param name="msg_dest">Message destination</param>
    /// <param name="msg_type">Message type</param>
    /// <param name="pOrigin">Origin for PVS/PAS</param>
    /// <param name="ed">Target entity</param>
    public void BuildSoundMsg(Edict entity, int channel, string sample, float volume, float attenuation, int fFlags, int pitch, int msg_dest, int msg_type, Vector3f pOrigin, Edict ed)
    {
        nint ns = Marshal.StringToHGlobalAnsi(sample);
        Base.pfnBuildSoundMsg(entity.GetPointer(), channel, ns, volume, attenuation, fFlags, pitch, msg_dest, msg_type, pOrigin.GetPointer(), ed.GetPointer());
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Checks if the server is running in dedicated mode
    /// </summary>
    /// <returns>True if dedicated server</returns>
    public bool IsDedicatedServer() => Base.pfnIsDedicatedServer() != 0;
    
    /// <summary>
    /// Gets a pointer to a console variable structure
    /// </summary>
    /// <param name="szVarName">Variable name</param>
    /// <returns>CVar structure pointer</returns>
    public CVar CVarGetPointer(string szVarName)
    {
        unsafe
        {
            nint ns = Marshal.StringToHGlobalAnsi(szVarName);
            nint res = Base.pfnCVarGetPointer(ns);
            Marshal.FreeHGlobal(ns);
            return new((NativeCVar*)res);
        }
    }
    /// <summary>
    /// Gets a player's WON ID (legacy authentication ID)
    /// </summary>
    /// <param name="e">Player entity</param>
    /// <returns>WON ID</returns>
    public uint GetPlayerWONId(Edict e) => Base.pfnGetPlayerWONId(e.GetPointer());
    
    /// <summary>
    /// Removes a key from an info string
    /// </summary>
    /// <param name="s">Info string (modified)</param>
    /// <param name="key">Key to remove</param>
    public void Info_RemoveKey(ref string s, string key)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(s);
        nint ns2 = Marshal.StringToHGlobalAnsi(key);
        Base.pfnInfo_RemoveKey(ns1, ns2);
        s = Marshal.PtrToStringUTF8(ns1) ?? string.Empty;
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
    }
    /// <summary>
    /// Gets a physics key value from an entity
    /// </summary>
    /// <param name="ent">Entity to query</param>
    /// <param name="key">Key name</param>
    /// <returns>Key value</returns>
    public string GetPhysicsKeyValue(Edict ent, string key)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(key);
        nint res = Base.pfnGetPhysicsKeyValue(ent.GetPointer(), ns1);
        Marshal.FreeHGlobal(ns1);
        return Marshal.PtrToStringUTF8(res) ?? string.Empty;
    }
    /// <summary>
    /// Sets a physics key value for an entity
    /// </summary>
    /// <param name="ent">Entity to modify</param>
    /// <param name="key">Key name</param>
    /// <param name="value">Value to set</param>
    public void SetPhysicsKeyValue(Edict ent, string key, string value)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(key);
        nint ns2 = Marshal.StringToHGlobalAnsi(value);
        Base.pfnSetPhysicsKeyValue(ent.GetPointer(), ns1, ns2);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
    }
    /// <summary>
    /// Gets the physics info string for an entity
    /// </summary>
    /// <param name="ent">Entity to query</param>
    /// <returns>Physics info string</returns>
    public string GetPhysicsInfoString(Edict ent)
    {
        nint res = Base.pfnGetPhysicsInfoString(ent.GetPointer());
        return Marshal.PtrToStringUTF8(res) ?? string.Empty;
    }
    /// <summary>
    /// Precaches an event for network playback
    /// </summary>
    /// <param name="type">Event type (1 = server-side)</param>
    /// <param name="psz">Event script path</param>
    /// <returns>Event index</returns>
    public ushort PrecacheEvent(int type, string psz)
    {
        nint ns = Marshal.StringToHGlobalAnsi(psz);
        ushort res = Base.pfnPrecacheEvent(type, ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    /// <summary>
    /// Plays back a precached event
    /// </summary>
    /// <param name="flags">Event flags (FEV_RELIABLE, FEV_GLOBAL, etc.)</param>
    /// <param name="ed">Entity invoking the event</param>
    /// <param name="eventindex">Event index from PrecacheEvent</param>
    /// <param name="delay">Delay before playing event</param>
    /// <param name="origin">Event origin position</param>
    /// <param name="angles">Event angles</param>
    /// <param name="fparam1">Float parameter 1</param>
    /// <param name="fparam2">Float parameter 2</param>
    /// <param name="iparam1">Integer parameter 1</param>
    /// <param name="iparam2">Integer parameter 2</param>
    /// <param name="bparam1">Boolean parameter 1</param>
    /// <param name="bparam2">Boolean parameter 2</param>
    public void PlaybackEvent(int flags, Edict ed, ushort eventindex, float delay, Vector3f origin, Vector3f angles, float fparam1, float fparam2, int iparam1, int iparam2, int bparam1, int bparam2)
        => Base.pfnPlaybackEvent(flags, ed.GetPointer(), eventindex, delay, origin.GetPointer(), angles.GetPointer(), fparam1, fparam2, iparam1, iparam2, bparam1, bparam2);

    /// <summary>
    /// Sets up a "fat" Potentially Visible Set for an origin
    /// </summary>
    /// <param name="org">Origin position</param>
    /// <returns>PVS data</returns>
    public string SetFatPVS(Vector3f org)
    {
        nint ns = Base.pfnSetFatPVS(org.GetPointer());
        return Marshal.PtrToStringUTF8(ns) ?? string.Empty;
    }
    /// <summary>
    /// Sets up a "fat" Potentially Audible Set for an origin
    /// </summary>
    /// <param name="org">Origin position</param>
    /// <returns>PAS data</returns>
    public string SetFatPAS(Vector3f org)
    {
        nint ns = Base.pfnSetFatPAS(org.GetPointer());
        return Marshal.PtrToStringUTF8(ns) ?? string.Empty;
    }
    /// <summary>
    /// Checks if an entity is visible in a PVS/PAS set
    /// </summary>
    /// <param name="entity">Entity to check</param>
    /// <param name="pset">PVS/PAS set data</param>
    /// <returns>True if entity is visible</returns>
    public bool CheckVisibility(Edict entity, nint pset)
    {
        int res = Base.pfnCheckVisibility(entity.GetPointer(), pset);
        return res != 0;
    }
    /// <summary>
    /// Marks a delta field as changed for network transmission
    /// </summary>
    /// <param name="pFields">Delta fields structure</param>
    /// <param name="fieldName">Field name to mark</param>
    public void DeltaSetField(nint pFields, string fieldName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(fieldName);
        Base.pfnDeltaSetField(pFields, ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Unmarks a delta field (won't be transmitted)
    /// </summary>
    /// <param name="pFields">Delta fields structure</param>
    /// <param name="fieldName">Field name to unmark</param>
    public void DeltaUnsetField(nint pFields, string fieldName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(fieldName);
        Base.pfnDeltaUnsetField(pFields, ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Adds a custom delta encoder callback
    /// </summary>
    /// <param name="name">Encoder name</param>
    /// <param name="callback">Callback function pointer</param>
    public void DeltaAddEncoder(string name, nint callback)
    {
        nint ns = Marshal.StringToHGlobalAnsi(name);
        Base.pfnDeltaAddEncoder(ns, callback);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Gets the current player index during message transmission
    /// </summary>
    /// <returns>Player index</returns>
    public int GetCurrentPlayer() => Base.pfnGetCurrentPlayer();
    
    /// <summary>
    /// Checks if a player can be skipped during message transmission
    /// </summary>
    /// <param name="player">Player entity to check</param>
    /// <returns>Non-zero if player can be skipped</returns>
    public int CanSkipPlayer(Edict player) => Base.pfnCanSkipPlayer(player.GetPointer());
    
    /// <summary>
    /// Finds a delta field by name
    /// </summary>
    /// <param name="pFields">Delta fields structure</param>
    /// <param name="fieldName">Field name to find</param>
    /// <returns>Field index or -1 if not found</returns>
    public int DeltaFindField(nint pFields, string fieldName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(fieldName);
        int res = Base.pfnDeltaFindField(pFields, ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    /// <summary>
    /// Marks a delta field as changed by field index
    /// </summary>
    /// <param name="pFields">Delta fields structure</param>
    /// <param name="fieldNumber">Field index</param>
    public void DeltaSetFieldByIndex(nint pFields, int fieldNumber)
        => Base.pfnDeltaSetFieldByIndex(pFields, fieldNumber);
    
    /// <summary>
    /// Unmarks a delta field by field index
    /// </summary>
    /// <param name="pFields">Delta fields structure</param>
    /// <param name="fieldNumber">Field index</param>
    public void DeltaUnsetFieldByIndex(nint pFields, int fieldNumber)
        => Base.pfnDeltaUnsetFieldByIndex(pFields, fieldNumber);
    
    /// <summary>
    /// Sets the group mask for entity visibility
    /// </summary>
    /// <param name="mask">Group mask value</param>
    /// <param name="op">Operation (OP_SET, OP_AND, OP_OR, OP_NAND)</param>
    public void SetGroupMask(int mask, int op) => Base.pfnSetGroupMask(mask, op);
    
    /// <summary>
    /// Creates an instanced baseline for an entity class
    /// </summary>
    /// <param name="classname">Class name index</param>
    /// <param name="baseline">Baseline entity state</param>
    /// <returns>Non-zero on success</returns>
    public int CreateInstancedBaseline(int classname, EntityState baseline)
        => Base.pfnCreateInstancedBaseline(classname, baseline.GetPointer());
    /// <summary>
    /// Directly sets a cvar value without triggering callbacks
    /// </summary>
    /// <param name="cvar">CVar structure</param>
    /// <param name="value">New value</param>
    public void Cvar_DirectSet(CVar cvar, string value)
    {
        nint ns = Marshal.StringToHGlobalAnsi(value);
        Base.pfnCvar_DirectSet(cvar.GetPointer(), ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Forces a file to remain unmodified (consistency checking)
    /// </summary>
    /// <param name="type">Force type (force_exactfile, force_model_samebounds, etc.)</param>
    /// <param name="mins">Minimum bounds (for model bounds checking)</param>
    /// <param name="maxs">Maximum bounds (for model bounds checking)</param>
    /// <param name="filename">File path to check</param>
    public void ForceUnmodified(ForceType type, Vector3f mins, Vector3f maxs, string filename)
    {
        nint ns = Marshal.StringToHGlobalAnsi(filename);
        Base.pfnForceUnmodified((int)type, mins.GetPointer(), maxs.GetPointer(), ns);
        Marshal.FreeHGlobal(ns);
    }
    /// <summary>
    /// Gets network statistics for a player
    /// </summary>
    /// <param name="ent">Player entity</param>
    /// <param name="ping">Output ping in milliseconds</param>
    /// <param name="packet_loss">Output packet loss percentage</param>
    public void GetPlayerStats(Edict ent, out int ping, out int packet_loss)
    {
        nint ni1 = Marshal.AllocHGlobal(sizeof(int));
        nint ni2 = Marshal.AllocHGlobal(sizeof(int));
        Base.pfnGetPlayerStats(ent.GetPointer(), ni1, ni2);
        ping = Marshal.ReadInt32(ni1);
        packet_loss = Marshal.ReadInt32(ni2);
        Marshal.FreeHGlobal(ni2);
        Marshal.FreeHGlobal(ni1);
    }

    /// <summary>
    /// Delegate for server command callbacks
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ServerCommandDelegate();
    
    /// <summary>
    /// Registers a new server console command
    /// </summary>
    /// <param name="cmd_name">Command name</param>
    /// <param name="function">Callback function to execute</param>
    public void AddServerCommand(string cmd_name, ServerCommandDelegate function)
    {
        nint func = Marshal.GetFunctionPointerForDelegate(function);
        nint cmd = Marshal.StringToHGlobalAnsi(cmd_name);
        unsafe
        {
            Base.pfnAddServerCommand(cmd, func);
        }
        Marshal.FreeHGlobal(cmd);
    }

    /// <summary>
    /// Checks if a client is listening to another client's voice
    /// </summary>
    /// <param name="iReceiver">Receiver client index</param>
    /// <param name="iSender">Sender client index</param>
    /// <returns>True if receiver is listening to sender</returns>
    public bool Voice_GetClientListening(int iReceiver, int iSender) => Base.pfnVoice_GetClientListening(iReceiver, iSender) != 0;
    
    /// <summary>
    /// Sets whether a client can hear another client's voice
    /// </summary>
    /// <param name="iReceiver">Receiver client index</param>
    /// <param name="iSender">Sender client index</param>
    /// <param name="bListen">True to allow listening, false to block</param>
    /// <returns>True on success</returns>
    public bool Voice_SetClientListening(int iReceiver, int iSender, bool bListen) => Base.pfnVoice_SetClientListening(iReceiver, iSender, bListen ? 1 : 0) != 0;
    /// <summary>
    /// Gets a player's authentication ID (SteamID)
    /// </summary>
    /// <param name="e">Player entity</param>
    /// <returns>Authentication ID string</returns>
    public string GetPlayerAuthId(Edict e)
    {
        nint res = Base.pfnGetPlayerAuthId(e.GetPointer());
        return Marshal.PtrToStringUTF8(res) ?? string.Empty;
    }
    /// <summary>
    /// Gets a sequence entry from a sentence group
    /// </summary>
    /// <param name="fieldName">Sentence group name</param>
    /// <param name="entryName">Entry name</param>
    /// <returns>Sequence data pointer</returns>
    public nint SequenceGet(string fieldName, string entryName)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(fieldName);
        nint ns2 = Marshal.StringToHGlobalAnsi(entryName);
        nint res = Base.pfnSequenceGet(ns1, ns2);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
        return res;
    }
    /// <summary>
    /// Picks a sentence from a sentence group
    /// </summary>
    /// <param name="groupName">Sentence group name</param>
    /// <param name="pickMethod">Pick method (0=sequential, 1=random, 2=random no repeat)</param>
    /// <param name="picked">Output index of picked sentence</param>
    /// <returns>Sentence data pointer</returns>
    public nint SequencePickSentence(string groupName, int pickMethod, out int picked)
    {
        nint ns = Marshal.StringToHGlobalAnsi(groupName);
        nint ni = Marshal.AllocHGlobal(sizeof(int));
        nint res = Base.pfnSequencePickSentence(ns, pickMethod, ni);
        picked = Marshal.ReadInt32(ni);
        Marshal.FreeHGlobal(ns);
        Marshal.FreeHGlobal(ni);
        return res;
    }
    /// <summary>
    /// Gets the size of a file in bytes
    /// </summary>
    /// <param name="filename">File path</param>
    /// <returns>File size in bytes, -1 if file not found</returns>
    public int GetFileSize(string filename)
    {
        nint ns = Marshal.StringToHGlobalAnsi(filename);
        int res = Base.pfnGetFileSize(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    /// <summary>
    /// Gets the approximate playback length of a WAV file
    /// </summary>
    /// <param name="filepath">WAV file path</param>
    /// <returns>Playback length in milliseconds</returns>
    public uint GetApproxWavePlayLen(string filepath)
    {
        nint ns = Marshal.StringToHGlobalAnsi(filepath);
        uint res = Base.pfnGetApproxWavePlayLen(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    /// <summary>
    /// Checks if the current game is a career match (CS only)
    /// </summary>
    /// <returns>Non-zero if career match</returns>
    public int IsCareerMatch() => Base.pfnIsCareerMatch();
    
    /// <summary>
    /// Gets the length of a localized string
    /// </summary>
    /// <param name="label">Localization label</param>
    /// <returns>String length</returns>
    public int GetLocalizedStringLength(string label)
    {
        nint ns = Marshal.StringToHGlobalAnsi(label);
        int res = Base.pfnGetLocalizedStringLength(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    /// <summary>
    /// Registers that a tutor message has been shown (CS only)
    /// </summary>
    /// <param name="mid">Message ID</param>
    public void RegisterTutorMessageShown(int mid) => Base.pfnRegisterTutorMessageShown(mid);
    
    /// <summary>
    /// Gets the number of times a tutor message has been shown (CS only)
    /// </summary>
    /// <param name="mid">Message ID</param>
    /// <returns>Show count</returns>
    public int GetTimesTutorMessageShown(int mid) => Base.pfnGetTimesTutorMessageShown(mid);
    
    /// <summary>
    /// Processes the tutor message decay buffer (CS only)
    /// </summary>
    /// <param name="buffer">Buffer pointer</param>
    /// <param name="bufferLength">Buffer length</param>
    public void ProcessTutorMessageDecayBuffer(nint buffer, int bufferLength)
        => Base.pfnProcessTutorMessageDecayBuffer(buffer, bufferLength);
    
    /// <summary>
    /// Constructs the tutor message decay buffer (CS only)
    /// </summary>
    /// <param name="buffer">Buffer pointer</param>
    /// <param name="bufferLength">Buffer length</param>
    public void ConstructTutorMessageDecayBuffer(nint buffer, int bufferLength)
        => Base.pfnConstructTutorMessageDecayBuffer(buffer, bufferLength);
    
    /// <summary>
    /// Resets tutor message decay data (CS only)
    /// </summary>
    public void ResetTutorMessageDecayData() => Base.pfnResetTutorMessageDecayData();

    /// <summary>
    /// Queries a client's console variable value (async, triggers CvarValue callback)
    /// </summary>
    /// <param name="player">Player entity</param>
    /// <param name="cvarName">CVar name to query</param>
    public void QueryClientCvarValue(Edict player, string cvarName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(cvarName);
        Base.pfnQueryClientCvarValue(player.GetPointer(), ns);
        Marshal.FreeHGlobal(ns);
    }

    /// <summary>
    /// Queries a client's console variable value with a request ID (async, triggers CvarValue2 callback)
    /// </summary>
    /// <param name="player">Player entity</param>
    /// <param name="cvarName">CVar name to query</param>
    /// <param name="requestID">Request ID for tracking the query</param>
    public void QueryClientCvarValue2(Edict player, string cvarName, int requestID)
    {
        nint ns = Marshal.StringToHGlobalAnsi(cvarName);
        Base.pfnQueryClientCvarValue2(player.GetPointer(), ns, requestID);
        Marshal.FreeHGlobal(ns);
    }

    /// <summary>
    /// Checks for a command line parameter and retrieves its value
    /// </summary>
    /// <param name="pchCmdLineToken">Command line token to search for</param>
    /// <param name="ppszValue">Output parameter value (if found)</param>
    public void EngCheckParm(string pchCmdLineToken, out string ppszValue)
    {
        nint ns = Marshal.StringToHGlobalAnsi(pchCmdLineToken);
        try
        {
            nint resultPtr = Base.pfnEngCheckParm(ns, out nint pchNextVal);
            ppszValue = Marshal.PtrToStringUTF8(pchNextVal) ?? string.Empty;
        }
        finally
        {
            Marshal.FreeHGlobal(ns);
        }
    }
}
