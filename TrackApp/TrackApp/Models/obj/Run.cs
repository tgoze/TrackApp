using System;
using System.Collections.Generic;

namespace TrackApp.Models
{
    class Run
    {
        public Run(int runnerNumber)
        {
            Splits = new List<string>();
            RunnerNumber = runnerNumber;
        }

        public Run()
        {
            Splits = new List<string>();        
        }

        public int RunnerNumber { get; set; }
        public List<string> Splits { get; set; }
        public string TotalTime { get; set; }

    }
}
