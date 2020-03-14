# OpenWeatherMap-API - C# Library
### Overview
This library takes what openweathermap api returns in JSON, and converts it to C# objects for easy interaction with in C# projects.  It supports (most/all) of the returned data the API returns in JSON. The JSON api returned properties are sometimes present, and sometimes not.  I have done my best to detect properties that are prone to not being presented, and assigning those values null.  You should check certain properties for null vals before assigning under the assumption they are good values.  It is also possible I missed values, and the C# library may nullref.  This project was originally created to be used in a Twitch chat bot, but has been released for others to use.

### Returned Data
- Clouds
  * All - Level of cloudiness (percentage of cloud cover?)
- Coords
  * Longitude - Query location longitude
  * Latitude - Query location latitude
- Main
  * CelsiusCurrent - Returns converted Kelvin values of current temperature in Centigrade
  * FahrenheitCurrent - Returns converted Kelvin values of current temperature in Fahrenheight
  * KelvinCurrent - Returns raw openweather API values for temperature in Kelvin
  * CelsiusMinimum - Returns converted Kelvin values of minimum temperature in Centigrade
  * CelsiusMaximum - Returns converted Kelvin values of maximum temperature in Centigrade
  * FahrenheitMinimum - Returns converted Kelvin values of minimum temperature in Fahrenheight
  * FahrenheitMaximum - Returns converted Kelvin values of maximum temperature in Fahrenheight
  * KelvinMinimum - Returns raw openweather API values for minimum temperature in Kelvin
  * KelvinMaximum - Returns raw openweather API values for maximum temperatures in Kelvin
  * SeaLevel - Returns atmospheric pressure on sea level, hPa, raw from openweather API
  * GroundLevel - Returns atmospheric pressure on ground level, hPa, raw from openweather API
- Rain
  * 3h - Returns rain related data for the last 3 hours at query location (if available).
- Snow
  * 3h - Returns snow related data for the last 3 hours at query location (if available).
- Sys
  * Type - System related parameter, avoid usage
  * ID - Openweather API city identification int
  * Message - System related parameter, avoid usage
  * Country - Country code of given query location
  * Sunrise - Returns DateTime for sunrise converted from openweather API returned unix time.
  * Sunset - Returns DateTime for sunset converted from openweather API returned unix time.
- Weather
  * ID - System related parameter, avoid usage
  * Main - Main description of the weather (IE rain, snow, etc.)
  * Description - Description of main parameter (heavy intensity rain, etc)
  * Icon - Weather icon ID
- Wind
  * SpeedMetersPerSecond -  Gives wind speed in raw values returned by openweathermap api, in meters per second
  * SpeedFeetPerSecond - Gives wind speed in converted values in feet per second
  * Direction - Returns DirectionEnum with details of direction of wind on basis of degree
  * Degree - Returns raw 360-oriented degree returned by openweathermap api
  * Gust - Returns speed of wind gusts in meters per second
### Added Functionality
- Additional Main values:  By default the openweathermap API returns just Kelvin temperatures.  I have created properties in the Main class that returns equivalent Celsius and Fahrenheight
- DirectionEnum - Added direction enum in Wind class that is set in constructor on the basis of degree double
- directionEnumToString(DirectionEnum dir) - Returns string value of wind direction on the basis of passed in DirectionEnum

### Installing
1. Clone this code
   - `git clone https://github.com/swiftyspiffy/OpenWeatherMap-API-CSharp.git`
2. Open the code in VS
3. Build the code base
4. In your project that's using this code, reference the built DLL from the previous step:
   - Project dropdown -> Add Reference -> Search for the created DLL(s) file.
   - Generally, the path is something like: `/OpenWeatherMap-API-CSharp/bin/Debug/OpenWeatherAPI.dll`
   - You may also need to reference the `Newtonsoft.Json.dll` if you aren't already using this library.

### Example Usage
```csharp
OpenWeatherAPI.OpenWeatherAPI openWeatherAPI = new OpenWeatherAPI.OpenWeatherAPI("my open weather api key");
OpenWeatherAPI.Query query = openWeatherAPI.query("city/location query");
Console.WriteLine(string.Format("The temperature in {0}, {1} is currently {2} °F", query.Name,query.Sys.Country, query.Main.Temperature.FahrenheitCurrent));
```

### Sample Project
This repository also has a sample project. Find it here: https://github.com/swiftyspiffy/OpenWeatherMap-API-CSharp/tree/master/OpenWeatherAPI%20Example

### Credits and Libraries Utilized
- Newtonsoft.Json - JSON parsing class. 

### License
The MIT License (MIT)

Copyright (c) 2015 swiftyspiffy

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
