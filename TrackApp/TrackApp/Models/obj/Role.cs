using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models
{
    class Role
    {
        [JsonProperty(PropertyName = "roleId")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "roleName")]
        public string Name { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdateAt { get; set; }
        //public DateTime DeletedAt { get; set; }

        public string CreatedAt { get; set; }
        public string UpdateAt { get; set; }
        public string DeletedAt { get; set; }
    }
}
