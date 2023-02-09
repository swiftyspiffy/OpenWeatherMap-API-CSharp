using Newtonsoft.Json.Linq;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Coordinates
	{
		public double Longitude { get; }

		public double Latitude { get; }

		public Coordinates(JToken coordinateData)
		{
			if (coordinateData is null)
				throw new System.ArgumentNullException(nameof(coordinateData));

			Longitude = double.Parse(coordinateData.SelectToken("lon").ToString(), CultureInfo.CurrentCulture);
			Latitude = double.Parse(coordinateData.SelectToken("lat").ToString(), CultureInfo.CurrentCulture);
		}
	}
}
