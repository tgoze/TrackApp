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
            //this.Title = "HomePage";
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        
            // Sets the tabs to the bottom of the screen
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
           //On<Xamarin.Forms.PlatformConfiguration.Android().
        }
    }            
}