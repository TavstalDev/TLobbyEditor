using Rocket.API;
using System.Collections.Generic;
using System.Reflection;
using Tavstal.TLibrary.Helpers.Unturned;
// ReSharper disable UnusedType.Global

namespace Tavstal.TLobbyEditor.Commands
{
    /// <summary>
    /// Represents the version command that displays the plugin's build version and date.
    /// </summary>
    public class CommandVersion : IRocketCommand
    {
        /// <inheritdoc />
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        /// <inheritdoc />
        public string Name => ("v" + Assembly.GetExecutingAssembly().GetName().Name);

        /// <inheritdoc />
        public string Help => "Gets the version of the plugin";

        /// <inheritdoc />
        public string Syntax => "";

        /// <inheritdoc />
        public List<string> Aliases => new List<string>();

        /// <inheritdoc />
        public List<string> Permissions => new List<string> { "tlobbyeditor.version", "tlobbyeditor.commands.version" };

        /// <summary>
        /// Executes the version command, displaying the plugin's build version and build date to the caller.
        /// </summary>
        /// <param name="caller">The player or console executing the command.</param>
        /// <param name="command">The command arguments (unused).</param>
        public void Execute(IRocketPlayer caller, string[] command)
        {
            TLobbyEditor.Instance.SendPlainCommandReply(caller, "#########################################");
            TLobbyEditor.Instance.SendPlainCommandReply(caller, $"# Build Version: {TLobbyEditor.Version}");
            TLobbyEditor.Instance.SendPlainCommandReply(caller, $"# Build Date: {TLobbyEditor.BuildDate}");
            TLobbyEditor.Instance.SendPlainCommandReply(caller, "#########################################");
        }
    }
}
