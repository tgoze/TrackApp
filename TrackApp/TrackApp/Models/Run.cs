using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    class Run
    {
        public int RunId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public TimeSpan OriginalTime { get; set; }
        public TimeSpan UpdatedTime { get; set; }
        public TimeSpan PredictedTime { get; set; }
        public List<Split> Splits { get; set; }
    }
}
