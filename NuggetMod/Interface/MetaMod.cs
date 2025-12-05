using NuggetMod.Interface.Events;
using NuggetMod.Interface.Events.NativeCaller;
using NuggetMod.Native.Engine;
using NuggetMod.Native.Game;
using NuggetMod.Native.Metamod;
using NuggetMod.Wrapper.Engine;
using NuggetMod.Wrapper.Metamod;
using System.Runtime.InteropServices;

namespace NuggetMod.Interface;

/// <summary>
/// Main MetaMod interface class for plugin integration
/// </summary>
public class MetaMod
{
    #region 内部函数
    private static DLLEvents? _entityApi = null;
    private static DLLEvents? _entityApi_Post = null;
    private static DLLEvents? _entityApi2 = null;
    private static DLLEvents? _entityApi2_Post = null;
    private static NewDLLEvents? _newDllFunctions = null;
    private static NewDLLEvents? _newDLLFunctions_Post = null;
    private static EngineEvents? _engineFunctions = null;
    private static EngineEvents? _engineFunctions_Post = null;
    private static BlendingInterfaceEvent? _blendingInterface = null;
    private static BlendingInterfaceEvent? _blendingInterface_Post = null;

    // 将托管 delegate 转为原生函数指针并按字段顺序写入到非托管结构内存中。
    // 注意：字段顺序必须与 NativeDllFuncs 的定义完全一致（指针大小顺序）。
    private static unsafe void LinkNativeDLLEvents(nint pFunctionTable, NativeDllFuncs source)
    {
        if (pFunctionTable == 0)
            throw new ArgumentNullException(nameof(pFunctionTable), "pFunctionTable is NULL in LinkNativeDLLEvents.");

        nint* dest = (nint*)pFunctionTable;
        int i = 0;

        dest[i++] = source.pfnGameInit == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGameInit);
        dest[i++] = source.pfnSpawn == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSpawn);
        dest[i++] = source.pfnThink == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnThink);
        dest[i++] = source.pfnUse == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnUse);
        dest[i++] = source.pfnTouch == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnTouch);
        dest[i++] = source.pfnBlocked == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnBlocked);
        dest[i++] = source.pfnKeyValue == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnKeyValue);
        dest[i++] = source.pfnSave == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSave);
        dest[i++] = source.pfnRestore == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnRestore);
        dest[i++] = source.pfnSetAbsBox == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetAbsBox);
        dest[i++] = source.pfnSaveWriteFields == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSaveWriteFields);
        dest[i++] = source.pfnSaveReadFields == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSaveReadFields);
        dest[i++] = source.pfnSaveGlobalState == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSaveGlobalState);
        dest[i++] = source.pfnRestoreGlobalState == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnRestoreGlobalState);
        dest[i++] = source.pfnResetGlobalState == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnResetGlobalState);
        dest[i++] = source.pfnClientConnect == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnClientConnect);
        dest[i++] = source.pfnClientDisconnect == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnClientDisconnect);
        dest[i++] = source.pfnClientKill == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnClientKill);
        dest[i++] = source.pfnClientPutInServer == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnClientPutInServer);
        dest[i++] = source.pfnClientCommand == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnClientCommand);
        dest[i++] = source.pfnClientUserInfoChanged == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnClientUserInfoChanged);
        dest[i++] = source.pfnServerActivate == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnServerActivate);
        dest[i++] = source.pfnServerDeactivate == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnServerDeactivate);
        dest[i++] = source.pfnPlayerPreThink == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPlayerPreThink);
        dest[i++] = source.pfnPlayerPostThink == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPlayerPostThink);
        dest[i++] = source.pfnStartFrame == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnStartFrame);
        dest[i++] = source.pfnParmsNewLevel == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnParmsNewLevel);
        dest[i++] = source.pfnParmsChangeLevel == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnParmsChangeLevel);
        dest[i++] = source.pfnGetGameDescription == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetGameDescription);
        dest[i++] = source.pfnPlayerCustomization == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPlayerCustomization);
        dest[i++] = source.pfnSpectatorConnect == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSpectatorConnect);
        dest[i++] = source.pfnSpectatorDisconnect == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSpectatorDisconnect);
        dest[i++] = source.pfnSpectatorThink == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSpectatorThink);
        dest[i++] = source.pfnSysError == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSysError);
        dest[i++] = source.pfnPMMove == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPMMove);
        dest[i++] = source.pfnPMInit == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPMInit);
        dest[i++] = source.pfnPMFindTextureType == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPMFindTextureType);
        dest[i++] = source.pfnSetupVisibility == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetupVisibility);
        dest[i++] = source.pfnUpdateClientData == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnUpdateClientData);
        dest[i++] = source.pfnAddToFullPack == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnAddToFullPack);
        dest[i++] = source.pfnCreateBaseline == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCreateBaseline);
        dest[i++] = source.pfnRegisterEncoders == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnRegisterEncoders);
        dest[i++] = source.pfnGetWeaponData == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetWeaponData);
        dest[i++] = source.pfnCmdStart == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCmdStart);
        dest[i++] = source.pfnCmdEnd == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCmdEnd);
        dest[i++] = source.pfnConnectionlessPacket == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnConnectionlessPacket);
        dest[i++] = source.pfnGetHullBounds == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetHullBounds);
        dest[i++] = source.pfnCreateInstancedBaselines == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCreateInstancedBaselines);
        dest[i++] = source.pfnInconsistentFile == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnInconsistentFile);
        dest[i++] = source.pfnAllowLagCompensation == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnAllowLagCompensation);
    }
    private static unsafe void LinkNativeNewDLLEvents(nint pFunctionTable, NativeNewDllFuncs source)
    {
        if (pFunctionTable == 0)
            throw new ArgumentNullException(nameof(pFunctionTable), "pFunctionTable is NULL in LinkNativeNewDLLEvents.");

        nint* dest = (nint*)pFunctionTable;
        int i = 0;

        dest[i++] = source.pfnOnFreeEntPrivateData == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnOnFreeEntPrivateData);
        dest[i++] = source.pfnGameShutdown == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGameShutdown);
        dest[i++] = source.pfnShouldCollide == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnShouldCollide);
        dest[i++] = source.pfnCvarValue == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCvarValue);
        dest[i++] = source.pfnCvarValue2 == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCvarValue2);
    }
    private static unsafe void LinkNativeEngineEvents(nint pFunctionTable, NativeEngineFuncs source)
    {
        if (pFunctionTable == 0)
            throw new ArgumentNullException(nameof(pFunctionTable), "pFunctionTable is NULL in LinkNativeEngineEvents.");
        nint* dest = (nint*)pFunctionTable;
        int i = 0;

        dest[i++] = source.pfnPrecacheModel == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPrecacheModel);
        dest[i++] = source.pfnPrecacheSound == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPrecacheSound);
        dest[i++] = source.pfnSetModel == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetModel);
        dest[i++] = source.pfnModelIndex == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnModelIndex);
        dest[i++] = source.pfnModelFrames == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnModelFrames);
        dest[i++] = source.pfnSetSize == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetSize);
        dest[i++] = source.pfnChangeLevel == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnChangeLevel);
        dest[i++] = source.pfnGetSpawnParms == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetSpawnParms);
        dest[i++] = source.pfnSaveSpawnParms == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSaveSpawnParms);
        dest[i++] = source.pfnVecToYaw == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnVecToYaw);
        dest[i++] = source.pfnVecToAngles == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnVecToAngles);
        dest[i++] = source.pfnMoveToOrigin == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnMoveToOrigin);
        dest[i++] = source.pfnChangeYaw == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnChangeYaw);
        dest[i++] = source.pfnChangePitch == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnChangePitch);
        dest[i++] = source.pfnFindEntityByString == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnFindEntityByString);
        dest[i++] = source.pfnGetEntityIllum == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetEntityIllum);
        dest[i++] = source.pfnFindEntityInSphere == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnFindEntityInSphere);
        dest[i++] = source.pfnFindClientInPVS == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnFindClientInPVS);
        dest[i++] = source.pfnEntitiesInPVS == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnEntitiesInPVS);
        dest[i++] = source.pfnMakeVectors == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnMakeVectors);
        dest[i++] = source.pfnAngleVectors == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnAngleVectors);
        dest[i++] = source.pfnCreateEntity == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCreateEntity);
        dest[i++] = source.pfnRemoveEntity == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnRemoveEntity);
        dest[i++] = source.pfnCreateNamedEntity == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCreateNamedEntity);
        dest[i++] = source.pfnMakeStatic == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnMakeStatic);
        dest[i++] = source.pfnEntIsOnFloor == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnEntIsOnFloor);
        dest[i++] = source.pfnDropToFloor == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnDropToFloor);
        dest[i++] = source.pfnWalkMove == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnWalkMove);
        dest[i++] = source.pfnSetOrigin == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetOrigin);
        dest[i++] = source.pfnEmitSound == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnEmitSound);
        dest[i++] = source.pfnEmitAmbientSound == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnEmitAmbientSound);
        dest[i++] = source.pfnTraceLine == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnTraceLine);
        dest[i++] = source.pfnTraceToss == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnTraceToss);
        dest[i++] = source.pfnTraceMonsterHull == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnTraceMonsterHull);
        dest[i++] = source.pfnTraceHull == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnTraceHull);
        dest[i++] = source.pfnTraceModel == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnTraceModel);
        dest[i++] = source.pfnTraceTexture == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnTraceTexture);
        dest[i++] = source.pfnTraceSphere == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnTraceSphere);
        dest[i++] = source.pfnGetAimVector == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetAimVector);
        dest[i++] = source.pfnServerCommand == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnServerCommand);
        dest[i++] = source.pfnServerExecute == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnServerExecute);
        dest[i++] = source.pfnClientCommand == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnClientCommand);
        dest[i++] = source.pfnParticleEffect == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnParticleEffect);
        dest[i++] = source.pfnLightStyle == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnLightStyle);
        dest[i++] = source.pfnDecalIndex == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnDecalIndex);
        dest[i++] = source.pfnPointContents == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPointContents);
        dest[i++] = source.pfnMessageBegin == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnMessageBegin);
        dest[i++] = source.pfnMessageEnd == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnMessageEnd);
        dest[i++] = source.pfnWriteByte == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnWriteByte);
        dest[i++] = source.pfnWriteChar == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnWriteChar);
        dest[i++] = source.pfnWriteShort == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnWriteShort);
        dest[i++] = source.pfnWriteLong == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnWriteLong);
        dest[i++] = source.pfnWriteAngle == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnWriteAngle);
        dest[i++] = source.pfnWriteCoord == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnWriteCoord);
        dest[i++] = source.pfnWriteString == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnWriteString);
        dest[i++] = source.pfnWriteEntity == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnWriteEntity);
        dest[i++] = source.pfnCVarRegister == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCVarRegister);
        dest[i++] = source.pfnCVarGetFloat == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCVarGetFloat);
        dest[i++] = source.pfnCVarGetString == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCVarGetString);
        dest[i++] = source.pfnCVarSetFloat == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCVarSetFloat);
        dest[i++] = source.pfnCVarSetString == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCVarSetString);
        dest[i++] = source.pfnAlertMessage == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnAlertMessage);
        dest[i++] = source.pfnEngineFprintf == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnEngineFprintf);
        dest[i++] = source.pfnPvAllocEntPrivateData == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPvAllocEntPrivateData);
        dest[i++] = source.pfnPvEntPrivateData == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPvEntPrivateData);
        dest[i++] = source.pfnFreeEntPrivateData == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnFreeEntPrivateData);
        dest[i++] = source.pfnSzFromIndex == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSzFromIndex);
        dest[i++] = source.pfnAllocString == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnAllocString);
        dest[i++] = source.pfnGetVarsOfEnt == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetVarsOfEnt);
        dest[i++] = source.pfnPEntityOfEntOffset == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPEntityOfEntOffset);
        dest[i++] = source.pfnEntOffsetOfPEntity == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnEntOffsetOfPEntity);
        dest[i++] = source.pfnIndexOfEdict == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnIndexOfEdict);
        dest[i++] = source.pfnPEntityOfEntIndex == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPEntityOfEntIndex);
        dest[i++] = source.pfnFindEntityByVars == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnFindEntityByVars);
        dest[i++] = source.pfnGetModelPtr == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetModelPtr);
        dest[i++] = source.pfnRegUserMsg == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnRegUserMsg);
        dest[i++] = source.pfnAnimationAutomove == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnAnimationAutomove);
        dest[i++] = source.pfnGetBonePosition == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetBonePosition);
        dest[i++] = source.pfnFunctionFromName == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnFunctionFromName);
        dest[i++] = source.pfnNameForFunction == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnNameForFunction);
        dest[i++] = source.pfnClientPrintf == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnClientPrintf);
        dest[i++] = source.pfnServerPrint == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnServerPrint);
        dest[i++] = source.pfnCmd_Args == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCmd_Args);
        dest[i++] = source.pfnCmd_Argv == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCmd_Argv);
        dest[i++] = source.pfnCmd_Argc == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCmd_Argc);
        dest[i++] = source.pfnGetAttachment == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetAttachment);
        dest[i++] = source.pfnCRC32_Init == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCRC32_Init);
        dest[i++] = source.pfnCRC32_ProcessBuffer == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCRC32_ProcessBuffer);
        dest[i++] = source.pfnCRC32_ProcessByte == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCRC32_ProcessByte);
        dest[i++] = source.pfnCRC32_Final == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCRC32_Final);
        dest[i++] = source.pfnRandomLong == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnRandomLong);
        dest[i++] = source.pfnRandomFloat == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnRandomFloat);
        dest[i++] = source.pfnSetView == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetView);
        dest[i++] = source.pfnTime == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnTime);
        dest[i++] = source.pfnCrosshairAngle == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCrosshairAngle);
        dest[i++] = source.pfnLoadFileForMe == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnLoadFileForMe);
        dest[i++] = source.pfnFreeFile == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnFreeFile);
        dest[i++] = source.pfnEndSection == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnEndSection);
        dest[i++] = source.pfnCompareFileTime == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCompareFileTime);
        dest[i++] = source.pfnGetGameDir == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetGameDir);
        dest[i++] = source.pfnCvar_RegisterVariable == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCvar_RegisterVariable);
        dest[i++] = source.pfnFadeClientVolume == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnFadeClientVolume);
        dest[i++] = source.pfnSetClientMaxspeed == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetClientMaxspeed);
        dest[i++] = source.pfnCreateFakeClient == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCreateFakeClient);
        dest[i++] = source.pfnRunPlayerMove == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnRunPlayerMove);
        dest[i++] = source.pfnNumberOfEntities == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnNumberOfEntities);
        dest[i++] = source.pfnGetInfoKeyBuffer == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetInfoKeyBuffer);
        dest[i++] = source.pfnInfoKeyValue == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnInfoKeyValue);
        dest[i++] = source.pfnSetKeyValue == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetKeyValue);
        dest[i++] = source.pfnSetClientKeyValue == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetClientKeyValue);
        dest[i++] = source.pfnIsMapValid == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnIsMapValid);
        dest[i++] = source.pfnStaticDecal == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnStaticDecal);
        dest[i++] = source.pfnPrecacheGeneric == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPrecacheGeneric);
        dest[i++] = source.pfnGetPlayerUserId == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetPlayerUserId);
        dest[i++] = source.pfnBuildSoundMsg == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnBuildSoundMsg);
        dest[i++] = source.pfnIsDedicatedServer == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnIsDedicatedServer);
        dest[i++] = source.pfnCVarGetPointer == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCVarGetPointer);
        dest[i++] = source.pfnGetPlayerWONId == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetPlayerWONId);
        dest[i++] = source.pfnInfo_RemoveKey == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnInfo_RemoveKey);
        dest[i++] = source.pfnGetPhysicsKeyValue == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetPhysicsKeyValue);
        dest[i++] = source.pfnSetPhysicsKeyValue == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetPhysicsKeyValue);
        dest[i++] = source.pfnGetPhysicsInfoString == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetPhysicsInfoString);
        dest[i++] = source.pfnPrecacheEvent == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPrecacheEvent);
        dest[i++] = source.pfnPlaybackEvent == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnPlaybackEvent);
        dest[i++] = source.pfnSetFatPVS == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetFatPVS);
        dest[i++] = source.pfnSetFatPAS == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetFatPAS);
        dest[i++] = source.pfnCheckVisibility == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCheckVisibility);
        dest[i++] = source.pfnDeltaSetField == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnDeltaSetField);
        dest[i++] = source.pfnDeltaUnsetField == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnDeltaUnsetField);
        dest[i++] = source.pfnDeltaAddEncoder == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnDeltaAddEncoder);
        dest[i++] = source.pfnGetCurrentPlayer == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetCurrentPlayer);
        dest[i++] = source.pfnCanSkipPlayer == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCanSkipPlayer);
        dest[i++] = source.pfnDeltaFindField == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnDeltaFindField);
        dest[i++] = source.pfnDeltaSetFieldByIndex == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnDeltaSetFieldByIndex);
        dest[i++] = source.pfnDeltaUnsetFieldByIndex == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnDeltaUnsetFieldByIndex);
        dest[i++] = source.pfnSetGroupMask == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSetGroupMask);
        dest[i++] = source.pfnCreateInstancedBaseline == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCreateInstancedBaseline);
        dest[i++] = source.pfnCvar_DirectSet == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnCvar_DirectSet);
        dest[i++] = source.pfnForceUnmodified == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnForceUnmodified);
        dest[i++] = source.pfnGetPlayerStats == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetPlayerStats);
        dest[i++] = source.pfnAddServerCommand == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnAddServerCommand);
        dest[i++] = source.pfnVoice_GetClientListening == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnVoice_GetClientListening);
        dest[i++] = source.pfnVoice_SetClientListening == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnVoice_SetClientListening);
        dest[i++] = source.pfnGetPlayerAuthId == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetPlayerAuthId);
        dest[i++] = source.pfnSequenceGet == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSequenceGet);
        dest[i++] = source.pfnSequencePickSentence == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSequencePickSentence);
        dest[i++] = source.pfnGetFileSize == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetFileSize);
        dest[i++] = source.pfnGetApproxWavePlayLen == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetApproxWavePlayLen);
        dest[i++] = source.pfnIsCareerMatch == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnIsCareerMatch);
        dest[i++] = source.pfnGetLocalizedStringLength == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetLocalizedStringLength);
        dest[i++] = source.pfnRegisterTutorMessageShown == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnRegisterTutorMessageShown);
        dest[i++] = source.pfnGetTimesTutorMessageShown == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnGetTimesTutorMessageShown);
        dest[i++] = source.pfnProcessTutorMessageDecayBuffer == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnProcessTutorMessageDecayBuffer);
        dest[i++] = source.pfnConstructTutorMessageDecayBuffer == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnConstructTutorMessageDecayBuffer);
        dest[i++] = source.pfnResetTutorMessageDecayData == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnResetTutorMessageDecayData);
        dest[i++] = source.pfnQueryClientCvarValue == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnQueryClientCvarValue);
        dest[i++] = source.pfnQueryClientCvarValue2 == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnQueryClientCvarValue2);
        dest[i++] = source.pfnEngCheckParm == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnEngCheckParm);
    }
    private static unsafe void LinkNativeBlendEvents(nint pFunctionTable, NativeServerBlendInterface source)
    {
        if (pFunctionTable == 0)
            throw new ArgumentNullException(nameof(pFunctionTable), "pFunctionTable is NULL in LinkNativeBlendEvents.");
        nint* dest = (nint*)pFunctionTable;
        int i = 0;
        dest[i++] = source.version;
        dest[i++] = source.pfnSV_StudioSetupBones == null ? nint.Zero : Marshal.GetFunctionPointerForDelegate(source.pfnSV_StudioSetupBones);
    }

    internal static NativeGetEntityApiDelegate GetEntityApiWrapper = (pFunctionTable, interfaceVersion) =>
    {
        int res = 0;
        unsafe
        {
            if (_entityApi == null)
                throw new NullReferenceException("DLLEvents instance is null in GetEntityApiWrapper.");
            EntityAPINativeCaller._dllEvents = _entityApi;
            LinkNativeDLLEvents(pFunctionTable, EntityAPINativeCaller.GetDLLFunctionsNative());
            res = 1;
        }
        return res;
    };
    internal static NativeGetEntityApiDelegate GetEntityApiPostWrapper = (pFunctionTable, interfaceVersion) =>
    {
        int res = 0;
        unsafe
        {
            if (_entityApi_Post == null)
                throw new NullReferenceException("DLLEvents instance is null in GetEntityApiPostWrapper.");
            EntityAPIPostNativeCaller._dllEvents = _entityApi_Post;
            LinkNativeDLLEvents(pFunctionTable, EntityAPIPostNativeCaller.GetDLLFunctionsNative());
            res = 1;
        }
        return res;
    };
    internal static NativeGetEntityApi2Delegate GetEntityApi2Wrapper = (pFunctionTable, interfaceVersion) =>
    {
        int res = 0;
        unsafe
        {
            if (_entityApi2 == null)
                throw new NullReferenceException("DLLEvents instance is null in GetEntityApi2Wrapper.");
            EntityAPI2NativeCaller._dllEvents = _entityApi2;
            LinkNativeDLLEvents(pFunctionTable, EntityAPI2NativeCaller.GetDLLFunctionsNative());
            res = 1;
        }
        return res;
    };
    internal static NativeGetEntityApi2Delegate GetEntityApi2PostWrapper = (pFunctionTable, interfaceVersion) =>
    {
        int res = 0;
        unsafe
        {
            if (_entityApi2_Post == null)
                throw new NullReferenceException("DLLEvents instance is null in GetEntityApi2PostWrapper.");
            EntityAPI2PostNativeCaller._dllEvents = _entityApi2_Post;
            LinkNativeDLLEvents(pFunctionTable, EntityAPI2PostNativeCaller.GetDLLFunctionsNative());
            res = 1;
        }
        return res;
    };
    internal static NativeGetNewDllFunctionsDelegate GetNewDllFunctionsWrapper = (pFunctionTable, interfaceVersion) =>
    {
        int res = 0;
        unsafe
        {
            if (_newDllFunctions == null)
                throw new NullReferenceException("NewDLLEvents instance is null in GetNewDllFunctionsWrapper.");
            NewDLLFunctionsNativeCaller._newEvents = _newDllFunctions;
            LinkNativeNewDLLEvents(pFunctionTable, NewDLLFunctionsNativeCaller.GetNewDLLFunctionsNative());
            res = 1;
        }
        return res;
    };
    internal static NativeGetNewDllFunctionsDelegate GetNewDllFunctions_PostWrapper = (pFunctionTable, interfaceVersion) =>
    {
        int res = 0;
        unsafe
        {
            if (_newDLLFunctions_Post == null)
                throw new NullReferenceException("NewDLLEvents instance is null in GetNewDllFunctions_PostWrapper.");
            NewDLLFunctionsPostNativeCaller._newEvents = _newDLLFunctions_Post;
            LinkNativeNewDLLEvents(pFunctionTable, NewDLLFunctionsPostNativeCaller.GetNewDLLFunctionsNative());
            res = 1;
        }
        return res;
    };
    internal static NativeGetEngineFunctionsDelegate GetEngineFunctions = (pFunctionTable, interfaceVersion) =>
    {
        int res = 0;
        unsafe
        {
            if (_engineFunctions == null)
                throw new NullReferenceException("EngineEvents instance is null in GetEngineFunctions.");
            EngineNativeCaller._engineEvents = _engineFunctions;
            LinkNativeEngineEvents(pFunctionTable, EngineNativeCaller.GetEngineFunctionsNative());
            res = 1;
        }
        return res;
    };
    internal static NativeGetEngineFunctionsDelegate GetEngineFunctions_Post = (pFunctionTable, interfaceVersion) =>
    {
        int res = 0;
        unsafe
        {
            if (_engineFunctions_Post == null)
                throw new NullReferenceException("EngineEvents instance is null in GetEngineFunctions_Post.");
            EnginePostNativeCaller._engineEvents = _engineFunctions_Post;
            LinkNativeEngineEvents(pFunctionTable, EnginePostNativeCaller.GetEngineFunctionsNative());
            res = 1;
        }
        return res;
    };
    internal static NativeGetStudioBlendingInterfaceDelegate GetBlendingInterfaceDelegate = (pFunctionTable, interfaceVersion) =>
    {
        int res = 0;
        unsafe
        {
            if (_blendingInterface == null)
                throw new NullReferenceException("BlendingEvent instance is null in GetStudioBlendingInterface.");
            BlendingInterfaceNativeCaller._Events = _blendingInterface;
            LinkNativeBlendEvents(pFunctionTable, BlendingInterfaceNativeCaller.GetBlendingInterfaceNative());
            res = 1;
        }
        return res;
    };
    internal static NativeGetStudioBlendingInterfaceDelegate GetBlendingInterface_PostDelegate = (pFunctionTable, interfaceVersion) =>
    {
        int res = 0;
        unsafe
        {
            if (_blendingInterface_Post == null)
                throw new NullReferenceException("BlendingEvent instance is null in GetStudioBlendingInterface_Post.");
            BlendingInterfacePostNativeCaller._Events = _blendingInterface_Post;
            LinkNativeBlendEvents(pFunctionTable, BlendingInterfacePostNativeCaller.GetBlendingInterfaceNative());
            res = 1;
        }
        return res;
    };


    internal static NativeMetaFuncs? _native = null;

    internal static NativeMetaFuncs GetNative()
    {
        _native ??= new()
        {
            pfnGetEntityAPI = _entityApi == null ? null : GetEntityApiWrapper,
            pfnGetEntityAPI_Post = _entityApi_Post == null ? null : GetEntityApiPostWrapper,
            pfnGetEntityAPI2 = _entityApi2 == null ? null : GetEntityApi2Wrapper,
            pfnGetEntityAPI2_Post = _entityApi2_Post == null ? null : GetEntityApi2PostWrapper,
            pfnGetNewDLLFunctions = _newDllFunctions == null ? null : GetNewDllFunctionsWrapper,
            pfnGetNewDLLFunctions_Post = _newDLLFunctions_Post == null ? null : GetNewDllFunctions_PostWrapper,
            pfnGetEngineFunctions = _engineFunctions == null ? null : GetEngineFunctions,
            pfnGetEngineFunctions_Post = _engineFunctions_Post == null ? null : GetEngineFunctions_Post,
            pfnGetStudioBlendingInterface = _blendingInterface == null ? null : GetBlendingInterfaceDelegate,
            pfnGetStudioBlendingInterface_Post = _blendingInterface_Post == null ? null : GetBlendingInterface_PostDelegate
        };
        return (NativeMetaFuncs)_native;
    }
    #endregion

    #region 对外函数
    /// <summary>
    /// Unified event registration interface
    /// </summary>
    /// <param name="entityApi">Entity API events</param>
    /// <param name="entityApiPost">Entity API post events</param>
    /// <param name="entityApi2">Entity API2 events</param>
    /// <param name="entityApi2Post">Entity API2 post events</param>
    /// <param name="newDllFunctions">New DLL function events</param>
    /// <param name="newDllFunctionsPost">New DLL function post events</param>
    /// <param name="engineFunctions">Engine function events</param>
    /// <param name="engineFunctionsPost">Engine function post events</param>
    /// <param name="blendingInterface">Blending interface events</param>
    /// <param name="blendingInterfacePost">Blending interface post events</param>
    public static void RegisterEvents(
        DLLEvents? entityApi = null,
        DLLEvents? entityApiPost = null,
        DLLEvents? entityApi2 = null,
        DLLEvents? entityApi2Post = null,
        NewDLLEvents? newDllFunctions = null,
        NewDLLEvents? newDllFunctionsPost = null,
        EngineEvents? engineFunctions = null,
        EngineEvents? engineFunctionsPost = null,
        BlendingInterfaceEvent? blendingInterface = null,
        BlendingInterfaceEvent? blendingInterfacePost = null)
    {
        _entityApi = entityApi;
        _entityApi_Post = entityApiPost;
        _entityApi2 = entityApi2;
        _entityApi2_Post = entityApi2Post;
        _newDllFunctions = newDllFunctions;
        _newDLLFunctions_Post = newDllFunctionsPost;
        _engineFunctions = engineFunctions;
        _engineFunctions_Post = engineFunctionsPost;
        _blendingInterface = blendingInterface;
        _blendingInterface_Post = blendingInterfacePost;
    }
    #endregion

    #region 对外变量
    /// <summary>
    /// Gets the engine functions interface
    /// </summary>
    public static EngineFuncs EngineFuncs => _engineFuncs ?? throw new NullReferenceException("EngineFuncs is NULL");

    /// <summary>
    /// Gets the global variables
    /// </summary>
    public static GlobalVars GlobalVars => _globalVars ?? throw new NullReferenceException("GlobalVars is NULL");

    /// <summary>
    /// Gets the MetaMod utility functions
    /// </summary>
    public static MetaUtilFunctions MetaUtilFuncs => _metaUtilFuncs ?? throw new NullReferenceException("MetaUtilFuncs is NULL");

    /// <summary>
    /// Gets the plugin information
    /// </summary>
    public static MetaPluginInfo PluginInfo => _pluginInfo ?? throw new NullReferenceException("PluginInfo is NULL");

    /// <summary>
    /// Gets the MetaMod global variables
    /// </summary>
    public static MetaGlobals MetaGlobals => _metaGlobals ?? throw new NullReferenceException("MetaGlobals is NULL");

    /// <summary>
    /// Gets the game DLL functions
    /// </summary>
    public static MetaGameDLLFunctions GameDllFuncs => _gameDllFuncs ?? throw new NullReferenceException("GameDllFuncs is NULL");

    internal static EngineFuncs? _engineFuncs;
    internal static GlobalVars? _globalVars;
    internal static MetaUtilFunctions? _metaUtilFuncs;
    internal static MetaPluginInfo? _pluginInfo;
    internal static MetaGlobals? _metaGlobals;
    internal static MetaGameDLLFunctions? _gameDllFuncs;
    #endregion
}