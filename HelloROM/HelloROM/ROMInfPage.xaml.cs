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
	public partial class ROMInfPage : ContentPage
	{
		public ROMInfPage()
		{
			InitializeComponent ();
		}

        public ROMInfPage(string Name, string Inf, string Image = "https://github.com/Roker2/HelloROM/raw/master/Images/404.png")
        {
            InitializeComponent();
            ROMName.Text = Name;
            ROMInf.Text = Inf;
            ROMPic.Source = Image;
        }

        public ROMInfPage(ROM _rom)
        {
            InitializeComponent();
            ROMName.Text = _rom.Name;
            ROMInf.Text = _rom.Name + " is based on " + _rom.Base + ".";
            ROMPic.Source = _rom.Image;
        }
    }
}