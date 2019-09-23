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
                new ROM("CarbonROM", 9.0, "AOSP"),
                new ROM("Lineage OS", 9.0, "AOSP"),
                new ROM("Resurrection Remix", 9.0, "Lineage OS")
            };
            ROMs rOMs = new ROMs(ROMArray);
            ROMList.ItemsSource = rOMs;
        }

        private void ROMList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void ROMList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ROM rOM = e.SelectedItem as ROM;
            DisplayAlert(rOM.Name, null, "OK");
        }
    }
}
