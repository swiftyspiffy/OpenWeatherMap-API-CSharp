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
        private const string AllSelector = "all";

        public double All { get; private set; }

        public Clouds(JToken cloudsData)
        {
            All = double.Parse(cloudsData.SelectToken(AllSelector).ToString());
        }
    }
}
