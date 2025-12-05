using NuggetMod.Enum.Common;
using NuggetMod.Enum.NuggetMod;
using NuggetMod.Native.Common;
using NuggetMod.Wrapper.Common;
using NuggetMod.Wrapper.Engine;

namespace NuggetMod.Interface.Events;

#region Delegates
/// <summary>
/// Delegate for precaching a model.
/// </summary>
public delegate (MetaResult, int) PrecacheModelDelegate(string s);
/// <summary>
/// Delegate for precaching a sound.
/// </summary>
public delegate (MetaResult, int) PrecacheSoundDelegate(string s);
/// <summary>
/// Delegate for setting entity model.
/// </summary>
public delegate MetaResult SetModelDelegate(Edict e, string m);
/// <summary>
/// Delegate for getting model index.
/// </summary>
public delegate (MetaResult, int) ModelIndexDelegate(string m);
/// <summary>
/// Delegate for getting model frame count.
/// </summary>
public delegate (MetaResult, int) ModelFramesDelegate(int modelIndex);
/// <summary>
/// Delegate for setting entity size.
/// </summary>
public delegate MetaResult SetSizeDelegate(Edict e, Vector3f min, Vector3f max);
/// <summary>
/// Delegate for changing level.
/// </summary>
public delegate MetaResult ChangeLevelDelegate(string s1, string s2);
/// <summary>
/// Delegate for getting spawn parameters.
/// </summary>
public delegate MetaResult GetSpawnParmsDelegate(Edict ent);
/// <summary>
/// Delegate for saving spawn parameters.
/// </summary>
public delegate MetaResult SaveSpawnParmsDelegate(Edict ent);
/// <summary>
/// Delegate for converting vector to yaw angle.
/// </summary>
public delegate (MetaResult, float) VecToYawDelegate(Vector3f vec);
/// <summary>
/// Delegate for converting vector to angles.
/// </summary>
public delegate MetaResult VecToAnglesDelegate(Vector3f vec, Vector3f angles);
/// <summary>
/// Delegate for moving entity to origin.
/// </summary>
public delegate MetaResult MoveToOriginDelegate(Edict ent, Vector3f goal, float dist, int moveType);
/// <summary>
/// Delegate for changing entity yaw.
/// </summary>
public delegate MetaResult ChangeYawDelegate(Edict edict);
/// <summary>
/// Delegate for changing entity pitch.
/// </summary>
public delegate MetaResult ChangePitchDelegate(Edict ent);
/// <summary>
/// Delegate for finding entity by string field.
/// </summary>
public delegate (MetaResult, Edict) FindEntityByStringDelegate(Edict e, string field, string value);
/// <summary>
/// Delegate for getting entity illumination.
/// </summary>
public delegate (MetaResult, int) GetEntityIllumDelegate(Edict ent);
/// <summary>
/// Delegate for finding entity in sphere.
/// </summary>
public delegate (MetaResult, Edict) FindEntityInSphereDelegate(Edict e, Vector3f origin, float radius);
/// <summary>
/// Delegate for finding client in PVS.
/// </summary>
public delegate (MetaResult, Edict) FindClientInPVSDelegate(Edict e);
/// <summary>
/// Delegate for getting entities in PVS.
/// </summary>
public delegate (MetaResult, Edict) EntitiesInPVSDelegate(Edict e);
/// <summary>
/// Delegate for making global vectors from angles.
/// </summary>
public delegate MetaResult MakeVectorsDelegate(Vector3f vec);
/// <summary>
/// Delegate for converting angles to vectors.
/// </summary>
public delegate MetaResult AngleVectorsDelegate(Vector3f vec, Vector3f forward, Vector3f right, Vector3f up);
/// <summary>
/// Delegate for creating entity.
/// </summary>
public delegate (MetaResult, Edict) CreateEntityDelegate();
/// <summary>
/// Delegate for removing entity.
/// </summary>
public delegate MetaResult RemoveEntityDelegate(Edict e);
/// <summary>
/// Delegate for creating named entity.
/// </summary>
public delegate (MetaResult, Edict) CreateNamedEntityDelegate(int className);
/// <summary>
/// Delegate for making entity static.
/// </summary>
public delegate MetaResult MakeStaticDelegate(Edict ent);
/// <summary>
/// Delegate for checking if entity is on floor.
/// </summary>
public delegate (MetaResult, int) EntIsOnFloorDelegate(Edict ent);
/// <summary>
/// Delegate for dropping entity to floor.
/// </summary>
public delegate (MetaResult, int) DropToFloorDelegate(Edict ent);
/// <summary>
/// Delegate for entity walk move.
/// </summary>
public delegate (MetaResult, int) WalkMoveDelegate(Edict ent, float yaw, float dist, int mode);
/// <summary>
/// Delegate for setting entity origin.
/// </summary>
public delegate MetaResult SetOriginDelegate(Edict ent, Vector3f origin);
/// <summary>
/// Delegate for emitting sound from entity.
/// </summary>
public delegate MetaResult EmitSoundDelegate(Edict ent, int channel, string sample, float volume, float attenuation, int fFlags, int pitch);
/// <summary>
/// Delegate for emitting ambient sound.
/// </summary>
public delegate MetaResult EmitAmbientSoundDelegate(Edict ent, Vector3f pos, string sample, float volume, float attenuation, int fFlags, int pitch);
/// <summary>
/// Delegate for tracing line.
/// </summary>
public delegate MetaResult TraceLineDelegate(Vector3f v1, Vector3f v2, int fNoMonsters, Edict pentToSkip, ref TraceResult ptr);
/// <summary>
/// Delegate for tracing toss trajectory.
/// </summary>
public delegate MetaResult TraceTossDelegate(Edict pent, Edict pentToIgnore, ref TraceResult ptr);
/// <summary>
/// Delegate for tracing monster hull.
/// </summary>
public delegate (MetaResult, int) TraceMonsterHullDelegate(Edict pent, Vector3f v1, Vector3f v2, int fNoMonsters, Edict pentToSkip, ref TraceResult ptr);
/// <summary>
/// Delegate for tracing hull.
/// </summary>
public delegate MetaResult TraceHullDelegate(Vector3f v1, Vector3f v2, int fNoMonsters, int hullNumber, Edict pentToSkip, ref TraceResult ptr);
/// <summary>
/// Delegate for tracing model.
/// </summary>
public delegate MetaResult TraceModelDelegate(Vector3f v1, Vector3f v2, int hullNumber, Edict pent, ref TraceResult ptr);
/// <summary>
/// Delegate for tracing texture.
/// </summary>
public delegate (MetaResult, string) TraceTextureDelegate(Edict pTextureEntity, Vector3f v1, Vector3f v2);
/// <summary>
/// Delegate for tracing sphere.
/// </summary>
public delegate MetaResult TraceSphereDelegate(Vector3f v1, Vector3f v2, int fNoMonsters, float radius, Edict pentToSkip, ref TraceResult ptr);
/// <summary>
/// Delegate for getting aim vector.
/// </summary>
public delegate MetaResult GetAimVectorDelegate(Edict ent, float speed, ref Vector3f vec);
/// <summary>
/// Delegate for executing server command.
/// </summary>
public delegate MetaResult ServerCommandDelegate(string str);
/// <summary>
/// Delegate for executing server command buffer.
/// </summary>
public delegate MetaResult ServerExecuteDelegate();
/// <summary>
/// Delegate for executing client command from engine.
/// </summary>
public delegate MetaResult EngineClientCommandDelegate(Edict ent, string str);
/// <summary>
/// Delegate for creating particle effect.
/// </summary>
public delegate MetaResult ParticleEffectDelegate(Vector3f org, Vector3f dir, float color, float count);
/// <summary>
/// Delegate for setting light style.
/// </summary>
public delegate MetaResult LightStyleDelegate(int style, string val);
/// <summary>
/// Delegate for getting decal index.
/// </summary>
public delegate (MetaResult, int) DecalIndexDelegate(string name);
/// <summary>
/// Delegate for getting point contents.
/// </summary>
public delegate (MetaResult, int) PointContentsDelegate(Vector3f vec);
/// <summary>
/// Delegate for beginning network message.
/// </summary>
public delegate MetaResult MessageBeginDelegate(int msg_dest, int msg_type, Vector3f pOrigin, Edict ed);
/// <summary>
/// Delegate for ending network message.
/// </summary>
public delegate MetaResult MessageEndDelegate();
/// <summary>
/// Delegate for writing byte to network message.
/// </summary>
public delegate MetaResult WriteByteDelegate(int iValue);
/// <summary>
/// Delegate for writing char to network message.
/// </summary>
public delegate MetaResult WriteCharDelegate(int iValue);
/// <summary>
/// Delegate for writing short to network message.
/// </summary>
public delegate MetaResult WriteShortDelegate(int iValue);
/// <summary>
/// Delegate for writing long to network message.
/// </summary>
public delegate MetaResult WriteLongDelegate(int iValue);
/// <summary>
/// Delegate for writing angle to network message.
/// </summary>
public delegate MetaResult WriteAngleDelegate(float flValue);
/// <summary>
/// Delegate for writing coordinate to network message.
/// </summary>
public delegate MetaResult WriteCoordDelegate(float flValue);
/// <summary>
/// Delegate for writing string to network message.
/// </summary>
public delegate MetaResult WriteStringDelegate(string sz);
/// <summary>
/// Delegate for writing entity to network message.
/// </summary>
public delegate MetaResult WriteEntityDelegate(int iValue);
/// <summary>
/// Delegate for registering console variable.
/// </summary>
public delegate MetaResult CVarRegisterDelegate(CVar cvar);
/// <summary>
/// Delegate for getting console variable float value.
/// </summary>
public delegate (MetaResult, float) CVarGetFloatDelegate(string szVarName);
/// <summary>
/// Delegate for getting console variable string value.
/// </summary>
public delegate (MetaResult, string) CVarGetStringDelegate(string szVarName);
/// <summary>
/// Delegate for setting console variable float value.
/// </summary>
public delegate MetaResult CVarSetFloatDelegate(string szVarName, float flValue);
/// <summary>
/// Delegate for setting console variable string value.
/// </summary>
public delegate MetaResult CVarSetStringDelegate(string szVarName, string szValue);
/// <summary>
/// Delegate for displaying alert message.
/// </summary>
public delegate MetaResult AlertMessageDelegate(AlertType atype, string szFmt);
/// <summary>
/// Delegate for engine file printf.
/// </summary>
public delegate MetaResult EngineFprintfDelegate(nint pFile, string szFmt, params string[] p);
/// <summary>
/// Delegate for allocating entity private data.
/// </summary>
public delegate (MetaResult, nint) PvAllocEntPrivateDataDelegate(Edict ed, int size);
/// <summary>
/// Delegate for getting entity private data pointer.
/// </summary>
public delegate (MetaResult, nint) PvEntPrivateDataDelegate(Edict ed);
/// <summary>
/// Delegate for freeing entity private data.
/// </summary>
public delegate MetaResult FreeEntPrivateDataDelegate(Edict ed);
/// <summary>
/// Delegate for getting string from index.
/// </summary>
public delegate (MetaResult, string) SzFromIndexDelegate(int iString);
/// <summary>
/// Delegate for allocating string.
/// </summary>
public delegate (MetaResult, int) AllocStringDelegate(string szValue);
/// <summary>
/// Delegate for getting entity variables from edict.
/// </summary>
public delegate (MetaResult, Entvars) GetVarsOfEntDelegate(Edict pEdict);
/// <summary>
/// Delegate for getting entity from offset.
/// </summary>
public delegate (MetaResult, Edict) PEntityOfEntOffsetDelegate(int iEntOffset);
/// <summary>
/// Delegate for getting offset from entity.
/// </summary>
public delegate (MetaResult, int) EntOffsetOfPEntityDelegate(Edict pEdict);
/// <summary>
/// Delegate for getting index of edict.
/// </summary>
public delegate (MetaResult, int) IndexOfEdictDelegate(Edict pEdict);
/// <summary>
/// Delegate for getting entity from index.
/// </summary>
public delegate (MetaResult, Edict) PEntityOfEntIndexDelegate(int iEntIndex);
/// <summary>
/// Delegate for finding entity by entity variables.
/// </summary>
public delegate (MetaResult, Edict) FindEntityByVarsDelegate(Entvars pvars);
/// <summary>
/// Delegate for getting model pointer.
/// </summary>
public delegate (MetaResult, nint) GetModelPtrDelegate(Edict pEdict);
/// <summary>
/// Delegate for registering user message.
/// </summary>
public delegate (MetaResult, int) RegUserMsgDelegate(string pszName, int iSize);
/// <summary>
/// Delegate for animation auto-move.
/// </summary>
public delegate MetaResult AnimationAutomoveDelegate(Edict ent, float flTime);
/// <summary>
/// Delegate for getting bone position.
/// </summary>
public delegate MetaResult GetBonePositionDelegate(Edict ent, int iBone, ref Vector3f origin, ref Vector3f angles);
/// <summary>
/// Delegate for getting function address from name.
/// </summary>
public delegate (MetaResult, uint) FunctionFromNameDelegate(string pName);
/// <summary>
/// Delegate for getting function name from address.
/// </summary>
public delegate (MetaResult, string) NameForFunctionDelegate(uint function);
/// <summary>
/// Delegate for printing message to client console.
/// </summary>
public delegate MetaResult ClientPrintfDelegate(Edict ent, PrintType ptype, string szMsg);
/// <summary>
/// Delegate for printing message to server console.
/// </summary>
public delegate MetaResult ServerPrintDelegate(string msg);
/// <summary>
/// Delegate for getting command arguments.
/// </summary>
public delegate (MetaResult, string) Cmd_ArgsDelegate();
/// <summary>
/// Delegate for getting command argument by index.
/// </summary>
public delegate (MetaResult, string) Cmd_ArgvDelegate(int argc);
/// <summary>
/// Delegate for getting command argument count.
/// </summary>
public delegate (MetaResult, int) Cmd_ArgcDelegate();
/// <summary>
/// Delegate for getting entity attachment position.
/// </summary>
public delegate MetaResult GetAttachmentDelegate(Edict ent, int iAttachment, ref Vector3f origin, ref Vector3f angles);
/// <summary>
/// Delegate for initializing CRC32.
/// </summary>
public delegate MetaResult CRC32_InitDelegate(CRC32 pulCRC);
/// <summary>
/// Delegate for processing CRC32 buffer.
/// </summary>
public delegate MetaResult CRC32_ProcessBufferDelegate(CRC32 pulCRC, nint buffer, int len);
/// <summary>
/// Delegate for processing CRC32 byte.
/// </summary>
public delegate MetaResult CRC32_ProcessByteDelegate(CRC32 pulCRC, byte ch);
/// <summary>
/// Delegate for finalizing CRC32.
/// </summary>
public delegate (MetaResult, CRC32) CRC32_FinalDelegate(CRC32 pulCRC);
/// <summary>
/// Delegate for generating random long integer.
/// </summary>
public delegate (MetaResult, int) RandomLongDelegate(int lLow, int lHigh);
/// <summary>
/// Delegate for generating random float.
/// </summary>
public delegate (MetaResult, float) RandomFloatDelegate(float flLow, float flHigh);
/// <summary>
/// Delegate for setting client view entity.
/// </summary>
public delegate MetaResult SetViewDelegate(Edict ent, Edict viewent);
/// <summary>
/// Delegate for getting server time.
/// </summary>
public delegate (MetaResult, float) TimeDelegate();
/// <summary>
/// Delegate for setting crosshair angle.
/// </summary>
public delegate MetaResult CrosshairAngleDelegate(Edict ent, float pitch, float yaw);
/// <summary>
/// Delegate for loading file.
/// </summary>
public delegate (MetaResult, nint) LoadFileForMeDelegate(string filename, out int pLength);
/// <summary>
/// Delegate for freeing loaded file.
/// </summary>
public delegate MetaResult FreeFileDelegate(nint buffer);
/// <summary>
/// Delegate for ending section.
/// </summary>
public delegate MetaResult EndSectionDelegate(string szSectionName);
/// <summary>
/// Delegate for comparing file times.
/// </summary>
public delegate (MetaResult, int) CompareFileTimeDelegate(string filename1, string filename2, out int iCompare);
/// <summary>
/// Delegate for getting game directory.
/// </summary>
public delegate (MetaResult, string) GetGameDirDelegate();
/// <summary>
/// Delegate for registering console variable (alternative).
/// </summary>
public delegate MetaResult CVar_RegisterVariableDelegate(CVar cvar);
/// <summary>
/// Delegate for fading client volume.
/// </summary>
public delegate MetaResult FadeClientVolumeDelegate(Edict ent, int fadePercent, int fadeOutSeconds, int holdTime, int fadeInSeconds);
/// <summary>
/// Delegate for setting client max speed.
/// </summary>
public delegate MetaResult SetClientMaxspeedDelegate(Edict ent, float fNewMaxspeed);
/// <summary>
/// Delegate for creating fake client (bot).
/// </summary>
public delegate (MetaResult, Edict) CreateFakeClientDelegate(string netname);
/// <summary>
/// Delegate for running player move for fake client.
/// </summary>
public delegate MetaResult RunPlayerMoveDelegate(Edict fakeClient, Vector3f viewangles, float forwardmove, float sidemove, float upmove, ushort buttons, byte impulse, byte msec);
/// <summary>
/// Delegate for getting number of entities.
/// </summary>
public delegate (MetaResult, int) NumberOfEntitiesDelegate();
/// <summary>
/// Delegate for getting info key buffer.
/// </summary>
public delegate (MetaResult, string) GetInfoKeyBufferDelegate(Edict ent);
/// <summary>
/// Delegate for getting info key value.
/// </summary>
public delegate (MetaResult, string) InfoKeyValueDelegate(string infobuffer, string key);
/// <summary>
/// Delegate for setting key value in info buffer.
/// </summary>
public delegate MetaResult SetKeyValueDelegate(ref string infobuffer, string key, string value);
/// <summary>
/// Delegate for setting client key value.
/// </summary>
public delegate MetaResult SetClientKeyValueDelegate(int clientIndex, string infobuffer, string key, string value);
/// <summary>
/// Delegate for checking if map is valid.
/// </summary>
public delegate (MetaResult, bool) IsMapValidDelegate(string filename);
/// <summary>
/// Delegate for creating static decal.
/// </summary>
public delegate MetaResult StaticDecalDelegate(Vector3f origin, int decalIndex, int entityIndex, int modelIndex);
/// <summary>
/// Delegate for precaching generic resource.
/// </summary>
public delegate (MetaResult, int) PrecacheGenericDelegate(string s);
/// <summary>
/// Delegate for getting player user ID.
/// </summary>
public delegate (MetaResult, int) GetPlayerUserIdDelegate(Edict e);
/// <summary>
/// Delegate for building sound message.
/// </summary>
public delegate MetaResult BuildSoundMsgDelegate(Edict entity, int channel, string sample, float volume, float attenuation, int fFlags, int pitch, int msg_dest, int msg_type, Vector3f pOrigin, Edict ed);
/// <summary>
/// Delegate for checking if server is dedicated.
/// </summary>
public delegate (MetaResult, bool) IsDedicatedServerDelegate();
/// <summary>
/// Delegate for getting console variable pointer.
/// </summary>
public delegate (MetaResult, CVar?) CVarGetPointerDelegate(string szVarName);
/// <summary>
/// Delegate for getting player WON ID.
/// </summary>
public delegate (MetaResult, uint) GetPlayerWONIdDelegate(Edict e);
/// <summary>
/// Delegate for removing key from info string.
/// </summary>
public delegate MetaResult Info_RemoveKeyDelegate(ref string s, string key);
/// <summary>
/// Delegate for getting physics key value.
/// </summary>
public delegate (MetaResult, string) GetPhysicsKeyValueDelegate(Edict ent, string key);
/// <summary>
/// Delegate for setting physics key value.
/// </summary>
public delegate MetaResult SetPhysicsKeyValueDelegate(Edict ent, string key, string value);
/// <summary>
/// Delegate for getting physics info string.
/// </summary>
public delegate (MetaResult, string) GetPhysicsInfoStringDelegate(Edict ent);
/// <summary>
/// Delegate for precaching event.
/// </summary>
public delegate (MetaResult, ushort) PrecacheEventDelegate(int type, string psz);
/// <summary>
/// Delegate for playing back event.
/// </summary>
public delegate MetaResult PlaybackEventDelegate(int flags, Edict ed, ushort eventindex, float delay, Vector3f origin, Vector3f angles, float fparam1, float fparam2, int iparam1, int iparam2, int bparam1, int bparam2);
/// <summary>
/// Delegate for setting fat PVS (Potentially Visible Set).
/// </summary>
public delegate (MetaResult, string) SetFatPVSDelegate(Vector3f org);
/// <summary>
/// Delegate for setting fat PAS (Potentially Audible Set).
/// </summary>
public delegate (MetaResult, string) SetFatPASDelegate(Vector3f org);
/// <summary>
/// Delegate for checking entity visibility.
/// </summary>
public delegate (MetaResult, bool) CheckVisibilityDelegate(Edict entity, nint pset);
/// <summary>
/// Delegate for setting delta field.
/// </summary>
public delegate MetaResult DeltaSetFieldDelegate(nint pFields, string fieldName);
/// <summary>
/// Delegate for unsetting delta field.
/// </summary>
public delegate MetaResult DeltaUnsetFieldDelegate(nint pFields, string fieldName);
/// <summary>
/// Delegate for adding delta encoder.
/// </summary>
public delegate MetaResult DeltaAddEncoderDelegate(string name, nint callback);
/// <summary>
/// Delegate for getting current player index.
/// </summary>
public delegate (MetaResult, int) GetCurrentPlayerDelegate();
/// <summary>
/// Delegate for checking if player can be skipped.
/// </summary>
public delegate (MetaResult, int) CanSkipPlayerDelegate(Edict player);
/// <summary>
/// Delegate for finding delta field.
/// </summary>
public delegate (MetaResult, int) DeltaFindFieldDelegate(nint pFields, string fieldName);
/// <summary>
/// Delegate for setting delta field by index.
/// </summary>
public delegate MetaResult DeltaSetFieldByIndexDelegate(nint pFields, int fieldNumber);
/// <summary>
/// Delegate for unsetting delta field by index.
/// </summary>
public delegate MetaResult DeltaUnsetFieldByIndexDelegate(nint pFields, int fieldNumber);
/// <summary>
/// Delegate for setting group mask.
/// </summary>
public delegate MetaResult SetGroupMaskDelegate(int mask, int op);
/// <summary>
/// Delegate for creating instanced baseline.
/// </summary>
public delegate (MetaResult, int) CreateInstancedBaselineDelegate(int classname, EntityState baseline);
/// <summary>
/// Delegate for directly setting console variable.
/// </summary>
public delegate MetaResult Cvar_DirectSetDelegate(CVar cvar, string value);
/// <summary>
/// Delegate for forcing file consistency check.
/// </summary>
public delegate MetaResult ForceUnmodifiedDelegate(ForceType type, Vector3f mins, Vector3f maxs, string filename);
/// <summary>
/// Delegate for getting player network statistics.
/// </summary>
public delegate MetaResult GetPlayerStatsDelegate(Edict ent, out int ping, out int packet_loss);
/// <summary>
/// Delegate for adding server command.
/// </summary>
public delegate MetaResult AddServerCommandDelegate(string cmd_name, ServerCommandDelegate function);
/// <summary>
/// Delegate for getting voice client listening status.
/// </summary>
public delegate (MetaResult, bool) Voice_GetClientListeningDelegate(int iReceiver, int iSender);
/// <summary>
/// Delegate for setting voice client listening status.
/// </summary>
public delegate (MetaResult, bool) Voice_SetClientListeningDelegate(int iReceiver, int iSender, bool bListen);
/// <summary>
/// Delegate for getting player authentication ID.
/// </summary>
public delegate (MetaResult, string) GetPlayerAuthIdDelegate(Edict e);
/// <summary>
/// Delegate for getting sequence entry.
/// </summary>
public delegate (MetaResult, nint) SequenceGetDelegate(string fieldName, string entryName);
/// <summary>
/// Delegate for picking sentence from sequence.
/// </summary>
public delegate (MetaResult, nint) SequencePickSentenceDelegate(string groupName, int pickMethod, out int picked);
/// <summary>
/// Delegate for getting file size.
/// </summary>
public delegate (MetaResult, int) GetFileSizeDelegate(string filename);
/// <summary>
/// Delegate for getting approximate wave play length.
/// </summary>
public delegate (MetaResult, uint) GetApproxWavePlayLenDelegate(string filepath);
/// <summary>
/// Delegate for checking if current match is career match.
/// </summary>
public delegate (MetaResult, int) IsCareerMatchDelegate();
/// <summary>
/// Delegate for getting localized string length.
/// </summary>
public delegate (MetaResult, int) GetLocalizedStringLengthDelegate(string label);
/// <summary>
/// Delegate for registering tutor message as shown.
/// </summary>
public delegate MetaResult RegisterTutorMessageShownDelegate(int mid);
/// <summary>
/// Delegate for getting times tutor message was shown.
/// </summary>
public delegate (MetaResult, int) GetTimesTutorMessageShownDelegate(int mid);
/// <summary>
/// Delegate for processing tutor message decay buffer.
/// </summary>
public delegate MetaResult ProcessTutorMessageDecayBufferDelegate(nint buffer, int bufferLength);
/// <summary>
/// Delegate for constructing tutor message decay buffer.
/// </summary>
public delegate MetaResult ConstructTutorMessageDecayBufferDelegate(nint buffer, int bufferLength);
/// <summary>
/// Delegate for resetting tutor message decay data.
/// </summary>
public delegate MetaResult ResetTutorMessageDecayDataDelegate();
/// <summary>
/// Delegate for querying client console variable value.
/// </summary>
public delegate MetaResult QueryClientCvarValueDelegate(Edict player, string cvarName);
/// <summary>
/// Delegate for querying client console variable value with request ID.
/// </summary>
public delegate MetaResult QueryClientCvarValue2Delegate(Edict player, string cvarName, int requestID);
/// <summary>
/// Delegate for checking engine command line parameter.
/// </summary>
public delegate (MetaResult, int) EngCheckParmDelegate(string pchCmdLineToken, out string ppszValue);
#endregion

