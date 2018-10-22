﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
