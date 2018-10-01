using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace TrackApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage ()
        {
            this.Title = "HomePage";

            this.ItemsSource = new ActivityData[]
            {
                new ActivityData("Run", "pathtoimage"),
                new ActivityData("History", "pathtoimage"),
                new ActivityData("Settings", "pathtoimage")              
            };

            this.ItemTemplate = new DataTemplate(() => {
                return new ActivityPage();
            });

            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }

    class ActivityPage : ContentPage
    {
        public ActivityPage ()
        {
            this.SetBinding(ContentPage.TitleProperty, "Name");
            this.SetBinding(ContentPage.IconProperty, "Icon");
            BoxView boxView = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center
            };
            this.Content = boxView;
        }
    }

    class ActivityData
    {
        public ActivityData (string name, string icon)
        {
            this.Name = name;
            this.Icon = icon;
        }

        public string Name { private set; get; }
        public string Icon { private set; get; }

        public override string ToString()
        {
            return Name;
        }
    }
}