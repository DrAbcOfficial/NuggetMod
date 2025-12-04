using Metamod.Enum.Common;
using Metamod.Helper;
using Metamod.Native.Common;
using Metamod.Native.Engine;
using Metamod.Wrapper.Common;
using System.Runtime.InteropServices;

namespace Metamod.Wrapper.Engine;

public class EngineFuncs(nint ptr) : BaseFunctionWrapper<NativeEngineFuncs>(ptr)
{
    public void PrecacheModel(string s)
    {
        nint ns = Marshal.StringToHGlobalAnsi(s);
        Base.pfnPrecacheModel(ns);
        Marshal.FreeHGlobal(ns);
    }

    public void PrecacheSound(string s)
    {
        nint ns = Marshal.StringToHGlobalAnsi(s);
        Base.pfnPrecacheSound(ns);
        Marshal.FreeHGlobal(ns);
    }

    public void SetModel(Edict e, string m)
    {
        nint ns = Marshal.StringToHGlobalAnsi(m);
        Base.pfnSetModel(e.GetPointer(), ns);
        Marshal.FreeHGlobal(ns);
    }

    public int ModelIndex(string m)
    {
        nint ns = Marshal.StringToHGlobalAnsi(m);
        int ret = Base.pfnModelIndex(ns);
        Marshal.FreeHGlobal(ns);
        return ret;
    }

    public int ModelFrames(int modelIndex) => Base.pfnModelFrames(modelIndex);
    public void SetSize(Edict e, Vector3f min, Vector3f max) => Base.pfnSetSize(e.GetPointer(), min.GetPointer(), max.GetPointer());

