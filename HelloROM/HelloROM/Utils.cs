using System.Resources;
using System.Collections.Generic;
using System.Text;

namespace HelloROM
{
    public static class Utils
    {
        static string GetLanguage()
        {
            object netLanguage;
            if (!App.Current.Properties.TryGetValue("netLanguage", out netLanguage))
            {
                return "en";
            }
            return (string)netLanguage;
        }

        public static string GetTranslation(string name)
        {
            string netLanguage = GetLanguage();
            ResourceManager rm = new ResourceManager("HelloROM.Translations.Translation", typeof(Translations.Translation).Assembly);
            return rm.GetString(name, new System.Globalization.CultureInfo(netLanguage));
        }

        public static string GetError(string name)
        {
            string netLanguage = GetLanguage();
            ResourceManager rm = new ResourceManager("HelloROM.Translations.Errors", typeof(Translations.Translation).Assembly);
            return rm.GetString(name, new System.Globalization.CultureInfo(netLanguage));
        }
    }
}
