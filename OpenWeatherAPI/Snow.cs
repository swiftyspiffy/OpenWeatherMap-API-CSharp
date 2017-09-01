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
        private const string ThreeHour = "3h";
        
        public double H3 { get; private set; }
        public Snow(JToken snowData)
        {
            if (snowData.SelectToken(ThreeHour) != null)
                H3 = double.Parse(snowData.SelectToken(ThreeHour).ToString());
        }
    }
}
