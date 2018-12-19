using System;
using System.Collections.Generic;

namespace TrackApp.Models
{
    public class Run
    {
        public Run(int runnerNumber)
        {
            Splits = new List<TimeSpan>();
            StrSplits = new List<string>();
            RunnerNumber = runnerNumber;
        }

        public Run()
        {
            Splits = new List<TimeSpan>();
            StrSplits = new List<string>();
        }

        public int RunnerNumber { get; set; }
        public List<TimeSpan> Splits { get; set; }
        public TimeSpan TotalTime { get; set; }

        // Properties for display   
        public List<string> StrSplits { get; set; }
        public string StrTotalTime { get; set; }
    }
}
