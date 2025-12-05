using NuggetMod.Enum.NuggetMod;
using NuggetMod.Wrapper.Common;
using NuggetMod.Wrapper.Engine;
using NuggetMod.Wrapper.Engine.PM;

namespace NuggetMod.Interface.Events;

#region delegates
#region dll functions
/// <summary>
/// Delegate for game initialization.
/// </summary>
public delegate MetaResult GameInitDelegate();
/// <summary>
/// Delegate for entity spawn.
/// </summary>
public delegate (MetaResult, int) SpawnDelegate(Edict pent);
/// <summary>
/// Delegate for entity think function.
/// </summary>
public delegate MetaResult ThinkDelegate(Edict pent);
/// <summary>
/// Delegate for entity use function.
/// </summary>
public delegate MetaResult UseDelegate(Edict pentUsed, Edict pentOther);
/// <summary>
/// Delegate for entity touch function.
/// </summary>
public delegate MetaResult TouchDelegate(Edict pentTouched, Edict pentOther);
/// <summary>
/// Delegate for entity blocked function.
/// </summary>
public delegate MetaResult BlockedDelegate(Edict pentBlocked, Edict pentOther);
/// <summary>
/// Delegate for entity key-value data handling.
/// </summary>
public delegate MetaResult KeyValueDelegate(Edict pentKeyvalue, KeyValueData pkvd);
/// <summary>
/// Delegate for entity save operation.
/// </summary>
public delegate MetaResult SaveDelegate(Edict pent, nint pSaveData);
/// <summary>
/// Delegate for entity restore operation.
/// </summary>
public delegate (MetaResult, int) RestoreDelegate(Edict pent, nint pSaveData, int globalEntity);
/// <summary>
/// Delegate for setting entity absolute bounding box.
/// </summary>
public delegate MetaResult SetAbsBoxDelegate(Edict pent);
/// <summary>
/// Delegate for writing save fields.
/// </summary>
public delegate MetaResult SaveWriteFieldsDelegate(nint a, nint b, nint c, nint d, int max);
/// <summary>
/// Delegate for reading save fields.
/// </summary>
public delegate MetaResult SaveReadFieldsDelegate(nint a, nint b, nint c, nint d, int max);
/// <summary>
/// Delegate for saving global state.
/// </summary>
public delegate MetaResult SaveGlobalStateDelegate(nint pSaveData);
/// <summary>
/// Delegate for restoring global state.
/// </summary>
public delegate MetaResult RestoreGlobalStateDelegate(nint pSaveData);
/// <summary>
/// Delegate for resetting global state.
/// </summary>
public delegate MetaResult ResetGlobalStateDelegate();
/// <summary>
/// Delegate for client connection.
/// </summary>
public delegate (MetaResult, bool) ClientConnectDelegate(Edict pEntity, string pszName, string pszAddress, ref string szRejectReason);
/// <summary>
/// Delegate for client disconnection.
/// </summary>
public delegate MetaResult ClientDisconnectDelegate(Edict pEntity);
/// <summary>
/// Delegate for client kill command.
/// </summary>
public delegate MetaResult ClientKillDelegate(Edict pEntity);
/// <summary>
/// Delegate for putting client in server.
/// </summary>
public delegate MetaResult ClientPutInServerDelegate(Edict pEntity);
/// <summary>
/// Delegate for client command execution.
/// </summary>
public delegate MetaResult DllClientCommandDelegate(Edict pEntity);
/// <summary>
/// Delegate for client user info change.
/// </summary>
public delegate MetaResult ClientUserInfoChangedDelegate(Edict pEntity, ref string infobuffer);
/// <summary>
/// Delegate for server activation.
/// </summary>
public delegate MetaResult ServerActivateDelegate(Edict pEdictList, int edictCount, int clientMax);
/// <summary>
/// Delegate for server deactivation.
/// </summary>
public delegate MetaResult ServerDeactivateDelegate();
/// <summary>
/// Delegate for player pre-think.
/// </summary>
public delegate MetaResult PlayerPreThinkDelegate(Edict pEntity);
/// <summary>
/// Delegate for player post-think.
/// </summary>
public delegate MetaResult PlayerPostThinkDelegate(Edict pEntity);
/// <summary>
/// Delegate for start of frame.
/// </summary>
public delegate MetaResult StartFrameDelegate();
/// <summary>
/// Delegate for new level parameters.
/// </summary>
public delegate MetaResult ParmsNewLevelDelegate();
/// <summary>
/// Delegate for change level parameters.
/// </summary>
public delegate MetaResult ParmsChangeLevelDelegate();
/// <summary>
/// Delegate for getting game description.
/// </summary>
public delegate (MetaResult, string) GetGameDescriptionDelegate();
/// <summary>
/// Delegate for player customization.
/// </summary>
public delegate MetaResult PlayerCustomizationDelegate(Edict pEntity, Customization pCustom);
/// <summary>
/// Delegate for spectator connection.
/// </summary>
public delegate MetaResult SpectatorConnectDelegate(Edict pEntity);
/// <summary>
/// Delegate for spectator disconnection.
/// </summary>
public delegate MetaResult SpectatorDisconnectDelegate(Edict pEntity);
/// <summary>
/// Delegate for spectator think.
/// </summary>
public delegate MetaResult SpectatorThinkDelegate(Edict pEntity);
/// <summary>
/// Delegate for system error handling.
/// </summary>
public delegate MetaResult SysErrorDelegate(string error_string);
/// <summary>
/// Delegate for player movement.
/// </summary>
public delegate MetaResult PMMoveDelegate(PlayerMove pm, bool server);
/// <summary>
/// Delegate for player movement initialization.
/// </summary>
public delegate MetaResult PMInitDelegate(PlayerMove pm);
/// <summary>
/// Delegate for finding texture type in player movement.
/// </summary>
public delegate MetaResult PMFindTextureTypeDelegate(string name);
/// <summary>
/// Delegate for setting up visibility.
/// </summary>
public delegate MetaResult SetupVisibilityDelegate(Edict pViewEntity, Edict pClient, ref byte[] pvs, ref byte[] pas);
/// <summary>
/// Delegate for updating client data.
/// </summary>
public delegate MetaResult UpdateClientDataDelegate(Edict ent, int sendweapons, ClientData cd);
/// <summary>
/// Delegate for adding entity to full pack.
/// </summary>
public delegate (MetaResult, int) AddToFullPackDelegate(EntityState state, int e, Edict ent, Edict host, int hostflags, int player, byte[] pSet);
/// <summary>
/// Delegate for creating entity baseline.
/// </summary>
public delegate MetaResult CreateBaselineDelegate(int player, int eindex, EntityState baseline, Edict entity, int playermodelindex, Vector3f player_mins, Vector3f player_maxs);
/// <summary>
/// Delegate for registering delta encoders.
/// </summary>
public delegate MetaResult RegisterEncodersDelegate();
/// <summary>
/// Delegate for getting weapon data.
/// </summary>
public delegate (MetaResult, int) GetWeaponDataDelegate(Edict player, WeaponData info);
/// <summary>
/// Delegate for command start.
/// </summary>
public delegate MetaResult CmdStartDelegate(Edict plyer, UserCmd cmd, uint random_seed);
/// <summary>
/// Delegate for command end.
/// </summary>
public delegate MetaResult CmdEndDelegate(Edict plyer);
/// <summary>
/// Delegate for connectionless packet handling.
/// </summary>
public delegate (MetaResult, int) ConnectionlessPacketDelegate(NetAdr net_from, string args, ref string response_buffer, ref int response_buffer_size);
/// <summary>
/// Delegate for getting hull bounds.
/// </summary>
public delegate (MetaResult, int) GetHullBoundsDelegate(int hullnumber, ref Vector3f mins, ref Vector3f maxs);
/// <summary>
/// Delegate for creating instanced baselines.
/// </summary>
public delegate MetaResult CreateInstancedBaselinesDelegate();
/// <summary>
/// Delegate for handling inconsistent file.
/// </summary>
public delegate (MetaResult, int) InconsistentFileDelegate(Edict player, string filename, ref string disconnect_message);
/// <summary>
/// Delegate for allowing lag compensation.
/// </summary>
public delegate (MetaResult, int) AllowLagCompensationDelegate();
#endregion
#endregion

