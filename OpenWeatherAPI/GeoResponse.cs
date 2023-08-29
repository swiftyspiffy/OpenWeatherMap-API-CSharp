using System.Globalization;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
	public class GeoResponse
	{
		public bool ValidRequest { get; }
		public double Lat { get; }
		public double Lon { get; }

		public GeoResponse(string jsonResponse)
		{
			var jsonData = JArray.Parse(jsonResponse);
			Lat = double.Parse(jsonData[0].SelectToken("lat").ToString(), CultureInfo.CurrentCulture);
			Lon = double.Parse(jsonData[0].SelectToken("lon").ToString(), CultureInfo.CurrentCulture);
			ValidRequest = true;
		}
	}
}
