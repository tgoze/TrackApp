using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace TrackApp.Models.dao
{
    class UserDao : Dao
    {
        public UserDao() : base()
        {

        }

        public new void CreateUser(User user)
        {
            //client.DownloadString(Dao.CreateUser + JsonConvert.SerializeObject(user));
        }

        public static User GetUser(int id)
        {
            
            //client1.QueryString = new NameValueCollection
            //{
            //    { "userId", id.ToString() }
            //};

            return JsonConvert.DeserializeObject<User>(client.DownloadString(GetUserById));
        }

        public static User GetUser(string username)
        {
            return JsonConvert.DeserializeObject<User>(client.DownloadString(GetUserByUsername + username));
        }

        public static void UpdateUser(int id)
        {
            //client.UploadString(UpdateUserById, JsonConvert.SerializeObject(id));
        }

        public static void DeleteUser(int id)
        {
            //client.DownloadString(DeleteUserById + id);
        }

        public static List<Team> GetTeamsByUser(int userId)
        {
            return JsonConvert.DeserializeObject<List<Team>>(client.DownloadString(GetTeamsByUserId + userId));
        }
    }
}
