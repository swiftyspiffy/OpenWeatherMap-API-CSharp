using Newtonsoft.Json;
using System.Diagnostics;
using Xunit;

namespace OpenWeatherAPI.Tests
{
	/// <summary>
	/// Tests <see cref="API"/>
	/// </summary>
	public class APITests
	{
		[Fact()]
		public void QueryTest_Success()
		{
			//Arrange
			var api = new API("YOURAPIKEYHERE"); //No good solution here to have safe and valid OpenWeather API keys in a test

			//Act
			var actual = api.Query("Rotterdam,NL");

			//Assert
			Assert.True(actual.ValidRequest);

			Trace.WriteLine(JsonConvert.SerializeObject(actual, Formatting.Indented));
		}
	}
}
