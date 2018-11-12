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

<<<<<<< refs/remotes/origin/beta
<<<<<<< refs/remotes/origin/beta
            //User user = UserDao.GetUser(1);
=======
=======
<<<<<<< refs/remotes/origin/amarkovic
>>>>>>> Adjusted DAO to reflect changes in webservice
            //User user = UserDao.GetUser(0);
<<<<<<< refs/remotes/origin/amarkovic
<<<<<<< refs/remotes/origin/amarkovic
>>>>>>> Trying to fix timer bug
            //List<Role> role = RoleDao.GetAllRoles();
=======
            List<Role> role = RoleDao.GetAllRoles();
>>>>>>> Auto stash before merge of "ddalton" and "origin/beta"
=======
            //List<Role> role = RoleDao.GetAllRoles();
>>>>>>> Trying to fix timer bug
=======
            //User user = UserDao.GetUser(1);
            List<Role> role = RoleDao.GetAllRoles();
>>>>>>> Adjusted DAO to reflect changes in webservice

            // Sets the tabs to the bottom of the screen
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
           //On<Xamarin.Forms.PlatformConfiguration.Android().
        }
    }            
}