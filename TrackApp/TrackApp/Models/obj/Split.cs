using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    class Split
    {
        public int Id { get; set; }
        public TimeSpan SplitTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
