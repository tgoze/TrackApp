using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    class User
    {
        public int UserId { get; set; }
        public int YearId { get; set; }
        public int RoleId { get; set; }
        public string GoogleSignInId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
    }
}
