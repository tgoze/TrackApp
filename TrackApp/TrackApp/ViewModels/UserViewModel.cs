using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrackApp.ViewModels
{
    class UserViewModel
    {
        public Command ChangePasswordCommand { get; }
        public Command UpdateHeightCommand { get; }
        public Command UpdateWeightCommand { get; }
        public Command UpdateRoleCommand { get; }
        INavigation Navigation;

        public UserViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.ChangePasswordCommand = new Command(async () => await ChangePassword());
            //this.UpdateHeightCommand = new Command(UpdateHeight());
            //this.UpdateWeightCommand = new Command(UpdateWeight());
            //this.UpdateRoleCommand = new Command(UpdateRole());
        }

        public int RoleId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Height { get; set; }

        public double Weight { get; set; }

        public string DisplayMessage
        {
            get
            {
                return string.Format("Welcome {0} {1}", FirstName, LastName);
            }
        }

        public async Task ChangePassword()
        {
            await Navigation.PushAsync(new ChangePassword(), true);
        }
        // private Action<object> UpdateHeight()
        // {
        //     throw new NotImplementedException();
        // }

        // private Action<object> UpdateWeight()
        // {
        //   throw new NotImplementedException();
        //}

        // private Action<object> UpdateRole()
        // {
        //   throw new NotImplementedException();
        //}

    }
}
