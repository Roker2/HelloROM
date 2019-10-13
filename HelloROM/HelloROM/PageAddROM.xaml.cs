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
		public PageAddROM()
		{
			InitializeComponent ();
		}

        private async void Preview_Clicked(object sender, EventArgs e)
        {
            ROM PreviewROM = new ROM(ROMName.Text, ROMBase.Text, PicURL.Text, ROMSite.Text, ROMGerrit.Text, ROMGithub.Text);
            await Navigation.PushAsync(new ROMPage(PreviewROM));
        }
    }
}