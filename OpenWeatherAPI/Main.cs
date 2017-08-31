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
        private Temperature temp;
        private double pressure, humidity, sea_level, grnd_level;

        public Temperature Temperature { get { return temp; } }
        public double Pressure { get { return pressure; } }
        public double Humdity { get { return humidity; } }
        public double SeaLevelAtm { get { return sea_level; } }
        public double GroundLevelAtm { get { return grnd_level; } }

        public Main(JToken mainData)
        {
            temp = new Temperature(double.Parse(mainData.SelectToken("temp").ToString()),
                double.Parse(mainData.SelectToken("temp_min").ToString()), double.Parse(mainData.SelectToken("temp_max").ToString()));
            pressure = double.Parse(mainData.SelectToken("pressure").ToString());
            humidity = double.Parse(mainData.SelectToken("humidity").ToString());
            if (mainData.SelectToken("sea_level") != null)
                sea_level = double.Parse(mainData.SelectToken("sea_level").ToString());
            if (mainData.SelectToken("grnd_level") != null)
                grnd_level = double.Parse(mainData.SelectToken("grnd_level").ToString());
        }
    }
}
