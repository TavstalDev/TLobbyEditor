using Rocket.API;
using Rocket.Core;
using Rocket.Unturned.Permissions;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Tavstal.TLibrary.Models.Plugin;
using Tavstal.TLobbyEditor.Models;
using Tavstal.TLobbyEditor.Helpers;

namespace Tavstal.TLobbyEditor
{
    public class TLobbyEditor : PluginBase<TLobbyEditorConfiguration>
    {
        public new static TLobbyEditor Instance { get; private set; }

        public override void OnLoad()
        {
            Instance = this;
            Level.onPostLevelLoaded += LateInit;
            if (Level.isLoaded)
                StartModifyingLobbyInfo();

            Logger.LogWarning("████████╗██╗      ██████╗ ██████╗ ██████╗ ██╗   ██╗");
            Logger.LogWarning("╚══██╔══╝██║     ██╔═══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝");
            Logger.LogWarning("   ██║   ██║     ██║   ██║██████╔╝██████╔╝ ╚████╔╝ ");
            Logger.LogWarning("   ██║   ██║     ██║   ██║██╔══██╗██╔══██╗  ╚██╔╝  ");
            Logger.LogWarning("   ██║   ███████╗╚██████╔╝██████╔╝██████╔╝   ██║   ");
            Logger.LogWarning("   ╚═╝   ╚══════╝ ╚═════╝ ╚═════╝ ╚═════╝    ╚═╝   ");
            Logger.Log("#########################################");
            Logger.Log("# Thanks for using my plugin");
            Logger.Log("# Plugin Created By Tavstal");
            Logger.Log("# Discord: Tavstal#6189");
            Logger.Log("# Website: https://redstoneplugins.com");
            Logger.Log("# Discord: https://discord.gg/redstoneplugins");
            Logger.Log("#########################################");
            Logger.Log($"# Build Version: {Version}");
            Logger.Log($"# Build Date: {BuildDate}");
            Logger.Log("#########################################");
        }

        public override void OnUnLoad()
        {
            UnturnedPermissions.OnJoinRequested -= Event_OnPlayerConnectPending;
            Level.onPostLevelLoaded -= LateInit;

            Logger.Log("TLobbyEdtior has been successfully unloaded");
        }

        private void LateInit(int level) => StartModifyingLobbyInfo();

        private void StartModifyingLobbyInfo() => new Thread(Modify).Start();

        private void Modify()
        {
            try
            {
                InvokeAction(1f, () => 
                {
                    if (Config.HideRocket)
                        SteamGameServer.SetBotPlayerCount(0);
                    if (Config.ReservedSlots.Enable)
                        SteamGameServer.SetMaxPlayerCount(Config.ReservedSlots.DefaultSlots + Config.ReservedSlots.MaxReservedSlots);
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
                        SteamGameServer.SetKeyValue("Cfg_Count", LobbyHelpers.GetConfigurationCount().ToString());
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
                        SteamGameServer.SetKeyValue("Mod_Count", LobbyHelpers.GetWorkshopCount().ToString());
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

                    string difficulty;

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

                    string cameraMode;
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
                });
                
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in Modify: " + ex);
            }
        }

        private void Event_OnPlayerConnectPending(CSteamID steamid, ref ESteamRejection? rejectionReason)
        {
            SteamPending pending = Provider.pending.Find(x => x.playerID.steamID == steamid);
            UnturnedPlayer player = UnturnedPlayer.FromCSteamID(steamid);

            if (Config.ReservedSlots.Enable)
            {
                if (Provider.clients.Count < Config.ReservedSlots.DefaultSlots)
                    return;

                if (Config.ReservedSlots.RequirePermission && !player.HasPermission(Config.ReservedSlots.Permission))
                    rejectionReason = ESteamRejection.SERVER_FULL;
            }
        }
    }
}
