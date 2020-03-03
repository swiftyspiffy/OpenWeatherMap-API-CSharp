using Newtonsoft.Json.Linq;
using System.Globalization;

namespace OpenWeatherAPI
{
	public partial class Main
	{
		public TemperatureObj Temperature { get; }

		public double Pressure { get; }

		public double Humdity { get; }

		public double SeaLevelAtm { get; }

		public double GroundLevelAtm { get; }

		public Main(JToken mainData)
		{
			if (mainData is null)
				throw new System.ArgumentNullException(nameof(mainData));

			Temperature = new TemperatureObj(
								double.Parse(mainData.SelectToken("temp").ToString(), CultureInfo.InvariantCulture),
								double.Parse(mainData.SelectToken("temp_min").ToString(), CultureInfo.InvariantCulture),
								double.Parse(mainData.SelectToken("temp_max").ToString(), CultureInfo.InvariantCulture));

			Pressure = double.Parse(mainData.SelectToken("pressure").ToString(), CultureInfo.InvariantCulture);
			Humdity = double.Parse(mainData.SelectToken("humidity").ToString(), CultureInfo.InvariantCulture);
			if (mainData.SelectToken("sea_level") != null)
				SeaLevelAtm = double.Parse(mainData.SelectToken("sea_level").ToString(), CultureInfo.InvariantCulture);
			if (mainData.SelectToken("grnd_level") != null)
				GroundLevelAtm = double.Parse(mainData.SelectToken("grnd_level").ToString(), CultureInfo.InvariantCulture);
		}
	}
}
