using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPlugins.TLobbyEditor.Compability
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string self, string string2)
        {
            return self.ToLower() == string2.ToLower();
        }

        public static bool ContainsIgnoreCase(this string self, string string2)
        {
            return self.ToLower().Contains(string2.ToLower());
        }

        public static string GetString(this string[] array, string separator = "")
        {
            string s = "";
            foreach (string i in array)
            {
                s += i + separator;
            }
            return s;
        }
    }
}
