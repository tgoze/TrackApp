using System;
using System.Collections.Generic;

namespace TrackApp.Models
{
    class Run
    {
        public Run()
        {
            Splits = new List<Split>();
        }

        public int RunnerNumer { get; set; }
        public List<Split> Splits { get; set; }

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
