using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    public class Coord
    {
        private const string Long = "long";
        private const string Lat = "lat";

        public double Longitude { get; private set; }
        public double Latitude { get; private set; }

        public Coord(JToken coordData)
        {
            Longitude = double.Parse(coordData.SelectToken(Long).ToString());
            Latitude = double.Parse(coordData.SelectToken(Lat).ToString());
        }
    }
}
