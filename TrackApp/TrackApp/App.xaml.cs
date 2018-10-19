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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU1NTRAMzEzNjJlMzMyZTMwT2lMb3pMdENaWWY2ODFUWkVCcGZOVU9tUzhNMDA3WmNUT3JFUU56bjVxUT0=");

            InitializeComponent();

            MainPage = new MainPage();
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
