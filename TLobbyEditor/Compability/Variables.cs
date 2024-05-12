using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPlugins.TLobbyEditor.Compability
{
    [Serializable]
    public class ReservedSlots
    {
        public bool Enable { get; set; }
        public bool RequirePermission { get; set; }
        public string Permission { get; set; }
        public int DefaultSlots { get; set; }
        public int MaxReservedSlots { get; set; }

        public ReservedSlots() { }
    }
}
