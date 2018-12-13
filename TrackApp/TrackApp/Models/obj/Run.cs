﻿using System;
using System.Collections.Generic;

namespace TrackApp.Models
{
    class Run
    {
        public Run()
        {
            Splits = new List<string>();
        }

        public int RunnerNumber { get; set; }
        public List<string> Splits { get; set; }
        public string TotalTime { get; set; }

    }
}
