using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using API.Weather.OpenWeatherMap.Request;
using API.Weather.OpenWeatherMap.Response;
using API.Weather.Model;

namespace API.Weather.OpenWeatherMap
{
    public class CurrentWeatherClient : RestAPIWrapper, ICurrentWeatherClient
    {
        private DateTime? _requestStartDateTime;
        private DateTime? _requestEndDateTime;
        private long _responseSizeBytes = 0;
        private string _AccessKey { get; set;  }

        public CurrentWeatherClient(HttpClient client, string url, string accessKey) : base(client, url)
        {
            _AccessKey = accessKey; // "d7432f95eff46ab9d1047f641430710f";
        }

        public async Task<WeatherLoad> Get(int cityId)
        {
            _Params = new Dictionary<string, string>();

            _Params.Add("id", cityId.ToString());
            _Params.Add("units", OW_Unit.Metric.ToString("g"));
            _Params.Add("appid", _AccessKey);

            _requestStartDateTime = DateTime.Now.ToUniversalTime();
            _requestEndDateTime = null;
            _responseSizeBytes = 0;

            CurrentWeatherResponse response = await this.Get();

            if(response != null)
            {
                return SerialiseResponse(response);
            }
            else
            {
                return null;
            }
        }

        public async Task<WeatherLoad> Get(string city)
        {
            _Params = new Dictionary<string, string>();

            _Params.Add("q", city);
            _Params.Add("units", OW_Unit.Metric.ToString("g"));
            _Params.Add("appid", _AccessKey);

            _requestStartDateTime = DateTime.Now.ToUniversalTime();
            _requestEndDateTime = null;
            _responseSizeBytes = 0;

            CurrentWeatherResponse response = await this.Get();

            return SerialiseResponse(response);

            if (response != null)
            {
                return SerialiseResponse(response);
            }
            else
            {
                return null;
            }
        }

        private async Task<CurrentWeatherResponse> Get()
        {
            try
            {
                try
                {
                    using var responseStream = await _Client.GetStreamAsync(GetUrl());
                    var currentForecast = await JsonSerializer.DeserializeAsync<CurrentWeatherResponse>(responseStream);
                    _requestEndDateTime = DateTime.Now.ToUniversalTime();
                    //_responseSizeBytes = responseStream.Length;

                    return currentForecast;
                }
                catch (Exception e)
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                return null;
            }

        }

        
        private WeatherLoad SerialiseResponse(CurrentWeatherResponse response)
        {
            //Setup WeatherLoad header data
            WeatherLoad weatherLoad = new WeatherLoad
            {
                WeatherProviderId = enumWeatherProvider.WP_OpenWeatherMap,
                ResponseId = response.Sys is not null ? response.Sys.Id : null,
                Message = response.Sys is not null ? response.Sys.Message.ToString() : null,
                LoadStartDateTime_UTC = _requestStartDateTime.Value,
                LoadEndDateTime_UTC = DateTime.Now.ToUniversalTime(),
                LoadDurationMs = (int)_requestEndDateTime.Value.Subtract(_requestStartDateTime.Value).TotalMilliseconds,
                ResponseSizeBytes = _responseSizeBytes,
                RecordCount = 1
            };

            //Setup Weather Location Data
            WeatherLocation weatherLocation = new WeatherLocation
            {
                CountryISO = response.Sys is not null ? response.Sys.Country : null,
                CityName = response.CityName,
                CityId = response.CityId,
                Longitude = response.Coordinates.Longitude,
                Latitude = response.Coordinates.Latitude
            };

            //Setup Weather Readings
            WeatherReading weatherReading = new WeatherReading
            {
                WeatherDateTime_UTC = DateTimeOffset.FromUnixTimeSeconds(response.TimeOfDataCalculation).UtcDateTime, //convert from unix time (seconds since jan 1, 1970)
                WeatherLocation = weatherLocation, //Add location from above
                Temperature_C = response.Main.Temperature,
                FeelsLike_C = response.Main is not null ? response.Main.FeelsLike : null,
                TempMin_C = response.Main is not null ? response.Main.TempMin : null,
                TempMax_C = response.Main is not null ? response.Main.TempMax : null,
                Description = response.Weather[0].Description,
                Pressure_hPA = (short)response.Main.Pressure,
                Pressure_SeaLevel_hPA = (short)response.Main.Pressure_SeaLevel_hPA,
                Pressure_GroundLevel_hPA = (short)response.Main.Pressure_GroundLevel_hPA,
                Humidity_Pct = (short)response.Main.Humidity,
                WindSpeed_MS = (short)response.Wind.Speed,
                WindSpeed_Deg = (short)response.Wind.Deg,
                WindSpeed_Gust = (short)response.Wind.Gust,
                CloudCover_Pct = (short)response.Clouds.All,
                Rain1h_mm = response.Rain is not null ? response.Rain.Rain1h : null,
                Rain3h_mm = response.Rain is not null ? response.Rain.Rain3h : null,
                Snow1h_mm = response.Snow is not null ? response.Snow.Snow1h : null,
                Snow3h_mm = response.Snow is not null ? response.Snow.Snow3h : null,
                WeatherIconId = response.Weather[0].Icon
            };

            //Add the weather reading to the WeatherLoad object
            weatherLoad.WeatherReadings = new List<Model.WeatherReading>();
            weatherLoad.WeatherReadings.Add(weatherReading);

            return weatherLoad;
        }
        
    }

 
}
