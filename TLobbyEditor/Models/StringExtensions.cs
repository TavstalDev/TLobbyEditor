namespace Tavstal.TLobbyEditor.Models
{
    public static class StringExtensions
    {
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
