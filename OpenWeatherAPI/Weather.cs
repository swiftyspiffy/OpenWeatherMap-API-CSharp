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
        public int ID { get; private set; }
        public string Main { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }

        public Weather(JToken weatherData)
        {
            ID = int.Parse(weatherData.SelectToken("id").ToString());
            Main = weatherData.SelectToken("main").ToString();
            Description = weatherData.SelectToken("description").ToString();
            Icon = weatherData.SelectToken("icon").ToString();
        }
    }
}
