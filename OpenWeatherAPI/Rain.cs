using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    public class Rain
    {
        private const string ThreeHour = "3h";

        public double H3 { get; private set; }

        public Rain(JToken rainData)
        {
            if (rainData.SelectToken(ThreeHour) != null)
                H3 = double.Parse(rainData.SelectToken(ThreeHour).ToString());
        }
    }
}
