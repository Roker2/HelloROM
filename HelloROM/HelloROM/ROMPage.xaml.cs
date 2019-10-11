﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Toasts;

namespace HelloROM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ROMPage : TabbedPage
    {
        string site;
        string GerritUrl;
        string GithubUrl;

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
            GerritUrl = _rom.GerritUrl;
            GithubUrl = _rom.GithubUrl;
            ROMScreensots.ItemsSource = _rom.Screenshots;

            if(GithubUrl != null)
            {
                Button Button_Github = new Button();
                Button_Github.Text = "GitHub";
                make_button_style(Button_Github);
                Button_Github.Clicked += Button_Github_Clicked;
                Buttons.Children.Add(Button_Github);
            }

            if(site != null)
            {
                Button Button_Site = new Button();
                Button_Site.Text = "Site";
                make_button_style(Button_Site);
                Button_Site.Clicked += Button_Site_Clicked;
                Buttons.Children.Add(Button_Site);
            }

            if(GerritUrl != null)
            {
                Button Button_Gerrit = new Button();
                Button_Gerrit.Text = "Gerrit";
                make_button_style(Button_Gerrit);
                Button_Gerrit.Clicked += Button_Gerrit_Clicked;
                Buttons.Children.Add(Button_Gerrit);
            }
        }

        void make_button_style (Button _button)
        {
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