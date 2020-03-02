using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    public class Rain
    {
        public readonly double H3;

        public Rain(JToken rainData)
        {
            if (rainData.SelectToken("3h") != null)
                H3 = double.Parse(rainData.SelectToken("3h").ToString());
        }
    }
}
