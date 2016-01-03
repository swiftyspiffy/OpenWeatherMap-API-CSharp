using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    public class Clouds
    {
        private double all;

        public double All { get { return all; } }

        public Clouds(JToken cloudsData)
        {
            all = double.Parse(cloudsData.SelectToken("all").ToString());
        }
    }
}
