using System;
using System.Collections.Generic;
using System.Text;
using TrackApp.Models;

namespace TrackApp.ViewModels
{
    public class ViewModel
    {
        private User user;
        public User User
        {
            get { return this.user; }
            set { this.user = value; }
        }
        public ViewModel()
        {
            this.user = new User();
        }
    }
}
