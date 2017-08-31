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
        private const string BaseAdress = "http://api.openweathermap.org/data/2.5/";
        private const string ValidCod = "200";

        public bool ValidRequest { get; private set; }
        public string Base { get; private set; }
        public Coord Coord { get; private set; }
        public List<Weather> Weathers { get; private set; }
        public Main Main { get; private set; }
        public double Visibility { get; private set; }
        public Wind Wind { get; private set; }
        public Rain Rain { get; private set; }
        public Snow Snow { get; private set; }
        public Clouds Clouds { get; private set; }
        public Sys Sys { get; private set; }
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Cod { get; private set; }

        public Query(string apiKey, string queryStr)
        {
            Weathers = new List<Weather>();

            JObject jsonData = JObject.Parse(new System.Net.WebClient().DownloadString(string.Format(Query.BaseAdress + "weather?appid={0}&q={1}", apiKey, queryStr)));
            if (jsonData.SelectToken("cod").ToString() == Query.ValidCod)
            {
                ValidRequest = true;
                Coord = new Coord(jsonData.SelectToken("coord"));
                foreach (JToken weather in jsonData.SelectToken("weather"))
                    Weathers.Add(new Weather(weather));
                Base = jsonData.SelectToken("base").ToString();
                Main = new Main(jsonData.SelectToken("main"));
                if (jsonData.SelectToken("visibility") != null)
                    Visibility = double.Parse(jsonData.SelectToken("visibility").ToString());
                Wind = new Wind(jsonData.SelectToken("wind"));
                if (jsonData.SelectToken("raid") != null)
                    Rain = new Rain(jsonData.SelectToken("rain"));
                if (jsonData.SelectToken("snow") != null)
                    Snow = new Snow(jsonData.SelectToken("snow"));
                Clouds = new Clouds(jsonData.SelectToken("clouds"));
                Sys = new Sys(jsonData.SelectToken("sys"));
                ID = int.Parse(jsonData.SelectToken("id").ToString());
                Name = jsonData.SelectToken("name").ToString();
                Cod = int.Parse(jsonData.SelectToken("cod").ToString());
            }
            else
            {
                ValidRequest = false;
            }
        }
    }
}
