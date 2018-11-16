using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TrackApp.Models.dao
{
    class RoleDao : Dao
    {
        public RoleDao() : base()
        { }

<<<<<<< refs/remotes/origin/beta
=======
<<<<<<< refs/remotes/origin/amarkovic
<<<<<<< refs/remotes/origin/amarkovic
<<<<<<< refs/remotes/origin/amarkovic
        //public static List<Role> GetAllRoles()
        //{
        //    List<Role> temp = JsonConvert.DeserializeObject<List<Role>>(client.DownloadString(Url + Dao.GetAllRoles));

        //    return temp;
        //}
=======
>>>>>>> Trying to fix timer bug
        public static List<Role> GetAllRoles()
        {
            return JsonConvert.DeserializeObject<List<Role>>(client1.GetStringAsync(Dao.GetAllRoles).Result, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat });
        }
<<<<<<< refs/remotes/origin/beta
=======
>>>>>>> Auto stash before merge of "ddalton" and "origin/beta"
=======
        //public static List<Role> GetAllRoles()
        //{
        //    List<Role> temp = JsonConvert.DeserializeObject<List<Role>>(client.DownloadString(Url + Dao.GetAllRoles));

        //    return temp;
        //}
>>>>>>> Trying to fix timer bug
<<<<<<< refs/remotes/origin/beta
>>>>>>> Trying to fix timer bug
=======
=======
        public static List<Role> GetAllRoles()
        {
            return JsonConvert.DeserializeObject<List<Role>>(client1.GetStringAsync(Dao.GetAllRoles).Result, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat });
        }
>>>>>>> Adjusted DAO to reflect changes in webservice
>>>>>>> Adjusted DAO to reflect changes in webservice

    }
}
