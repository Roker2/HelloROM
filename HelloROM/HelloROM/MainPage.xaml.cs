using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json;
using Plugin.Connectivity;
using MarcTron.Plugin;
using MarcTron.Plugin.Controls;

namespace HelloROM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
#if DEBUG
            CrossMTAdmob.Current.TestDevices = new List<string>() { "7d597d111dd8c64e" }; //.Add("7d597d111dd8c64e");
#endif
        }

        protected override void OnAppearing()
        {
            GetStat();
            base.OnAppearing();
        }

        private void Sorting(ROMs temp)
        {
            temp.SortByName();
            object objSortType;
            if (!App.Current.Properties.TryGetValue("SortType", out objSortType))
            {
                objSortType = SortTypes.Name;
            }
            if ((SortTypes)objSortType == SortTypes.Base)
                temp.SortByBase();
            ROMList.ItemsSource = temp;
        }

        private void SetItemsSource(string json)
        {
            ROMs temp = new ROMs(JsonConvert.DeserializeObject<List<ROM>>((string)json));
            Sorting(temp);
        }

        private async void GetStat()
        {
            IsBusy = true;
            object json = "";
            object UseMobileConnection;
            if (!App.Current.Properties.TryGetValue("UseMobileConnection", out UseMobileConnection))
            {
                UseMobileConnection = true;
            }
            if (CrossConnectivity.Current.IsConnected == true)
            {
#if DEBUG
                Console.WriteLine("Type connection: " + CrossConnectivity.Current.ConnectionTypes.FirstOrDefault().ToString());
#endif
                if (CrossConnectivity.Current.ConnectionTypes.FirstOrDefault().ToString() != "Cellular")
                {
                    UseMobileConnection = true;
                }
            }
            object UseCustomJSON;
            if (!App.Current.Properties.TryGetValue("UseCustomJSON", out UseCustomJSON))
            {
                UseCustomJSON = false;
            }
            if (!CrossConnectivity.Current.IsConnected || !(bool)UseMobileConnection || (bool)UseCustomJSON)
            {
                if (!App.Current.Properties.TryGetValue("json", out json))
                {
                    await DisplayAlert(Utils.GetError("Error"), Utils.GetError("ErrorNoInternet"), "OK");
                    GetStat();
                    return;
                }
            }
            else
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://github.com/Roker2/HelloROM/raw/master/ROMList.json");
                json = await response.Content.ReadAsStringAsync();
            }
            App.Current.Properties["json"] = (string)json;
            await Task.Delay(5000);
            Task<bool> task = IsDownloadJSON.FadeTo(0);
            await task.ContinueWith(t => { });
            IsBusy = false;
            ROMView.Children.Remove(IsDownloadJSON);
            SetItemsSource((string)json);
        }

        private async void UpdateStat()
        {
            App.Current.Properties["UseCustomJSON"] = false;
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert(Utils.GetError("Error"), Utils.GetError("ErrorNoInternet"), "OK");
            }
            else
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://github.com/Roker2/HelloROM/raw/master/ROMList.json");
                string json = await response.Content.ReadAsStringAsync();
                App.Current.Properties["json"] = json;
                SetItemsSource(json);
            }
        }

        private async void ROMList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ROM rOM = e.Item as ROM;
            await Navigation.PushAsync(new ROMPage(rOM));
        }

        private void ROMList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ROMList.SelectedItem = null;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAddROM());
        }

        private void ROMList_Refreshing(object sender, EventArgs e)
        {
            UpdateStat();
            ROMList.EndRefresh();
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            object json = "";
            if (!App.Current.Properties.TryGetValue("json", out json))
            {
                await DisplayAlert(Utils.GetError("Error"), Utils.GetError("ErrorNoInternet"), "OK");
                return;
            }
            ROMs temp = new ROMs(JsonConvert.DeserializeObject<List<ROM>>((string)json));
            temp.SortByName();
            ROMList.ItemsSource = temp.Where(x => x.Name.ToLowerInvariant().Contains(e.NewTextValue.ToLowerInvariant()));
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMenu());
            object json;
            if (!App.Current.Properties.TryGetValue("json", out json))
            {
                await DisplayAlert(Utils.GetError("Error"), "json doesn't exist", "OK");
                return;
            }
            GetStat();
        }

        private async void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutProgram());
        }
    }
}
