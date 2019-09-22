using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloROM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ROM[] ROMArray = new ROM[2]
            {
                new ROM("CarbonROM", 9.0, "AOSP"),
                new ROM("Lineage OS", 9.0, "AOSP")
            };
            ROMs rOMs = new ROMs(ROMArray);
            ROMList.ItemsSource = rOMs;
        }
    }
}
