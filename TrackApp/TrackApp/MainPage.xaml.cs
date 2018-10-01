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

            Xamarin.Forms.Button beepButton = new Xamarin.Forms.Button
            {
                Text = "Click beep",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center                
            };
            beepButton.Clicked += BeepButton_Clicked;

            this.Children.Add(new ContentPage
            {
                Title = "Run",
                Content = new StackLayout
                {
                    HeightRequest = 100f,
                    VerticalOptions = LayoutOptions.Center,                    
                    Children =
                    {
                        beepButton       
                    }
                }                          
            }
            );

            this.Children.Add(new ContentPage
            {
                Title = "History",
                Content = new StackLayout
                {                                    
                }
            }
            );

            this.Children.Add(new ContentPage
            {
                Title = "Settings",
                Content = new StackLayout
                {
                }
            }
            );

            InitializeComponent();

            // Sets the tabs to the bottom of the screen
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }

        private void BeepButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBeep>().playBeep();
        }
    }            
}