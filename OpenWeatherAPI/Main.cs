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
        private TemperatureObj temp;
        private double pressure, humidity, sea_level, grnd_level;

        public TemperatureObj Temperature { get { return temp; } }
        public double Pressure { get { return pressure; } }
        public double Humdity { get { return humidity; } }
        public double SeaLevelAtm { get { return sea_level; } }
        public double GroundLevelAtm { get { return grnd_level; } }

        public Main(JToken mainData)
        {
            temp = new TemperatureObj(double.Parse(mainData.SelectToken("temp").ToString()),
                double.Parse(mainData.SelectToken("temp_min").ToString()), double.Parse(mainData.SelectToken("temp_max").ToString()));
            pressure = double.Parse(mainData.SelectToken("pressure").ToString());
            humidity = double.Parse(mainData.SelectToken("humidity").ToString());
            if (mainData.SelectToken("sea_level") != null)
                sea_level = double.Parse(mainData.SelectToken("sea_level").ToString());
            if (mainData.SelectToken("grnd_level") != null)
                grnd_level = double.Parse(mainData.SelectToken("grnd_level").ToString());
        }

        public class TemperatureObj
        {
            private double current_kel_temp, temp_kel_min, temp_kel_max;
            private double current_cel_temp, temp_cel_min, temp_cel_max;

            public double CelsiusCurrent { get { return current_cel_temp; } }
            public double FahrenheitCurrent { get { return convertToFahrenheit(current_cel_temp); } }
            public double KelvinCurrent { get { return current_kel_temp; } }
            public double CelsiusMinimum { get { return temp_cel_min; } }
            public double CelsiusMaximum { get { return temp_cel_max; } }
            public double FahrenheitMinimum { get { return convertToFahrenheit(temp_cel_min); } }
            public double FahrenheitMaximum { get { return convertToFahrenheit(temp_cel_max); } }
            public double KelvinMinimum { get { return temp_kel_min; } }
            public double KelvinMaximum { get { return temp_kel_max; } }

            public TemperatureObj(double temp, double min, double max)
            {
                current_kel_temp = temp;
                temp_kel_min = min;
                temp_kel_max = max;
                current_cel_temp = convertToCelsius(current_kel_temp);
                temp_cel_min = convertToCelsius(temp_kel_min);
                temp_cel_max = convertToCelsius(temp_kel_max);
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
