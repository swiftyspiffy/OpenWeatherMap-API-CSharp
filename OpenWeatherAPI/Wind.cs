using Newtonsoft.Json.Linq;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Wind
	{
		public enum DirectionEnum
		{
			North,
			North_North_East,
			North_East,
			East_North_East,
			East,
			East_South_East,
			South_East,
			South_South_East,
			South,
			South_South_West,
			South_West,
			West_South_West,
			West,
			West_North_West,
			North_West,
			North_North_West,
			Unknown
		}

		public double SpeedMetersPerSecond { get; }

		public double SpeedFeetPerSecond { get; }

		public DirectionEnum Direction { get; }

		public double Degree { get; }

		public double Gust { get; }

		public Wind(JToken windData)
		{
			if (windData is null)
				throw new System.ArgumentNullException(nameof(windData));


			SpeedMetersPerSecond = double.Parse(windData.SelectToken("speed").ToString(), CultureInfo.InvariantCulture);
			SpeedFeetPerSecond = SpeedMetersPerSecond * 3.28084;
			Degree = double.Parse(windData.SelectToken("deg").ToString(), CultureInfo.InvariantCulture);
			Direction = assignDirection(Degree);
			if (windData.SelectToken("gust") != null)
				Gust = double.Parse(windData.SelectToken("gust").ToString(), CultureInfo.InvariantCulture);
		}

		public static string DirectionEnumToString(DirectionEnum dir)
		{
			switch (dir)
			{
				case DirectionEnum.East:
					return "East";
				case DirectionEnum.East_North_East:
					return "East North-East";
				case DirectionEnum.East_South_East:
					return "East South-East";
				case DirectionEnum.North:
					return "North";
				case DirectionEnum.North_East:
					return "North East";
				case DirectionEnum.North_North_East:
					return "North North-East";
				case DirectionEnum.North_North_West:
					return "North North-West";
				case DirectionEnum.North_West:
					return "North West";
				case DirectionEnum.South:
					return "South";
				case DirectionEnum.South_East:
					return "South East";
				case DirectionEnum.South_South_East:
					return "South South-East";
				case DirectionEnum.South_South_West:
					return "South South-West";
				case DirectionEnum.South_West:
					return "South West";
				case DirectionEnum.West:
					return "West";
				case DirectionEnum.West_North_West:
					return "West North-West";
				case DirectionEnum.West_South_West:
					return "West South-West";
				case DirectionEnum.Unknown:
					return "Unknown";
				default:
					return "Unknown";
			}
		}

		private DirectionEnum assignDirection(double degree)
		{
			if (fB(degree, 348.75, 360))
				return DirectionEnum.North;
			if (fB(degree, 0, 11.25))
				return DirectionEnum.North;
			if (fB(degree, 11.25, 33.75))
				return DirectionEnum.North_North_East;
			if (fB(degree, 33.75, 56.25))
				return DirectionEnum.North_East;
			if (fB(degree, 56.25, 78.75))
				return DirectionEnum.East_North_East;
			if (fB(degree, 78.75, 101.25))
				return DirectionEnum.East;
			if (fB(degree, 101.25, 123.75))
				return DirectionEnum.East_South_East;
			if (fB(degree, 123.75, 146.25))
				return DirectionEnum.South_East;
			if (fB(degree, 168.75, 191.25))
				return DirectionEnum.South;
			if (fB(degree, 191.25, 213.75))
				return DirectionEnum.South_South_West;
			if (fB(degree, 213.75, 236.25))
				return DirectionEnum.South_West;
			if (fB(degree, 236.25, 258.75))
				return DirectionEnum.West_South_West;
			if (fB(degree, 258.75, 281.25))
				return DirectionEnum.West;
			if (fB(degree, 281.25, 303.75))
				return DirectionEnum.West_North_West;
			if (fB(degree, 303.75, 326.25))
				return DirectionEnum.North_West;
			if (fB(degree, 326.25, 348.75))
				return DirectionEnum.North_North_West;
			return DirectionEnum.Unknown;
		}

		//fB = fallsBetween
		private static bool fB(double val, double min, double max)
		{
			if ((min <= val) && (val <= max))
				return true;
			return false;
		}
	}
}
