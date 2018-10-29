using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using TrackApp.Models;
using TrackApp.Models.dao;

namespace TrackApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage ()
        {
            Title = "HomePage";                        

            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            //User user = UserDao.GetUser(1);
            //List<Role> role = RoleDao.GetAllRoles();
=======
            List<Role> role = RoleDao.GetAllRoles();
>>>>>>> Auto stash before merge of "ddalton" and "origin/beta"

            // Sets the tabs to the bottom of the screen
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
           //On<Xamarin.Forms.PlatformConfiguration.Android().
        }
    }            
}