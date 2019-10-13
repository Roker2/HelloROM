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
                    Screenshots.Children.Add(entryMass[i]);
                }
            }
        }
    }
}