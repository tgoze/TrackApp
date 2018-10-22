using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    class User
    {
        public int Id { get; set; }
        public Password Password { get; set; }
        public Year Year { get; set; }
        public Role Role { get; set; }
        public string GoogleSignInId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public List<Invite> Invites { get; set; }
        public List<Team> Teams { get; set; }
        public List<Group> Groups { get; set; }
        public List<Event> Events { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
