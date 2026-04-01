using NuggetMod.Native.Common;
using System.Runtime.InteropServices;

namespace NuggetMod.Native.Engine;

/// <summary>
/// Native engine functions
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NativeEngineFuncs : INativeStruct
{
    internal NativePrecacheModelDelegate pfnPrecacheModel;
    internal NativePrecacheSoundDelegate pfnPrecacheSound;
    internal NativeSetModelDelegate pfnSetModel;
    internal NativeModelIndexDelegate pfnModelIndex;
    internal NativeModelFramesDelegate pfnModelFrames;
    internal NativeSetSizeDelegate pfnSetSize;
    internal NativeChangeLevelDelegate pfnChangeLevel;
    internal NativeGetSpawnParmsDelegate pfnGetSpawnParms;
    internal NativeSaveSpawnParmsDelegate pfnSaveSpawnParms;
    internal NativeVecToYawDelegate pfnVecToYaw;
    internal NativeVecToAnglesDelegate pfnVecToAngles;
    internal NativeMoveToOriginDelegate pfnMoveToOrigin;
    internal NativeChangeYawDelegate pfnChangeYaw;
    internal NativeChangePitchDelegate pfnChangePitch;
    internal NativeFindEntityByStringDelegate pfnFindEntityByString;
    internal NativeGetEntityIllumDelegate pfnGetEntityIllum;
    internal NativeFindEntityInSphereDelegate pfnFindEntityInSphere;
    internal NativeFindClientInPVSDelegate pfnFindClientInPVS;
    internal NativeEntitiesInPVSDelegate pfnEntitiesInPVS;
    internal NativeMakeVectorsDelegate pfnMakeVectors;
    internal NativeAngleVectorsDelegate pfnAngleVectors;
    internal NativeCreateEntityDelegate pfnCreateEntity;
    internal NativeRemoveEntityDelegate pfnRemoveEntity;
    internal NativeCreateNamedEntityDelegate pfnCreateNamedEntity;
    internal NativeMakeStaticDelegate pfnMakeStatic;
    internal NativeEntIsOnFloorDelegate pfnEntIsOnFloor;
    internal NativeDropToFloorDelegate pfnDropToFloor;
    internal NativeWalkMoveDelegate pfnWalkMove;
    internal NativeSetOriginDelegate pfnSetOrigin;
    internal NativeEmitSoundDelegate pfnEmitSound;
    internal NativeEmitAmbientSoundDelegate pfnEmitAmbientSound;
    internal NativeTraceLineDelegate pfnTraceLine;
    internal NativeTraceTossDelegate pfnTraceToss;
    internal NativeTraceMonsterHullDelegate pfnTraceMonsterHull;
    internal NativeTraceHullDelegate pfnTraceHull;
    internal NativeTraceModelDelegate pfnTraceModel;
    internal NativeTraceTextureDelegate pfnTraceTexture;
    internal NativeTraceSphereDelegate pfnTraceSphere;
    internal NativeGetAimVectorDelegate pfnGetAimVector;
    internal NativeServerCommandDelegate pfnServerCommand;
    internal NativeServerExecuteDelegate pfnServerExecute;
    internal NativeClientCommandDelegate pfnClientCommand;
    internal NativeParticleEffectDelegate pfnParticleEffect;
    internal NativeLightStyleDelegate pfnLightStyle;
    internal NativeDecalIndexDelegate pfnDecalIndex;
    internal NativePointContentsDelegate pfnPointContents;
    internal NativeMessageBeginDelegate pfnMessageBegin;
    internal NativeMessageEndDelegate pfnMessageEnd;
    internal NativeWriteByteDelegate pfnWriteByte;
    internal NativeWriteCharDelegate pfnWriteChar;
    internal NativeWriteShortDelegate pfnWriteShort;
    internal NativeWriteLongDelegate pfnWriteLong;
    internal NativeWriteAngleDelegate pfnWriteAngle;
    internal NativeWriteCoordDelegate pfnWriteCoord;
    internal NativeWriteStringDelegate pfnWriteString;
    internal NativeWriteEntityDelegate pfnWriteEntity;
    internal NativeCVarRegisterDelegate pfnCVarRegister;
    internal NativeCVarGetFloatDelegate pfnCVarGetFloat;
    internal NativeCVarGetStringDelegate pfnCVarGetString;
    internal NativeCVarSetFloatDelegate pfnCVarSetFloat;
    internal NativeCVarSetStringDelegate pfnCVarSetString;
    internal NativeAlertMessageDelegate pfnAlertMessage;
    internal NativeEngineFprintfDelegate pfnEngineFprintf;
    internal NativePvAllocEntPrivateDataDelegate pfnPvAllocEntPrivateData;
    internal NativePvEntPrivateDataDelegate pfnPvEntPrivateData;
    internal NativeFreeEntPrivateDataDelegate pfnFreeEntPrivateData;
    internal NativeSzFromIndexDelegate pfnSzFromIndex;
    internal NativeAllocStringDelegate pfnAllocString;
    internal NativeGetVarsOfEntDelegate pfnGetVarsOfEnt;
    internal NativePEntityOfEntOffsetDelegate pfnPEntityOfEntOffset;
    internal NativeEntOffsetOfPEntityDelegate pfnEntOffsetOfPEntity;
    internal NativeIndexOfEdictDelegate pfnIndexOfEdict;
    internal NativePEntityOfEntIndexDelegate pfnPEntityOfEntIndex;
    internal NativeFindEntityByVarsDelegate pfnFindEntityByVars;
    internal NativeGetModelPtrDelegate pfnGetModelPtr;
    internal NativeRegUserMsgDelegate pfnRegUserMsg;
    internal NativeAnimationAutomoveDelegate pfnAnimationAutomove;
    internal NativeGetBonePositionDelegate pfnGetBonePosition;
    internal NativeFunctionFromNameDelegate pfnFunctionFromName;
    internal NativeNameForFunctionDelegate pfnNameForFunction;
    internal NativeClientPrintfDelegate pfnClientPrintf;
    internal NativeServerPrintDelegate pfnServerPrint;
    internal NativeCmd_ArgsDelegate pfnCmd_Args;
    internal NativeCmd_ArgvDelegate pfnCmd_Argv;
    internal NativeCmd_ArgcDelegate pfnCmd_Argc;
    internal NativeGetAttachmentDelegate pfnGetAttachment;
    internal NativeCRC32_InitDelegate pfnCRC32_Init;
    internal NativeCRC32_ProcessBufferDelegate pfnCRC32_ProcessBuffer;
    internal NativeCRC32_ProcessByteDelegate pfnCRC32_ProcessByte;
    internal NativeCRC32_FinalDelegate pfnCRC32_Final;
    internal NativeRandomLongDelegate pfnRandomLong;
    internal NativeRandomFloatDelegate pfnRandomFloat;
    internal NativeSetViewDelegate pfnSetView;
    internal NativeTimeDelegate pfnTime;
    internal NativeCrosshairAngleDelegate pfnCrosshairAngle;
    internal NativeLoadFileForMeDelegate pfnLoadFileForMe;
    internal NativeFreeFileDelegate pfnFreeFile;
    internal NativeEndSectionDelegate pfnEndSection;
    internal NativeCompareFileTimeDelegate pfnCompareFileTime;
    internal NativeGetGameDirDelegate pfnGetGameDir;
    internal NativeCvar_RegisterVariableDelegate pfnCvar_RegisterVariable;
    internal NativeFadeClientVolumeDelegate pfnFadeClientVolume;
    internal NativeSetClientMaxspeedDelegate pfnSetClientMaxspeed;
    internal NativeCreateFakeClientDelegate pfnCreateFakeClient;
    internal NativeRunPlayerMoveDelegate pfnRunPlayerMove;
    internal NativeNumberOfEntitiesDelegate pfnNumberOfEntities;
    internal NativeGetInfoKeyBufferDelegate pfnGetInfoKeyBuffer;
    internal NativeInfoKeyValueDelegate pfnInfoKeyValue;
    internal NativeSetKeyValueDelegate pfnSetKeyValue;
    internal NativeSetClientKeyValueDelegate pfnSetClientKeyValue;
    internal NativeIsMapValidDelegate pfnIsMapValid;
    internal NativeStaticDecalDelegate pfnStaticDecal;
    internal NativePrecacheGenericDelegate pfnPrecacheGeneric;
    internal NativeGetPlayerUserIdDelegate pfnGetPlayerUserId;
    internal NativeBuildSoundMsgDelegate pfnBuildSoundMsg;
    internal NativeIsDedicatedServerDelegate pfnIsDedicatedServer;
    internal NativeCVarGetPointerDelegate pfnCVarGetPointer;
    internal NativeGetPlayerWONIdDelegate pfnGetPlayerWONId;
    internal NativeInfo_RemoveKeyDelegate pfnInfo_RemoveKey;
    internal NativeGetPhysicsKeyValueDelegate pfnGetPhysicsKeyValue;
    internal NativeSetPhysicsKeyValueDelegate pfnSetPhysicsKeyValue;
    internal NativeGetPhysicsInfoStringDelegate pfnGetPhysicsInfoString;
    internal NativePrecacheEventDelegate pfnPrecacheEvent;
    internal NativePlaybackEventDelegate pfnPlaybackEvent;
    internal NativeSetFatPVSDelegate pfnSetFatPVS;
    internal NativeSetFatPASDelegate pfnSetFatPAS;
    internal NativeCheckVisibilityDelegate pfnCheckVisibility;
    internal NativeDeltaSetFieldDelegate pfnDeltaSetField;
    internal NativeDeltaUnsetFieldDelegate pfnDeltaUnsetField;
    internal NativeDeltaAddEncoderDelegate pfnDeltaAddEncoder;
    internal NativeGetCurrentPlayerDelegate pfnGetCurrentPlayer;
    internal NativeCanSkipPlayerDelegate pfnCanSkipPlayer;
    internal NativeDeltaFindFieldDelegate pfnDeltaFindField;
    internal NativeDeltaSetFieldByIndexDelegate pfnDeltaSetFieldByIndex;
    internal NativeDeltaUnsetFieldByIndexDelegate pfnDeltaUnsetFieldByIndex;
    internal NativeSetGroupMaskDelegate pfnSetGroupMask;
    internal NativeCreateInstancedBaselineDelegate pfnCreateInstancedBaseline;
    internal NativeCvar_DirectSetDelegate pfnCvar_DirectSet;
    internal NativeForceUnmodifiedDelegate pfnForceUnmodified;
    internal NativeGetPlayerStatsDelegate pfnGetPlayerStats;
    internal NativeAddServerCommandDelegate pfnAddServerCommand;
    internal NativeVoice_GetClientListeningDelegate pfnVoice_GetClientListening;
    internal NativeVoice_SetClientListeningDelegate pfnVoice_SetClientListening;
    internal NativeGetPlayerAuthIdDelegate pfnGetPlayerAuthId;
    internal NativeSequenceGetDelegate pfnSequenceGet;
    internal NativeSequencePickSentenceDelegate pfnSequencePickSentence;
    internal NativeGetFileSizeDelegate pfnGetFileSize;
    internal NativeGetApproxWavePlayLenDelegate pfnGetApproxWavePlayLen;
    internal NativeIsCareerMatchDelegate pfnIsCareerMatch;
    internal NativeGetLocalizedStringLengthDelegate pfnGetLocalizedStringLength;
    internal NativeRegisterTutorMessageShownDelegate pfnRegisterTutorMessageShown;
    internal NativeGetTimesTutorMessageShownDelegate pfnGetTimesTutorMessageShown;
    internal NativeProcessTutorMessageDecayBufferDelegate pfnProcessTutorMessageDecayBuffer;
    internal NativeConstructTutorMessageDecayBufferDelegate pfnConstructTutorMessageDecayBuffer;
    internal NativeResetTutorMessageDecayDataDelegate pfnResetTutorMessageDecayData;
    internal NativeQueryClientCvarValueDelegate pfnQueryClientCvarValue;
    internal NativeQueryClientCvarValue2Delegate pfnQueryClientCvarValue2;
    internal NativeEngCheckParmDelegate pfnEngCheckParm;

    #region Delegate
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativePrecacheModelDelegate(nint s);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativePrecacheSoundDelegate(nint s);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSetModelDelegate(nint e, nint m);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeModelIndexDelegate(nint m);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeModelFramesDelegate(int modelIndex);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSetSizeDelegate(nint e, nint rgflMin, nint rgflMax);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeChangeLevelDelegate(nint s1, nint s2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeGetSpawnParmsDelegate(nint ent);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSaveSpawnParmsDelegate(nint ent);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate float NativeVecToYawDelegate(nint rgflVector);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeVecToAnglesDelegate(nint rgflVectorIn, nint rgflVectorOut);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeMoveToOriginDelegate(nint ent, nint pflGoal, float dist, int iMoveType);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeChangeYawDelegate(nint ent);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeChangePitchDelegate(nint ent);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeFindEntityByStringDelegate(nint pEdictStartSearchAfter, nint pszField, nint pszValue);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeGetEntityIllumDelegate(nint pEnt);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeFindEntityInSphereDelegate(nint pEdictStartSearchAfter, nint org, float rad);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeFindClientInPVSDelegate(nint pEdict);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeEntitiesInPVSDelegate(nint pplayer);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeMakeVectorsDelegate(nint rgflVector);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeAngleVectorsDelegate(nint rgflVector, nint forward, nint right, nint up);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeCreateEntityDelegate();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeRemoveEntityDelegate(nint e);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeCreateNamedEntityDelegate(int className);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeMakeStaticDelegate(nint ent);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeEntIsOnFloorDelegate(nint e);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeDropToFloorDelegate(nint e);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeWalkMoveDelegate(nint ent, float yaw, float dist, int iMode);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSetOriginDelegate(nint e, nint rgflOrigin);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeEmitSoundDelegate(nint entity, int channel, nint sample, float volume, float attenuation, int fFlags, int pitch);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeEmitAmbientSoundDelegate(nint entity, nint pos, nint samp, float vol, float attenuation, int fFlags, int pitch);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeTraceLineDelegate(nint v1, nint v2, int fNoMonsters, nint pentToSkip, nint ptr);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeTraceTossDelegate(nint pent, nint pentToIgnore, nint ptr);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeTraceMonsterHullDelegate(nint pEdict, nint v1, nint v2, int fNoMonsters, nint pentToSkip, nint ptr);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeTraceHullDelegate(nint v1, nint v2, int fNoMonsters, int hullNumber, nint pentToSkip, nint ptr);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeTraceModelDelegate(nint v1, nint v2, int hullNumber, nint pent, nint ptr);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeTraceTextureDelegate(nint pTextureEntity, nint v1, nint v2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeTraceSphereDelegate(nint v1, nint v2, int fNoMonsters, float radius, nint pentToSkip, nint ptr);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeGetAimVectorDelegate(nint ent, float speed, nint rgflReturn);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeServerCommandDelegate(nint str);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeServerExecuteDelegate();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeClientCommandDelegate(nint pEdict, nint szFmt);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeParticleEffectDelegate(nint org, nint dir, float color, float count);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeLightStyleDelegate(int style, nint val);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeDecalIndexDelegate(nint name);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativePointContentsDelegate(nint rgflVector);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeMessageBeginDelegate(int msg_dest, int msg_type, nint pOrigin, nint ed);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeMessageEndDelegate();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeWriteByteDelegate(int iValue);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeWriteCharDelegate(int iValue);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeWriteShortDelegate(int iValue);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeWriteLongDelegate(int iValue);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeWriteAngleDelegate(float flValue);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeWriteCoordDelegate(float flValue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeWriteStringDelegate(nint sz);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeWriteEntityDelegate(int iValue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCVarRegisterDelegate(nint pCvar);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate float NativeCVarGetFloatDelegate(nint szVarName);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeCVarGetStringDelegate(nint szVarName);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCVarSetFloatDelegate(nint szVarName, float flValue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCVarSetStringDelegate(nint szVarName, nint szValue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeAlertMessageDelegate(int atype, nint szFmt);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeEngineFprintfDelegate(nint pfile, nint szFmt);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativePvAllocEntPrivateDataDelegate(nint pEdict, int cb);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativePvEntPrivateDataDelegate(nint pEdict);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeFreeEntPrivateDataDelegate(nint pEdict);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeSzFromIndexDelegate(int iString);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeAllocStringDelegate(nint szValue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeGetVarsOfEntDelegate(nint pEdict);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativePEntityOfEntOffsetDelegate(int iEntOffset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeEntOffsetOfPEntityDelegate(nint pEdict);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeIndexOfEdictDelegate(nint pEdict);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativePEntityOfEntIndexDelegate(int iEntIndex);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeFindEntityByVarsDelegate(nint pvars);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeGetModelPtrDelegate(nint pEdict);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeRegUserMsgDelegate(nint pszName, int iSize);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeAnimationAutomoveDelegate(nint pEdict, float flTime);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeGetBonePositionDelegate(nint pEdict, int iBone, nint rgflOrigin, nint rgflAngles);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate uint NativeFunctionFromNameDelegate(nint pName);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeNameForFunctionDelegate(uint function);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeClientPrintfDelegate(nint pEdict, int ptype, nint szMsg);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeServerPrintDelegate(nint szMsg);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeCmd_ArgsDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeCmd_ArgvDelegate(int argc);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeCmd_ArgcDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeGetAttachmentDelegate(nint pEdict, int iAttachment, nint rgflOrigin, nint rgflAngles);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCRC32_InitDelegate(nint pulCRC);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCRC32_ProcessBufferDelegate(nint pulCRC, nint p, int len);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCRC32_ProcessByteDelegate(nint pulCRC, byte ch);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate NativeCRC32 NativeCRC32_FinalDelegate(NativeCRC32 pulCRC);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeRandomLongDelegate(int lLow, int lHigh);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate float NativeRandomFloatDelegate(float flLow, float flHigh);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSetViewDelegate(nint pClient, nint pViewent);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate float NativeTimeDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCrosshairAngleDelegate(nint pClient, float pitch, float yaw);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeLoadFileForMeDelegate(nint filename, nint pLength);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeFreeFileDelegate(nint buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeEndSectionDelegate(nint pszSectionName);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeCompareFileTimeDelegate(nint filename1, nint filename2, nint iCompare);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeGetGameDirDelegate(nint szGetGameDir);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCvar_RegisterVariableDelegate(nint variable);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeFadeClientVolumeDelegate(nint pEdict, int fadePercent, int fadeOutSeconds, int holdTime, int fadeInSeconds);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSetClientMaxspeedDelegate(nint pEdict, float fNewMaxspeed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeCreateFakeClientDelegate(nint netname);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeRunPlayerMoveDelegate(nint fakeclient, nint viewangles, float forwardmove, float sidemove, float upmove, ushort buttons, byte impulse, byte msec);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNumberOfEntitiesDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeGetInfoKeyBufferDelegate(nint e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeInfoKeyValueDelegate(nint infobuffer, nint key);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSetKeyValueDelegate(nint infobuffer, nint key, nint value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSetClientKeyValueDelegate(int clientIndex, nint infobuffer, nint key, nint value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeIsMapValidDelegate(nint filename);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeStaticDecalDelegate(nint origin, int decalIndex, int entityIndex, int modelIndex);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativePrecacheGenericDelegate(nint s);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeGetPlayerUserIdDelegate(nint e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeBuildSoundMsgDelegate(nint entity, int channel, nint sample, float volume, float attenuation, int fFlags, int pitch, int msg_dest, int msg_type, nint pOrigin, nint ed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeIsDedicatedServerDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeCVarGetPointerDelegate(nint szVarName);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate uint NativeGetPlayerWONIdDelegate(nint e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeInfo_RemoveKeyDelegate(nint s, nint key);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeGetPhysicsKeyValueDelegate(nint pClient, nint key);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSetPhysicsKeyValueDelegate(nint pClient, nint key, nint value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeGetPhysicsInfoStringDelegate(nint pClient);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate ushort NativePrecacheEventDelegate(int type, nint psz);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativePlaybackEventDelegate(int flags, nint pInvoker, ushort eventindex, float delay, nint origin, nint angles, float fparam1, float fparam2, int iparam1, int iparam2, int bparam1, int bparam2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeSetFatPVSDelegate(nint org);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeSetFatPASDelegate(nint org);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeCheckVisibilityDelegate(nint entity, nint pset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeDeltaSetFieldDelegate(nint pFields, nint fieldname);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeDeltaUnsetFieldDelegate(nint pFields, nint fieldname);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeDeltaAddEncoderDelegate(nint name, nint conditionalencode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeGetCurrentPlayerDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeCanSkipPlayerDelegate(nint player);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeDeltaFindFieldDelegate(nint pFields, nint fieldname);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeDeltaSetFieldByIndexDelegate(nint pFields, int fieldNumber);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeDeltaUnsetFieldByIndexDelegate(nint pFields, int fieldNumber);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSetGroupMaskDelegate(int mask, int op);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeCreateInstancedBaselineDelegate(int classname, nint baseline);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCvar_DirectSetDelegate(nint var, nint value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeForceUnmodifiedDelegate(int type, nint mins, nint maxs, nint filename);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeGetPlayerStatsDelegate(nint pClient, nint ping, nint packet_loss);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeAddServerCommandDelegate(nint cmd_name, nint function);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeVoice_GetClientListeningDelegate(int iReceiver, int iSender);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeVoice_SetClientListeningDelegate(int iReceiver, int iSender, int bListen);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeGetPlayerAuthIdDelegate(nint e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeSequenceGetDelegate(nint fileName, nint entryName);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeSequencePickSentenceDelegate(nint groupName, int pickMethod, nint picked);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeGetFileSizeDelegate(nint filename);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate uint NativeGetApproxWavePlayLenDelegate(nint filepath);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeIsCareerMatchDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeGetLocalizedStringLengthDelegate(nint label);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeRegisterTutorMessageShownDelegate(int mid);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeGetTimesTutorMessageShownDelegate(int mid);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeProcessTutorMessageDecayBufferDelegate(nint buffer, int bufferLength);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeConstructTutorMessageDecayBufferDelegate(nint buffer, int bufferLength);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeResetTutorMessageDecayDataDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeQueryClientCvarValueDelegate(nint player, nint cvarName);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeQueryClientCvarValue2Delegate(nint player, nint cvarName, int requestID);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeEngCheckParmDelegate(nint pchCmdLineToken, out nint pchNextVal);
    #endregion
}
