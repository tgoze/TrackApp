using System;
using System.Collections.Generic;

namespace TrackApp.Models
{
    class Run
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
        public TimeSpan OriginalTime { get; set; }
        public TimeSpan UpdatedTime { get; set; }
        public TimeSpan PredictedTime { get; set; }
        public User OriginalTimeRecordedBy { get; set; }
        public User UpdatedTimeRecordedBy { get; set; }
        public List<Split> Splits { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public TimeSpan TotalTime
        {
            get
            {
                TimeSpan total = new TimeSpan();
                foreach (Split s in Splits)
                    total.Add(s.SplitTime);
                return TotalTime;
            }
        }
    }
}
