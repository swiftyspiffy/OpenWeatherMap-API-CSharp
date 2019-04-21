using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    public class Query
    {
        private bool validRequest;
        private Coord coord;
        private List<Weather> weathers = new List<Weather>();
        private string baseStr;
        private Main main;
        private double visibility;
        private Wind wind;
        private Rain rain;
        private Snow snow;
        private Clouds clouds;
        private Sys sys;
        private int id;
        private string name;
        private int cod;

        public bool ValidRequest { get { return validRequest; } }
        public Coord Coord { get { return coord; } }
        public List<Weather> Weathers { get { return weathers; } }
        public string Base { get { return baseStr; } }
        public Main Main { get { return main; } }
        public double Visibility { get { return visibility; } }
        public Wind Wind { get { return wind; } }
        public Rain Rain { get { return rain; } }
        public Snow Snow { get { return snow; } }
        public Clouds Clouds { get { return clouds; } }
        public Sys Sys { get { return sys; } }
        public int ID { get { return id; } }
        public string Name { get { return name; } }
        public int Cod { get { return cod; } }

        public Query(string apiKey, string queryStr)
        {
            JObject jsonData = JObject.Parse(new System.Net.WebClient().DownloadString(string.Format("http://api.openweathermap.org/data/2.5/weather?appid={0}&q={1}", apiKey, queryStr)));
            if(jsonData.SelectToken("cod").ToString() == "200")
            {
                validRequest = true;
                coord = new Coord(jsonData.SelectToken("coord"));
                foreach (JToken weather in jsonData.SelectToken("weather"))
                    weathers.Add(new Weather(weather));
                baseStr = jsonData.SelectToken("base").ToString();
                main = new Main(jsonData.SelectToken("main"));
                if(jsonData.SelectToken("visibility") != null)
                    visibility = double.Parse(jsonData.SelectToken("visibility").ToString());
                wind = new Wind(jsonData.SelectToken("wind"));
                if(jsonData.SelectToken("rain") != null)
                    rain = new Rain(jsonData.SelectToken("rain"));
                if (jsonData.SelectToken("snow") != null)
                    snow = new Snow(jsonData.SelectToken("snow"));
                clouds = new Clouds(jsonData.SelectToken("clouds"));
                sys = new Sys(jsonData.SelectToken("sys"));
                id = int.Parse(jsonData.SelectToken("id").ToString());
                name = jsonData.SelectToken("name").ToString();
                cod = int.Parse(jsonData.SelectToken("cod").ToString());
            } else
            {
                validRequest = false;
            }
        }
    }
}
