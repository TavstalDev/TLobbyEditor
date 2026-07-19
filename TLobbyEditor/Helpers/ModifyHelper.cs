using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Rocket.Core;
using SDG.Unturned;
using Steamworks;
using Tavstal.TLibrary.Extensions;

namespace Tavstal.TLobbyEditor.Helpers
{
    /// <summary>
    /// Provides methods to apply lobby modifications to the Steam Game Server based on the plugin configuration.
    /// </summary>
    public static class ModifyHelper
    {
        /// <summary>
        /// Gets the current plugin configuration.
        /// </summary>
        private static LobbyEditorConfiguration Config => TLobbyEditor.Instance.Config;
        
        /// <summary>
        /// Applies all lobby modifications including player list, config, workshop, plugins, tags, and description.
        /// </summary>
        public static void Apply()
        {
            try
            {
                ApplyPlayerList();
                ApplyConfig();
                ApplyWorkshop();
                ApplyPlugins();
                ApplyTags();
                ApplyDescription();
                ApplyLinks();
                ApplyImages();
            }
            catch (Exception ex)
            {
                TLobbyEditor.Logger.Error("Failed to apply lobby modifies.", ex);
            }
        }

        /// <summary>
        /// Applies player list modifications including bot count, max player count, and server advertisement.
        /// </summary>
        public static void ApplyPlayerList()
        {
            try
            {
                if (Config.Masking.HideRocket)
                    SteamGameServer.SetBotPlayerCount(0);
                if (Config.ReservedSlots.Enable)
                    SteamGameServer.SetMaxPlayerCount(Config.ReservedSlots.DefaultSlots +
                                                      Config.ReservedSlots.MaxReservedSlots);
                SteamGameServer.SetAdvertiseServerActive(Config.Identity.ShouldAdvertiseServer);
            }
            catch (Exception ex)
            {
                TLobbyEditor.Logger.Error("Failed to apply player list modifies.", ex);
            }
        }
        
        /// <summary>
        /// Applies config entries to the server browser, hiding, replacing, or showing the real values.
        /// </summary>
        public static void ApplyConfig()
        {
            try
            {
                if (Config.Masking.HideConfig)
                {
                    SteamGameServer.SetKeyValue("Cfg_Count", "0");
                    return;
                }

                if (Config.CustomData.MessConfig)
                {
                    SteamGameServer.SetKeyValue("Cfg_Count", Config.CustomData.Config.Length.ToString());
                    for (int i = 0; i < Config.CustomData.Config.Length; i++)
                    {
                        string pKey = "Cfg_" + i.ToString(CultureInfo.InvariantCulture);
                        SteamGameServer.SetKeyValue(pKey, Config.CustomData.Config[i]);
                    }

                    return;
                }

                SteamGameServer.SetKeyValue("Cfg_Count", LobbyHelpers.GetConfigurationCount().ToString());
            }
            catch (Exception ex)
            {
                TLobbyEditor.Logger.Error("Failed to apply config modifies.", ex);
            }
        }
        
        /// <summary>
        /// Applies workshop item information to the server browser, hiding, replacing, or showing the real values.
        /// </summary>
        public static void ApplyWorkshop()
        {
            try
            {
                if (Config.Masking.HideWorkshop)
                {
                    SteamGameServer.SetKeyValue("Mod_Count", "0");
                    return;
                }

                if (Config.CustomData.MessWorkshop)
                {
                    SteamGameServer.SetKeyValue("Mod_Count", Config.CustomData.Workshop.Length.ToString());
                    for (int i = 0; i < Config.CustomData.Workshop.Length; i++)
                    {
                        string pKey = "Mod_Line_" + i.ToString(CultureInfo.InvariantCulture);
                        SteamGameServer.SetKeyValue(pKey, Config.CustomData.Workshop[i]);
                    }

                    return;
                }

                SteamGameServer.SetKeyValue("Mod_Count", LobbyHelpers.GetWorkshopCount().ToString());
            }
            catch (Exception ex)
            {
                TLobbyEditor.Logger.Error("Failed to apply workshop modifies.", ex);
            }
        }

        /// <summary>
        /// Applies plugin information to the server browser, hiding, replacing, or showing the real plugin names.
        /// </summary>
        public static void ApplyPlugins()
        {
            try
            {
                if (Config.Masking.HidePlugins)
                {
                    SteamGameServer.SetKeyValue("rocketplugins", "0");
                    return;
                }

                if (Config.CustomData.MessPlugins)
                {
                    SteamGameServer.SetKeyValue("rocketplugins", string.Join(",", Config.CustomData.Plugins));
                    return;
                }

                SteamGameServer.SetKeyValue("rocketplugins",
                    string.Join(",", R.Plugins.GetPlugins().Select(p => p.Name).ToArray()));
            }
            catch (Exception ex)
            {
                TLobbyEditor.Logger.Error("Failed to apply plugin modifies.", ex);
            }
        }
        
