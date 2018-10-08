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
	public partial class Signup2 : ContentPage
	{
        private string email;
        private string password;
        private string firstName;
        private string lastName;

        public Signup2 ()
		{
			InitializeComponent ();
		}

        public Signup2(string email, string password, string firstName, string lastName)
        {
            InitializeComponent();
            this.email = email;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        private void VerifyCreateAccount(object sender, EventArgs e)
        {
            String Feet = feet.Text;
            String Inches = inches.Text;
            String Weight = weight.Text;
            String Grade = gradeLevel.Items[gradeLevel.SelectedIndex];
        }
    }
}