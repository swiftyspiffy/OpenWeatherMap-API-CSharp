using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    public class Snow
    {
        private double h3;

        public double H3 { get { return h3; } }
        public Snow(JToken snowData)
        {
            if (snowData.SelectToken("3h") != null)
                h3 = double.Parse(snowData.SelectToken("3h").ToString());
        }
    }
}
