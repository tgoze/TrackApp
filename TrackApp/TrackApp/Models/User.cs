using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    public class User
    {
        
        public int UserId { get; set; }

        
        public int YearId {get; set; } 
       
        public int RoleId { get; set; }
        
        public string GoogleSignInId { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set;}

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Height { get; set; }

        public double Weight { get; set; }

        public User()
        {

        }
    }
}

