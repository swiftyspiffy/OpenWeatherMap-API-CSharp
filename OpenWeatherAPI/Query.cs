using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Query
	{
		public bool ValidRequest { get; }
		public Coord Coord { get; }
		public List<Weather> Weathers { get; } = new List<Weather>();
		public string Base { get; }
		public Main Main { get; }
		public double Visibility { get; }
		public Wind Wind { get; }
		public Rain Rain { get; }
		public Snow Snow { get; }
		public Clouds Clouds { get; }
		public Sys Sys { get; }
		public int ID { get; }
		public string Name { get; }
		public int Cod { get; }

		public Query(string apiKey, string queryStr)
		{
			JObject jsonData;
			using (var client = new System.Net.WebClient())
				jsonData = JObject.Parse(client.DownloadString($"http://api.openweathermap.org/data/2.5/weather?appid={apiKey}&q={queryStr}"));

			if (jsonData.SelectToken("cod").ToString() == "200")
			{
				ValidRequest = true;
				Coord = new Coord(jsonData.SelectToken("coord"));
				foreach (JToken weather in jsonData.SelectToken("weather"))
					Weathers.Add(new Weather(weather));
				Base = jsonData.SelectToken("base").ToString();
				Main = new Main(jsonData.SelectToken("main"));
				if (jsonData.SelectToken("visibility") != null)
					Visibility = double.Parse(jsonData.SelectToken("visibility").ToString(), CultureInfo.InvariantCulture);
				Wind = new Wind(jsonData.SelectToken("wind"));
				if (jsonData.SelectToken("rain") != null)
					Rain = new Rain(jsonData.SelectToken("rain"));
				if (jsonData.SelectToken("snow") != null)
					Snow = new Snow(jsonData.SelectToken("snow"));
				Clouds = new Clouds(jsonData.SelectToken("clouds"));
				Sys = new Sys(jsonData.SelectToken("sys"));
				ID = int.Parse(jsonData.SelectToken("id").ToString(), CultureInfo.InvariantCulture);
				Name = jsonData.SelectToken("name").ToString();
				Cod = int.Parse(jsonData.SelectToken("cod").ToString(), CultureInfo.InvariantCulture);
			}
			else
			{
				ValidRequest = false;
			}
		}
	}
}
