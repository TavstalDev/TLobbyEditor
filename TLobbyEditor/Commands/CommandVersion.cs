using Rocket.API;
using System.Collections.Generic;
using System.Reflection;
using Tavstal.TLibrary.Helpers.Unturned;

namespace Tavstal.TLobbyEditor.Commands
{
    public class CommandVersion : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;
        public string Name => ("v" + Assembly.GetExecutingAssembly().GetName().Name);
        public string Help => "Gets the version of the plugin";
        public string Syntax => "";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string> { "tshop.version" };


        public void Execute(IRocketPlayer caller, string[] command)
        {
            UChatHelper.SendPlainCommandReply(TLobbyEditor.Instance, caller, "#########################################");
            UChatHelper.SendPlainCommandReply(TLobbyEditor.Instance, caller, $"# Build Version: {TLobbyEditor.Version}");
            UChatHelper.SendPlainCommandReply(TLobbyEditor.Instance, caller, $"# Build Date: {TLobbyEditor.BuildDate}");
            UChatHelper.SendPlainCommandReply(TLobbyEditor.Instance, caller, "#########################################");
        }
    }
}
