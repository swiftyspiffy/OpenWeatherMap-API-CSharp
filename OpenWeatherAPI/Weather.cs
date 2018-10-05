using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    public class Weather
    {
        public readonly int ID;
        public readonly string Main;
        public readonly string Description;
        public readonly string Icon;

        public Weather(JToken weatherData)
        {
            ID = int.Parse(weatherData.SelectToken("id").ToString());
            Main = weatherData.SelectToken("main").ToString();
            Description = weatherData.SelectToken("description").ToString();
            Icon = weatherData.SelectToken("icon").ToString();
        }
    }
}
