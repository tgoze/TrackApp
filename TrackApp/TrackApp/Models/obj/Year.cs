﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    class Year
    {
        public int Id { get; set; }
        public string YearString { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
