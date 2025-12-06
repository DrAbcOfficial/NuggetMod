using NuggetMod.Native.Game;
using NuggetMod.Wrapper.Common;
using NuggetMod.Wrapper.Engine;
using NuggetMod.Wrapper.Engine.PM;
using System.Runtime.InteropServices;

namespace NuggetMod.Wrapper.Game;

/// <summary>
/// Wrapper for game DLL function table
/// </summary>
public class DLLFunctions(nint ptr) : BaseFunctionWrapper<NativeDllFuncs>(ptr)
{
    /// <summary>
    /// Initializes the game (one-time call after loading of game DLL)
    /// </summary>
    public void GameInit() => Base.pfnGameInit();
    
    /// <summary>
    /// Spawns an entity
    /// </summary>
    /// <param name="pent">Entity to spawn</param>
    /// <returns>Spawn result code</returns>
    public int Spawn(Edict pent) => Base.pfnSpawn(pent.GetNative());
    /// <summary>
    /// Called every frame for entities that need to think
    /// </summary>
    /// <param name="pent">Entity to think</param>
    public void Think(Edict pent) => Base.pfnThink(pent.GetNative());
    
    /// <summary>
    /// Called when an entity is used by another entity
    /// </summary>
    /// <param name="pentUsed">Entity being used</param>
    /// <param name="pentOther">Entity doing the using</param>
    public void Use(Edict pentUsed, Edict pentOther) => Base.pfnUse(pentUsed.GetNative(), pentOther.GetNative());
    
    /// <summary>
    /// Called when two entities touch each other
    /// </summary>
    /// <param name="pentTouched">Entity being touched</param>
    /// <param name="pentOther">Entity doing the touching</param>
    public void Touch(Edict pentTouched, Edict pentOther) => Base.pfnTouch(pentTouched.GetNative(), pentOther.GetNative());
    
    /// <summary>
    /// Called when an entity is blocked by another entity
    /// </summary>
    /// <param name="pentBlocked">Entity being blocked</param>
    /// <param name="pentOther">Entity doing the blocking</param>
    public void Blocked(Edict pentBlocked, Edict pentOther) => Base.pfnBlocked(pentBlocked.GetNative(), pentOther.GetNative());
    
    /// <summary>
    /// Called to set a key-value pair on an entity during map loading
    /// </summary>
    /// <param name="pentKeyvalue">Entity receiving the key-value</param>
    /// <param name="pkvd">Key-value data</param>
    public void KeyValue(Edict pentKeyvalue, KeyValueData pkvd) => Base.pfnKeyValue(pentKeyvalue.GetNative(), pkvd.GetNative());

    /// <summary>
    /// Saves entity data to persistent storage
    /// </summary>
    /// <param name="pent">Entity to save</param>
    /// <param name="pSaveData">Save data structure</param>
    public void Save(Edict pent, nint pSaveData) => Base.pfnSave(pent.GetNative(), pSaveData);
    
    /// <summary>
    /// Restores entity data from persistent storage
    /// </summary>
    /// <param name="pent">Entity to restore</param>
    /// <param name="pSaveData">Save data structure</param>
    /// <param name="globalEntity">Whether this is a global entity</param>
    /// <returns>Restore result code</returns>
    public int Restore(Edict pent, nint pSaveData, int globalEntity) => Base.pfnRestore(pent.GetNative(), pSaveData, globalEntity);
    
    /// <summary>
    /// Sets the absolute bounding box for an entity
    /// </summary>
    /// <param name="pent">Entity to update</param>
    public void SetAbsBox(Edict pent) => Base.pfnSetAbsBox(pent.GetNative());
    
    /// <summary>
    /// Writes save fields to storage
    /// </summary>
    public void SveWriteFields(nint a, nint b, nint c, nint d, int max) => Base.pfnSaveWriteFields(a, b, c, d, max);
    
