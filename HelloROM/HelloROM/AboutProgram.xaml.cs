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
    }
}