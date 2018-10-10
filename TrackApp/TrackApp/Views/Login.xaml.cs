using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        async void OnSignupButtonClickedAsync(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Signup());
        }
        void OnLoginButtonClicked(Object sender, EventArgs e)
        {
            var EmailValue = usernameEntry.Text;
            var PasswordValue = passwordEntry.Text;
            //validate
            //load info from json
        }
    }
}