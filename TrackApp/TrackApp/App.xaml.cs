using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TrackApp
{
    public partial class App : Application
    {
        public App()
        {
            // License registered under tjgoze@gmail.com
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTIxMTJAMzEzNjJlMzQyZTMwRG5mTXFaZHAwZjZQYndDeU9BaEhrZ1Q0TE5adzZFa3dlWEVrQzBhd1BxST0=");

            InitializeComponent();
            MainPage = new NavigationPage(new MainPage())
            {
                // This will set the status bar (for battery and wifi) to white in the app
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
