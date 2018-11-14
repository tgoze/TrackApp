using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace TrackApp.ViewModels
{
   public class ChangePasswordViewModel : INotifyPropertyChanged
    {
        public Command ChangePasswordCommand;
        INavigation Navigation;
        private string oldPassword;
        private string oldPasswordError;
        private string password;
        private string passwordError;
        private string confirmPassword;
        private string confirmPasswordError;

        public ChangePasswordViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
       //      this.ChangePasswordCommand = new Command(ChangePasswordCommand());
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

        public string OldPassword
        {
            get { return oldPassword; }
            set
            {
                if (oldPassword != value) { oldPassword = value; }
                ValidateOldPassword(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(OldPasswordError));
            }
        }

        private bool ValidateOldPassword(string value)
        {
            if (value.Length > 7)
            {
                oldPasswordError = "";
                return true;
            }
            else
            {
                oldPasswordError = "Password must be at least 8 characters";
                return false;
            }
        }

        public string OldPasswordError
        {
            get { return oldPasswordError; }
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
        //  private Action<object> ChangePasswordCommand()
        // {
        //  throw new NotImplementedException();
        // }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

