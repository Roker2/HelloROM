using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HelloROM
{
    public class ROMList
    {
        //здесь отображаются:
        //1) Name
        //2) AndroidVersion
        //3) Base

        Label header = new Label
        {
            Text = "ROM List",
            HorizontalOptions = LayoutOptions.Center,
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
        };

        static List<ROM> _roms = new List<ROM>
        {
            new ROM("CarbonROM", 9.0, "AOSP"),
            new ROM("Lineage OS", 9.0, "AOSP")
        };

        ListView listView = new ListView
        {
            ItemsSource = _roms,
            ItemTemplate = new DataTemplate(() =>
            {
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            //boxView,
                            new StackLayout
                            {
                                VerticalOptions = LayoutOptions.Center,
                                Spacing = 0,
                                Children =
                                {
                                        nameLabel
                                }
                            }
                        }
                    }
                };
            })
        };

    }
};
