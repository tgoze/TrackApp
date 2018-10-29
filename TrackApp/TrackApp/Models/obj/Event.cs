using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
        public List<User> Users { get; set; }
        public List<Run> Runs { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
