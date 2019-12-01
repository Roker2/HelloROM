﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;

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
                    SortTypeButton.Text = Translations.Translation.NameSort;
                    break;
                case SortTypes.Base:
                    SortTypeButton.Text = Translations.Translation.BaseSort;
                    break;
                default:
                    break;
            }
        }

        private void UseMobileInternet_OnChanged(object sender, ToggledEventArgs e)
        {
            App.Current.Properties["UseMobileConnection"] = e.Value;
        }

        private async void SortTypeButton_Clicked(object sender, EventArgs e)
        {
            string actionSheet = await DisplayActionSheet("Choose sort type", "Cancel", null, "Name", "Base");
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

        private async void CustomJSONFile_Clicked(object sender, EventArgs e)
        {
            FileData fileData = await CrossFilePicker.Current.PickFile();
            if (fileData == null)
                return;
            if (!fileData.FilePath.Contains(".json"))
            {
                await DisplayAlert(Translations.Errors.Error, Translations.Errors.ErrorIsNotJSON, "OK");
                return;
            }
            string json = "";
            FileStream fs = File.OpenRead(fileData.FilePath);
            using (StreamReader streamReader = new StreamReader(fs))
            {
                while (streamReader.EndOfStream == false)
                {
                    json += streamReader.ReadLine();
                    json += '\n';
                }
            }
            fs.Close();
            Console.WriteLine(json);
            App.Current.Properties["json"] = json;
            App.Current.Properties["UseCustomJSON"] = (bool)true;
        }

        private async void ChooseLanguage_Clicked(object sender, EventArgs e)
        {
            string actionSheet = await DisplayActionSheet("Choose language", "Cancel", null, "English", "Русский");
            switch (actionSheet)
            {
                case "English":
                    App.Current.Properties["netLanguage"] = "en";
                    break;
                case "Русский":
                    App.Current.Properties["netLanguage"] = "ru";
                    break;
                default:
                    break;
            }
            await DisplayAlert("Warning", "Please, restart program!", "OK");
        }

        private async void ResetLanguage_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties.Remove("netLanguage");
            await DisplayAlert("Warning", "Please, restart program!", "OK");
        }
    }
}