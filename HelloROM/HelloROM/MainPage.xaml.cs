using System;
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
                new ROM("CarbonROM", "AOSP", "https://github.com/Roker2/HelloROM/raw/master/Images/CarbonROM.png", "https://carbonrom.org", "https://review.carbonrom.org", "https://github.com/CarbonROM"),
                new ROM("Lineage OS", "AOSP", "https://avatars3.githubusercontent.com/u/24304779", "https://lineageos.org", "https://review.lineageos.org", "https://github.com/LineageOS"),
                new ROM("Resurrection Remix", "Lineage OS", "https://avatars3.githubusercontent.com/u/4931972", "https://www.resurrectionremix.com", null, "https://github.com/ResurrectionRemix")
            };
            ROMArray[0].AddScreenshots("https://github.com/Roker2/HelloROMScreenshots/raw/master/CarbonROM/", 7, ".png");
            ROMArray[1].AddScreenshots("https://github.com/Roker2/HelloROMScreenshots/raw/master/Lineage%20OS/", 6, ".png");
            ROMArray[2].AddScreenshots("https://www.resurrectionremix.com/img/screenshots/screenshot_0", 6, ".png");
            ROMArray[1].Description = "It is the successor to the custom ROM CyanogenMod, from which it was forked in December 2016 when Cyanogen Inc. announced it was discontinuing development and shut down the infrastructure behind the project.\n© Wikipedia";
            ROMs rOMs = new ROMs(ROMArray);
            ROMList.ItemsSource = rOMs;
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
    }
}
