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
        private const string Temp = "temp";
        private const string TempMin = "temp_min";
        private const string TempMax = "temp_max";
        private const string PressureSelector = "pressure";
        private const string HumiditySelector = "humidity";
        private const string SeaLevelSelector = "sea_level";
        private const string GroundLevel = "grnd_level";

        public Temperature Temperature { get; private set; }
        public double Pressure { get; private set; }
        public double Humdity { get; private set; }
        public double SeaLevelAtm { get; private set; }
        public double GroundLevelAtm { get; private set; }

        public Main(JToken mainData)
        {
            Temperature = new Temperature(double.Parse(mainData.SelectToken(Temp).ToString()),
                double.Parse(mainData.SelectToken(TempMin).ToString()), double.Parse(mainData.SelectToken(TempMax).ToString()));

            Pressure = double.Parse(mainData.SelectToken(PressureSelector).ToString());
            Humdity = double.Parse(mainData.SelectToken(HumiditySelector).ToString());

            if (mainData.SelectToken(SeaLevelSelector) != null)
                SeaLevelAtm = double.Parse(mainData.SelectToken(SeaLevelSelector).ToString());

            if (mainData.SelectToken(GroundLevel) != null)
                GroundLevelAtm = double.Parse(mainData.SelectToken(GroundLevel).ToString());
        }
    }
}
