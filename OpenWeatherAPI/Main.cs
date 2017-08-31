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
        public Temperature Temperature { get; private set; }
        public double Pressure { get; private set; }
        public double Humdity { get; private set; }
        public double SeaLevelAtm { get; private set; }
        public double GroundLevelAtm { get; private set; }

        public Main(JToken mainData)
        {
            Temperature = new Temperature(double.Parse(mainData.SelectToken("temp").ToString()),
                double.Parse(mainData.SelectToken("temp_min").ToString()), double.Parse(mainData.SelectToken("temp_max").ToString()));
            Pressure = double.Parse(mainData.SelectToken("pressure").ToString());
            Humdity = double.Parse(mainData.SelectToken("humidity").ToString());
            if (mainData.SelectToken("sea_level") != null)
                SeaLevelAtm = double.Parse(mainData.SelectToken("sea_level").ToString());
            if (mainData.SelectToken("grnd_level") != null)
                GroundLevelAtm = double.Parse(mainData.SelectToken("grnd_level").ToString());
        }
    }
}
