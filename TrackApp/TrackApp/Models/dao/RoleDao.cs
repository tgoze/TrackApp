using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models.dao
{
    class RoleDao : Dao
    {
        public RoleDao() : base()
        {}

        //public static List<Role> GetAllRoles()
        //{
        //    List<Role> temp = JsonConvert.DeserializeObject<List<Role>>(client.DownloadString(Url + Dao.GetAllRoles));

        //    return temp;
        //}

    }
}
