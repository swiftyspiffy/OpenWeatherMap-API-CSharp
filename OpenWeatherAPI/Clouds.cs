using Newtonsoft.Json.Linq;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Clouds
	{
		public Clouds(JToken cloudsData)
		{
			if (cloudsData is null)
				throw new System.ArgumentNullException(nameof(cloudsData));


			All = double.Parse(cloudsData.SelectToken("all").ToString(), CultureInfo.InvariantCulture);
		}

		public double All { get; }
	}
}
