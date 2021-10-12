namespace OpenWeatherAPI
{
	public class API
	{
		private readonly string _openWeatherApiKey;

		public API(string apiKey)
		{
			_openWeatherApiKey = apiKey;
		}

		//Returns null if invalid request
		public Query Query(string queryStr)
		{
			var newQuery = new Query(_openWeatherApiKey, queryStr);
			if (newQuery.ValidRequest)
				return newQuery;
			return null;
		}
	}
}
