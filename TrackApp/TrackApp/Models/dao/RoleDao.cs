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
            string temp2 = Regex.Unescape(client1.GetStringAsync(Dao.GetAllRoles).Result.Replace("\n", string.Empty));
            List<Role> temp = JsonConvert.DeserializeObject<List<Role>>(temp2, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat });

            return temp;
        }

    }
}
