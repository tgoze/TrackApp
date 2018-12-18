using System;
using System.Collections.Generic;

namespace TrackApp.Models
{
    public class Run
    {
        public Run(int runnerNumber)
        {
            Splits = new List<TimeSpan>();
            RunnerNumber = runnerNumber;
        }

        public Run()
        {
            Splits = new List<TimeSpan>();        
        }

        public int RunnerNumber { get; set; }
        public List<TimeSpan> Splits { get; set; }
        public TimeSpan TotalTime { get; set; }

    }
}