/// <summary>
/// Provides events for game DLL functions that can be hooked by plugins.
/// </summary>
public class DLLEvents
{
    #region Events
    public event GameInitDelegate? GameInit;
    public event SpawnDelegate? Spawn;
    public event ThinkDelegate? Think;
    public event UseDelegate? Use;
    public event TouchDelegate? Touch;
    public event BlockedDelegate? Blocked;
    public event KeyValueDelegate? KeyValue;
    public event SaveDelegate? Save;
    public event RestoreDelegate? Restore;
    public event SetAbsBoxDelegate? SetAbsBox;
    public event SaveWriteFieldsDelegate? SaveWriteFields;
    public event SaveReadFieldsDelegate? SaveReadFields;
    public event SaveGlobalStateDelegate? SaveGlobalState;
    public event RestoreGlobalStateDelegate? RestoreGlobalState;
    public event ResetGlobalStateDelegate? ResetGlobalState;
    public event ClientConnectDelegate? ClientConnect;
    public event ClientDisconnectDelegate? ClientDisconnect;
    public event ClientKillDelegate? ClientKill;
    public event ClientPutInServerDelegate? ClientPutInServer;
    public event DllClientCommandDelegate? ClientCommand;
    public event ClientUserInfoChangedDelegate? ClientUserInfoChanged;
    public event ServerActivateDelegate? ServerActivate;
    public event ServerDeactivateDelegate? ServerDeactivate;
    public event PlayerPreThinkDelegate? PlayerPreThink;
    public event PlayerPostThinkDelegate? PlayerPostThink;
    public event StartFrameDelegate? StartFrame;
    public event ParmsNewLevelDelegate? ParmsNewLevel;
    public event ParmsChangeLevelDelegate? ParmsChangeLevel;
    public event GetGameDescriptionDelegate? GetGameDescription;
    public event PlayerCustomizationDelegate? PlayerCustomization;
    public event SpectatorConnectDelegate? SpectatorConnect;
    public event SpectatorDisconnectDelegate? SpectatorDisconnect;
    public event SpectatorThinkDelegate? SpectatorThink;
    public event SysErrorDelegate? SysError;
    public event PMMoveDelegate? PM_Move;
    public event PMInitDelegate? PM_Init;
    public event PMFindTextureTypeDelegate? PM_FindTextureType;
    public event SetupVisibilityDelegate? SetupVisibility;
    public event UpdateClientDataDelegate? UpdateClientData;
    public event AddToFullPackDelegate? AddToFullPack;
    public event CreateBaselineDelegate? CreateBaseline;
    public event RegisterEncodersDelegate? RegisterEncoders;
    public event GetWeaponDataDelegate? GetWeaponData;
    public event CmdStartDelegate? CmdStart;
    public event CmdEndDelegate? CmdEnd;
    public event ConnectionlessPacketDelegate? ConnectionlessPacket;
    public event GetHullBoundsDelegate? GetHullBounds;
    public event CreateInstancedBaselinesDelegate? CreateInstancedBaselines;
    public event InconsistentFileDelegate? InconsistentFile;
    public event AllowLagCompensationDelegate? AllowLagCompensation;
    #endregion
    #region Invoker
    internal void InvokeGameInit()
    {
        var result = GameInit?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal int InvokeSpawn(Edict pent)
    {
        var result = Spawn?.Invoke(pent);
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
    internal void InvokeThink(Edict pent)
    {
        var result = Think?.Invoke(pent);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeUse(Edict pentUsed, Edict pentOther)
    {
        var result = Use?.Invoke(pentUsed, pentOther);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeTouch(Edict pentTouched, Edict pentOther)
    {
        var result = Touch?.Invoke(pentTouched, pentOther);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeBlocked(Edict pentBlocked, Edict pentOther)
    {
        var result = Blocked?.Invoke(pentBlocked, pentOther);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeKeyValue(Edict pentKeyvalue, KeyValueData pkvd)
    {
        var result = KeyValue?.Invoke(pentKeyvalue, pkvd);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeSave(Edict pent, nint pSaveData)
    {
        var result = Save?.Invoke(pent, pSaveData);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal int InvokeRestore(Edict pent, nint pSaveData, int globalEntity)
    {
        var result = Restore?.Invoke(pent, pSaveData, globalEntity);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return 1;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeSetAbsBox(Edict pent)
    {
        var result = SetAbsBox?.Invoke(pent);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeSaveWriteFields(nint a, nint b, nint c, nint d, int max)
    {
        var result = SaveWriteFields?.Invoke(a, b, c, d, max);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeSaveReadFields(nint a, nint b, nint c, nint d, int max)
    {
        var result = SaveReadFields?.Invoke(a, b, c, d, max);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeSaveGlobalState(nint pSaveData)
    {
        var result = SaveGlobalState?.Invoke(pSaveData);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeRestoreGlobalState(nint pSaveData)
    {
        var result = RestoreGlobalState?.Invoke(pSaveData);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeResetGlobalState()
    {
        var result = ResetGlobalState?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal bool InvokeClientConnect(Edict pEntity, string pszName, string pszAddress, ref string szRejectReason)
    {
        var result = ClientConnect?.Invoke(pEntity, pszName, pszAddress, ref szRejectReason);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.MRES_IGNORED;
            return true;
        }
        else
        {
            MetaMod.MetaGlobals.Result = result.Value.Item1;
            return result.Value.Item2;
        }
    }
    internal void InvokeClientDisconnect(Edict pEntity)
    {
        var result = ClientDisconnect?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeClientKill(Edict pEntity)
    {
        var result = ClientKill?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeClientPutInServer(Edict pEntity)
    {
        var result = ClientPutInServer?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeClientCommand(Edict pEntity)
    {
        var result = ClientCommand?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeClientUserInfoChanged(Edict pEntity, ref string infobuffer)
    {
        var result = ClientUserInfoChanged?.Invoke(pEntity, ref infobuffer);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeServerActivate(Edict pEdictList, int edictCount, int clientMax)
    {
        var result = ServerActivate?.Invoke(pEdictList, edictCount, clientMax);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeServerDeactivate()
    {
        var result = ServerDeactivate?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokePlayerPreThink(Edict pEntity)
    {
        var result = PlayerPreThink?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokePlayerPostThink(Edict pEntity)
    {
        var result = PlayerPostThink?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeStartFrame()
    {
        var result = StartFrame?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeParmsNewLevel()
    {
        var result = ParmsNewLevel?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeParmsChangeLevel()
    {
        var result = ParmsChangeLevel?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal string InvokeGetGameDescription()
    {
        var result = GetGameDescription?.Invoke();
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
    internal void InvokePlayerCustomization(Edict pEntity, Customization pCustom)
    {
        var result = PlayerCustomization?.Invoke(pEntity, pCustom);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeSpectatorConnect(Edict pEntity)
    {
        var result = SpectatorConnect?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeSpectatorDisconnect(Edict pEntity)
    {
        var result = SpectatorDisconnect?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeSpectatorThink(Edict pEntity)
    {
        var result = SpectatorThink?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeSysError(string error_string)
    {
        var result = SysError?.Invoke(error_string);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokePM_Move(PlayerMove pm, bool server)
    {
        var result = PM_Move?.Invoke(pm, server);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokePM_Init(PlayerMove pm)
    {
        var result = PM_Init?.Invoke(pm);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal byte InvokePM_FindTextureType(string name)
    {
        var result = PM_FindTextureType?.Invoke(name);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
        return 0;
    }
    internal void InvokeSetupVisibility(Edict pViewEntity, Edict pClient, ref byte[] pvs, ref byte[] pas)
    {
        var result = SetupVisibility?.Invoke(pViewEntity, pClient, ref pvs, ref pas);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeUpdateClientData(Edict ent, int sendweapons, ClientData cd)
    {
        var result = UpdateClientData?.Invoke(ent, sendweapons, cd);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal int InvokeAddToFullPack(EntityState state, int e, Edict ent, Edict host, int hostflags, int player, byte[] pSet)
    {
        var result = AddToFullPack?.Invoke(state, e, ent, host, hostflags, player, pSet);
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
    internal void InvokeCreateBaseline(int player, int eindex, EntityState baseline, Edict entity, int playermodelindex, Vector3f player_mins, Vector3f player_maxs)
    {
        var result = CreateBaseline?.Invoke(player, eindex, baseline, entity, playermodelindex, player_mins, player_maxs);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeRegisterEncoders()
    {
        var result = RegisterEncoders?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal int InvokeGetWeaponData(Edict player, WeaponData info)
    {
        var result = GetWeaponData?.Invoke(player, info);
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
    internal void InvokeCmdStart(Edict plyer, UserCmd cmd, uint random_seed)
    {
        var result = CmdStart?.Invoke(plyer, cmd, random_seed);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal void InvokeCmdEnd(Edict plyer)
    {
        var result = CmdEnd?.Invoke(plyer);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal int InvokeConnectionlessPacket(NetAdr net_from, string args, ref string response_buffer, ref int response_buffer_size)
    {
        var result = ConnectionlessPacket?.Invoke(net_from, args, ref response_buffer, ref response_buffer_size);
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
    internal int InvokeGetHullBounds(int hullnumber, ref Vector3f mins, ref Vector3f maxs)
    {
        var result = GetHullBounds?.Invoke(hullnumber, ref mins, ref maxs);
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
    internal void InvokeCreateInstancedBaselines()
    {
        var result = CreateInstancedBaselines?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.MRES_IGNORED;
    }
    internal int InvokeInconsistentFile(Edict player, string filename, ref string disconnect_message)
    {
        var result = InconsistentFile?.Invoke(player, filename, ref disconnect_message);
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
    internal int InvokeAllowLagCompensation()
    {
        var result = AllowLagCompensation?.Invoke();
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
    internal bool IsGameInitNull => GameInit == null;
    internal bool IsSpawnNull => Spawn == null;
    internal bool IsThinkNull => Think == null;
    internal bool IsUseNull => Use == null;
    internal bool IsTouchNull => Touch == null;
    internal bool IsBlockedNull => Blocked == null;
    internal bool IsKeyValueNull => KeyValue == null;
    internal bool IsSaveNull => Save == null;
    internal bool IsRestoreNull => Restore == null;
    internal bool IsSetAbsBoxNull => SetAbsBox == null;
    internal bool IsSaveWriteFieldsNull => SaveWriteFields == null;
    internal bool IsSaveReadFieldsNull => SaveReadFields == null;
    internal bool IsSaveGlobalStateNull => SaveGlobalState == null;
    internal bool IsRestoreGlobalStateNull => RestoreGlobalState == null;
    internal bool IsResetGlobalStateNull => ResetGlobalState == null;
    internal bool IsClientConnectNull => ClientConnect == null;
    internal bool IsClientDisconnectNull => ClientDisconnect == null;
    internal bool IsClientKillNull => ClientKill == null;
    internal bool IsClientPutInServerNull => ClientPutInServer == null;
    internal bool IsClientCommandNull => ClientCommand == null;
    internal bool IsClientUserInfoChangedNull => ClientUserInfoChanged == null;
    internal bool IsServerActivateNull => ServerActivate == null;
    internal bool IsServerDeactivateNull => ServerDeactivate == null;
    internal bool IsPlayerPreThinkNull => PlayerPreThink == null;
    internal bool IsPlayerPostThinkNull => PlayerPostThink == null;
    internal bool IsStartFrameNull => StartFrame == null;
    internal bool IsParmsNewLevelNull => ParmsNewLevel == null;
    internal bool IsParmsChangeLevelNull => ParmsChangeLevel == null;
    internal bool IsGetGameDescriptionNull => GetGameDescription == null;
    internal bool IsPlayerCustomizationNull => PlayerCustomization == null;
    internal bool IsSpectatorConnectNull => SpectatorConnect == null;
    internal bool IsSpectatorDisconnectNull => SpectatorDisconnect == null;
    internal bool IsSpectatorThinkNull => SpectatorThink == null;
    internal bool IsSysErrorNull => SysError == null;
    internal bool IsPM_MoveNull => PM_Move == null;
    internal bool IsPM_InitNull => PM_Init == null;
    internal bool IsPM_FindTextureTypeNull => PM_FindTextureType == null;
    internal bool IsSetupVisibilityNull => SetupVisibility == null;
    internal bool IsUpdateClientDataNull => UpdateClientData == null;
    internal bool IsAddToFullPackNull => AddToFullPack == null;
    internal bool IsCreateBaselineNull => CreateBaseline == null;
    internal bool IsRegisterEncodersNull => RegisterEncoders == null;
    internal bool IsGetWeaponDataNull => GetWeaponData == null;
    internal bool IsCmdStartNull => CmdStart == null;
    internal bool IsCmdEndNull => CmdEnd == null;
    internal bool IsConnectionlessPacketNull => ConnectionlessPacket == null;
    internal bool IsGetHullBoundsNull => GetHullBounds == null;
    internal bool IsCreateInstancedBaselinesNull => CreateInstancedBaselines == null;
    internal bool IsInconsistentFileNull => InconsistentFile == null;
    internal bool IsAllowLagCompensationNull => AllowLagCompensation == null;
    #endregion
}