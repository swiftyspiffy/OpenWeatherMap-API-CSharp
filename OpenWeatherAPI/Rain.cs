using Newtonsoft.Json.Linq;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Rain
	{
		public Rain(JToken rainData)
		{
			if (rainData is null)
				throw new System.ArgumentNullException(nameof(rainData));

			if (rainData.SelectToken("3h") != null)
				H3 = double.Parse(rainData.SelectToken("3h").ToString(), CultureInfo.InvariantCulture);
		}

		public double H3 { get; }
	}
}
