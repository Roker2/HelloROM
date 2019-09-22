using System;
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
            test.ItemsSource = new List<ROM>
            {
                new ROM("CarbonROM", 9.0, "AOSP"),
                new ROM("Lineage OS", 9.0, "AOSP")
            };
        }
    }
}
