﻿using System;
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
            if(!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert(Translations.Errors.Error, Translations.Errors.ErrorNoInternet, "OK");
                GetStat();
                return;
            }
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://github.com/Roker2/HelloROM/raw/master/ROMList.json");
            var json = await response.Content.ReadAsStringAsync();
            ROMList.ItemsSource = JsonConvert.DeserializeObject<List<ROM>>(json);
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
    }
}
