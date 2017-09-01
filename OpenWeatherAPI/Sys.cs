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
        private const string TypeSelector = "type";
        private const string IdSelector = "id";
        private const string MessageSelector = "message";
        private const string CountrySelector = "country";
        private const string SunriseSelector = "sunrise";
        private const string SunsetSelector = "sunset";

        public int Type { get; private set; }
        public int ID { get; private set; }
        public double Message { get; private set; }
        public string Country { get; private set; }
        public DateTime Sunrise { get; private set; }
        public DateTime Sunset { get; private set; }

        public Sys(JToken sysData)
        {
            if (sysData.SelectToken(TypeSelector) != null)
                Type = int.Parse(sysData.SelectToken(TypeSelector).ToString());

            if (sysData.SelectToken(IdSelector) != null)
                ID = int.Parse(sysData.SelectToken(IdSelector).ToString());

            Message = double.Parse(sysData.SelectToken(MessageSelector).ToString());
            Country = sysData.SelectToken(CountrySelector).ToString();
            Sunrise = convertUnixToDateTime(double.Parse(sysData.SelectToken(SunriseSelector).ToString()));
            Sunset = convertUnixToDateTime(double.Parse(sysData.SelectToken(SunsetSelector).ToString()));
        }

        private DateTime convertUnixToDateTime(double unixTime)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dt.AddSeconds(unixTime).ToLocalTime();
        }
    }
}
