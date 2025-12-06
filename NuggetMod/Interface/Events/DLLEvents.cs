using NuggetMod.Enum.Metamod;
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
    /// <summary>
    /// Event fired when the game DLL is initialized.
    /// </summary>
    public event GameInitDelegate? GameInit;
    /// <summary>
    /// Event fired when an entity is spawned.
    /// </summary>
    public event SpawnDelegate? Spawn;
    /// <summary>
    /// Event fired when an entity thinks.
    /// </summary>
    public event ThinkDelegate? Think;
    /// <summary>
    /// Event fired when an entity is used by another entity.
    /// </summary>
    public event UseDelegate? Use;
    /// <summary>
    /// Event fired when an entity touches another entity.
    /// </summary>
    public event TouchDelegate? Touch;
    /// <summary>
    /// Event fired when an entity is blocked by another entity.
    /// </summary>
    public event BlockedDelegate? Blocked;
    /// <summary>
    /// Event fired when key-value data is set on an entity during map load.
    /// </summary>
    public event KeyValueDelegate? KeyValue;
    /// <summary>
    /// Event fired when an entity is saved.
    /// </summary>
    public event SaveDelegate? Save;
    /// <summary>
    /// Event fired when an entity is restored from save data.
    /// </summary>
    public event RestoreDelegate? Restore;
    /// <summary>
    /// Event fired when an entity's absolute bounding box is set.
    /// </summary>
    public event SetAbsBoxDelegate? SetAbsBox;
    /// <summary>
    /// Event fired when save fields are written.
    /// </summary>
    public event SaveWriteFieldsDelegate? SaveWriteFields;
    /// <summary>
    /// Event fired when save fields are read.
    /// </summary>
    public event SaveReadFieldsDelegate? SaveReadFields;
    /// <summary>
    /// Event fired when global state is saved.
    /// </summary>
    public event SaveGlobalStateDelegate? SaveGlobalState;
    /// <summary>
    /// Event fired when global state is restored.
    /// </summary>
    public event RestoreGlobalStateDelegate? RestoreGlobalState;
    /// <summary>
    /// Event fired when global state is reset.
    /// </summary>
    public event ResetGlobalStateDelegate? ResetGlobalState;
    /// <summary>
    /// Event fired when a client attempts to connect to the server.
    /// </summary>
    public event ClientConnectDelegate? ClientConnect;
    /// <summary>
    /// Event fired when a client disconnects from the server.
    /// </summary>
    public event ClientDisconnectDelegate? ClientDisconnect;
    /// <summary>
    /// Event fired when a client executes the kill command.
    /// </summary>
    public event ClientKillDelegate? ClientKill;
    /// <summary>
    /// Event fired when a client is put into the server after connecting.
    /// </summary>
    public event ClientPutInServerDelegate? ClientPutInServer;
    /// <summary>
    /// Event fired when a client executes a command.
    /// </summary>
    public event DllClientCommandDelegate? ClientCommand;
    /// <summary>
    /// Event fired when a client's user info is changed.
    /// </summary>
    public event ClientUserInfoChangedDelegate? ClientUserInfoChanged;
    /// <summary>
    /// Event fired when the server is activated (map loaded).
    /// </summary>
    public event ServerActivateDelegate? ServerActivate;
    /// <summary>
    /// Event fired when the server is deactivated (map unloaded).
    /// </summary>
    public event ServerDeactivateDelegate? ServerDeactivate;
    /// <summary>
    /// Event fired before player physics simulation.
    /// </summary>
    public event PlayerPreThinkDelegate? PlayerPreThink;
    /// <summary>
    /// Event fired after player physics simulation.
    /// </summary>
    public event PlayerPostThinkDelegate? PlayerPostThink;
    /// <summary>
    /// Event fired at the start of each server frame.
    /// </summary>
    public event StartFrameDelegate? StartFrame;
    /// <summary>
    /// Event fired when starting a new level.
    /// </summary>
    public event ParmsNewLevelDelegate? ParmsNewLevel;
    /// <summary>
    /// Event fired when changing levels.
    /// </summary>
    public event ParmsChangeLevelDelegate? ParmsChangeLevel;
    /// <summary>
    /// Event fired to get the game description string.
    /// </summary>
    public event GetGameDescriptionDelegate? GetGameDescription;
    /// <summary>
    /// Event fired when a player's customization is applied.
    /// </summary>
    public event PlayerCustomizationDelegate? PlayerCustomization;
    /// <summary>
    /// Event fired when a spectator connects.
    /// </summary>
    public event SpectatorConnectDelegate? SpectatorConnect;
    /// <summary>
    /// Event fired when a spectator disconnects.
    /// </summary>
    public event SpectatorDisconnectDelegate? SpectatorDisconnect;
    /// <summary>
    /// Event fired when a spectator thinks.
    /// </summary>
    public event SpectatorThinkDelegate? SpectatorThink;
    /// <summary>
    /// Event fired when a system error occurs.
    /// </summary>
    public event SysErrorDelegate? SysError;
    /// <summary>
    /// Event fired during player movement simulation.
    /// </summary>
    public event PMMoveDelegate? PM_Move;
    /// <summary>
    /// Event fired to initialize player movement.
    /// </summary>
    public event PMInitDelegate? PM_Init;
    /// <summary>
    /// Event fired to find texture type during player movement.
    /// </summary>
    public event PMFindTextureTypeDelegate? PM_FindTextureType;
    /// <summary>
    /// Event fired to set up visibility for a client.
    /// </summary>
    public event SetupVisibilityDelegate? SetupVisibility;
    /// <summary>
    /// Event fired to update client data before sending to client.
    /// </summary>
    public event UpdateClientDataDelegate? UpdateClientData;
    /// <summary>
    /// Event fired to add entity to the full pack for network transmission.
    /// </summary>
    public event AddToFullPackDelegate? AddToFullPack;
    /// <summary>
    /// Event fired to create entity baseline for delta compression.
    /// </summary>
    public event CreateBaselineDelegate? CreateBaseline;
    /// <summary>
    /// Event fired to register delta encoders.
    /// </summary>
    public event RegisterEncodersDelegate? RegisterEncoders;
    /// <summary>
    /// Event fired to get weapon data for client prediction.
    /// </summary>
    public event GetWeaponDataDelegate? GetWeaponData;
    /// <summary>
    /// Event fired at the start of a client command.
    /// </summary>
    public event CmdStartDelegate? CmdStart;
    /// <summary>
    /// Event fired at the end of a client command.
    /// </summary>
    public event CmdEndDelegate? CmdEnd;
    /// <summary>
    /// Event fired when a connectionless packet is received.
    /// </summary>
    public event ConnectionlessPacketDelegate? ConnectionlessPacket;
    /// <summary>
    /// Event fired to get hull bounds for collision detection.
    /// </summary>
    public event GetHullBoundsDelegate? GetHullBounds;
    /// <summary>
    /// Event fired to create instanced baselines.
    /// </summary>
    public event CreateInstancedBaselinesDelegate? CreateInstancedBaselines;
    /// <summary>
    /// Event fired when an inconsistent file is detected on the client.
    /// </summary>
    public event InconsistentFileDelegate? InconsistentFile;
    /// <summary>
    /// Event fired to check if lag compensation is allowed.
    /// </summary>
    public event AllowLagCompensationDelegate? AllowLagCompensation;
    #endregion
    #region Invoker
    internal void InvokeGameInit()
    {
        var result = GameInit?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal int InvokeSpawn(Edict pent)
    {
        var result = Spawn?.Invoke(pent);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.Ignored;
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
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeUse(Edict pentUsed, Edict pentOther)
    {
        var result = Use?.Invoke(pentUsed, pentOther);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeTouch(Edict pentTouched, Edict pentOther)
    {
        var result = Touch?.Invoke(pentTouched, pentOther);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeBlocked(Edict pentBlocked, Edict pentOther)
    {
        var result = Blocked?.Invoke(pentBlocked, pentOther);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeKeyValue(Edict pentKeyvalue, KeyValueData pkvd)
    {
        var result = KeyValue?.Invoke(pentKeyvalue, pkvd);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeSave(Edict pent, nint pSaveData)
    {
        var result = Save?.Invoke(pent, pSaveData);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal int InvokeRestore(Edict pent, nint pSaveData, int globalEntity)
    {
        var result = Restore?.Invoke(pent, pSaveData, globalEntity);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.Ignored;
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
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeSaveWriteFields(nint a, nint b, nint c, nint d, int max)
    {
        var result = SaveWriteFields?.Invoke(a, b, c, d, max);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeSaveReadFields(nint a, nint b, nint c, nint d, int max)
    {
        var result = SaveReadFields?.Invoke(a, b, c, d, max);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeSaveGlobalState(nint pSaveData)
    {
        var result = SaveGlobalState?.Invoke(pSaveData);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeRestoreGlobalState(nint pSaveData)
    {
        var result = RestoreGlobalState?.Invoke(pSaveData);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeResetGlobalState()
    {
        var result = ResetGlobalState?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal bool InvokeClientConnect(Edict pEntity, string pszName, string pszAddress, ref string szRejectReason)
    {
        var result = ClientConnect?.Invoke(pEntity, pszName, pszAddress, ref szRejectReason);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.Ignored;
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
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeClientKill(Edict pEntity)
    {
        var result = ClientKill?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeClientPutInServer(Edict pEntity)
    {
        var result = ClientPutInServer?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeClientCommand(Edict pEntity)
    {
        var result = ClientCommand?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeClientUserInfoChanged(Edict pEntity, ref string infobuffer)
    {
        var result = ClientUserInfoChanged?.Invoke(pEntity, ref infobuffer);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeServerActivate(Edict pEdictList, int edictCount, int clientMax)
    {
        var result = ServerActivate?.Invoke(pEdictList, edictCount, clientMax);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeServerDeactivate()
    {
        var result = ServerDeactivate?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokePlayerPreThink(Edict pEntity)
    {
        var result = PlayerPreThink?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokePlayerPostThink(Edict pEntity)
    {
        var result = PlayerPostThink?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeStartFrame()
    {
        var result = StartFrame?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeParmsNewLevel()
    {
        var result = ParmsNewLevel?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeParmsChangeLevel()
    {
        var result = ParmsChangeLevel?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal string InvokeGetGameDescription()
    {
        var result = GetGameDescription?.Invoke();
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.Ignored;
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
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeSpectatorConnect(Edict pEntity)
    {
        var result = SpectatorConnect?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeSpectatorDisconnect(Edict pEntity)
    {
        var result = SpectatorDisconnect?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeSpectatorThink(Edict pEntity)
    {
        var result = SpectatorThink?.Invoke(pEntity);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeSysError(string error_string)
    {
        var result = SysError?.Invoke(error_string);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokePM_Move(PlayerMove pm, bool server)
    {
        var result = PM_Move?.Invoke(pm, server);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokePM_Init(PlayerMove pm)
    {
        var result = PM_Init?.Invoke(pm);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal byte InvokePM_FindTextureType(string name)
    {
        var result = PM_FindTextureType?.Invoke(name);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
        return 0;
    }
    internal void InvokeSetupVisibility(Edict pViewEntity, Edict pClient, ref byte[] pvs, ref byte[] pas)
    {
        var result = SetupVisibility?.Invoke(pViewEntity, pClient, ref pvs, ref pas);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeUpdateClientData(Edict ent, int sendweapons, ClientData cd)
    {
        var result = UpdateClientData?.Invoke(ent, sendweapons, cd);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal int InvokeAddToFullPack(EntityState state, int e, Edict ent, Edict host, int hostflags, int player, byte[] pSet)
    {
        var result = AddToFullPack?.Invoke(state, e, ent, host, hostflags, player, pSet);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.Ignored;
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
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeRegisterEncoders()
    {
        var result = RegisterEncoders?.Invoke();
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal int InvokeGetWeaponData(Edict player, WeaponData info)
    {
        var result = GetWeaponData?.Invoke(player, info);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.Ignored;
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
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal void InvokeCmdEnd(Edict plyer)
    {
        var result = CmdEnd?.Invoke(plyer);
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal int InvokeConnectionlessPacket(NetAdr net_from, string args, ref string response_buffer, ref int response_buffer_size)
    {
        var result = ConnectionlessPacket?.Invoke(net_from, args, ref response_buffer, ref response_buffer_size);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.Ignored;
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
            MetaMod.MetaGlobals.Result = MetaResult.Ignored;
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
        MetaMod.MetaGlobals.Result = result ?? MetaResult.Ignored;
    }
    internal int InvokeInconsistentFile(Edict player, string filename, ref string disconnect_message)
    {
        var result = InconsistentFile?.Invoke(player, filename, ref disconnect_message);
        if (result == null)
        {
            MetaMod.MetaGlobals.Result = MetaResult.Ignored;
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
            MetaMod.MetaGlobals.Result = MetaResult.Ignored;
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