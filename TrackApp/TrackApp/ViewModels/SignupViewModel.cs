using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using System;

namespace TrackApp.ViewModels
{
    public class SignupViewModel : INotifyPropertyChanged
    {
        INavigation Navigation;
        public Command SignupCommand { get; }
        private string email;
        private string emailError;
        private string password;
        private string passwordError;
        private string confirmPassword;
        private string confirmPasswordError;
        private string firstName;
        private string firstNameError;
        private string lastName;
        private string lastNameError;
        private string weight;
        private string weightError;
        public SignupViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
         //   this.SignupCommand = new Command(Signup());
        }

        //  private Action<object> Signup()
        //  {
        //     throw new NotImplementedException();
        // }

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

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                if (confirmPassword != value) { confirmPassword = value; }
                ValidateConfirmPassword(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(ConfirmPasswordError));
            }
        }

        private bool ValidateConfirmPassword(string value)
        {
            if (value.Length > 7 && value == password)
            {
                confirmPasswordError = "";
                return true;
            }
            else
            {
                if (value.Length < 8)
                {
                    confirmPasswordError = "Password must be at least 8 characters";
                }
                else
                {
                    confirmPasswordError = "Passwords do not match";
                }
                return false;
            }
        }

        public string ConfirmPasswordError
        {
            get { return confirmPasswordError; }
        }



        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value) { firstName = value; }
                ValidateFirstName(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(firstNameError));
            }
        }

        private bool ValidateFirstName(string value)
        {
            if (value.Length > 0)
            {
                firstNameError = "";
                return true;
            }
            else
            {
                firstNameError = "Please enter your First Name";
                return false;
            }
        }

        public string FirstNameError
        {
            get { return firstNameError; }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value) { lastName = value; }
                ValidateLastName(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(lastNameError));
            }
        }

        private bool ValidateLastName(string value)
        {
            if (value.Length > 0)
            {
                lastNameError = "";
                return true;
            }
            else
            {
                lastNameError = "Please enter your Last Name";
                return false;
            }
        }

        public string LastNameError
        {
            get { return lastNameError; }
        }

        public string Weight
        {
            get { return weight; }
            set
            {
                if (weight != value) { weight = value; }
                ValidateWeight(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(weightError));
            }
        }

        private bool ValidateWeight(string value)
        {
            if (value.Length > 1)
            {
                weightError = "";
                return true;
            }
            else
            {
                weightError = "Please enter a valid Weight";
                return false;
            }
        }

        public string WeightError
        {
            get { return lastNameError; }
        }




        // used to instill two-way data binding between a viewmodel's properties and a given view object.
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}