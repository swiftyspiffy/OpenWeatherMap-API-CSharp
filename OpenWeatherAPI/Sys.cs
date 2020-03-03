using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Sys
	{
		private readonly DateTime sunset;

		public int Type { get; }

		public int ID { get; }

		public double Message { get; }

		public string Country { get; }

		public DateTime Sunrise { get; }

		public DateTime Sunset => sunset;

		public Sys(JToken sysData)
		{
			if (sysData is null)
				throw new ArgumentNullException(nameof(sysData));


			if (sysData.SelectToken("type") != null)
				Type = int.Parse(sysData.SelectToken("type").ToString(), CultureInfo.InvariantCulture);
			if (sysData.SelectToken("id") != null)
				ID = int.Parse(sysData.SelectToken("id").ToString(), CultureInfo.InvariantCulture);
			if (sysData.SelectToken("message") != null)
				Message = double.Parse(sysData.SelectToken("message").ToString(), CultureInfo.InvariantCulture);
			Country = sysData.SelectToken("country").ToString();
			Sunrise = convertUnixToDateTime(double.Parse(sysData.SelectToken("sunrise").ToString(), CultureInfo.InvariantCulture));
			sunset = convertUnixToDateTime(double.Parse(sysData.SelectToken("sunset").ToString(), CultureInfo.InvariantCulture));
		}

		private DateTime convertUnixToDateTime(double unixTime)
		{
			DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			return dt.AddSeconds(unixTime).ToLocalTime();
		}
	}
}
