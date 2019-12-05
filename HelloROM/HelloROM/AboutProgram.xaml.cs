using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloROM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutProgram : ContentPage
    {
		public AboutProgram ()
		{
			InitializeComponent ();
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (Info.FontSize == 21)
                Info.FontSize = 14;
            else
                Info.FontSize = 21;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://github.com/Roker2/HelloROMScreenshots"));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://github.com/Roker2/HelloROM"));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Logo.Source = "Roker2.jpg";
            TapGesture.Tapped -= TapGestureRecognizer_Tapped;
            TapGesture.Tapped += TapGestureRecognizer_Tapped_Second;
        }

        private async void TapGestureRecognizer_Tapped_Second(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EasterEgg());
        }
    }
}