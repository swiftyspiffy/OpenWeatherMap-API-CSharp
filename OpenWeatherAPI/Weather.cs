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
        private int id;
        private string main, description, icon;

        public int ID { get { return id; } }
        public string Main { get { return main; } }
        public string Description { get { return description; } }
        public string Icon { get { return icon; } }

        public Weather(JToken weatherData)
        {
            id = int.Parse(weatherData.SelectToken("id").ToString());
            main = weatherData.SelectToken("main").ToString();
            description = weatherData.SelectToken("description").ToString();
            icon = weatherData.SelectToken("icon").ToString();
        }
    }
}
