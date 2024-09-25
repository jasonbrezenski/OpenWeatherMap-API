using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMap_API;

public class OpenWeatherMapApi
{
    public static void GetWeatherInfo()
    {
        var appsettingsText = File.ReadAllText("appsettings.json");

        var apiKey = JObject.Parse(appsettingsText)["key"].ToString();

        Console.WriteLine("Please enter your 5 digit zipcode:");
        var userInput = int.Parse(Console.ReadLine());
    
        var url = $"https://api.openweathermap.org/data/2.5/weather?zip={userInput}&appid={apiKey}&units=imperial";

        var client = new HttpClient();

        var weatherResponseJson = client.GetStringAsync(url).Result;

        var actualTemp = JObject.Parse(weatherResponseJson)["main"]["temp"].ToString();
        var feelsLike = JObject.Parse(weatherResponseJson)["main"]["feels_like"].ToString();
        var highTemp = JObject.Parse(weatherResponseJson)["main"]["temp_max"].ToString();

        Console.WriteLine();
        Console.WriteLine($"Currently in your location, the temperature is {actualTemp} degrees Fahrenheit " +
                          $"but the 'feels like' temperature is {feelsLike} degrees. " +
                          $"Today's high temperature will be {highTemp} degrees!");
    }
    
}