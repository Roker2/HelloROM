using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloROM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsMenu : ContentPage
	{
		public SettingsMenu()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            object objUseMobileConnection;
            if (!App.Current.Properties.TryGetValue("UseMobileConnection", out objUseMobileConnection))
            {
                objUseMobileConnection = true;
            }
            UseMobileConnection.On = (bool)objUseMobileConnection;
            base.OnAppearing();
        }

        private void UseMobileInternet_OnChanged(object sender, ToggledEventArgs e)
        {
            App.Current.Properties["UseMobileConnection"] = e.Value;
        }
    }
}