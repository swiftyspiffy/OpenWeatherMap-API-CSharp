using System;

namespace OpenWeatherAPI
{
	public class TemperatureObj
	{
		public double CelsiusCurrent { get; }
		public double FahrenheitCurrent { get; }
		public double KelvinCurrent { get; }
		public double CelsiusMinimum { get; }
		public double CelsiusMaximum { get; }
		public double FahrenheitMinimum { get; }
		public double FahrenheitMaximum { get; }
		public double KelvinMinimum { get; }
		public double KelvinMaximum { get; }

		public TemperatureObj(double temp, double min, double max)
		{
			KelvinCurrent = temp;
			KelvinMaximum = max;
			KelvinMinimum = min;

			CelsiusCurrent = convertToCelsius(KelvinCurrent);
			CelsiusMaximum = convertToCelsius(KelvinMaximum);
			CelsiusMinimum = convertToCelsius(KelvinMinimum);

			FahrenheitCurrent = convertToFahrenheit(CelsiusCurrent);
			FahrenheitMaximum = convertToFahrenheit(CelsiusMaximum);
			FahrenheitMinimum = convertToFahrenheit(CelsiusMinimum);
		}

		private double convertToFahrenheit(double celsius)
		{
			return Math.Round(((9.0 / 5.0) * celsius) + 32, 3);
		}

		private double convertToCelsius(double kelvin)
		{
			return Math.Round(kelvin - 273.15, 3);
		}
	}
}
