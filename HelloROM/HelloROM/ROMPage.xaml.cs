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
        string site;

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
            site = _rom.SiteUrl;
            ROMScreensots.ItemsSource = _rom.Screenshots;
        }

        private void Button_Gerrit_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Site_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(site));
        }

        private void Button_Github_Clicked(object sender, EventArgs e)
        {

        }
    }
}