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
        private const string COD = "cod";
        private const string CoordSelector = "coord";
        private const string WeatherSelector = "weather";
        private const string BaseSelector = "base";
        private const string MainSelector = "main";
        private const string VisibilitySelector = "visibility";
        private const string WindSelector = "wind";
        private const string RaidSelector = "raid";
        private const string SnowSelector = "snow";
        private const string CloudsSelector = "clouds";
        private const string SysSelector = "sys";
        private const string IdSelector = "id";
        private const string NameSelector = "name";
        private const string CODSelector = "cod";

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
            if (jsonData.SelectToken(COD).ToString() == Query.ValidCod)
            {
                ValidRequest = true;
                Coord = new Coord(jsonData.SelectToken(CoordSelector));

                foreach (JToken weather in jsonData.SelectToken(WeatherSelector))
                    Weathers.Add(new Weather(weather));

                Base = jsonData.SelectToken(BaseSelector).ToString();
                Main = new Main(jsonData.SelectToken(MainSelector));

                if (jsonData.SelectToken(VisibilitySelector) != null)
                    Visibility = double.Parse(jsonData.SelectToken(VisibilitySelector).ToString());

                Wind = new Wind(jsonData.SelectToken(WindSelector));

                if (jsonData.SelectToken(RaidSelector) != null)
                    Rain = new Rain(jsonData.SelectToken(RaidSelector));

                if (jsonData.SelectToken(SnowSelector) != null)
                    Snow = new Snow(jsonData.SelectToken(SnowSelector));

                Clouds = new Clouds(jsonData.SelectToken(CloudsSelector));
                Sys = new Sys(jsonData.SelectToken(SysSelector));
                ID = int.Parse(jsonData.SelectToken(IdSelector).ToString());
                Name = jsonData.SelectToken(NameSelector).ToString();
                Cod = int.Parse(jsonData.SelectToken(CODSelector).ToString());
            }
            else
            {
                ValidRequest = false;
            }
        }
    }
}
