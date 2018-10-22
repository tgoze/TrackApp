using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
