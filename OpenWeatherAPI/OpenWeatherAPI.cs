using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherAPI
{
    public class OpenWeatherAPI
    {
        string openWeatherAPIKey;

        public OpenWeatherAPI(string apiKey)
        {
            openWeatherAPIKey = apiKey;
        }

        public void updateAPIKey(string apiKey)
        {
            openWeatherAPIKey = apiKey;
        }

        //Returns null if invalid request
        public Query query(string queryStr)
        {
            Query newQuery = new Query(openWeatherAPIKey, queryStr);
            if (newQuery.ValidRequest)
                return newQuery;
            return null;
        }
    }
}
