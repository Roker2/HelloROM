using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace HelloROM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageAddROM : ContentPage
	{
        int ScreensNumber = 0;

        List<Entry> entryMass = new List<Entry> { };

		public PageAddROM()
		{
			InitializeComponent ();
		}

        private async void Preview_Clicked(object sender, EventArgs e)
        {
            ROM PreviewROM = new ROM(ROMName.Text, ROMBase.Text, PicURL.Text, ROMSite.Text, ROMGerrit.Text, ROMGithub.Text);
            PreviewROM.AddDescription(ROMDescription.Text);
            PreviewROM.Screenshots.Clear();
            for(int i = 0; i < ScreensNumber; i++)
            {
                PreviewROM.AddScreenshot(entryMass[i].Text);
            }
            await Navigation.PushAsync(new ROMPage(PreviewROM));
        }

        private void ScreenshotsNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            Screenshots.Children.Clear();
            entryMass.Clear();
            if(ScreenshotsNumber.Text != "")
            {
                ScreensNumber = Convert.ToInt32(ScreenshotsNumber.Text);
                for (int i = 0; i < ScreensNumber; i++)
                {
                    entryMass.Add(new Entry());
                    entryMass[i].Keyboard = Keyboard.Url;
                    Screenshots.Children.Add(entryMass[i]);
                }
            }
        }

        public async Task ShareText(string text)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = Translations.Translation.ShareJSON
            });
        }

        string ToJSONInf(string Tag, string Info)
        {
            return "\"" + Tag + "\":\"" + Info + "\"";
        }

        bool CheckScreenshots()
        {
            for (int i = 0; i < ScreensNumber; i++)
            {
                if (string.IsNullOrEmpty(entryMass[i].Text))
                    return false;
            }
            return true;
        }

        private void SaveToJSON_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ROMName.Text))
            {
                DisplayAlert(Translations.Errors.Error, Translations.Errors.ErrorNoName, "OK");
                return;
            }
            if (string.IsNullOrEmpty(ROMBase.Text))
            {
                DisplayAlert(Translations.Errors.Error, Translations.Errors.ErrorNoBase, "OK");
                return;
            }
            if ((ScreensNumber == 0))
            {
                DisplayAlert(Translations.Errors.Error, Translations.Errors.ErrorNoScreenshots, "OK");
                return;
            }
            if (!CheckScreenshots())
            {
                DisplayAlert(Translations.Errors.Error, Translations.Errors.ErrorNoOneOrMoreScreenshots, "OK");
                return;
            }
            ROM rOM = new ROM { Name = ROMName.Text, Base = ROMBase.Text };
            if (!string.IsNullOrEmpty(PicURL.Text))
                rOM.Image = PicURL.Text;
            if (!string.IsNullOrEmpty(ROMDescription.Text))
                rOM.Description = ROMDescription.Text;
            if (!string.IsNullOrEmpty(ROMSite.Text))
                rOM.SiteUrl = ROMSite.Text;
            if (!string.IsNullOrEmpty(ROMGerrit.Text))
                rOM.GerritUrl = ROMGerrit.Text;
            if (!string.IsNullOrEmpty(ROMGithub.Text))
                rOM.GithubUrl = ROMGithub.Text;
            for (int i = 0; i < entryMass.Count; i++)
            {
                rOM.AddScreenshot(entryMass[i].Text);
            }
            ShareText(rOM.ToJSON());
        }
    }
}