using System;
using System.Collections.Generic;

namespace TrackApp.Models
{
    class Run
    {
        public Run()
        {
            Splits = new List<TimeSpan>();
        }

        public int RunnerNumer { get; set; }
        public List<TimeSpan> Splits { get; set; }

        public TimeSpan TotalTime
        {
            get
            {
                TimeSpan total = new TimeSpan();
                foreach (TimeSpan t in Splits)
                    total.Add(t);
                return total;
            }
        }
    }
}
