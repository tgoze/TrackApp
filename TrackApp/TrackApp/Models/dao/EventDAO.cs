using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TrackApp.Models.dao
{
    class EventDAO : Dao
    {
        public EventDAO() : base()
        {
            
        }

        protected Event GetEventById(int id)
        {
            string json = client.DownloadString("");

            return new Event();
        }
    }
}
