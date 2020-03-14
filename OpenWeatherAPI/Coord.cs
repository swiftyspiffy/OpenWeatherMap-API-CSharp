using Newtonsoft.Json.Linq;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Coord
	{
		public double Longitude { get; }

		public double Latitude { get; }

		public Coord(JToken coordData)
		{
			if (coordData is null)
				throw new System.ArgumentNullException(nameof(coordData));

			Longitude = double.Parse(coordData.SelectToken("lon").ToString(), CultureInfo.InvariantCulture);
			Latitude = double.Parse(coordData.SelectToken("lat").ToString(), CultureInfo.InvariantCulture);
		}
	}
}
