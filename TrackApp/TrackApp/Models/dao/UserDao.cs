using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models.dao
{
    class UserDao : Dao
    {
        public UserDao() : base()
        {

        }

        protected static User GetUser(int id)
        {
            return JsonConvert.DeserializeObject<User>(client.DownloadString(GetUserById + id));
        }

        protected static User GetUser(string username)
        {
            return JsonConvert.DeserializeObject<User>(client.DownloadString(GetUserByUsername + username));
        }

        protected static void DeleteUser(int id)
        {
            client.DownloadString(DeleteUserById + id);
        }
    }
}
