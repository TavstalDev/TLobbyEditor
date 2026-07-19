using Rocket.API;
using Rocket.Unturned.Permissions;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Text;
using Tavstal.TLibrary.Extensions;
using Tavstal.TLibrary.Models.Logging;
using Tavstal.TLibrary.Models.Plugin;
using Tavstal.TLobbyEditor.Helpers;

namespace Tavstal.TLobbyEditor
{
    /// <summary>
    /// Represents a plugin for the lobby editor, inheriting from <see cref="PluginBase{TLobbyEditorConfiguration}"/>.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class TLobbyEditor : PluginBase<LobbyEditorConfiguration>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="TLobbyEditor"/> plugin.
        /// </summary>
        public static TLobbyEditor Instance { get; private set; } = null!;

        /// <summary>
        /// Called before the plugin is loaded. Sets the singleton instance and prints the plugin banner to the console.
        /// </summary>
        public override void OnPreLoad()
        {
            Instance = this;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("────────────────────────────────────────────────────────");
            sb.AppendLine();
            sb.AppendLine("████████╗██╗      ██████╗ ██████╗ ██████╗ ██╗   ██╗");
            sb.AppendLine("╚══██╔══╝██║     ██╔═══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝");
            sb.AppendLine("   ██║   ██║     ██║   ██║██████╔╝██████╔╝ ╚████╔╝ ");
            sb.AppendLine("   ██║   ██║     ██║   ██║██╔══██╗██╔══██╗  ╚██╔╝  ");
            sb.AppendLine("   ██║   ███████╗╚██████╔╝██████╔╝██████╔╝   ██║   ");
            sb.AppendLine("   ╚═╝   ╚══════╝ ╚═════╝ ╚═════╝ ╚═════╝    ╚═╝   ");
            sb.AppendLine();
            sb.AppendLine("[ About ]");
            sb.AppendLine(" ▸ Developer : Tavstal");
            sb.AppendLine(" ▸ Discord   : @Tavstal");
            sb.AppendLine(" ▸ Website   : https://redstoneplugins.com");
            sb.AppendLine(" ▸ GitHub    : https://github.com/TavstalDev");
            sb.AppendLine();
            sb.AppendLine("[ Build ]");
            sb.AppendLine($" ▸ Version   : {Version}");
            sb.AppendLine($" ▸ Build Date: {BuildDate} UTC");
            sb.AppendLine($" ▸ TLibrary  : {LibraryVersion}");
            sb.AppendLine();
            sb.AppendLine("[ Support ]");
            sb.AppendLine(" ▸ Report issues or request features:");
            sb.AppendLine(" ▸ https://github.com/TavstalDev/TLobbyEditor/issues");
            sb.AppendLine();
            sb.AppendLine("────────────────────────────────────────────────────────");
            Logger.Log(ELogLevel.COMMAND, sb.ToString(), includePrefixes: false, color:  ConsoleColor.Cyan);
        }
        
        /// <summary>
        /// Called when the plugin is loaded. Initializes the necessary resources and configurations for the plugin.
        /// </summary>
        public override void OnLoad()
        {
            UnturnedPermissions.OnJoinRequested += OnPlayerConnectPending;
            Level.onPostLevelLoaded += OnPostLevelLoaded;
            ModifyHelper.Apply();
            
            Logger.Info($"# {GetPluginName()} has been loaded.");
            Logger.Info("# Starting late initialization...");
        }

        /// <summary>
        /// Called when the plugin is unloaded. Cleans up resources and event handlers used by the plugin.
        /// </summary>
        public override void OnUnLoad()
        {
            UnturnedPermissions.OnJoinRequested -= OnPlayerConnectPending;
            Level.onPostLevelLoaded -= OnPostLevelLoaded;

            Logger.Info($"# {GetPluginName()} has been successfully unloaded.");
        }

        /// <summary>
        /// Initializes the lobby modification process after the level is loaded.
        /// </summary>
        /// <param name="level">The level index or identifier that indicates when to start the modification process.</param>
        private void OnPostLevelLoaded(int level) => ModifyHelper.Apply();

        /// <summary>
        /// Called when a player is attempting to connect to the server, but their connection is still pending.
        /// </summary>
        /// <param name="steamId">The Steam ID of the player attempting to connect.</param>
        /// <param name="rejectionReason">The reason for rejecting the player's connection, if applicable. This is passed by reference and can be modified.</param>
        private void OnPlayerConnectPending(CSteamID steamId, ref ESteamRejection? rejectionReason)
        {
            if (!Config.ReservedSlots.Enable)
                return;
            
            if (Provider.clients.Count < Config.ReservedSlots.DefaultSlots)
                return;
            
            UnturnedPlayer player = UnturnedPlayer.FromCSteamID(steamId);
            if (Config.ReservedSlots.RequirePermission && !player.HasPermission(Config.ReservedSlots.Permission))
                rejectionReason = ESteamRejection.SERVER_FULL;
        }
    }
}