    /// <summary>
    /// Reads save fields from storage
    /// </summary>
    public void SaveReadFields(nint a, nint b, nint c, nint d, int max) => Base.pfnSaveReadFields(a, b, c, d, max);
    
    /// <summary>
    /// Saves global game state
    /// </summary>
    /// <param name="pSaveData">Save data structure</param>
    public void SaveGlobalState(nint pSaveData) => Base.pfnSaveGlobalState(pSaveData);
    
    /// <summary>
    /// Restores global game state
    /// </summary>
    /// <param name="pSaveData">Save data structure</param>
    public void RestoreGlobalState(nint pSaveData) => Base.pfnRestoreGlobalState(pSaveData);
    
    /// <summary>
    /// Resets global game state to defaults
    /// </summary>
    public void ResetGlobalState() => Base.pfnResetGlobalState();
    /// <summary>
    /// Called when a client attempts to connect to the server
    /// </summary>
    /// <param name="pEntity">Client entity</param>
    /// <param name="pszName">Client name</param>
    /// <param name="pszAddress">Client IP address</param>
    /// <param name="szRejectReason">Reason for rejection if connection is denied</param>
    /// <returns>True if connection is allowed, false otherwise</returns>
    public bool ClientConnect(Edict pEntity, string pszName, string pszAddress, ref string szRejectReason)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(pszName);
        nint ns2 = Marshal.StringToHGlobalAnsi(pszAddress);
        nint ns3 = Marshal.AllocHGlobal(128 * sizeof(byte));
        for (int i = 0; i < Math.Min(szRejectReason.Length, 128); i++)
        {
            Marshal.WriteByte(ns3, i, (byte)szRejectReason[i]);
        }
        bool res = Base.pfnClientConnect(pEntity.GetNative(), ns1, ns2, ns3) == 1;
        szRejectReason = Marshal.PtrToStringUTF8(ns3) ?? string.Empty;
        Marshal.FreeHGlobal(ns3);
        Marshal.FreeHGlobal(ns2);
        Marshal.FreeHGlobal(ns1);
        return res;
    }
    /// <summary>
    /// Called when a client disconnects from the server
    /// </summary>
    /// <param name="pEntity">Client entity</param>
    public void ClientDisconnect(Edict pEntity) => Base.pfnClientDisconnect(pEntity.GetNative());
    
    /// <summary>
    /// Called when a client is killed
    /// </summary>
    /// <param name="pEntity">Client entity</param>
    public void ClientKill(Edict pEntity) => Base.pfnClientKill(pEntity.GetNative());
    
    /// <summary>
    /// Called when a client is spawned into the game
    /// </summary>
    /// <param name="pEntity">Client entity</param>
    public void ClientPutInServer(Edict pEntity) => Base.pfnClientPutInServer(pEntity.GetNative());
    
    /// <summary>
    /// Called when a client executes a command
    /// </summary>
    /// <param name="pEntity">Client entity</param>
    public void ClientCommand(Edict pEntity) => Base.pfnClientCommand(pEntity.GetNative());
    /// <summary>
    /// Called when a client's user info changes (name, model, etc.)
    /// </summary>
    /// <param name="pEntity">Client entity</param>
    /// <param name="infobuffer">User info buffer</param>
    public void ClientUserInfoChanged(Edict pEntity, ref string infobuffer)
    {
        nint ns = Marshal.StringToHGlobalAnsi(infobuffer);
        Base.pfnClientUserInfoChanged(pEntity.GetNative(), ns);
        infobuffer = Marshal.PtrToStringUTF8(ns) ?? string.Empty;
        Marshal.FreeHGlobal(ns);
    }

    /// <summary>
    /// Called when the server is activated and ready to accept clients
    /// </summary>
    /// <param name="pEdictList">List of all edicts</param>
    /// <param name="edictCount">Number of edicts</param>
    /// <param name="clientMax">Maximum number of clients</param>
    public void ServerActivate(Edict pEdictList, int edictCount, int clientMax) => Base.pfnServerActivate(pEdictList.GetNative(), edictCount, clientMax);
    
    /// <summary>
    /// Called when the server is deactivated
    /// </summary>
    public void ServerDeactivate() => Base.pfnServerDeactivate();

    /// <summary>
    /// Called before player physics simulation
    /// </summary>
    /// <param name="pEntity">Player entity</param>
    public void PlayerPreThink(Edict pEntity) => Base.pfnPlayerPreThink(pEntity.GetNative());
    
    /// <summary>
    /// Called after player physics simulation
    /// </summary>
    /// <param name="pEntity">Player entity</param>
    public void PlayerPostThink(Edict pEntity) => Base.pfnPlayerPostThink(pEntity.GetNative());

    /// <summary>
    /// Called at the start of each server frame
    /// </summary>
    public void StartFrame() => Base.pfnStartFrame();
    
    /// <summary>
    /// Called when starting a new level
    /// </summary>
    public void ParmsNewLevel() => Base.pfnParmsNewLevel();
    
    /// <summary>
    /// Called when changing levels
    /// </summary>
    public void ParmsChangeLevel() => Base.pfnParmsChangeLevel();

    /// <summary>
    /// Returns string describing current game DLL (e.g., "Team Fortress 2", "Half-Life")
    /// </summary>
    /// <returns>Game description string</returns>
    public string GetGameDescription()
    {
        nint ptr = Base.pfnGetGameDescription();
        return Marshal.PtrToStringUTF8(ptr) ?? string.Empty;
    }

    /// <summary>
    /// Notifies the DLL about a player customization (model, decals, etc.)
    /// </summary>
    /// <param name="pEntity">Player entity</param>
    /// <param name="pCustom">Customization data</param>
    public void PlayerCustomization(Edict pEntity, Customization pCustom) => Base.pfnPlayerCustomization(pEntity.GetNative(), pCustom.GetNative());

    /// <summary>
    /// Called when a spectator connects
    /// </summary>
    /// <param name="pEntity">Spectator entity</param>
    public void SpectatorConnect(Edict pEntity) => Base.pfnSpectatorConnect(pEntity.GetNative());
    
    /// <summary>
    /// Called when a spectator disconnects
    /// </summary>
    /// <param name="pEntity">Spectator entity</param>
    public void SpectatorDisconnect(Edict pEntity) => Base.pfnSpectatorDisconnect(pEntity.GetNative());
    
    /// <summary>
    /// Called every frame for spectators
    /// </summary>
    /// <param name="pEntity">Spectator entity</param>
    public void SpectatorThink(Edict pEntity) => Base.pfnSpectatorThink(pEntity.GetNative());

    /// <summary>
    /// Notifies the game DLL that the engine is shutting down (allows mod authors to set a breakpoint)
    /// </summary>
    /// <param name="error_string">Error message if shutdown is due to an error</param>
    public void SysError(string error_string)
    {
        nint ns = Marshal.StringToHGlobalAnsi(error_string);
        Base.pfnSysError(ns);
        Marshal.FreeHGlobal(ns);
    }

    /// <summary>
    /// Performs player movement simulation
    /// </summary>
    /// <param name="pm">Player movement structure</param>
    /// <param name="server">True if running on server, false if on client</param>
    public void PMMove(PlayerMove pm, bool server) => Base.pfnPMMove(pm.GetNative(), server ? 1 : 0);
    
    /// <summary>
    /// Initializes player movement structure
    /// </summary>
    /// <param name="pm">Player movement structure</param>
    public void PMInit(PlayerMove pm) => Base.pfnPMInit(pm.GetNative());

    /// <summary>
    /// Finds the texture type by name for footstep sounds
    /// </summary>
    /// <param name="name">Texture name</param>
    /// <returns>Texture type identifier</returns>
    public int PMFindTextureType(string name)
    {
        nint ns = Marshal.StringToHGlobalAnsi(name);
        int res = Base.pfnPMFindTextureType(ns);
        Marshal.FreeHGlobal(ns);
        return res;
    }

    /// <summary>
    /// Sets up visibility for a client (potentially visible set and potentially audible set)
    /// </summary>
    /// <param name="pViewEntity">Entity from which visibility is calculated</param>
    /// <param name="pClient">Client entity</param>
    /// <param name="pvs">Potentially visible set</param>
    /// <param name="pas">Potentially audible set</param>
    public void SetupVisibility(Edict pViewEntity, Edict pClient, ref byte[] pvs, ref byte[] pas)
    {
        unsafe
        {
            fixed (byte* ppvs = pvs)
            {
                fixed (byte* ppas = pas)
                {
                    Base.pfnSetupVisibility(pViewEntity.GetNative(), pClient.GetNative(), (nint)(&ppvs), (nint)(&ppas));
                }
            }
        }
    }

    /// <summary>
    /// Updates client-specific data before sending to the client
    /// </summary>
    /// <param name="ent">Client entity</param>
    /// <param name="sendweapons">Whether to send weapon data</param>
    /// <param name="cd">Client data structure</param>
    public void UpdateClientData(Edict ent, int sendweapons, ClientData cd) => Base.pfnUpdateClientData(ent.GetNative(), sendweapons, cd.GetNative());
    
    /// <summary>
    /// Adds entity state to the full pack for network transmission
    /// </summary>
    /// <param name="state">Entity state to fill</param>
    /// <param name="e">Entity index</param>
    /// <param name="ent">Entity to add</param>
    /// <param name="host">Host client entity</param>
    /// <param name="hostflags">Host flags</param>
    /// <param name="player">Whether this is a player entity</param>
    /// <param name="pSet">Visibility set</param>
    /// <returns>Non-zero if entity was added, zero otherwise</returns>
    public int AddToFullPack(EntityState state, int e, Edict ent, Edict host, int hostflags, int player, byte[] pSet)
    {
        int res = 0;
        unsafe
        {
            fixed (byte* ppSet = pSet)
            {
                res = Base.pfnAddToFullPack(state.GetNative(), e, ent.GetNative(), host.GetNative(), hostflags, player, (nint)ppSet);
            }
        }
        return res;
    }

    /// <summary>
    /// Creates a baseline for entity delta compression
    /// </summary>
    /// <param name="player">Whether this is a player entity</param>
    /// <param name="eindex">Entity index</param>
    /// <param name="baseline">Baseline state to fill</param>
    /// <param name="entity">Entity</param>
    /// <param name="playermodelindex">Player model index</param>
    /// <param name="player_mins">Player minimum bounds</param>
    /// <param name="player_maxs">Player maximum bounds</param>
    public void CreateBaseline(int player, int eindex, EntityState baseline, Edict entity, int playermodelindex, Vector3f player_mins, Vector3f player_maxs) => Base.pfnCreateBaseline(player, eindex, baseline.GetNative(), entity.GetNative(), playermodelindex, player_mins.GetNative(), player_maxs.GetNative());
    
    /// <summary>
    /// Registers custom network message encoders
    /// </summary>
    public void RegisterEncoders() => Base.pfnRegisterEncoders();
    
    /// <summary>
    /// Gets weapon data for a player
    /// </summary>
    /// <param name="player">Player entity</param>
    /// <param name="info">Weapon data structure to fill</param>
    /// <returns>Non-zero if successful</returns>
    public int GetWeaponData(Edict player, WeaponData info) => Base.pfnGetWeaponData(player.GetNative(), info.GetNative());
    
    /// <summary>
    /// Called when a client command starts
    /// </summary>
    /// <param name="plyer">Player entity</param>
    /// <param name="cmd">User command</param>
    /// <param name="random_seed">Random seed for prediction</param>
    public void CmdStart(Edict plyer, UserCmd cmd, uint random_seed) => Base.pfnCmdStart(plyer.GetNative(), cmd.GetNative(), random_seed);
    
    /// <summary>
    /// Called when a client command ends
    /// </summary>
    /// <param name="plyer">Player entity</param>
    public void CmdEnd(Edict plyer) => Base.pfnCmdEnd(plyer.GetNative());

    /// <summary>
    /// Handles a connectionless packet (server browser queries, etc.).
    /// Return 1 if the packet is valid. Set response_buffer_size if you want to send a response packet.
    /// </summary>
    /// <param name="net_from">Source network address</param>
    /// <param name="args">Packet arguments</param>
    /// <param name="response_buffer">Response buffer to fill</param>
    /// <param name="response_buffer_size">Maximum response buffer size (set to 0 if no response)</param>
    /// <returns>1 if packet is valid, 0 otherwise</returns>
    public int ConnectionlessPacket(NetAdr net_from, string args, ref string response_buffer, ref int response_buffer_size)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(args);
        nint ns2 = Marshal.AllocHGlobal(response_buffer_size);
        nint ni = Marshal.AllocHGlobal(sizeof(int));
        int res = Base.pfnConnectionlessPacket(net_from.GetNative(), ns1, ns2, ni);
        response_buffer = Marshal.PtrToStringUTF8(ns2) ?? string.Empty;
        response_buffer_size = Marshal.ReadInt32(ni);
        Marshal.FreeHGlobal(ni);
        Marshal.FreeHGlobal(ns2);
        Marshal.FreeHGlobal(ns1);
        return res;
    }

    /// <summary>
    /// Gets the bounding box for a player hull. Returns 0 if the hull number doesn't exist, 1 otherwise.
    /// </summary>
    /// <param name="hullnumber">Hull number (0-3)</param>
    /// <param name="mins">Minimum bounds output</param>
    /// <param name="maxs">Maximum bounds output</param>
    /// <returns>1 if hull exists, 0 otherwise</returns>
    public int GetHullBounds(int hullnumber, ref Vector3f mins, ref Vector3f maxs) => Base.pfnGetHullBounds(hullnumber, mins.GetNative(), maxs.GetNative());

    /// <summary>
    /// Creates baselines for certain "unplaced" items
    /// </summary>
    public void CreateInstancedBaselines() => Base.pfnCreateInstancedBaselines();

    /// <summary>
    /// Called when a file fails consistency check for a player.
    /// Return 0 to allow the client to continue, 1 to force immediate disconnection.
    /// </summary>
    /// <param name="player">Player entity</param>
    /// <param name="filename">File that failed consistency check</param>
    /// <param name="disconnect_message">Optional disconnect message (up to 256 characters)</param>
    /// <returns>0 to allow, 1 to disconnect</returns>
    public int InconsistentFile(Edict player, string filename, ref string disconnect_message)
    {
        nint ns1 = Marshal.StringToHGlobalAnsi(filename);
        nint ns2 = Marshal.AllocHGlobal(256 * sizeof(byte));
        for (int i = 0; i < Math.Min(disconnect_message.Length, 256); i++)
        {
            Marshal.WriteByte(ns2, i, (byte)disconnect_message[i]);
        }
        int res = Base.pfnInconsistentFile(player.GetNative(), ns1, ns2);
        disconnect_message = Marshal.PtrToStringUTF8(ns2) ?? string.Empty;
        Marshal.FreeHGlobal(ns2);
        Marshal.FreeHGlobal(ns1);
        return res;
    }

    /// <summary>
    /// Determines if lag compensation should be allowed (can also be controlled by sv_unlag cvar).
    /// Most games should return 0 until client-side weapon prediction is implemented and tested.
    /// </summary>
    /// <returns>1 to allow lag compensation, 0 otherwise</returns>
    int AllowLagCompensation() => Base.pfnAllowLagCompensation();
}
