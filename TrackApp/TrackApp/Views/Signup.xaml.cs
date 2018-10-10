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
	public partial class Signup : ContentPage
	{
        int MinimumCharInPassword = 8;
        public Signup()
        {
            InitializeComponent();
        }

        private async void NextSignupAsync(object sender, EventArgs e)
        {
            String Password = password.Text;
            String Email = email.Text;
            String FirstName = firstName.Text;
            String LastName = lastName.Text;

            if (Password.Length < MinimumCharInPassword)
            {
                //error
            }
            await Navigation.PushAsync(new Signup2(Email, Password, FirstName, LastName));
        }
    }
}