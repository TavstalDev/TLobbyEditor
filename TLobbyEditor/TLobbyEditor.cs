#region References
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using Rocket.Core;
using Rocket.Core.Plugins;
using SDG.Unturned;
using SDG.Framework.Modules;
using Steamworks;
using Rocket.Unturned;
using Rocket.Unturned.Permissions;
using Rocket.Unturned.Player;
using UnityEngine;
using Logger = TPlugins.TLobbyEditor.Logger;
using System.Globalization;
using Rocket.API;
using Rocket.API.Collections;
using Rocket.Unturned.Chat;
using Rocket.Core.Permissions;
using Rocket.API.Serialisation;
using Rocket.Core.Commands;
using System.Text.RegularExpressions;
using Rocket.Unturned.Events;
using System.IO;
using UnityEngine.Networking;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using SDG.Provider.Services.Matchmaking;
using SDG.SteamworksProvider;
using TPlugins.TLobbyEditor.Compability;
#endregion

namespace TPlugins.TLobbyEditor
{
    public class TLobbyEditor : RocketPlugin<TLobbyEditorConfiguration>
    {
        public const string PluginName = "TLobbyEditor";
        public const string PluginAuthor = "Tavstal";
        public const string PluginCompany = "TPlugins";
        public const string PluginCopyright = "Copyright © TPlugins 2022";
        public const string PluginDescription = "This plugin has been made for the Unturfield server network.";
        public const string Version = "1.0.0.0";

        public static TLobbyEditor Instance { get; set; }
        public static TLobbyEditorConfiguration Config { get; set; }

        protected override void Load()
        {
            Instance = this;
            Config = Configuration.Instance;

            U.Events.OnPlayerConnected += Event_OnPlayerConnected;
            U.Events.OnPlayerDisconnected += Event_OnPlayerDisconnected;
            LateInit(1);
            //UnturnedPermissions.OnJoinRequested += Event_OnPlayerConnectPending;

            Level.onPostLevelLoaded += LateInit;
            if (Level.isLoaded)
                StartModifyingLobbyInfo();

            Logger.Log("##################################################");
            Logger.Log("#            Thanks for using my plugin          #");
            Logger.Log("#            Plugin Created By Tavstal           #");
            Logger.Log("#              Discord: Tavstal#6189             #");
            Logger.Log("#      Website: https://redstoneplugins.com      #");
            Logger.Log("#                Version: " + Version + "                #");
            Logger.Log("##################################################");
            Logger.Log("");
            Logger.Log("TLobbyEdtior has been successfully loaded");
        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Event_OnPlayerConnected;
            U.Events.OnPlayerDisconnected -= Event_OnPlayerDisconnected;
            UnturnedPermissions.OnJoinRequested -= Event_OnPlayerConnectPending;

            //Level.onPostLevelLoaded -= LateInit;

            Logger.Log("TLobbyEdtior has been successfully unloaded");
        }

        protected void LateInit(int level) => StartModifyingLobbyInfo();

        private void StartModifyingLobbyInfo() => new Thread(Modify).Start();

