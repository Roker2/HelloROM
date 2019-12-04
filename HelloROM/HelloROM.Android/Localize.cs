using System;
using Xamarin.Forms;
using System.Threading;
using System.Globalization;

[assembly:Dependency(typeof(HelloROM.Android.Localize))]

namespace HelloROM.Android
{
	public class Localize : HelloROM.ILocalize
	{
		public void SetLocale(CultureInfo ci)
		{
			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;

			Console.WriteLine("CurrentCulture set: " + ci.Name);
		}

		public CultureInfo GetCurrentCultureInfo()
		{
			object netLanguage = "en";
            object UseSystemLanguage;
            if (!App.Current.Properties.TryGetValue("UseSystemLanguage", out UseSystemLanguage))
            {
                UseSystemLanguage = true;
            }
            if (!(bool)UseSystemLanguage)
            {
                if (!App.Current.Properties.TryGetValue("netLanguage", out netLanguage))
                {
                    netLanguage = AndroidToDotnetLanguage(Java.Util.Locale.Default.ToString().Replace("_", "-"));
                    App.Current.Properties["netLanguage"] = netLanguage;
                }
            } else
            {
                netLanguage = AndroidToDotnetLanguage(Java.Util.Locale.Default.ToString().Replace("_", "-"));
                App.Current.Properties["netLanguage"] = netLanguage;
            }

            // this gets called a lot - try/catch can be expensive so consider caching or something
            System.Globalization.CultureInfo ci = null;
			try
			{
				ci = new System.Globalization.CultureInfo((string)netLanguage);
			}
			catch (CultureNotFoundException e1)
			{
				// iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
				// fallback to first characters, in this case "en"
				try
				{
					var fallback = ToDotnetFallbackLanguage(new PlatformCulture((string)netLanguage));
					Console.WriteLine((string)netLanguage + " failed, trying " + fallback + " (" + e1.Message + ")");
					ci = new System.Globalization.CultureInfo(fallback);
				}
				catch (CultureNotFoundException e2)
				{
					// iOS language not valid .NET culture, falling back to English
					Console.WriteLine((string)netLanguage + " couldn't be set, using 'en' (" + e2.Message + ")");
					ci = new System.Globalization.CultureInfo("en");
				}
			}

			return ci;
		}

		string AndroidToDotnetLanguage(string androidLanguage)
		{
			Console.WriteLine("Android Language:" + androidLanguage);
			var netLanguage = androidLanguage;

			//certain languages need to be converted to CultureInfo equivalent
			switch (androidLanguage)
			{
				case "in-ID":  // "Indonesian (Indonesia)" has different code in  .NET 
					netLanguage = "id-ID"; // correct code for .NET
					break;
				case "gsw-CH":  // "Schwiizertüütsch (Swiss German)" not supported .NET culture
					netLanguage = "de-CH"; // closest supported
					break;
					// add more application-specific cases here (if required)
					// ONLY use cultures that have been tested and known to work
			}

			Console.WriteLine(".NET Language/Locale:" + netLanguage);
			return netLanguage;
		}
		string ToDotnetFallbackLanguage(PlatformCulture platCulture)
		{
			Console.WriteLine(".NET Fallback Language:" + platCulture.LanguageCode);
			var netLanguage = platCulture.LanguageCode; // use the first part of the identifier (two chars, usually);

			switch (platCulture.LanguageCode)
			{
				case "gsw":
					netLanguage = "de-CH"; // equivalent to German (Switzerland) for this app
					break;
					// add more application-specific cases here (if required)
					// ONLY use cultures that have been tested and known to work
			}

			Console.WriteLine(".NET Fallback Language/Locale:" + netLanguage + " (application-specific)");
			return netLanguage;
		}


	}
}
