using System.Resources;
using System.Collections.Generic;
using System.Text;

namespace HelloROM
{
    public static class Utils
    {
        public static string GetTranslation(string name)
        {
            object netLanguage;
            if (!App.Current.Properties.TryGetValue("netLanguage", out netLanguage))
            {
                netLanguage = "en";
            }
            ResourceManager rm = new ResourceManager("HelloROM.Translations.Translation", typeof(Translations.Translation).Assembly);
            return rm.GetString(name, new System.Globalization.CultureInfo((string)netLanguage));
        }
    }
}
