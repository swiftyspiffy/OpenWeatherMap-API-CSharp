using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    public class Main
    {
        public readonly TemperatureObj Temperature;
        public readonly double Pressure;
        public readonly double Humdity;
        public readonly double SeaLevelAtm;
        public readonly double GroundLevelAtm;

        public Main(JToken mainData)
        {
            Temperature = new TemperatureObj(double.Parse(mainData.SelectToken("temp").ToString()),
                double.Parse(mainData.SelectToken("temp_min").ToString()), double.Parse(mainData.SelectToken("temp_max").ToString()));
            Pressure = double.Parse(mainData.SelectToken("pressure").ToString());
            Humdity = double.Parse(mainData.SelectToken("humidity").ToString());
            if (mainData.SelectToken("sea_level") != null)
                SeaLevelAtm = double.Parse(mainData.SelectToken("sea_level").ToString());
            if (mainData.SelectToken("grnd_level") != null)
                GroundLevelAtm = double.Parse(mainData.SelectToken("grnd_level").ToString());
        }

        public class TemperatureObj
        {
            public readonly double CelsiusCurrent;
            public readonly double FahrenheitCurrent;
            public readonly double KelvinCurrent;
            public readonly double CelsiusMinimum;
            public readonly double CelsiusMaximum;
            public readonly double FahrenheitMinimum;
            public readonly double FahrenheitMaximum;
            public readonly double KelvinMinimum;
            public readonly double KelvinMaximum;

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
}
