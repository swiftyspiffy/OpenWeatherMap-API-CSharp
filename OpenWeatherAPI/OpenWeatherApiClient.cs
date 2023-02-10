using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherAPI
{
	public class OpenWeatherApiClient : IDisposable
	{
		private readonly string _apiKey;
		private readonly HttpClient _httpClient;
		private readonly bool _useHttps;
		public OpenWeatherApiClient(string apiKey, bool useHttps = false)
		{
			_apiKey = apiKey;
			_httpClient = new HttpClient();
			_useHttps = useHttps;
		}

		private async Task<Uri> GenerateRequestUrl(string queryString)
		{
			var geo = await Geolocate(queryString).ConfigureAwait(false);

			string scheme = "http";
			if (_useHttps)
				scheme = "https";
			return new Uri($"{scheme}://api.openweathermap.org/data/2.5/weather?appid={_apiKey}&lat={geo.Lat}&lon={geo.Lon}");
		}

		public async Task<GeoResponse> Geolocate(string queryString)
		{
			string scheme = "http";
			if (_useHttps)
				scheme = "https";

			var jsonResponse = await _httpClient
				.GetStringAsync(
					new Uri($"{scheme}://api.openweathermap.org/geo/1.0/direct?q={queryString}&limit={1}&appid={_apiKey}"))
				.ConfigureAwait(false);
			return new GeoResponse(jsonResponse);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="queryString"></param>
		/// <returns>Returns null if the query is invalid.</returns>
		public async Task<QueryResponse> QueryAsync(string queryString)
		{
			var jsonResponse = await _httpClient.GetStringAsync(GenerateRequestUrl(queryString).Result).ConfigureAwait(false);
			var query = new QueryResponse(jsonResponse);
			return query.ValidRequest ? query : null;
		}

		/// <summary>
		/// Non-async version. Use for legacy code, use Async version wherever possible.
		/// </summary>
		/// <param name="queryString"></param>
		/// <returns>Returns null if the query is invalid.</returns>
		[Obsolete("Use Async version wherever possible.")]
		public QueryResponse Query(string queryString)
		{
			return Task.Run(async () => await QueryAsync(queryString).ConfigureAwait(false)).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		private bool _disposed;

		public void Dispose()
		{
			// Dispose of unmanaged resources.
			Dispose(true);
			// Suppress finalization.
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}

			if (disposing)
			{
				// dispose managed state (managed objects).
			}

			// free unmanaged resources (unmanaged objects) and override a finalizer below.
			// set large fields to null.

			_httpClient.Dispose();

			_disposed = true;
		}
	}
}
