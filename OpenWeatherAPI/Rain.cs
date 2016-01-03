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
        private double h1, h3, h5;

        public double H1 { get { return h1; } }

        public Rain(JToken rainData)
        {
            if(rainData.SelectToken("1h") != null)
                h1 = double.Parse(rainData.SelectToken("1h").ToString());
            if (rainData.SelectToken("3h") != null)
                h3 = double.Parse(rainData.SelectToken("3h").ToString());
            if (rainData.SelectToken("5h") != null)
                h5 = double.Parse(rainData.SelectToken("5h").ToString());
        }
    }
}
