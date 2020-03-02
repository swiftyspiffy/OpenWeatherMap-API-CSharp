using Newtonsoft.Json;
using System.Diagnostics;
using Xunit;

namespace OpenWeatherAPI.Tests
{
    public class OpenWeatherAPITests
    {
        [Fact(Skip = "Needs API key config")]
        public void QueryTest_Success()
        {
            //Arrange
            var api = new OpenWeatherAPI("");

            //Act
            var actual = api.Query("Rotterdam,NL");

            //Assert
            Assert.True(actual.ValidRequest);

            Trace.WriteLine(JsonConvert.SerializeObject(actual, Formatting.Indented));
        }
    }
}
