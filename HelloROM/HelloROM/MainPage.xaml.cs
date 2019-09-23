﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FFImageLoading.Forms;

namespace HelloROM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ROM[] ROMArray = new ROM[]
            {
                new ROM("CarbonROM", 9.0, "AOSP", "https://github.com/Roker2/HelloROM/raw/master/Images/CarbonROM.png"),
                new ROM("Lineage OS", 9.0, "AOSP"),
                new ROM("Resurrection Remix", 9.0, "Lineage OS")
            };
            ROMs rOMs = new ROMs(ROMArray);
            ROMList.ItemsSource = rOMs;
        }

        private async void ROMList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ROM rOM = e.Item as ROM;
            //DisplayAlert(rOM.Name, rOM.Name + " is based on " + rOM.Base + ".", "OK");
            await Navigation.PushAsync(new ROMInfPage(rOM.Name, rOM.Name + " is based on " + rOM.Base + ".", rOM.Image));
        }

        private void ROMList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ROMList.SelectedItem = null;
        }
    }
}
