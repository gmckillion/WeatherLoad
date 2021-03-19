using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using API.Weather.OpenWeatherMap;
using API.Weather.Model;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WeatherLoad
{
    class Program
    {

        const string _configFileName = "appsettings.json";

        private class ConfigOpenWeatherMap
        {
            public string Url { get; set; }
            public string AccessKey { get; set; }
        }

        static void Main(string[] args)
        {
            string cityName = "<missing argument>";

            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("Missing CityName Parameter.  Call with ? for usage");
                }
                else
                {
                    if(args[0] == "?")
                    {
                        Console.WriteLine("=================================");
                        Console.WriteLine("==         WeatherLoad         ==");
                        Console.WriteLine("==  OpenWeatherMap API Caller  ==");
                        Console.WriteLine("==    (with insert into DB)    ==");
                        Console.WriteLine("==                             ==");
                        Console.WriteLine("==     Gary McKillion 2021     ==");
                        Console.WriteLine("=================================\r\n");
                        Console.WriteLine("Example: WeatherLoad \"New York\"\r\n");
                        Console.WriteLine("NOTE: This utility is a demonstrator, supported cities are: London, Madrid, Paris, New York, Sydney");

                        return;
                    }
                    else
                    {
                        cityName = args[0];
                    }
                }

                Console.WriteLine(String.Format("Info: Reading config file from '{0}'", _configFileName));

                //get the config for the API and the DB Connection String   
                IConfiguration Configuration = new ConfigurationBuilder()
                  .AddJsonFile(_configFileName, optional: true, reloadOnChange: true)
                  .AddEnvironmentVariables()
                  .AddCommandLine(args)
                  .Build();

                var apiSettings = Configuration.GetSection("APISettings").GetSection("OpenWeatherMap");
                string connString = Configuration.GetSection("ConnectionStrings").GetSection("WeatherDatabase").Get<String>();

                ConfigOpenWeatherMap configOpenWeatherMap = apiSettings.Get<ConfigOpenWeatherMap>();

                //setup the database onbjects
                DB.Weather.DBWeatherLoad dbWL = new DB.Weather.DBWeatherLoad(connString);
                DB.Weather.DBWeatherReading dbWR = new DB.Weather.DBWeatherReading(connString);
                DB.Weather.DBWeatherLocation dbLoc = new DB.Weather.DBWeatherLocation(connString);

                //get the location record matches for "cityName"
                List<WeatherLocation> loc = dbLoc.GetByCity(cityName);

                if (loc.Count == 0)
                    throw new Exception(String.Format("City Name '{0}' not found in Locations table.", cityName));
                else if (loc.Count > 1)
                    throw new Exception(String.Format("Multiple Location matches for City Name '{0}'.", cityName));

                Console.WriteLine(String.Format("Info: Calling API {0} for City Name '{1}'", configOpenWeatherMap.Url, cityName));
                //call and WAIT for the API with the City parameter (argument of this console app)
                API.Weather.Model.WeatherLoad currentWeather = GetCurrentWeather(configOpenWeatherMap.Url, configOpenWeatherMap.AccessKey, cityName).GetAwaiter().GetResult();

                if(currentWeather.WeatherReadings.Count == 0)
                {
                    throw new Exception("API call returned no current weather readings");
                }
                else
                {
                    Console.WriteLine("Info: The temperature in {0} is {1}C", cityName, currentWeather.WeatherReadings[0].Temperature_C.ToString());
                }

                //insert the weather load record
                int weatherLoadId = dbWL.AddRow(currentWeather);

                //insert the Readings into the database
                foreach (WeatherReading wr in currentWeather.WeatherReadings)
                {
                    wr.WeatherLoadId = weatherLoadId;
                    wr.WeatherLocationId = loc[0].WeatherLocationId; //set the location id (foreign key)
                    dbWR.AddRow(currentWeather.WeatherReadings[0]); //insert the reading intto the database
                }

                Console.WriteLine("Success: Weather Load '{0}' added to Database", weatherLoadId);
            }
            catch (Exception ex)
            {
                if(ex is ArgumentException)
                {
                    Console.WriteLine($"!! ERROR: ArgumentException: {ex.Message}");
                }
                else
                {
                    Console.WriteLine($"!! ERROR: {ex.Message}");
                }
            }
        }

        static async Task<API.Weather.Model.WeatherLoad> GetCurrentWeather(string url, string accessKey, string city)
        {
            CurrentWeatherClient currentWeather = new API.Weather.OpenWeatherMap.CurrentWeatherClient(new System.Net.Http.HttpClient(), url, accessKey);

            var result = await currentWeather.Get("London");

            return result;
        }

    }


}
