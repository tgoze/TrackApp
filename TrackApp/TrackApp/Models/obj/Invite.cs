using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    class Invite
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
        public int Recipient { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
