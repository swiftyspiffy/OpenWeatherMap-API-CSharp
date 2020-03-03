using Newtonsoft.Json.Linq;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Snow
	{
		public Snow(JToken snowData)
		{
			if (snowData is null)
				throw new System.ArgumentNullException(nameof(snowData));

			if (snowData.SelectToken("3h") != null)
				H3 = double.Parse(snowData.SelectToken("3h").ToString(), CultureInfo.InvariantCulture);
		}

		public double H3 { get; }
	}
}
