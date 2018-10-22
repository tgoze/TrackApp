using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SchoolName { get; set; }
        public List<Invite> Invites { get; set; }
        public List<User> Members { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
