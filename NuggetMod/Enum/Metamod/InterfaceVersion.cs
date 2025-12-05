namespace NuggetMod.Enum.NuggetMod;

/// <summary>
/// Represents the Metamod plugin interface version. Version consists of "major:minor", two separate integer numbers.
/// </summary>
public enum InterfaceVersion
{
    /// <summary>
    /// Version 1 - original.
    /// </summary>
    V1,
    /// <summary>
    /// Version 2 - added plugin_info_t **pinfo.
    /// </summary>
    V2,
    /// <summary>
    /// Version 3 - init split into query and attach, added detach.
    /// </summary>
    V3,
    /// <summary>
    /// Version 4 - added (PLUG_LOADTIME now) to attach.
    /// </summary>
    V4,
    /// <summary>
    /// Version 5 - changed mm ifvers int* to string, moved pl ifvers to info.
    /// </summary>
    V5,
    /// <summary>
    /// Version 5:1 - added link support for entity "adminmod_timer" (adminmod).
    /// </summary>
    V5_1,
    /// <summary>
    /// Version 5:2 - added gamedll_funcs to meta_attach() [v1.0-rc2].
    /// </summary>
    V5_2,
    /// <summary>
    /// Version 5:3 - added mutil_funcs to meta_query() [v1.05].
    /// </summary>
    V5_3,
    /// <summary>
    /// Version 5:4 - added centersay utility functions [v1.06].
    /// </summary>
    V5_4,
    /// <summary>
    /// Version 5:5 - added Meta_Init to plugin API [v1.08].
    /// </summary>
    V5_5,
    /// <summary>
    /// Version 5:6 - added CallGameEntity utility function [v1.09].
    /// </summary>
    V5_6,
    /// <summary>
    /// Version 5:7 - added GetUserMsgID, GetUserMsgName util funcs [v1.11].
    /// </summary>
    V5_7,
    /// <summary>
    /// Version 5:8 - added GetPluginPath [v1.11].
    /// </summary>
    V5_8,
    /// <summary>
    /// Version 5:9 - added GetGameInfo [v1.14].
    /// </summary>
    V5_9,
    /// <summary>
    /// Version 5:10 - added GINFO_REALDLL_FULLPATH for GetGameInfo [v1.17].
    /// </summary>
    V5_10,
    /// <summary>
    /// Version 5:11 - added plugin loading and unloading API [v1.18].
    /// </summary>
    V5_11,
    /// <summary>
    /// Version 5:12 - added IS_QUERYING_CLIENT_CVAR to mutils [v1.18].
    /// </summary>
    V5_12,
    /// <summary>
    /// Version 5:13 - added MAKE_REQUESTID and GET_HOOK_TABLES to mutils [v1.19].
    /// </summary>
    V5_13,
    /// <summary>
    /// Version 5:14 - added Binary Analysis and InlineHook to mutils by hzqst.
    /// </summary>
    V5_14,
    /// <summary>
    /// Version 5:15 - added EngineStudioAPI, rotationmatrix and bonematrix to mutils by hzqst.
    /// </summary>
    V5_15,
    /// <summary>
    /// Version 5:16 - added GetEngineType to mutils by hzqst.
    /// </summary>
    V5_16
}
