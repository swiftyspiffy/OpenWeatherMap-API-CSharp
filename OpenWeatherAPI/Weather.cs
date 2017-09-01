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
        private const string IdSelector = "id";
        private const string MainSelector = "main";
        private const string DescriptionSelector = "description";
        private const string IconSelector = "icon";

        public int ID { get; private set; }
        public string Main { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }

        public Weather(JToken weatherData)
        {
            ID = int.Parse(weatherData.SelectToken(IdSelector).ToString());
            Main = weatherData.SelectToken(MainSelector).ToString();
            Description = weatherData.SelectToken(DescriptionSelector).ToString();
            Icon = weatherData.SelectToken(IconSelector).ToString();
        }
    }
}
