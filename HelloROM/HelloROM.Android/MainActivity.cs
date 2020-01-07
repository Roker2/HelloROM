using System;

using Android.App;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Platform;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace HelloROM.Droid
{
    [Activity(Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            CachedImageRenderer.Init(true);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            MobileAds.Initialize(ApplicationContext, "ca-app-pub-7279205474652160~2424812542");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
#if DEBUG
            Console.WriteLine("DeviceID: " + Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId));
#endif
            LoadApplication(new App());
        }
    }
}