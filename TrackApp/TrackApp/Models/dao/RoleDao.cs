using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TrackApp.Models.dao
{
    class RoleDao : Dao
    {
        public RoleDao() : base()
        { }

        public static List<Role> GetAllRoles()
        {
            return JsonConvert.DeserializeObject<List<Role>>(client1.GetStringAsync(Dao.GetAllRoles).Result, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat });
        }

    }
}