/// <summary>
/// Provides events for engine functions that can be hooked by plugins.
/// </summary>
public class EngineEvents
{
    #region Events
    public event PrecacheModelDelegate? PrecacheModel;
    public event PrecacheSoundDelegate? PrecacheSound;
    public event SetModelDelegate? SetModel;
    public event ModelIndexDelegate? ModelIndex;
    public event ModelFramesDelegate? ModelFrames;
    public event SetSizeDelegate? SetSize;
    public event ChangeLevelDelegate? ChangeLevel;
    public event GetSpawnParmsDelegate? GetSpawnParms;
    public event SaveSpawnParmsDelegate? SaveSpawnParms;
    public event VecToYawDelegate? VecToYaw;
    public event VecToAnglesDelegate? VecToAngles;
    public event MoveToOriginDelegate? MoveToOrigin;
    public event ChangeYawDelegate? ChangeYaw;
    public event ChangePitchDelegate? ChangePitch;
    public event FindEntityByStringDelegate? FindEntityByString;
    public event GetEntityIllumDelegate? GetEntityIllum;
    public event FindEntityInSphereDelegate? FindEntityInSphere;
    public event FindClientInPVSDelegate? FindClientInPVS;
    public event EntitiesInPVSDelegate? EntitiesInPVS;
    public event MakeVectorsDelegate? MakeVectors;
    public event AngleVectorsDelegate? AngleVectors;
    public event CreateEntityDelegate? CreateEntity;
    public event RemoveEntityDelegate? RemoveEntity;
    public event CreateNamedEntityDelegate? CreateNamedEntity;
    public event MakeStaticDelegate? MakeStatic;
    public event EntIsOnFloorDelegate? EntIsOnFloor;
    public event DropToFloorDelegate? DropToFloor;
    public event WalkMoveDelegate? WalkMove;
    public event SetOriginDelegate? SetOrigin;
    public event EmitSoundDelegate? EmitSound;
    public event EmitAmbientSoundDelegate? EmitAmbientSound;
    public event TraceLineDelegate? TraceLine;
    public event TraceTossDelegate? TraceToss;
    public event TraceMonsterHullDelegate? TraceMonsterHull;
    public event TraceHullDelegate? TraceHull;
    public event TraceModelDelegate? TraceModel;
    public event TraceTextureDelegate? TraceTexture;
    public event TraceSphereDelegate? TraceSphere;
    public event GetAimVectorDelegate? GetAimVector;
    public event ServerCommandDelegate? ServerCommand;
    public event ServerExecuteDelegate? ServerExecute;
    public event EngineClientCommandDelegate? ClientCommand;
    public event ParticleEffectDelegate? ParticleEffect;
    public event LightStyleDelegate? LightStyle;
    public event DecalIndexDelegate? DecalIndex;
    public event PointContentsDelegate? PointContents;
    public event MessageBeginDelegate? MessageBegin;
    public event MessageEndDelegate? MessageEnd;
    public event WriteByteDelegate? WriteByte;
    public event WriteCharDelegate? WriteChar;
    public event WriteShortDelegate? WriteShort;
    public event WriteLongDelegate? WriteLong;
    public event WriteAngleDelegate? WriteAngle;
    public event WriteCoordDelegate? WriteCoord;
    public event WriteStringDelegate? WriteString;
    public event WriteEntityDelegate? WriteEntity;
    public event CVarRegisterDelegate? CVarRegister;
    public event CVarGetFloatDelegate? CVarGetFloat;
    public event CVarGetStringDelegate? CVarGetString;
    public event CVarSetFloatDelegate? CVarSetFloat;
    public event CVarSetStringDelegate? CVarSetString;
    public event AlertMessageDelegate? AlertMessage;
    public event EngineFprintfDelegate? EngineFprintf;
    public event PvAllocEntPrivateDataDelegate? PvAllocEntPrivateData;
    public event PvEntPrivateDataDelegate? PvEntPrivateData;
    public event FreeEntPrivateDataDelegate? FreeEntPrivateData;
    public event SzFromIndexDelegate? SzFromIndex;
    public event AllocStringDelegate? AllocString;
    public event GetVarsOfEntDelegate? GetVarsOfEnt;
    public event PEntityOfEntOffsetDelegate? PEntityOfEntOffset;
    public event EntOffsetOfPEntityDelegate? EntOffsetOfPEntity;
    public event IndexOfEdictDelegate? IndexOfEdict;
    public event PEntityOfEntIndexDelegate? PEntityOfEntIndex;
    public event FindEntityByVarsDelegate? FindEntityByVars;
    public event GetModelPtrDelegate? GetModelPtr;
    public event RegUserMsgDelegate? RegUserMsg;
    public event AnimationAutomoveDelegate? AnimationAutomove;
    public event GetBonePositionDelegate? GetBonePosition;
    public event FunctionFromNameDelegate? FunctionFromName;
    public event NameForFunctionDelegate? NameForFunction;
    public event ClientPrintfDelegate? ClientPrintf;
    public event ServerPrintDelegate? ServerPrint;
    public event Cmd_ArgsDelegate? Cmd_Args;
    public event Cmd_ArgvDelegate? Cmd_Argv;
    public event Cmd_ArgcDelegate? Cmd_Argc;
    public event GetAttachmentDelegate? GetAttachment;
    public event CRC32_InitDelegate? CRC32_Init;
    public event CRC32_ProcessBufferDelegate? CRC32_ProcessBuffer;
    public event CRC32_ProcessByteDelegate? CRC32_ProcessByte;
    public event CRC32_FinalDelegate? CRC32_Final;
    public event RandomLongDelegate? RandomLong;
    public event RandomFloatDelegate? RandomFloat;
    public event SetViewDelegate? SetView;
    public event TimeDelegate? Time;
    public event CrosshairAngleDelegate? CrosshairAngle;
    public event LoadFileForMeDelegate? LoadFileForMe;
    public event FreeFileDelegate? FreeFile;
    public event EndSectionDelegate? EndSection;
    public event CompareFileTimeDelegate? CompareFileTime;
    public event GetGameDirDelegate? GetGameDir;
    public event CVar_RegisterVariableDelegate? Cvar_RegisterVariable;
    public event FadeClientVolumeDelegate? FadeClientVolume;
    public event SetClientMaxspeedDelegate? SetClientMaxspeed;
    public event CreateFakeClientDelegate? CreateFakeClient;
    public event RunPlayerMoveDelegate? RunPlayerMove;
    public event NumberOfEntitiesDelegate? NumberOfEntities;
    public event GetInfoKeyBufferDelegate? GetInfoKeyBuffer;
    public event InfoKeyValueDelegate? InfoKeyValue;
    public event SetKeyValueDelegate? SetKeyValue;
    public event SetClientKeyValueDelegate? SetClientKeyValue;
    public event IsMapValidDelegate? IsMapValid;
    public event StaticDecalDelegate? StaticDecal;
    public event PrecacheGenericDelegate? PrecacheGeneric;
    public event GetPlayerUserIdDelegate? GetPlayerUserId;
    public event BuildSoundMsgDelegate? BuildSoundMsg;
    public event IsDedicatedServerDelegate? IsDedicatedServer;
    public event CVarGetPointerDelegate? CVarGetPointer;
    public event GetPlayerWONIdDelegate? GetPlayerWONId;
    public event Info_RemoveKeyDelegate? Info_RemoveKey;
    public event GetPhysicsKeyValueDelegate? GetPhysicsKeyValue;
    public event SetPhysicsKeyValueDelegate? SetPhysicsKeyValue;
    public event GetPhysicsInfoStringDelegate? GetPhysicsInfoString;
    public event PrecacheEventDelegate? PrecacheEvent;
    public event PlaybackEventDelegate? PlaybackEvent;
    public event SetFatPVSDelegate? SetFatPVS;
    public event SetFatPASDelegate? SetFatPAS;
    public event CheckVisibilityDelegate? CheckVisibility;
    public event DeltaSetFieldDelegate? DeltaSetField;
    public event DeltaUnsetFieldDelegate? DeltaUnsetField;
    public event DeltaAddEncoderDelegate? DeltaAddEncoder;
    public event GetCurrentPlayerDelegate? GetCurrentPlayer;
    public event CanSkipPlayerDelegate? CanSkipPlayer;
    public event DeltaFindFieldDelegate? DeltaFindField;
    public event DeltaSetFieldByIndexDelegate? DeltaSetFieldByIndex;
    public event DeltaUnsetFieldByIndexDelegate? DeltaUnsetFieldByIndex;
    public event SetGroupMaskDelegate? SetGroupMask;
    public event CreateInstancedBaselineDelegate? CreateInstancedBaseline;
    public event Cvar_DirectSetDelegate? Cvar_DirectSet;
    public event ForceUnmodifiedDelegate? ForceUnmodified;
    public event GetPlayerStatsDelegate? GetPlayerStats;
    public event AddServerCommandDelegate? AddServerCommand;
    public event Voice_GetClientListeningDelegate? Voice_GetClientListening;
    public event Voice_SetClientListeningDelegate? Voice_SetClientListening;
    public event GetPlayerAuthIdDelegate? GetPlayerAuthId;
    public event SequenceGetDelegate? SequenceGet;
    public event SequencePickSentenceDelegate? SequencePickSentence;
    public event GetFileSizeDelegate? GetFileSize;
    public event GetApproxWavePlayLenDelegate? GetApproxWavePlayLen;
    public event IsCareerMatchDelegate? IsCareerMatch;
    public event GetLocalizedStringLengthDelegate? GetLocalizedStringLength;
    public event RegisterTutorMessageShownDelegate? RegisterTutorMessageShown;
    public event GetTimesTutorMessageShownDelegate? GetTimesTutorMessageShown;
    public event ProcessTutorMessageDecayBufferDelegate? ProcessTutorMessageDecayBuffer;
    public event ConstructTutorMessageDecayBufferDelegate? ConstructTutorMessageDecayBuffer;
    public event ResetTutorMessageDecayDataDelegate? ResetTutorMessageDecayData;
    public event QueryClientCvarValueDelegate? QueryClientCvarValue;
    public event QueryClientCvarValue2Delegate? QueryClientCvarValue2;
    public event EngCheckParmDelegate? EngCheckParm;
    #endregion

