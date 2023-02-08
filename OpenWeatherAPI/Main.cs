using Newtonsoft.Json.Linq;
using System.Globalization;

namespace OpenWeatherAPI
{
	public partial class Main
	{
		public TemperatureObj Temperature { get; }

		public double Pressure { get; }

		public double Humidity { get; }

		public double SeaLevelAtm { get; }

		public double GroundLevelAtm { get; }

		public Main(JToken mainData)
		{
			if (mainData is null)
				throw new System.ArgumentNullException(nameof(mainData));

			Temperature = new TemperatureObj(
								double.Parse(mainData.SelectToken("temp").ToString(), CultureInfo.CurrentCulture),
								double.Parse(mainData.SelectToken("temp_min").ToString(), CultureInfo.CurrentCulture),
								double.Parse(mainData.SelectToken("temp_max").ToString(), CultureInfo.CurrentCulture));

			Pressure = double.Parse(mainData.SelectToken("pressure").ToString(), CultureInfo.CurrentCulture);
			Humidity = double.Parse(mainData.SelectToken("humidity").ToString(), CultureInfo.CurrentCulture);
			if (mainData.SelectToken("sea_level") != null)
				SeaLevelAtm = double.Parse(mainData.SelectToken("sea_level").ToString(), CultureInfo.CurrentCulture);
			if (mainData.SelectToken("grnd_level") != null)
				GroundLevelAtm = double.Parse(mainData.SelectToken("grnd_level").ToString(), CultureInfo.CurrentCulture);
		}
	}
}