    public void ChangeLevel(string s1, string s2)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(s1);
        nint ns2 = Marshal.StringToHGlobalAnsi(s2);
        Base.pfnChangeLevel(ns1, ns2);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
    }

    public void GetSpawnParms(Edict ent) => Base.pfnGetSpawnParms(ent.GetPointer());
    public void SaveSpawnParms(Edict ent) => Base.pfnSaveSpawnParms(ent.GetPointer());
    public float VecToYaw(Vector3f vec) => Base.pfnVecToYaw(vec.GetPointer());
    public void VecToAngles(Vector3f vec, Vector3f angles) => Base.pfnVecToAngles((nint)vec.GetPointer(), angles.GetPointer());
    public void MoveToOrigin(Edict ent, Vector3f goal, float dist, int moveType) => Base.pfnMoveToOrigin(ent.GetPointer(), goal.GetPointer(), dist, moveType);
    public void ChangeYaw(Edict edict) => Base.pfnChangeYaw(edict.GetPointer());
    public void ChangePitch(Edict ent) => Base.pfnChangePitch(ent.GetPointer());
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
    public int GetEntityIllum(Edict ent) => Base.pfnGetEntityIllum(ent.GetPointer());
    public Edict FindEntityInSphere(Edict e, Vector3f origin, float radius)
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnFindEntityInSphere(e.GetPointer(), origin.GetPointer(), radius));
        }
    }
    public Edict FindClientInPVS(Edict e)
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnFindClientInPVS(e.GetPointer()));
        }
    }
    public Edict EntitiesInPVS(Edict e)
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnEntitiesInPVS(e.GetPointer()));
        }
    }
    public void MakeVectors(Vector3f vec) => Base.pfnMakeVectors(vec.GetPointer());
    public void AngleVectors(Vector3f vec, Vector3f forward, Vector3f right, Vector3f up) => Base.pfnAngleVectors(vec.GetPointer(), forward.GetPointer(), right.GetPointer(), up.GetPointer());
    public Edict CreateEntity()
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnCreateEntity());
        }
    }
    public void RemoveEntity(Edict e) => Base.pfnRemoveEntity(e.GetPointer());

    public Edict CreateNamedEntity(string className)
    {
        StringHandle? _namedEntity = new(className);
        unsafe
        {
            return new((NativeEdict*)Base.pfnCreateNamedEntity(_namedEntity.ToHandle()));
        }
    }
    public void MakeStatic(Edict ent) => Base.pfnMakeStatic(ent.GetPointer());
    public int EntIsOnFloor(Edict ent) => Base.pfnEntIsOnFloor(ent.GetPointer());
    public int DropToFloor(Edict ent) => Base.pfnDropToFloor(ent.GetPointer());
    public int WalkMove(Edict ent, float yaw, float dist, int mode) => Base.pfnWalkMove(ent.GetPointer(), yaw, dist, mode);
    public void SetOrigin(Edict ent, Vector3f origin) => Base.pfnSetOrigin(ent.GetPointer(), origin.GetPointer());
    public void EmitSound(Edict ent, int channel, string sample, float volume, float attenuation, int fFlags, int pitch)
    {
        nint ns = Marshal.StringToHGlobalAnsi(sample);
        Base.pfnEmitSound(ent.GetPointer(), channel, ns, volume, attenuation, fFlags, pitch);
        Marshal.FreeHGlobal(ns);
    }
    public void EmitAmbientSound(Edict ent, Vector3f pos, string sample, float volume, float attenuation, int fFlags, int pitch)
    {
        nint ns = Marshal.StringToHGlobalAnsi(sample);
        Base.pfnEmitAmbientSound(ent.GetPointer(), pos.GetPointer(), ns, volume, attenuation, fFlags, pitch);
        Marshal.FreeHGlobal(ns);
    }
    public void TraceLine(Vector3f v1, Vector3f v2, int fNoMonsters, Edict pentToSkip, ref TraceResult ptr) =>
        Base.pfnTraceLine(v1.GetPointer(), v2.GetPointer(), fNoMonsters, pentToSkip.GetPointer(), ptr.GetPointer());
    public void TraceToss(Edict pent, Edict pentToIgnore, ref TraceResult ptr) =>
        Base.pfnTraceToss(pent.GetPointer(), pentToIgnore.GetPointer(), ptr.GetPointer());
    public int TraceMonsterHull(Edict pent, Vector3f v1, Vector3f v2, int fNoMonsters, Edict pentToSkip, ref TraceResult ptr) =>
        Base.pfnTraceMonsterHull(pent.GetPointer(), v1.GetPointer(), v2.GetPointer(), fNoMonsters, pentToSkip.GetPointer(), ptr.GetPointer());
    public void TraceHull(Vector3f v1, Vector3f v2, int fNoMonsters, int hullNumber, Edict pentToSkip, ref TraceResult ptr) =>
        Base.pfnTraceHull(v1.GetPointer(), v2.GetPointer(), fNoMonsters, hullNumber, pentToSkip.GetPointer(), ptr.GetPointer());
    public void TraceModel(Vector3f v1, Vector3f v2, int hullNumber, Edict pent, ref TraceResult ptr) =>
        Base.pfnTraceModel(v1.GetPointer(), v2.GetPointer(), hullNumber, pent.GetPointer(), ptr.GetPointer());
    public string TraceTexture(Edict pTextureEntity, Vector3f v1, Vector3f v2)
    {
        nint ptr = Base.pfnTraceTexture(pTextureEntity.GetPointer(), v1.GetPointer(), v2.GetPointer());
        return Marshal.PtrToStringUTF8(ptr) ?? string.Empty;
    }
    public void TraceSphere(Vector3f v1, Vector3f v2, int fNoMonsters, float radius, Edict pentToSkip, ref TraceResult ptr) =>
        Base.pfnTraceSphere(v1.GetPointer(), v2.GetPointer(), fNoMonsters, radius, pentToSkip.GetPointer(), ptr.GetPointer());
    public void GetAimVector(Edict ent, float speed, ref Vector3f vec) => Base.pfnGetAimVector(ent.GetPointer(), speed, vec.GetPointer());
    public void ServerCommand(string str)
    {
        nint ns = Marshal.StringToHGlobalAnsi(str);
        Base.pfnServerCommand(ns);
        Marshal.FreeHGlobal(ns);
    }
    public void ServerExecute() => Base.pfnServerExecute();
    public void ClientCommand(Edict ent, string str)
    {
        nint ns = Marshal.StringToHGlobalAnsi(str);
        Base.pfnClientCommand(ent.GetPointer(), ns);
        Marshal.FreeHGlobal(ns);
    }
    public void ParticleEffect(Vector3f org, Vector3f dir, float color, float count) => Base.pfnParticleEffect(org.GetPointer(), dir.GetPointer(), color, count);
    public void LightStyle(int style, string val)
    {
        nint ns = Marshal.StringToHGlobalAnsi(val);
        Base.pfnLightStyle(style, ns);
        Marshal.FreeHGlobal(ns);
    }
    public int DecalIndex(string name)
    {
        nint ns = Marshal.StringToHGlobalAnsi(name);
        int res = Base.pfnDecalIndex(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    public int PointContents(Vector3f vec) => Base.pfnPointContents(vec.GetPointer());
    public void MessageBegin(int msg_dest, int msg_type, Vector3f pOrigin, Edict ed) => Base.pfnMessageBegin(msg_dest, msg_type, pOrigin.GetPointer(), ed.GetPointer());
    public void MessageEnd() => Base.pfnMessageEnd();
    public void WriteByte(int iValue) => Base.pfnWriteByte(iValue);
    public void WriteChar(int iValue) => Base.pfnWriteChar(iValue);
    public void WriteShort(int iValue) => Base.pfnWriteShort(iValue);
    public void WriteLong(int iValue) => Base.pfnWriteLong(iValue);
    public void WriteAngle(float flValue) => Base.pfnWriteAngle(flValue);
    public void WriteCoord(float flValue) => Base.pfnWriteCoord(flValue);
    public void WriteString(string sz)
    {
        nint ns = Marshal.StringToHGlobalAnsi(sz);
        Base.pfnWriteString(ns);
        Marshal.FreeHGlobal(ns);
    }
    public void WriteEntity(int iValue) => Base.pfnWriteEntity(iValue);
    public void CVarRegister(CVar cvar) => Base.pfnCVarRegister(cvar.GetPointer());
    public float CVarGetFloat(string szVarName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szVarName);
        float res = Base.pfnCVarGetFloat(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    public string CVarGetString(string szVarName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szVarName);
        nint res = Base.pfnCVarGetString(ns);
        Marshal.FreeHGlobal(ns);
        return Marshal.PtrToStringUTF8(res) ?? string.Empty;
    }
    public void CVarSetFloat(string szVarName, float flValue)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szVarName);
        Base.pfnCVarSetFloat(ns, flValue);
        Marshal.FreeHGlobal(ns);
    }
    public void CVarSetString(string szVarName, string szValue)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(szVarName);
        nint ns2 = Marshal.StringToHGlobalAnsi(szValue);
        Base.pfnCVarSetString(ns1, ns2);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
    }
    public void AlertMessage(AlertType atype, string szFmt)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szFmt);
        Base.pfnAlertMessage((int)atype, ns);
        Marshal.FreeHGlobal(ns);
    }
    public void EngineFprintf(nint pFile, string szFmt, params string[] p)
    {
        nint ns = Marshal.StringToHGlobalAnsi(string.Format(szFmt, p));
        Base.pfnEngineFprintf(pFile, ns);
        Marshal.FreeHGlobal(ns);
    }
    public nint PvAllocEntPrivateData(Edict ed, int size) => Base.pfnPvAllocEntPrivateData(ed.GetPointer(), size);
    public nint PvEntPrivateData(Edict ed) => Base.pfnPvEntPrivateData(ed.GetPointer());
    public void FreeEntPrivateData(Edict ed) => Base.pfnFreeEntPrivateData(ed.GetPointer());
    public string SzFromIndex(int iString)
    {
        nint ns = Base.pfnSzFromIndex(iString);
        return Marshal.PtrToStringUTF8(ns) ?? string.Empty;
    }
    public int AllocString(string szValue)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szValue);
        return Base.pfnAllocString(ns);
    }
    public Entvars GetVarsOfEnt(Edict pEdict)
    {
        unsafe
        {
             return new((NativeEntvars*)Base.pfnGetVarsOfEnt(pEdict.GetPointer()));
        }
    }
    public Edict PEntityOfEntOffset(int iEntOffset)
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnPEntityOfEntOffset(iEntOffset));
        }
    }
    public int EntOffsetOfPEntity(Edict pEdict) => Base.pfnEntOffsetOfPEntity(pEdict.GetPointer());
    public int IndexOfEdict(Edict pEdict) => Base.pfnIndexOfEdict(pEdict.GetPointer());
    public Edict PEntityOfEntIndex(int iEntIndex)
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnPEntityOfEntIndex(iEntIndex));
        }
    }
    public Edict FindEntityByVars(Entvars pvars)
    {
        unsafe
        {
            return new((NativeEdict*)Base.pfnFindEntityByVars(pvars.GetPointer()));
        }
    }
    public nint GetModelPtr(Edict pEdict) => Base.pfnGetModelPtr(pEdict.GetPointer());
    public int RegUserMsg(string pszName, int iSize)
    {
        nint ns = Marshal.StringToHGlobalAnsi(pszName);
        int res = Base.pfnRegUserMsg(ns, iSize);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    public void AnimationAutomove(Edict ent, float flTime) => Base.pfnAnimationAutomove(ent.GetPointer(), flTime);
    public void GetBonePosition(Edict ent, int iBone, ref Vector3f origin, ref Vector3f angles) => Base.pfnGetBonePosition(ent.GetPointer(), iBone, origin.GetPointer(), angles.GetPointer());
    public uint FunctionFromName(string pName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(pName);
        uint res = Base.pfnFunctionFromName(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    public string NameForFunction(uint function) => Marshal.PtrToStringUTF8(Base.pfnNameForFunction(function)) ?? string.Empty;
    public void ClientPrintf(Edict ent, PrintType ptype, string szMsg)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szMsg);
        Base.pfnClientPrintf(ent.GetPointer(), (int)ptype, ns);
        Marshal.FreeHGlobal(ns);
    }
    public void ServerPrint(string msg)
    {
        nint nmsg = Marshal.StringToHGlobalAnsi(msg);
        Base.pfnServerPrint(nmsg);
        Marshal.FreeHGlobal(nmsg);
    }
    public string Cmd_Args() => Marshal.PtrToStringUTF8(Base.pfnCmd_Args()) ?? string.Empty;
    public string Cmd_Argv(int argc) => Marshal.PtrToStringUTF8(Base.pfnCmd_Argv(argc)) ?? string.Empty;
    public int Cmd_Argc() => Base.pfnCmd_Argc();
    public void GetAttachment(Edict ent, int iAttachment, ref Vector3f origin, ref Vector3f angles) =>
        Base.pfnGetAttachment(ent.GetPointer(), iAttachment, origin.GetPointer(), angles.GetPointer());
    public void CRC32_Init(CRC32 pulCRC) => Base.pfnCRC32_Init(pulCRC.GetPointer());
    public void CRC32_ProcessBuffer(CRC32 pulCRC, nint buffer, int len) =>
        Base.pfnCRC32_ProcessBuffer(pulCRC.GetPointer(), buffer, len);
    public void CRC32_ProcessByte(CRC32 pulCRC, byte ch) =>
        Base.pfnCRC32_ProcessByte(pulCRC.GetPointer(), ch);
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
    public int RandomLong(int lLow, int lHigh) => Base.pfnRandomLong(lLow, lHigh);
    public float RandomFloat(float flLow, float flHigh) => Base.pfnRandomFloat(flLow, flHigh);
    public void SetView(Edict ent, Edict viewent) => Base.pfnSetView(ent.GetPointer(), viewent.GetPointer());
    public float Time() => Base.pfnTime();
    public void CrosshairAngle(Edict ent, float pitch, float yaw) => Base.pfnCrosshairAngle(ent.GetPointer(), pitch, yaw);
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
    public void FreeFile(nint buffer) => Base.pfnFreeFile(buffer);
    public void EndSection(string szSectionName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(szSectionName);
        Base.pfnEndSection(ns);
        Marshal.FreeHGlobal(ns);
    }
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
    public string GetGameDir()
    {
        nint ns = Marshal.AllocHGlobal(sizeof(byte) * 256);
        Base.pfnGetGameDir(ns);
        string res = Marshal.PtrToStringUTF8(ns) ?? string.Empty;
        Marshal.FreeHGlobal(ns);
        return res;
    }
    public void CVar_RegisterVariable(CVar cvar) => Base.pfnCvar_RegisterVariable(cvar.GetPointer());
    public void FadeClientVolume(Edict ent, int fadePercent, int fadeOutSeconds, int holdTime, int fadeInSeconds) =>
        Base.pfnFadeClientVolume(ent.GetPointer(), fadePercent, fadeOutSeconds, holdTime, fadeInSeconds);
    public void SetClientMaxspeed(Edict ent, float fNewMaxspeed) => Base.pfnSetClientMaxspeed(ent.GetPointer(), fNewMaxspeed);
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
    public void RunPlayerMove(Edict fakeClient, Vector3f viewangles, float forwardmove, float sidemove, float upmove, ushort buttons, byte impulse, byte msec) =>
        Base.pfnRunPlayerMove(fakeClient.GetPointer(), viewangles.GetPointer(), forwardmove, sidemove, upmove, buttons, impulse, msec);
    public int NumberOfEntities() => Base.pfnNumberOfEntities();
    public string GetInfoKeyBuffer(Edict ent) => Marshal.PtrToStringUTF8(Base.pfnGetInfoKeyBuffer(ent.GetPointer())) ?? string.Empty;
    public string InfoKeyValue(string infobuffer, string key)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(infobuffer);
        nint ns2 = Marshal.StringToHGlobalAnsi(key);
        nint res = Base.pfnInfoKeyValue(ns1, ns2);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
        return Marshal.PtrToStringUTF8(res) ?? string.Empty;
    }
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
    public bool IsMapValid(string filename)
    {
        nint ns = Marshal.StringToHGlobalAnsi(filename);
        int res = Base.pfnIsMapValid(ns);
        Marshal.FreeHGlobal(ns);
        return res != 0;
    }
    public void StaticDecal(Vector3f origin, int decalIndex, int entityIndex, int modelIndex) =>
        Base.pfnStaticDecal(origin.GetPointer(), decalIndex, entityIndex, modelIndex);
    public void PrecacheGeneric(string s)
    {
        nint ns = Marshal.StringToHGlobalAnsi(s);
        Base.pfnPrecacheGeneric(ns);
        Marshal.FreeHGlobal(ns);
    }
    public int GetPlayerUserId(Edict e) => Base.pfnGetPlayerUserId(e.GetPointer());
    public void BuildSoundMsg(Edict entity, int channel, string sample, float volume, float attenuation, int fFlags, int pitch, int msg_dest, int msg_type, Vector3f pOrigin, Edict ed)
    {
        nint ns = Marshal.StringToHGlobalAnsi(sample);
        Base.pfnBuildSoundMsg(entity.GetPointer(), channel, ns, volume, attenuation, fFlags, pitch, msg_dest, msg_type, pOrigin.GetPointer(), ed.GetPointer());
        Marshal.FreeHGlobal(ns);
    }
    public bool IsDedicatedServer() => Base.pfnIsDedicatedServer() != 0;
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
    public uint GetPlayerWONId(Edict e) => Base.pfnGetPlayerWONId(e.GetPointer());
    public void Info_RemoveKey(ref string s, string key)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(s);
        nint ns2 = Marshal.StringToHGlobalAnsi(key);
        Base.pfnInfo_RemoveKey(ns1, ns2);
        s = Marshal.PtrToStringUTF8(ns1) ?? string.Empty;
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
    }
    public string GetPhysicsKeyValue(Edict ent, string key)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(key);
        nint res = Base.pfnGetPhysicsKeyValue(ent.GetPointer(), ns1);
        Marshal.FreeHGlobal(ns1);
        return Marshal.PtrToStringUTF8(res) ?? string.Empty;
    }
    public void SetPhysicsKeyValue(Edict ent, string key, string value)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(key);
        nint ns2 = Marshal.StringToHGlobalAnsi(value);
        Base.pfnSetPhysicsKeyValue(ent.GetPointer(), ns1, ns2);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
    }
    public string GetPhysicsInfoString(Edict ent)
    {
        nint res = Base.pfnGetPhysicsInfoString(ent.GetPointer());
        return Marshal.PtrToStringUTF8(res) ?? string.Empty;
    }
    public ushort PrecacheEvent(int type, string psz)
    {
        nint ns = Marshal.StringToHGlobalAnsi(psz);
        ushort res = Base.pfnPrecacheEvent(type, ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    public void PlaybackEvent(int flags, Edict ed, ushort eventindex, float delay, Vector3f origin, Vector3f angles, float fparam1, float fparam2, int iparam1, int iparam2, int bparam1, int bparam2)
        => Base.pfnPlaybackEvent(flags, ed.GetPointer(), eventindex, delay, origin.GetPointer(), angles.GetPointer(), fparam1, fparam2, iparam1, iparam2, bparam1, bparam2);

    public string SetFatPVS(Vector3f org)
    {
        nint ns = Base.pfnSetFatPVS(org.GetPointer());
        return Marshal.PtrToStringUTF8(ns) ?? string.Empty;
    }
    public string SetFatPAS(Vector3f org)
    {
        nint ns = Base.pfnSetFatPAS(org.GetPointer());
        return Marshal.PtrToStringUTF8(ns) ?? string.Empty;
    }
    public bool CheckVisibility(Edict entity, nint pset)
    {
        int res = Base.pfnCheckVisibility(entity.GetPointer(), pset);
        return res != 0;
    }
    public void DeltaSetField(nint pFields, string fieldName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(fieldName);
        Base.pfnDeltaSetField(pFields, ns);
        Marshal.FreeHGlobal(ns);
    }
    public void DeltaUnsetField(nint pFields, string fieldName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(fieldName);
        Base.pfnDeltaUnsetField(pFields, ns);
        Marshal.FreeHGlobal(ns);
    }
    public void DeltaAddEncoder(string name, nint callback)
    {
        nint ns = Marshal.StringToHGlobalAnsi(name);
        Base.pfnDeltaAddEncoder(ns, callback);
        Marshal.FreeHGlobal(ns);
    }
    public int GetCurrentPlayer() => Base.pfnGetCurrentPlayer();
    public int CanSkipPlayer(Edict player) => Base.pfnCanSkipPlayer(player.GetPointer());
    public int DeltaFindField(nint pFields, string fieldName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(fieldName);
        int res = Base.pfnDeltaFindField(pFields, ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    public void DeltaSetFieldByIndex(nint pFields, int fieldNumber)
        => Base.pfnDeltaSetFieldByIndex(pFields, fieldNumber);
    public void DeltaUnsetFieldByIndex(nint pFields, int fieldNumber)
        => Base.pfnDeltaUnsetFieldByIndex(pFields, fieldNumber);
    public void SetGroupMask(int mask, int op) => Base.pfnSetGroupMask(mask, op);
    public int CreateInstancedBaseline(int classname, EntityState baseline)
        => Base.pfnCreateInstancedBaseline(classname, baseline.GetPointer());
    public void Cvar_DirectSet(CVar cvar, string value)
    {
        nint ns = Marshal.StringToHGlobalAnsi(value);
        Base.pfnCvar_DirectSet(cvar.GetPointer(), ns);
        Marshal.FreeHGlobal(ns);
    }
    public void ForceUnmodified(ForceType type, Vector3f mins, Vector3f maxs, string filename)
    {
        nint ns = Marshal.StringToHGlobalAnsi(filename);
        Base.pfnForceUnmodified((int)type, mins.GetPointer(), maxs.GetPointer(), ns);
        Marshal.FreeHGlobal(ns);
    }
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

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ServerCommandDelegate();
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

    public bool Voice_GetClientListening(int iReceiver, int iSender) => Base.pfnVoice_GetClientListening(iReceiver, iSender) != 0;
    public bool Voice_SetClientListening(int iReceiver, int iSender, bool bListen) => Base.pfnVoice_SetClientListening(iReceiver, iSender, bListen ? 1 : 0) != 0;
    public string GetPlayerAuthId(Edict e)
    {
        nint res = Base.pfnGetPlayerAuthId(e.GetPointer());
        return Marshal.PtrToStringUTF8(res) ?? string.Empty;
    }
    public nint SequenceGet(string fieldName, string entryName)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(fieldName);
        nint ns2 = Marshal.StringToHGlobalAnsi(entryName);
        nint res = Base.pfnSequenceGet(ns1, ns2);
        Marshal.FreeHGlobal(ns1);
        Marshal.FreeHGlobal(ns2);
        return res;
    }
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
    public int GetFileSize(string filename)
    {
        nint ns = Marshal.StringToHGlobalAnsi(filename);
        int res = Base.pfnGetFileSize(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    public uint GetApproxWavePlayLen(string filepath)
    {
        nint ns = Marshal.StringToHGlobalAnsi(filepath);
        uint res = Base.pfnGetApproxWavePlayLen(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    public int IsCareerMatch() => Base.pfnIsCareerMatch();
    public int GetLocalizedStringLength(string label)
    {
        nint ns = Marshal.StringToHGlobalAnsi(label);
        int res = Base.pfnGetLocalizedStringLength(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }
    public void RegisterTutorMessageShown(int mid) => Base.pfnRegisterTutorMessageShown(mid);
    public int GetTimesTutorMessageShown(int mid) => Base.pfnGetTimesTutorMessageShown(mid);
    public void ProcessTutorMessageDecayBuffer(nint buffer, int bufferLength)
        => Base.pfnProcessTutorMessageDecayBuffer(buffer, bufferLength);
    public void ConstructTutorMessageDecayBuffer(nint buffer, int bufferLength)
        => Base.pfnConstructTutorMessageDecayBuffer(buffer, bufferLength);
    public void ResetTutorMessageDecayData() => Base.pfnResetTutorMessageDecayData();

    public void QueryClientCvarValue(Edict player, string cvarName)
    {
        nint ns = Marshal.StringToHGlobalAnsi(cvarName);
        Base.pfnQueryClientCvarValue(player.GetPointer(), ns);
        Marshal.FreeHGlobal(ns);
    }

    public void QueryClientCvarValue2(Edict player, string cvarName, int requestID)
    {
        nint ns = Marshal.StringToHGlobalAnsi(cvarName);
        Base.pfnQueryClientCvarValue2(player.GetPointer(), ns, requestID);
        Marshal.FreeHGlobal(ns);
    }

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
