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
        string GerritUrl;
        string GithubUrl;

        public ROMPage(ROM _rom)
        {
            InitializeComponent();
            ROMName.Text = _rom.Name;
            ROMInf.Text = _rom.Description + "\n" + "\n" + _rom.Name + " is based on " + _rom.Base + ".";
            ROMPic.Source = _rom.Image;
            site = _rom.SiteUrl;
            GerritUrl = _rom.GerritUrl;
            GithubUrl = _rom.GithubUrl;
            ROMScreensots.ItemsSource = _rom.Screenshots;

            if(GithubUrl != null)
            {
                Button Button_Github = new Button();
                make_button_style(Button_Github, "GitHub");
                Button_Github.Clicked += Button_Github_Clicked;
                Buttons.Children.Add(Button_Github);
            }

            if(site != null)
            {
                Button Button_Site = new Button();
                make_button_style(Button_Site, "Site");
                Button_Site.Clicked += Button_Site_Clicked;
                Buttons.Children.Add(Button_Site);
            }

            if(GerritUrl != null)
            {
                Button Button_Gerrit = new Button();
                make_button_style(Button_Gerrit, "Gerrit");
                Button_Gerrit.Clicked += Button_Gerrit_Clicked;
                Buttons.Children.Add(Button_Gerrit);
            }
        }

        void make_button_style (Button _button, string bt_name)
        {
            _button.Text = bt_name;
            _button.BackgroundColor = Color.White;
        }

        private void Button_Gerrit_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(GerritUrl));
        }

        private void Button_Site_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(site));
        }

        private void Button_Github_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(GithubUrl));
        }
    }
}