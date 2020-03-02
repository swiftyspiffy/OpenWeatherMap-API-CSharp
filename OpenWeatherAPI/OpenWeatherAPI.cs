namespace OpenWeatherAPI
{
    public class OpenWeatherAPI
    {
        private string openWeatherAPIKey;

        public OpenWeatherAPI(string apiKey)
        {
            openWeatherAPIKey = apiKey;
        }

        public void UpdateAPIKey(string apiKey)
        {
            openWeatherAPIKey = apiKey;
        }

        //Returns null if invalid request
        public Query Query(string queryStr)
        {
            Query newQuery = new Query(openWeatherAPIKey, queryStr);
            if (newQuery.ValidRequest)
                return newQuery;
            return null;
        }
    }
}
