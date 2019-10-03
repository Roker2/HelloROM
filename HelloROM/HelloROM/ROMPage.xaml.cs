using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloROM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ROMPage : TabbedPage
    {
        public ROMPage()
        {
            InitializeComponent();
        }

        public ROMPage(ROM _rom)
        {
            InitializeComponent();
            ROMName.Text = _rom.Name;
            ROMInf.Text = _rom.Name + " is based on " + _rom.Base + ".";
            ROMPic.Source = _rom.Image;
            ROMSite.Text = _rom.SiteUrl;
            var tapOpenURI = new TapGestureRecognizer();
            tapOpenURI.Tapped += (s, e) =>
            {
                Device.OpenUri(new Uri(ROMSite.Text));
            };
            ROMSite.GestureRecognizers.Add(tapOpenURI);
            ROMScreensots.ItemsSource = _rom.Screenshots;
        }
    }
}