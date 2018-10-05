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
        public readonly double Longitude;
        public readonly double Latitude;

        public Coord(JToken coordData)
        {
            Longitude = double.Parse(coordData.SelectToken("lon").ToString());
            Latitude = double.Parse(coordData.SelectToken("lat").ToString());
        }
    }
}
