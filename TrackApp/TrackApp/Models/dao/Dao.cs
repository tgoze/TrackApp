using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace TrackApp.Models.dao
{
    abstract class Dao
    {
        protected static HttpClient client1 = new HttpClient();
        protected static WebClient client = new WebClient();
        protected static string Url = "http://www.offbynone.net:8785";
        protected static string FindAllRoles = "FindAllRoles";

        //\\//\\//\\//USER STRINGS\\//\\//\\//\\
        //Create
        protected static string CreateUser = "CreateUser";

        //Read
<<<<<<< refs/remotes/origin/beta
<<<<<<< refs/remotes/origin/beta
        protected static string GetUserById = "FindUserByUserId";
=======
        protected static string GetUserById = "FindUserById";
>>>>>>> Adjusted DAO to reflect changes in webservice
=======
        protected static string GetUserById = "FindUserByUserId";
>>>>>>> DAO
        protected static string GetUserByUsername = "FindUserByUserName";

        //Update
        protected static string UpdateUserById = "UpdateUserById";

        //Delete
        protected static string DeleteUserById = "DeleteUserById";

        //\\//\\//\\//TEAM STRINGS\\//\\//\\//\\
        protected static string GetTeamsByUserId = "GetTeamsByUserId";

        //\\//\\//\\//GROUP STRINGS\\//\\//\\//\\
        protected static string GetGroupByUserId = "GetGroupsByUserId";

        //\\//\\//\\//ROLE STRINGS\\//\\//\\//\\
        protected static string GetAllRoles = "FindAllRoles";

        static Dao()
        {
            client.BaseAddress = Url;
            client1.BaseAddress = new System.Uri(Url);
        }
    }
}
