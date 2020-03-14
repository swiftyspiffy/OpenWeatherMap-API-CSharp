namespace OpenWeatherAPI
{
	public class API
	{
		private string openWeatherAPIKey;

		public API(string apiKey)
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
