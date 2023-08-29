using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace OpenWeatherAPI.Tests
{
	/// <summary>
	/// Tests <see cref="OpenWeatherApiClient"/>
	/// </summary>
	public class APITests
	{
		private const string apiKey = "API key goes here"; //No good solution here to have safe and valid OpenWeather API keys in a test
		private readonly ITestOutputHelper output;

		public APITests(ITestOutputHelper output)
		{
			this.output = output;
		}

		[Fact]
		public async Task QueryTest_Success()
		{
			//Arrange
			var api = new OpenWeatherApiClient(apiKey);

			//Act
			var actual = await api.QueryAsync("Rotterdam,NL");

			//Assert
			Assert.True(actual.ValidRequest);

			output.WriteLine(JsonConvert.SerializeObject(actual, Formatting.Indented));
		}

		[Fact]
		public async Task QueryTestHttps_Success()
		{
			//Arrange
			var api = new OpenWeatherApiClient(apiKey, true);

			//Act
			var actual = await api.QueryAsync("Rotterdam,NL");

			//Assert
			Assert.True(actual.ValidRequest);
			Assert.True(actual.Main.Temperature.KelvinCurrent < 1000);

			output.WriteLine(JsonConvert.SerializeObject(actual, Formatting.Indented));
		}

		[Fact]
		public async Task Geolocate_Success()
		{
			//Arrange
			var api = new OpenWeatherApiClient(apiKey);

			//Act
			var actual = await api.Geolocate("Rotterdam,NL");

			//Assert
			Assert.True(actual.ValidRequest);

			output.WriteLine(JsonConvert.SerializeObject(actual, Formatting.Indented));
		}

		[Fact]
		public async Task GeolocateHttps_Success()
		{
			//Arrange
			var api = new OpenWeatherApiClient(apiKey, true);

			//Act
			var actual = await api.Geolocate("Rotterdam,NL");

			//Assert
			Assert.True(actual.ValidRequest);

			output.WriteLine(JsonConvert.SerializeObject(actual, Formatting.Indented));
		}
	}
}
