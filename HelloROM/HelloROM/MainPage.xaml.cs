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
                new ROM("CarbonROM", 9.0, "AOSP", "https://github.com/Roker2/HelloROM/raw/master/Images/CarbonROM.png", "https://carbonrom.org"),
                new ROM("Lineage OS", 9.0, "AOSP", "https://avatars3.githubusercontent.com/u/24304779", "https://lineageos.org"),
                new ROM("Resurrection Remix", 9.0, "Lineage OS", "https://avatars3.githubusercontent.com/u/4931972", "https://www.resurrectionremix.com")
            };
            ROMs rOMs = new ROMs(ROMArray);
            ROMList.ItemsSource = rOMs;
        }

        private async void ROMList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ROM rOM = e.Item as ROM;
            await Navigation.PushAsync(new ROMInfPage(rOM));
        }

        private void ROMList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ROMList.SelectedItem = null;
        }
    }
}
