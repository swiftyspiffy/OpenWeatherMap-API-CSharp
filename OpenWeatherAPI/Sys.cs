using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    public class Sys
    {
        private int type, id;
        private double message;
        private string country;
        private DateTime sunrise, sunset;

        public int Type { get { return type; } }
        public int ID { get { return id; } }
        public double Message { get { return message; } }
        public string Country { get { return country; } }
        public DateTime Sunrise { get { return sunrise; } }
        public DateTime Sunset { get { return sunset; } }

        public Sys(JToken sysData)
        {
            if(sysData.SelectToken("type") != null)
                type = int.Parse(sysData.SelectToken("type").ToString());
            if(sysData.SelectToken("id") != null)
                id = int.Parse(sysData.SelectToken("id").ToString());
            message = double.Parse(sysData.SelectToken("message").ToString());
            country = sysData.SelectToken("country").ToString();
            sunrise = convertUnixToDateTime(double.Parse(sysData.SelectToken("sunrise").ToString()));
            sunset = convertUnixToDateTime(double.Parse(sysData.SelectToken("sunset").ToString()));
        }

        private DateTime convertUnixToDateTime(double unixTime)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dt.AddSeconds(unixTime).ToLocalTime();
        }
    }
}