        /// <summary>
        /// Applies game tags to the server browser including PVP/PVE, gamemode, difficulty, camera mode, and other settings.
        /// </summary>
        public static void ApplyTags()
        {
            try
            {
                #region Difficulty

                string difficulty;
                switch (Config.Identity.Difficulty.ToUpperInvariant())
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
                switch (Config.Identity.CameraMode.ToUpperInvariant())
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

                List<string> tags = new List<string>
                {
                    Config.Identity.IsPvp ? "PVP" : "PVE",
                    Config.CustomData.MessGamemode
                        ? $"<gm>{Config.CustomData.Gamemode}</gm>"
                        : $"<gm>{Provider.gameMode.GetType().Name}</gm>",
                    Config.Identity.HasCheats ? "CHy" : "CHn",
                    difficulty,
                    cameraMode,
                    !Config.Masking.HideWorkshop ? "WSy" : "WSn",
                    Config.Identity.GoldOnly ? "GLD" : "F2P",
                    Config.Identity.HasBattleEye ? "BEy" : "BEn"
                };

                if (Config.Informational.MessThumbnail)
                {
                    if (Config.Informational.BrowserIcon.Length > 128)
                        TLobbyEditor.Logger.Warning("The thumbnail is longer than 128 characters, it might not appear.");
                    tags.Add($"<tn>{Config.Informational.Thumbnail}</tn>");
                }
                else if (!string.IsNullOrEmpty(Provider.configData.Browser.Thumbnail))
                    tags.Add($"<tn>{Provider.configData.Browser.Thumbnail}</tn>");

                SteamGameServer.SetGameTags(string.Join(",", tags));
            }
            catch (Exception ex)
            {
                TLobbyEditor.Logger.Error("Failed to apply tag modifies.", ex);
            }
        }

        /// <summary>
        /// Applies server description information to the server browser including the short description, hint, and full description.
        /// </summary>
        public static void ApplyDescription()
        {
            try
            {
                if (Config.Informational.MessDescription)
                    SteamGameServer.SetGameDescription(Config.Informational.Description);
                if (Config.Informational.MessBrowserDescription)
                    SteamGameServer.SetKeyValue("Browser_Desc_Hint", Config.Informational.BrowserDescription);
                
                if (!Config.Informational.MessDescriptionFull)
                    return;
                
                var browser = Provider.configData.Browser;
                if (Config.Informational.DescriptionFull.Count == 0)
                {
                    browser.Desc_Full = string.Empty;
                    return;
                }

                browser.Desc_Full = string.Join(System.Environment.NewLine, Config.Informational.DescriptionFull);
            }
            catch (Exception ex)
            {
                TLobbyEditor.Logger.Error("Failed to apply description modifies.", ex);
            }
        }
        

        public static void ApplyLinks()
        {
            try
            {
                if (!Config.Informational.MessLinks)
                    return;
                
                var browser = Provider.configData.Browser;
                browser.Links = new BrowserConfigData.Link[Config.Informational.Links.Count];
                for (int i = 0; i < Config.Informational.Links.Count; i++)
                {
                    var value = Config.Informational.Links[i];
                    browser.Links[i] = new BrowserConfigData.Link
                    {
                        Message = value.Message,
                        Url = value.Url,
                    };
                }
            }
            catch (Exception ex)
            {
                TLobbyEditor.Logger.Error("Failed to apply links modifies.", ex);
            }
        }

        /// <summary>
        /// Sets the server's browser icon via Steam key-value. Skipped if disabled, warns if the icon URL exceeds 128 characters.
        /// </summary>
        public static void ApplyImages()
        {
            try
            {
                if (!Config.Informational.MessBrowserIcon)
                    return;
                
                if (Config.Informational.BrowserIcon.Length > 128)
                    TLobbyEditor.Logger.Warning("The browser icon is longer than 128 characters, it might not appear.");
                
                SteamGameServer.SetKeyValue("Browser_Icon",  Config.Informational.BrowserIcon);
            }
            catch (Exception ex)
            {
                TLobbyEditor.Logger.Error("Failed to apply images modifies.", ex);
            }
        }
    }
}