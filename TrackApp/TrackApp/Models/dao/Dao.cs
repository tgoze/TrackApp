using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TrackApp.Models.dao
{
    abstract class Dao
    {
        protected static WebClient client = new WebClient();
        protected static string Url = "https://www.offbynone.net:8785";
        protected static string FindAllRoles = "FindAllRoles";

        //\\//\\//\\//USER STRINGS\\//\\//\\//\\
        //Create
        protected static string CreateUser = "CreateUser/";

        //Read
        protected static string GetUserById = "GetUserById/";
        protected static string GetUserByUsername = "GetUserByUserName/";

        //Update
        protected static string UpdateUserById = "UpdateUserById/";

        //Delete
        protected static string DeleteUserById = "DeleteUserById/";

        //\\//\\//\\//TEAM STRINGS\\//\\//\\//\\
        protected static string GetTeamsByUserId = "GetTeamsByUserId/";

        //\\//\\//\\//GROUP STRINGS\\//\\//\\//\\
        protected static string GetGroupByUserId = "GetGroupsByUserId/";

        //\\//\\//\\//ROLE STRINGS\\//\\//\\//\\
        protected static string GetAllRoles = "GetAllRoles/1";

        static Dao()
        {
            client.BaseAddress = Url;
        }
    }
}
