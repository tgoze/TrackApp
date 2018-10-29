using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrackApp;
using System;

namespace TrackApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        INavigation Navigation;
        public Command ForgotPasswordCommand { get; }
        public Command LoginCommand { get; }
        public Command SignupCommand { get; }
        private string email;
        private string emailError;
        private string password;
        private string passwordError;
        public LoginViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.SignupCommand = new Command(async () => await Signup());
           // this.LoginCommand = new Command(Login());
          //  this.ForgotPasswordCommand = new Command(ForgotPassword());
        }

       

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value) { email = value; }
                ValidateEmail(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(EmailError));
            }
        }

        public string EmailError
        {
            get { return emailError; }
        }



        private bool ValidateEmail(string value)
        {
            if ((value.Length > 5) && Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                emailError = "";
                return true;
            }
            else
            {
                emailError = "Please enter a Valid Email";
                return false;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value) { password = value; }
                ValidatePassword(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(PasswordError));
            }
        }

        private bool ValidatePassword(string value)
        {
            if (value.Length > 7)
            {
                passwordError = "";
                return true;
            }
            else
            {
                passwordError = "Password must be at least 8 characters";
                return false;
            }
        }

        public string PasswordError
        {
            get { return passwordError; }
        }

        public async Task Signup()
        {
            await Navigation.PushAsync(new Signup(), true);
        }

        // private Action<object> ForgotPassword()
        // {
        //     throw new NotImplementedException();
        // }

        // private Action<object> Login()
        // {
        //   throw new NotImplementedException();
        //}
        // used to instill two-way data binding between a viewmodel's properties and a given view object.
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}