        private void Modify()
        {
            try
            {
                StartCoroutine(DelayedInvoke(1f, () => 
                {
                    if (Config.HideRocket)
                        SteamGameServer.SetBotPlayerCount(0);
                    if (Config.reservedSlots.Enable)
                        SteamGameServer.SetMaxPlayerCount(Config.reservedSlots.DefaultSlots + Config.reservedSlots.MaxReservedSlots);
                    SteamGameServer.SetAdvertiseServerActive(Config.ShouldAdversiteServer);

                    #region Config
                    if (Config.HideConfig)
                        SteamGameServer.SetKeyValue("Cfg_Count", "0");
                    else if (Config.MessConfig)
                    {
                        SteamGameServer.SetKeyValue("Cfg_Count", Config.Config.Length.ToString());

                        for (int i = 0; i < Config.Config.Length; i++)
                        {
                            string pKey = "Cfg_" + i.ToString(CultureInfo.InvariantCulture);
                            SteamGameServer.SetKeyValue(pKey, Config.Config[i]);
                        }
                    }
                    else
                        SteamGameServer.SetKeyValue("Cfg_Count", Helpers.GetConfigurationCount().ToString());
                    #endregion
                    #region Workshop
                    if (Config.HideWorkshop)
                        SteamGameServer.SetKeyValue("Mod_Count", "0");
                    else if (Config.MessWorkshop)
                    {
                        SteamGameServer.SetKeyValue("Mod_Count", Config.Workshop.Length.ToString());

                        for (int i = 0; i < Config.Workshop.Length; i++)
                        {
                            string pKey = "Mod_Line_" + i.ToString(CultureInfo.InvariantCulture);
                            SteamGameServer.SetKeyValue(pKey, Config.Workshop[i]);
                        }
                    }
                    else
                        SteamGameServer.SetKeyValue("Mod_Count", Helpers.GetWorkshopCount().ToString());
                    #endregion
                    #region Plugins 
                    if (Config.HidePlugins)
                        SteamGameServer.SetKeyValue("rocketplugins", "0");
                    else if (Config.MessPlugins)
                    {
                        SteamGameServer.SetKeyValue("rocketplugins", Config.Plugins.GetString(","));
                    }
                    else
                        SteamGameServer.SetKeyValue("rocketplugins", string.Join(",", R.Plugins.GetPlugins().Select(p => p.Name).ToArray()));
                    #endregion

                    #region Tags
                    #region Difficulty
                    string difficulty = "NRM";

                    string configDifficulty = Config.Difficulty.ToUpperInvariant();
                    switch (configDifficulty)
                    {
                        case "NRM":
                        case "NORMAL":
                            difficulty = "NRM";
                            break;
                        case "HARD":
                        case "HRD":
                            difficulty = "HRD";
                            break;
                        case "EZY":
                        case "EASY":
                            difficulty = "EZY";
                            break;
                        default:
                            difficulty = "NRM";
                            break;
                    }
                    #endregion

                    #region CameraMode
                    string cameraMode = "2Pp";
                    string configCameraMode = Config.CameraMode.ToUpperInvariant();
                    switch (configCameraMode.ToUpper())
                    {
                        case "FIRST":
                        case "1PP":
                            cameraMode = "1Pp";
                            break;
                        case "BOTH":
                        case "2PP":
                            cameraMode = "2Pp";
                            break;
                        case "THIRD":
                        case "3PP":
                            cameraMode = "3Pp";
                            break;
                        case "VEHICLE":
                        case "4PP":
                            cameraMode = "4Pp";
                            break;
                        default:
                            cameraMode = "2Pp";
                            break;
                    }
                    #endregion

                    string tags = "";
                    tags += String.Concat(new string[]
                    {
                    Config.IsPVP ? "PVP" : "PVE",
                    ",<gm>",
                    Config.MessGamemode ? Config.Gamemode : Provider.gameMode.GetType().Name,
                    "</gm>,",
                    Config.HasCheats ? "CHy" : "CHn",
                    ",",
                    difficulty,
                    ",",
                    cameraMode,
                    ",",
                    !Config.HideWorkshop ? "WSy" : "WSn",
                    ",",
                    Config.GoldOnly ? "GLD" : "F2P",
                    ",",
                    Config.HasBattleye ? "BEy" : "BEn"
                    });

                    if (!String.IsNullOrEmpty(Provider.configData.Browser.Thumbnail))
                        tags += ",<tn>" + Provider.configData.Browser.Thumbnail + "</tn>";

                    SteamGameServer.SetGameTags(tags);
                    #endregion

                    #region Description
                    SteamGameServer.SetGameDescription(Config.Description);
                    SteamGameServer.SetKeyValue("Browser_Desc_Hint", Config.DescriptionHint);
                    if (Config.DescriptionFull.Length == 0)
                    {
                        SteamGameServer.SetKeyValue("Browser_Desc_Full_Count", "0");
                        SteamGameServer.SetKeyValue("Browser_Desc_Full_Line_0", String.Empty);
                    }
                    else
                    {
                        SteamGameServer.SetKeyValue("Browser_Desc_Full_Count", Config.DescriptionFull.Length.ToString());

                        for (int i = 0; i < Config.DescriptionFull.Length; i++)
                        {
                            SteamGameServer.SetKeyValue("Browser_Desc_Full_Line_" + i, Config.DescriptionFull[i] + System.Environment.NewLine);
                        }
                    }

                    
                    #endregion
                }));
                
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in Modify: " + ex);
            }
        }

        public static IEnumerator DelayedInvoke(float time, System.Action action)
        {
            yield return new WaitForSeconds(time);
            action();
        }

        private void Event_OnPlayerConnected(UnturnedPlayer player)
        {
           
        }

        private void Event_OnPlayerDisconnected(UnturnedPlayer player)
        { 

        }

        private void Event_OnPlayerConnectPending(CSteamID steamid, ref ESteamRejection? rejectionReason)
        {
            SteamPending pending = Provider.pending.Find(x => x.playerID.steamID == steamid);
            UnturnedPlayer player = UnturnedPlayer.FromCSteamID(steamid);

            if (Config.reservedSlots.Enable)
            {
                if (Provider.clients.Count < Config.reservedSlots.DefaultSlots)
                    return;

                if (Config.reservedSlots.RequirePermission && !player.HasPermission(Config.reservedSlots.Permission))
                    rejectionReason = ESteamRejection.SERVER_FULL;
            }
        }
    }
}
