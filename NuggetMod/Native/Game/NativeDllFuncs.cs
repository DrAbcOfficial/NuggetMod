using System.Runtime.InteropServices;

namespace NuggetMod.Native.Game;

/// <summary>
/// Native DLL Functions
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NativeDllFuncs : INativeStruct
{
    internal NativeGameInitDelegate pfnGameInit;
    internal NativeSpawnDelegate pfnSpawn;
    internal NativeThinkDelegate pfnThink;
    internal NativeUseDelegate pfnUse;
    internal NativeTouchDelegate pfnTouch;
    internal NativeBlockedDelegate pfnBlocked;
    internal NativeKeyValueDelegate pfnKeyValue;
    internal NativeSaveDelegate pfnSave;
    internal NativeRestoreDelegate pfnRestore;
    internal NativeSetAbsBoxDelegate pfnSetAbsBox;

    internal NativeSaveWriteFieldsDelegate pfnSaveWriteFields;
    internal NativeSaveReadFieldsDelegate pfnSaveReadFields;

    internal NativeSaveGlobalStateDelegate pfnSaveGlobalState;
    internal NativeRestoreGlobalStateDelegate pfnRestoreGlobalState;
    internal NativeResetGlobalStateDelegate pfnResetGlobalState;

    internal NativeClientConnectDelegate pfnClientConnect;
    internal NativeClientDisconnectDelegate pfnClientDisconnect;
    internal NativeClientKillDelegate pfnClientKill;
    internal NativeClientPutInServerDelegate pfnClientPutInServer;
    internal NativeClientCommandDelegate pfnClientCommand;
    internal NativeClientUserInfoChangedDelegate pfnClientUserInfoChanged;

    internal NativeServerActivateDelegate pfnServerActivate;
    internal NativeServerDeactivateDelegate pfnServerDeactivate;

    internal NativePlayerPreThinkDelegate pfnPlayerPreThink;
    internal NativePlayerPostThinkDelegate pfnPlayerPostThink;

    internal NativeStartFrameDelegate pfnStartFrame;
    internal NativeParmsNewLevelDelegate pfnParmsNewLevel;
    internal NativeParmsChangeLevelDelegate pfnParmsChangeLevel;

    internal NativeGetGameDescriptionDelegate pfnGetGameDescription;
    internal NativePlayerCustomizationDelegate pfnPlayerCustomization;
    internal NativeSpectatorConnectDelegate pfnSpectatorConnect;
    internal NativeSpectatorDisconnectDelegate pfnSpectatorDisconnect;
    internal NativeSpectatorThinkDelegate pfnSpectatorThink;
    internal NativeSysErrorDelegate pfnSysError;

    internal NativePMMoveDelegate pfnPMMove;
    internal NativePMInitDelegate pfnPMInit;
    internal NativePMFindTextureTypeDelegate pfnPMFindTextureType;
    internal NativeSetupVisibilityDelegate pfnSetupVisibility;
    internal NativeUpdateClientDataDelegate pfnUpdateClientData;
    internal NativeAddToFullPackDelegate pfnAddToFullPack;
    internal NativeCreateBaselineDelegate pfnCreateBaseline;
    internal NativeRegisterEncodersDelegate pfnRegisterEncoders;
    internal NativeGetWeaponDataDelegate pfnGetWeaponData;

    internal NativeCmdStartDelegate pfnCmdStart;
    internal NativeCmdEndDelegate pfnCmdEnd;

    internal NativeConnectionlessPacketDelegate pfnConnectionlessPacket;

    internal NativeGetHullBoundsDelegate pfnGetHullBounds;
    internal NativeCreateInstancedBaselinesDelegate pfnCreateInstancedBaselines;

    internal NativeInconsistentFileDelegate pfnInconsistentFile;
    internal NativeAllowLagCompensationDelegate pfnAllowLagCompensation;

#pragma warning disable CS8500 // 这会获取托管类型的地址、获取其大小或声明指向它的指针
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeGameInitDelegate();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeSpawnDelegate(nint pent);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeThinkDelegate(nint pent);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeUseDelegate(nint pentUsed, nint pentOther);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeTouchDelegate(nint pentTouched, nint pentOther);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeBlockedDelegate(nint pentBlocked, nint pentOther);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeKeyValueDelegate(nint pentKeyvalue, nint pkvd);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSaveDelegate(nint pent, nint pSaveData);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeRestoreDelegate(nint pent, nint pSaveData, int globalEntity);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSetAbsBoxDelegate(nint pent);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSaveWriteFieldsDelegate(nint pSaveData, nint name, nint data, nint typeDescription, int count);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSaveReadFieldsDelegate(nint pSaveData, nint name, nint data, nint typeDescription, int count);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSaveGlobalStateDelegate(nint pSaveData);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeRestoreGlobalStateDelegate(nint pSaveData);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeResetGlobalStateDelegate();

    //szRejectReason len 128
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeClientConnectDelegate(nint pEntity, nint pszName, nint pszAddress, nint szRejectReason);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeClientDisconnectDelegate(nint pEntity);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeClientKillDelegate(nint pEntity);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeClientPutInServerDelegate(nint pEntity);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeClientCommandDelegate(nint pEntity);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeClientUserInfoChangedDelegate(nint pEntity, nint infobuffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeServerActivateDelegate(nint pEdictList, int edictCount, int clientMax);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeServerDeactivateDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativePlayerPreThinkDelegate(nint pEntity);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativePlayerPostThinkDelegate(nint pEntity);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeStartFrameDelegate();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeParmsNewLevelDelegate();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeParmsChangeLevelDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate nint NativeGetGameDescriptionDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativePlayerCustomizationDelegate(nint pEntity, nint pCustom);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSpectatorConnectDelegate(nint pEntity);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSpectatorDisconnectDelegate(nint pEntity);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSpectatorThinkDelegate(nint pEntity);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSysErrorDelegate(nint error_string);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativePMMoveDelegate(nint ppmove, int server);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativePMInitDelegate(nint ppmove);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate byte NativePMFindTextureTypeDelegate(nint name);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeSetupVisibilityDelegate(nint pViewEntity, nint pClient, nint pvs, nint pas);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeUpdateClientDataDelegate(nint ent, int sendweapons, nint cd);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeAddToFullPackDelegate(nint state, int e, nint ent, nint host, int hostflags, int player, nint pSet);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCreateBaselineDelegate(int player, int eindex, nint baseline, nint entity, int playermodelindex, nint player_mins, nint player_maxs);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeRegisterEncodersDelegate();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeGetWeaponDataDelegate(nint player, nint info);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCmdStartDelegate(nint player, nint cmd, uint random_seed);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCmdEndDelegate(nint player);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeConnectionlessPacketDelegate(nint net_from, nint args, nint response_buffer, nint response_buffer_size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeGetHullBoundsDelegate(int hullnumber, nint mins, nint maxs);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NativeCreateInstancedBaselinesDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeInconsistentFileDelegate(nint player, nint filename, nint disconnect_message);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeAllowLagCompensationDelegate();
#pragma warning restore CS8500 // 这会获取托管类型的地址、获取其大小或声明指向它的指针
}
