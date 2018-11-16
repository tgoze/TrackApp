using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TrackApp.Models.dao;

namespace TrackApp.Models
{
    class User
    {
        public User(int id)
        {
            Id = id;
        }

        [JsonProperty(PropertyName = "userId")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "year")]
        public Year Year { get; set; }

        [JsonProperty(PropertyName = "role")]
        public Role Role { get; set; }

        [JsonProperty(PropertyName = "googleSignInId")]
        public string GoogleSignInId { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "height")]
        public double Height { get; set; }

        [JsonProperty(PropertyName = "weight")]
        public double Weight { get; set; }

        [JsonProperty(PropertyName = "invites")]
        public List<Invite> Invites { get; set; }

        [JsonProperty(PropertyName = "teams")]
        public List<Team> Teams { get; set; }

        [JsonProperty(PropertyName = "groups")]
        public List<Group> Groups { get; set; }

        [JsonProperty(PropertyName = "events")]
        public List<Event> Events { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        //public DateTime CreatedAt { get; set; }
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        //public DateTime UpdatedAt { get; set; }
        public string UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "deletedAt")]
        //public DateTime DeletedAt { get; set; }
        public string DeletedAt { get; set; }
    }
}