    #region Invoker
    internal int InvokePrecacheModel(string s)
    {
        var result = PrecacheModel?.Invoke(s);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal int InvokePrecacheSound(string s)
    {
        var result = PrecacheSound?.Invoke(s);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeSetModel(Edict e, string m)
    {
        var result = SetModel?.Invoke(e, m);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal int InvokeModelIndex(string m)
    {
        var result = ModelIndex?.Invoke(m);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal int InvokeModelFrames(int modelIndex)
    {
        var result = ModelFrames?.Invoke(modelIndex);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeSetSize(Edict e, Vector3f min, Vector3f max)
    {
        var result = SetSize?.Invoke(e, min, max);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeChangeLevel(string s1, string s2)
    {
        var result = ChangeLevel?.Invoke(s1, s2);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeGetSpawnParms(Edict ent)
    {
        var result = GetSpawnParms?.Invoke(ent);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeSaveSpawnParms(Edict ent)
    {
        var result = SaveSpawnParms?.Invoke(ent);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal float InvokeVecToYaw(Vector3f vec)
    {
        var result = VecToYaw?.Invoke(vec);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0f;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeVecToAngles(Vector3f vec, Vector3f angles)
    {
        var result = VecToAngles?.Invoke(vec, angles);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeMoveToOrigin(Edict ent, Vector3f goal, float dist, int moveType)
    {
        var result = MoveToOrigin?.Invoke(ent, goal, dist, moveType);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeChangeYaw(Edict edict)
    {
        var result = ChangeYaw?.Invoke(edict);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeChangePitch(Edict ent)
    {
        var result = ChangePitch?.Invoke(ent);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal Edict InvokeFindEntityByString(Edict e, string field, string value)
    {
        var result = FindEntityByString?.Invoke(e, field, value);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return new Edict();
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal int InvokeGetEntityIllum(Edict ent)
    {
        var result = GetEntityIllum?.Invoke(ent);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal Edict InvokeFindEntityInSphere(Edict e, Vector3f origin, float radius)
    {
        var result = FindEntityInSphere?.Invoke(e, origin, radius);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return new Edict();
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal Edict InvokeFindClientInPVS(Edict e)
    {
        var result = FindClientInPVS?.Invoke(e);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return new Edict();
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal Edict InvokeEntitiesInPVS(Edict e)
    {
        var result = EntitiesInPVS?.Invoke(e);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return new Edict();
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeMakeVectors(Vector3f vec)
    {
        var result = MakeVectors?.Invoke(vec);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeAngleVectors(Vector3f vec, Vector3f forward, Vector3f right, Vector3f up)
    {
        var result = AngleVectors?.Invoke(vec, forward, right, up);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal Edict InvokeCreateEntity()
    {
        var result = CreateEntity?.Invoke();
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return new Edict();
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeRemoveEntity(Edict e)
    {
        var result = RemoveEntity?.Invoke(e);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal Edict InvokeCreateNamedEntity(int className)
    {
        var result = CreateNamedEntity?.Invoke(className);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return new Edict();
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeMakeStatic(Edict ent)
    {
        var result = MakeStatic?.Invoke(ent);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal int InvokeEntIsOnFloor(Edict ent)
    {
        var result = EntIsOnFloor?.Invoke(ent);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal int InvokeDropToFloor(Edict ent)
    {
        var result = DropToFloor?.Invoke(ent);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal int InvokeWalkMove(Edict ent, float yaw, float dist, int mode)
    {
        var result = WalkMove?.Invoke(ent, yaw, dist, mode);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeSetOrigin(Edict ent, Vector3f origin)
    {
        var result = SetOrigin?.Invoke(ent, origin);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeEmitSound(Edict ent, int channel, string sample, float volume, float attenuation, int fFlags, int pitch)
    {
        var result = EmitSound?.Invoke(ent, channel, sample, volume, attenuation, fFlags, pitch);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeEmitAmbientSound(Edict ent, Vector3f pos, string sample, float volume, float attenuation, int fFlags, int pitch)
    {
        var result = EmitAmbientSound?.Invoke(ent, pos, sample, volume, attenuation, fFlags, pitch);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeTraceLine(Vector3f v1, Vector3f v2, int fNoMonsters, Edict pentToSkip, ref TraceResult ptr)
    {
        var result = TraceLine?.Invoke(v1, v2, fNoMonsters, pentToSkip, ref ptr);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeTraceToss(Edict pent, Edict pentToIgnore, ref TraceResult ptr)
    {
        var result = TraceToss?.Invoke(pent, pentToIgnore, ref ptr);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal int InvokeTraceMonsterHull(Edict pent, Vector3f v1, Vector3f v2, int fNoMonsters, Edict pentToSkip, ref TraceResult ptr)
    {
        var result = TraceMonsterHull?.Invoke(pent, v1, v2, fNoMonsters, pentToSkip, ref ptr);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeTraceHull(Vector3f v1, Vector3f v2, int fNoMonsters, int hullNumber, Edict pentToSkip, ref TraceResult ptr)
    {
        var result = TraceHull?.Invoke(v1, v2, fNoMonsters, hullNumber, pentToSkip, ref ptr);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeTraceModel(Vector3f v1, Vector3f v2, int hullNumber, Edict pent, ref TraceResult ptr)
    {
        var result = TraceModel?.Invoke(v1, v2, hullNumber, pent, ref ptr);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal string InvokeTraceTexture(Edict pTextureEntity, Vector3f v1, Vector3f v2)
    {
        var result = TraceTexture?.Invoke(pTextureEntity, v1, v2);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeTraceSphere(Vector3f v1, Vector3f v2, int fNoMonsters, float radius, Edict pentToSkip, ref TraceResult ptr)
    {
        var result = TraceSphere?.Invoke(v1, v2, fNoMonsters, radius, pentToSkip, ref ptr);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeGetAimVector(Edict ent, float speed, ref Vector3f vec)
    {
        var result = GetAimVector?.Invoke(ent, speed, ref vec);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeServerCommand(string str)
    {
        var result = ServerCommand?.Invoke(str);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeServerExecute()
    {
        var result = ServerExecute?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeClientCommand(Edict ent, string str)
    {
        var result = ClientCommand?.Invoke(ent, str);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeParticleEffect(Vector3f org, Vector3f dir, float color, float count)
    {
        var result = ParticleEffect?.Invoke(org, dir, color, count);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeLightStyle(int style, string val)
    {
        var result = LightStyle?.Invoke(style, val);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal int InvokeDecalIndex(string name)
    {
        var result = DecalIndex?.Invoke(name);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokePointContents(Vector3f vec)
    {
        var result = PointContents?.Invoke(vec);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeMessageBegin(int msg_dest, int msg_type, Vector3f pOrigin, Edict ed)
    {
        var result = MessageBegin?.Invoke(msg_dest, msg_type, pOrigin, ed);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeMessageEnd()
    {
        var result = MessageEnd?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeWriteByte(int iValue)
    {
        var result = WriteByte?.Invoke(iValue);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeWriteChar(int iValue)
    {
        var result = WriteChar?.Invoke(iValue);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeWriteShort(int iValue)
    {
        var result = WriteShort?.Invoke(iValue);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeWriteLong(int iValue)
    {
        var result = WriteLong?.Invoke(iValue);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeWriteAngle(float flValue)
    {
        var result = WriteAngle?.Invoke(flValue);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeWriteCoord(float flValue)
    {
        var result = WriteCoord?.Invoke(flValue);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeWriteString(string sz)
    {
        var result = WriteString?.Invoke(sz);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeWriteEntity(int iValue)
    {
        var result = WriteEntity?.Invoke(iValue);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeCVarRegister(CVar cvar)
    {
        var result = CVarRegister?.Invoke(cvar);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal float InvokeCVarGetFloat(string szVarName)
    {
        var result = CVarGetFloat?.Invoke(szVarName);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0f;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal string InvokeCVarGetString(string szVarName)
    {
        var result = CVarGetString?.Invoke(szVarName);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeCVarSetFloat(string szVarName, float flValue)
    {
        var result = CVarSetFloat?.Invoke(szVarName, flValue);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeCVarSetString(string szVarName, string szValue)
    {
        var result = CVarSetString?.Invoke(szVarName, szValue);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeAlertMessage(AlertType atype, string szFmt)
    {
        var result = AlertMessage?.Invoke(atype, szFmt);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeEngineFprintf(nint pFile, string szFmt, params string[] p)
    {
        var result = EngineFprintf?.Invoke(pFile, szFmt, p);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal nint InvokePvAllocEntPrivateData(Edict ed, int size)
    {
        var result = PvAllocEntPrivateData?.Invoke(ed, size);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return nint.Zero;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal nint InvokePvEntPrivateData(Edict ed)
    {
        var result = PvEntPrivateData?.Invoke(ed);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return nint.Zero;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeFreeEntPrivateData(Edict ed)
    {
        var result = FreeEntPrivateData?.Invoke(ed);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal string InvokeSzFromIndex(int iString)
    {
        var result = SzFromIndex?.Invoke(iString);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokeAllocString(string szValue)
    {
        var result = AllocString?.Invoke(szValue);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal Entvars InvokeGetVarsOfEnt(Edict pEdict)
    {
        var result = GetVarsOfEnt?.Invoke(pEdict);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return new Entvars();
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal Edict InvokePEntityOfEntOffset(int iEntOffset)
    {
        var result = PEntityOfEntOffset?.Invoke(iEntOffset);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return new Edict();
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokeEntOffsetOfPEntity(Edict pEdict)
    {
        var result = EntOffsetOfPEntity?.Invoke(pEdict);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokeIndexOfEdict(Edict pEdict)
    {
        var result = IndexOfEdict?.Invoke(pEdict);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal Edict InvokePEntityOfEntIndex(int iEntIndex)
    {
        var result = PEntityOfEntIndex?.Invoke(iEntIndex);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return new Edict();
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal Edict InvokeFindEntityByVars(Entvars pvars)
    {
        var result = FindEntityByVars?.Invoke(pvars);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return new Edict();
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal nint InvokeGetModelPtr(Edict pEdict)
    {
        var result = GetModelPtr?.Invoke(pEdict);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return nint.Zero;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokeRegUserMsg(string pszName, int iSize)
    {
        var result = RegUserMsg?.Invoke(pszName, iSize);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeAnimationAutomove(Edict ent, float flTime)
    {
        var result = AnimationAutomove?.Invoke(ent, flTime);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeGetBonePosition(Edict ent, int iBone, ref Vector3f origin, ref Vector3f angles)
    {
        var result = GetBonePosition?.Invoke(ent, iBone, ref origin, ref angles);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal uint InvokeFunctionFromName(string pName)
    {
        var result = FunctionFromName?.Invoke(pName);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0u;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal string InvokeNameForFunction(uint function)
    {
        var result = NameForFunction?.Invoke(function);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeClientPrintf(Edict ent, PrintType ptype, string szMsg)
    {
        var result = ClientPrintf?.Invoke(ent, ptype, szMsg);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeServerPrint(string msg)
    {
        var result = ServerPrint?.Invoke(msg);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal string InvokeCmd_Args()
    {
        var result = Cmd_Args?.Invoke();
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal string InvokeCmd_Argv(int argc)
    {
        var result = Cmd_Argv?.Invoke(argc);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokeCmd_Argc()
    {
        var result = Cmd_Argc?.Invoke();
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeGetAttachment(Edict ent, int iAttachment, ref Vector3f origin, ref Vector3f angles)
    {
        var result = GetAttachment?.Invoke(ent, iAttachment, ref origin, ref angles);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeCRC32_Init(CRC32 pulCRC)
    {
        var result = CRC32_Init?.Invoke(pulCRC);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeCRC32_ProcessBuffer(CRC32 pulCRC, nint buffer, int len)
    {
        var result = CRC32_ProcessBuffer?.Invoke(pulCRC, buffer, len);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeCRC32_ProcessByte(CRC32 pulCRC, byte ch)
    {
        var result = CRC32_ProcessByte?.Invoke(pulCRC, ch);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal CRC32 InvokeCRC32_Final(CRC32 pulCRC)
    {
        var result = CRC32_Final?.Invoke(pulCRC);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return new CRC32(new NativeCRC32());
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokeRandomLong(int lLow, int lHigh)
    {
        var result = RandomLong?.Invoke(lLow, lHigh);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal float InvokeRandomFloat(float flLow, float flHigh)
    {
        var result = RandomFloat?.Invoke(flLow, flHigh);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0f;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeSetView(Edict ent, Edict viewent)
    {
        var result = SetView?.Invoke(ent, viewent);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal float InvokeTime()
    {
        var result = Time?.Invoke();
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0f;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeCrosshairAngle(Edict ent, float pitch, float yaw)
    {
        var result = CrosshairAngle?.Invoke(ent, pitch, yaw);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal nint InvokeLoadFileForMe(string filename, out int pLength)
    {
        if (LoadFileForMe == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            pLength = 0;
            return nint.Zero;
        }
        var result = LoadFileForMe.Invoke(filename, out pLength);
        MetaMod.MetaGlobals.Result = result.Item1;
        return result.Item2;
    }

    internal void InvokeFreeFile(nint buffer)
    {
        var result = FreeFile?.Invoke(buffer);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeEndSection(string szSectionName)
    {
        var result = EndSection?.Invoke(szSectionName);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal int InvokeCompareFileTime(string filename1, string filename2, out int iCompare)
    {
        if (CompareFileTime == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            iCompare = 0;
            return 0;
        }
        var result = CompareFileTime.Invoke(filename1, filename2, out iCompare);
        MetaMod.MetaGlobals.Result = result.Item1;
        return result.Item2;
    }

    internal string InvokeGetGameDir()
    {
        var result = GetGameDir?.Invoke();
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeCVar_RegisterVariable(CVar cvar)
    {
        var result = Cvar_RegisterVariable?.Invoke(cvar);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeFadeClientVolume(Edict ent, int fadePercent, int fadeOutSeconds, int holdTime, int fadeInSeconds)
    {
        var result = FadeClientVolume?.Invoke(ent, fadePercent, fadeOutSeconds, holdTime, fadeInSeconds);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeSetClientMaxspeed(Edict ent, float fNewMaxspeed)
    {
        var result = SetClientMaxspeed?.Invoke(ent, fNewMaxspeed);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal Edict InvokeCreateFakeClient(string netname)
    {
        var result = CreateFakeClient?.Invoke(netname);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return new Edict();
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeRunPlayerMove(Edict fakeClient, Vector3f viewangles, float forwardmove, float sidemove, float upmove, ushort buttons, byte impulse, byte msec)
    {
        var result = RunPlayerMove?.Invoke(fakeClient, viewangles, forwardmove, sidemove, upmove, buttons, impulse, msec);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal int InvokeNumberOfEntities()
    {
        var result = NumberOfEntities?.Invoke();
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal string InvokeGetInfoKeyBuffer(Edict ent)
    {
        var result = GetInfoKeyBuffer?.Invoke(ent);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal string InvokeInfoKeyValue(string infobuffer, string key)
    {
        var result = InfoKeyValue?.Invoke(infobuffer, key);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeSetKeyValue(ref string infobuffer, string key, string value)
    {
        var result = SetKeyValue?.Invoke(ref infobuffer, key, value);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeSetClientKeyValue(int clientIndex, string infobuffer, string key, string value)
    {
        var result = SetClientKeyValue?.Invoke(clientIndex, infobuffer, key, value);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal bool InvokeIsMapValid(string filename)
    {
        var result = IsMapValid?.Invoke(filename);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return false;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeStaticDecal(Vector3f origin, int decalIndex, int entityIndex, int modelIndex)
    {
        var result = StaticDecal?.Invoke(origin, decalIndex, entityIndex, modelIndex);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal int InvokePrecacheGeneric(string s)
    {
        var result = PrecacheGeneric?.Invoke(s);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokeGetPlayerUserId(Edict e)
    {
        var result = GetPlayerUserId?.Invoke(e);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeBuildSoundMsg(Edict entity, int channel, string sample, float volume, float attenuation, int fFlags, int pitch, int msg_dest, int msg_type, Vector3f pOrigin, Edict ed)
    {
        var result = BuildSoundMsg?.Invoke(entity, channel, sample, volume, attenuation, fFlags, pitch, msg_dest, msg_type, pOrigin, ed);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal bool InvokeIsDedicatedServer()
    {
        var result = IsDedicatedServer?.Invoke();
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return false;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal CVar? InvokeCVarGetPointer(string szVarName)
    {
        var result = CVarGetPointer?.Invoke(szVarName);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return null;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal uint InvokeGetPlayerWONId(Edict e)
    {
        var result = GetPlayerWONId?.Invoke(e);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0u;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeInfo_RemoveKey(ref string s, string key)
    {
        var result = Info_RemoveKey?.Invoke(ref s, key);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal string InvokeGetPhysicsKeyValue(Edict ent, string key)
    {
        var result = GetPhysicsKeyValue?.Invoke(ent, key);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeSetPhysicsKeyValue(Edict ent, string key, string value)
    {
        var result = SetPhysicsKeyValue?.Invoke(ent, key, value);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal string InvokeGetPhysicsInfoString(Edict ent)
    {
        var result = GetPhysicsInfoString?.Invoke(ent);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal ushort InvokePrecacheEvent(int type, string psz)
    {
        var result = PrecacheEvent?.Invoke(type, psz);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokePlaybackEvent(int flags, Edict ed, ushort eventindex, float delay, Vector3f origin, Vector3f angles, float fparam1, float fparam2, int iparam1, int iparam2, int bparam1, int bparam2)
    {
        var result = PlaybackEvent?.Invoke(flags, ed, eventindex, delay, origin, angles, fparam1, fparam2, iparam1, iparam2, bparam1, bparam2);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal string InvokeSetFatPVS(Vector3f org)
    {
        var result = SetFatPVS?.Invoke(org);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal string InvokeSetFatPAS(Vector3f org)
    {
        var result = SetFatPAS?.Invoke(org);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal bool InvokeCheckVisibility(Edict entity, nint pset)
    {
        var result = CheckVisibility?.Invoke(entity, pset);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return false;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeDeltaSetField(nint pFields, string fieldName)
    {
        var result = DeltaSetField?.Invoke(pFields, fieldName);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeDeltaUnsetField(nint pFields, string fieldName)
    {
        var result = DeltaUnsetField?.Invoke(pFields, fieldName);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeDeltaAddEncoder(string name, nint callback)
    {
        var result = DeltaAddEncoder?.Invoke(name, callback);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal int InvokeGetCurrentPlayer()
    {
        var result = GetCurrentPlayer?.Invoke();
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokeCanSkipPlayer(Edict player)
    {
        var result = CanSkipPlayer?.Invoke(player);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokeDeltaFindField(nint pFields, string fieldName)
    {
        var result = DeltaFindField?.Invoke(pFields, fieldName);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeDeltaSetFieldByIndex(nint pFields, int fieldNumber)
    {
        var result = DeltaSetFieldByIndex?.Invoke(pFields, fieldNumber);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeDeltaUnsetFieldByIndex(nint pFields, int fieldNumber)
    {
        var result = DeltaUnsetFieldByIndex?.Invoke(pFields, fieldNumber);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeSetGroupMask(int mask, int op)
    {
        var result = SetGroupMask?.Invoke(mask, op);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal int InvokeCreateInstancedBaseline(int classname, EntityState baseline)
    {
        var result = CreateInstancedBaseline?.Invoke(classname, baseline);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeCvar_DirectSet(CVar cvar, string value)
    {
        var result = Cvar_DirectSet?.Invoke(cvar, value);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeForceUnmodified(ForceType type, Vector3f mins, Vector3f maxs, string filename)
    {
        var result = ForceUnmodified?.Invoke(type, mins, maxs, filename);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeGetPlayerStats(Edict ent, out int ping, out int packet_loss)
    {
        var originalPing = ping = 0;
        var originalPacketLoss = packet_loss = 0;
        var result = GetPlayerStats?.Invoke(ent, out ping, out packet_loss);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeAddServerCommand(string cmd_name, ServerCommandDelegate function)
    {
        var result = AddServerCommand?.Invoke(cmd_name, function);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal bool InvokeVoice_GetClientListening(int iReceiver, int iSender)
    {
        var result = Voice_GetClientListening?.Invoke(iReceiver, iSender);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return false;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal bool InvokeVoice_SetClientListening(int iReceiver, int iSender, bool bListen)
    {
        var result = Voice_SetClientListening?.Invoke(iReceiver, iSender, bListen);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return false;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal string InvokeGetPlayerAuthId(Edict e)
    {
        var result = GetPlayerAuthId?.Invoke(e);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return string.Empty;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal nint InvokeSequenceGet(string fieldName, string entryName)
    {
        var result = SequenceGet?.Invoke(fieldName, entryName);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return nint.Zero;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal nint InvokeSequencePickSentence(string groupName, int pickMethod, out int picked)
    {
        picked = 0;
        var result = SequencePickSentence?.Invoke(groupName, pickMethod, out picked);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return nint.Zero;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokeGetFileSize(string filename)
    {
        var result = GetFileSize?.Invoke(filename);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal uint InvokeGetApproxWavePlayLen(string filepath)
    {
        var result = GetApproxWavePlayLen?.Invoke(filepath);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0u;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokeIsCareerMatch()
    {
        var result = IsCareerMatch?.Invoke();
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal int InvokeGetLocalizedStringLength(string label)
    {
        var result = GetLocalizedStringLength?.Invoke(label);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeRegisterTutorMessageShown(int mid)
    {
        var result = RegisterTutorMessageShown?.Invoke(mid);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal int InvokeGetTimesTutorMessageShown(int mid)
    {
        var result = GetTimesTutorMessageShown?.Invoke(mid);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }

    internal void InvokeProcessTutorMessageDecayBuffer(nint buffer, int bufferLength)
    {
        var result = ProcessTutorMessageDecayBuffer?.Invoke(buffer, bufferLength);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeConstructTutorMessageDecayBuffer(nint buffer, int bufferLength)
    {
        var result = ConstructTutorMessageDecayBuffer?.Invoke(buffer, bufferLength);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeResetTutorMessageDecayData()
    {
        var result = ResetTutorMessageDecayData?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeQueryClientCvarValue(Edict player, string cvarName)
    {
        var result = QueryClientCvarValue?.Invoke(player, cvarName);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal void InvokeQueryClientCvarValue2(Edict player, string cvarName, int requestID)
    {
        var result = QueryClientCvarValue2?.Invoke(player, cvarName, requestID);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }

    internal int InvokeEngCheckParm(string pchCmdLineToken, out string ppszValue)
    {
        ppszValue = string.Empty;
        var result = EngCheckParm?.Invoke(pchCmdLineToken, out ppszValue);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 0;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    #endregion

    #region Null Checker
    internal bool IsPrecacheModelNull => PrecacheModel == null;
    internal bool IsPrecacheSoundNull => PrecacheSound == null;
    internal bool IsSetModelNull => SetModel == null;
    internal bool IsModelIndexNull => ModelIndex == null;
    internal bool IsModelFramesNull => ModelFrames == null;
    internal bool IsSetSizeNull => SetSize == null;
    internal bool IsChangeLevelNull => ChangeLevel == null;
    internal bool IsGetSpawnParmsNull => GetSpawnParms == null;
    internal bool IsSaveSpawnParmsNull => SaveSpawnParms == null;
    internal bool IsVecToYawNull => VecToYaw == null;
    internal bool IsVecToAnglesNull => VecToAngles == null;
    internal bool IsMoveToOriginNull => MoveToOrigin == null;
    internal bool IsChangeYawNull => ChangeYaw == null;
    internal bool IsChangePitchNull => ChangePitch == null;
    internal bool IsFindEntityByStringNull => FindEntityByString == null;
    internal bool IsGetEntityIllumNull => GetEntityIllum == null;
    internal bool IsFindEntityInSphereNull => FindEntityInSphere == null;
    internal bool IsFindClientInPVSNull => FindClientInPVS == null;
    internal bool IsEntitiesInPVSNull => EntitiesInPVS == null;
    internal bool IsMakeVectorsNull => MakeVectors == null;
    internal bool IsAngleVectorsNull => AngleVectors == null;
    internal bool IsCreateEntityNull => CreateEntity == null;
    internal bool IsRemoveEntityNull => RemoveEntity == null;
    internal bool IsCreateNamedEntityNull => CreateNamedEntity == null;
    internal bool IsMakeStaticNull => MakeStatic == null;
    internal bool IsEntIsOnFloorNull => EntIsOnFloor == null;
    internal bool IsDropToFloorNull => DropToFloor == null;
    internal bool IsWalkMoveNull => WalkMove == null;
    internal bool IsSetOriginNull => SetOrigin == null;
    internal bool IsEmitSoundNull => EmitSound == null;
    internal bool IsEmitAmbientSoundNull => EmitAmbientSound == null;
    internal bool IsTraceLineNull => TraceLine == null;
    internal bool IsTraceTossNull => TraceToss == null;
    internal bool IsTraceMonsterHullNull => TraceMonsterHull == null;
    internal bool IsTraceHullNull => TraceHull == null;
    internal bool IsTraceModelNull => TraceModel == null;
    internal bool IsTraceTextureNull => TraceTexture == null;
    internal bool IsTraceSphereNull => TraceSphere == null;
    internal bool IsGetAimVectorNull => GetAimVector == null;
    internal bool IsServerCommandNull => ServerCommand == null;
    internal bool IsServerExecuteNull => ServerExecute == null;
    internal bool IsClientCommandNull => ClientCommand == null;
    internal bool IsParticleEffectNull => ParticleEffect == null;
    internal bool IsLightStyleNull => LightStyle == null;
    internal bool IsDecalIndexNull => DecalIndex == null;
    internal bool IsPointContentsNull => PointContents == null;
    internal bool IsMessageBeginNull => MessageBegin == null;
    internal bool IsMessageEndNull => MessageEnd == null;
    internal bool IsWriteByteNull => WriteByte == null;
    internal bool IsWriteCharNull => WriteChar == null;
    internal bool IsWriteShortNull => WriteShort == null;
    internal bool IsWriteLongNull => WriteLong == null;
    internal bool IsWriteAngleNull => WriteAngle == null;
    internal bool IsWriteCoordNull => WriteCoord == null;
    internal bool IsWriteStringNull => WriteString == null;
    internal bool IsWriteEntityNull => WriteEntity == null;
    internal bool IsCVarRegisterNull => CVarRegister == null;
    internal bool IsCVarGetFloatNull => CVarGetFloat == null;
    internal bool IsCVarGetStringNull => CVarGetString == null;
    internal bool IsCVarSetFloatNull => CVarSetFloat == null;
    internal bool IsCVarSetStringNull => CVarSetString == null;
    internal bool IsAlertMessageNull => AlertMessage == null;
    internal bool IsEngineFprintfNull => EngineFprintf == null;
    internal bool IsPvAllocEntPrivateDataNull => PvAllocEntPrivateData == null;
    internal bool IsPvEntPrivateDataNull => PvEntPrivateData == null;
    internal bool IsFreeEntPrivateDataNull => FreeEntPrivateData == null;
    internal bool IsSzFromIndexNull => SzFromIndex == null;
    internal bool IsAllocStringNull => AllocString == null;
    internal bool IsGetVarsOfEntNull => GetVarsOfEnt == null;
    internal bool IsPEntityOfEntOffsetNull => PEntityOfEntOffset == null;
    internal bool IsEntOffsetOfPEntityNull => EntOffsetOfPEntity == null;
    internal bool IsIndexOfEdictNull => IndexOfEdict == null;
    internal bool IsPEntityOfEntIndexNull => PEntityOfEntIndex == null;
    internal bool IsFindEntityByVarsNull => FindEntityByVars == null;
    internal bool IsGetModelPtrNull => GetModelPtr == null;
    internal bool IsRegUserMsgNull => RegUserMsg == null;
    internal bool IsAnimationAutomoveNull => AnimationAutomove == null;
    internal bool IsGetBonePositionNull => GetBonePosition == null;
    internal bool IsFunctionFromNameNull => FunctionFromName == null;
    internal bool IsNameForFunctionNull => NameForFunction == null;
    internal bool IsClientPrintfNull => ClientPrintf == null;
    internal bool IsServerPrintNull => ServerPrint == null;
    internal bool IsCmd_ArgsNull => Cmd_Args == null;
    internal bool IsCmd_ArgvNull => Cmd_Argv == null;
    internal bool IsCmd_ArgcNull => Cmd_Argc == null;
    internal bool IsGetAttachmentNull => GetAttachment == null;
    internal bool IsCRC32_InitNull => CRC32_Init == null;
    internal bool IsCRC32_ProcessBufferNull => CRC32_ProcessBuffer == null;
    internal bool IsCRC32_ProcessByteNull => CRC32_ProcessByte == null;
    internal bool IsCRC32_FinalNull => CRC32_Final == null;
    internal bool IsRandomLongNull => RandomLong == null;
    internal bool IsRandomFloatNull => RandomFloat == null;
    internal bool IsSetViewNull => SetView == null;
    internal bool IsTimeNull => Time == null;
    internal bool IsCrosshairAngleNull => CrosshairAngle == null;
    internal bool IsLoadFileForMeNull => LoadFileForMe == null;
    internal bool IsFreeFileNull => FreeFile == null;
    internal bool IsEndSectionNull => EndSection == null;
    internal bool IsCompareFileTimeNull => CompareFileTime == null;
    internal bool IsGetGameDirNull => GetGameDir == null;
    internal bool IsCvar_RegisterVariableNull => Cvar_RegisterVariable == null;
    internal bool IsFadeClientVolumeNull => FadeClientVolume == null;
    internal bool IsSetClientMaxspeedNull => SetClientMaxspeed == null;
    internal bool IsCreateFakeClientNull => CreateFakeClient == null;
    internal bool IsRunPlayerMoveNull => RunPlayerMove == null;
    internal bool IsNumberOfEntitiesNull => NumberOfEntities == null;
    internal bool IsGetInfoKeyBufferNull => GetInfoKeyBuffer == null;
    internal bool IsInfoKeyValueNull => InfoKeyValue == null;
    internal bool IsSetKeyValueNull => SetKeyValue == null;
    internal bool IsSetClientKeyValueNull => SetClientKeyValue == null;
    internal bool IsIsMapValidNull => IsMapValid == null;
    internal bool IsStaticDecalNull => StaticDecal == null;
    internal bool IsPrecacheGenericNull => PrecacheGeneric == null;
    internal bool IsGetPlayerUserIdNull => GetPlayerUserId == null;
    internal bool IsBuildSoundMsgNull => BuildSoundMsg == null;
    internal bool IsIsDedicatedServerNull => IsDedicatedServer == null;
    internal bool IsCVarGetPointerNull => CVarGetPointer == null;
    internal bool IsGetPlayerWONIdNull => GetPlayerWONId == null;
    internal bool IsInfo_RemoveKeyNull => Info_RemoveKey == null;
    internal bool IsGetPhysicsKeyValueNull => GetPhysicsKeyValue == null;
    internal bool IsSetPhysicsKeyValueNull => SetPhysicsKeyValue == null;
    internal bool IsGetPhysicsInfoStringNull => GetPhysicsInfoString == null;
    internal bool IsPrecacheEventNull => PrecacheEvent == null;
    internal bool IsPlaybackEventNull => PlaybackEvent == null;
    internal bool IsSetFatPVSNull => SetFatPVS == null;
    internal bool IsSetFatPASNull => SetFatPAS == null;
    internal bool IsCheckVisibilityNull => CheckVisibility == null;
    internal bool IsDeltaSetFieldNull => DeltaSetField == null;
    internal bool IsDeltaUnsetFieldNull => DeltaUnsetField == null;
    internal bool IsDeltaAddEncoderNull => DeltaAddEncoder == null;
    internal bool IsGetCurrentPlayerNull => GetCurrentPlayer == null;
    internal bool IsCanSkipPlayerNull => CanSkipPlayer == null;
    internal bool IsDeltaFindFieldNull => DeltaFindField == null;
    internal bool IsDeltaSetFieldByIndexNull => DeltaSetFieldByIndex == null;
    internal bool IsDeltaUnsetFieldByIndexNull => DeltaUnsetFieldByIndex == null;
    internal bool IsSetGroupMaskNull => SetGroupMask == null;
    internal bool IsCreateInstancedBaselineNull => CreateInstancedBaseline == null;
    internal bool IsCvar_DirectSetNull => Cvar_DirectSet == null;
    internal bool IsForceUnmodifiedNull => ForceUnmodified == null;
    internal bool IsGetPlayerStatsNull => GetPlayerStats == null;
    internal bool IsAddServerCommandNull => AddServerCommand == null;
    internal bool IsVoice_GetClientListeningNull => Voice_GetClientListening == null;
    internal bool IsVoice_SetClientListeningNull => Voice_SetClientListening == null;
    internal bool IsGetPlayerAuthIdNull => GetPlayerAuthId == null;
    internal bool IsSequenceGetNull => SequenceGet == null;
    internal bool IsSequencePickSentenceNull => SequencePickSentence == null;
    internal bool IsGetFileSizeNull => GetFileSize == null;
    internal bool IsGetApproxWavePlayLenNull => GetApproxWavePlayLen == null;
    internal bool IsIsCareerMatchNull => IsCareerMatch == null;
    internal bool IsGetLocalizedStringLengthNull => GetLocalizedStringLength == null;
    internal bool IsRegisterTutorMessageShownNull => RegisterTutorMessageShown == null;
    internal bool IsGetTimesTutorMessageShownNull => GetTimesTutorMessageShown == null;
    internal bool IsProcessTutorMessageDecayBufferNull => ProcessTutorMessageDecayBuffer == null;
    internal bool IsConstructTutorMessageDecayBufferNull => ConstructTutorMessageDecayBuffer == null;
    internal bool IsResetTutorMessageDecayDataNull => ResetTutorMessageDecayData == null;
    internal bool IsQueryClientCvarValueNull => QueryClientCvarValue == null;
    internal bool IsQueryClientCvarValue2Null => QueryClientCvarValue2 == null;
    internal bool IsEngCheckParmNull => EngCheckParm == null;
    #endregion
}

