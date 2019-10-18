using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using FFImageLoading.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;

namespace HelloROM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            GetStat();
        }

        private async void GetStat()
        {
            object json = "";
            if(!CrossConnectivity.Current.IsConnected)
            {
                if (!App.Current.Properties.TryGetValue("json", out json))
                {
                    await DisplayAlert(Translations.Errors.Error, Translations.Errors.ErrorNoInternet, "OK");
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
            ROMList.ItemsSource = JsonConvert.DeserializeObject<List<ROM>>((string)json);
            App.Current.Properties["json"] = (string)json;
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
            GetStat();
            ROMList.EndRefresh();
        }
    }
}
