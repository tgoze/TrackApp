using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    class Split
    {
        public int SplitId { get; set; }
        public int RunId { get; set; }
        public TimeSpan SplitTime { get; set; }
    }
}
