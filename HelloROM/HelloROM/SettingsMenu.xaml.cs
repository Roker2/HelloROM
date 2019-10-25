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
            UseMobileConnectionSetting();
            SortTypeSetting();
            base.OnAppearing();
        }

        void UseMobileConnectionSetting()
        {
            object objUseMobileConnection;
            if (!App.Current.Properties.TryGetValue("UseMobileConnection", out objUseMobileConnection))
            {
                objUseMobileConnection = true;
            }
            UseMobileConnection.On = (bool)objUseMobileConnection;
        }

        void SortTypeSetting()
        {
            object objSortType;
            if (!App.Current.Properties.TryGetValue("SortType", out objSortType))
            {
                objSortType = SortTypes.Name;
            }
            switch ((SortTypes)objSortType)
            {
                case SortTypes.Name:
                    SortTypeButton.Text = "Sort by name";
                    break;
                case SortTypes.Base:
                    SortTypeButton.Text = "Sort by base";
                    break;
            }
        }

        private void UseMobileInternet_OnChanged(object sender, ToggledEventArgs e)
        {
            App.Current.Properties["UseMobileConnection"] = e.Value;
        }

        private async void SortTypeButton_Clicked(object sender, EventArgs e)
        {
            var actionSheet = await DisplayActionSheet("Choose sort type", "Cancel", null, "Name", "Base");
            switch (actionSheet)
            {
                case "Name":
                    App.Current.Properties["SortType"] = SortTypes.Name;
                    SortTypeButton.Text = "Sort by name";
                    break;
                case "Base":
                    App.Current.Properties["SortType"] = SortTypes.Base;
                    SortTypeButton.Text = "Sort by base";
                    break;
                default:
                    break;
            }
        }
    }
}