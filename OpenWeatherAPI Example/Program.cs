using System;

namespace OpenWeatherAPI_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new OpenWeatherAPI.OpenWeatherAPI("YOUR-API-KEY");

            Console.WriteLine("OpenWeatherAPI Example Application");
            Console.WriteLine();

            Console.WriteLine("Enter city to get weather data for:");
            var city = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine($"Fetching weather data for '{city}'");
            var results = client.Query(city);

            Console.WriteLine($"The temperature in {city} is {results.Main.Temperature.FahrenheitCurrent}F. There is {results.Wind.SpeedFeetPerSecond} f/s wind in the {results.Wind.Direction} direction.");

            Console.ReadLine();
        }
    }
}
