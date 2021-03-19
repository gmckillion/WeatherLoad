using System.Text.Json.Serialization;

namespace API.Weather.OpenWeatherMap.Response
{
    public class Coordinates
    {
        [JsonPropertyName("lon")]
        public decimal Longitude { get; set; }
        [JsonPropertyName("lat")]
        public decimal Latitude { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("main")]
        public string Main { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public decimal Temperature { get; set; }
        [JsonPropertyName("feels_like")]
        public decimal FeelsLike { get; set; }
        [JsonPropertyName("temp_min")]
        public decimal TempMin { get; set; }
        [JsonPropertyName("temp_max")]
        public decimal TempMax { get; set; }
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }
        [JsonPropertyName("sea_level")]
        public ushort Pressure_SeaLevel_hPA { get; set; }
        [JsonPropertyName("grnd_level")]
        public ushort Pressure_GroundLevel_hPA { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public decimal Speed { get; set; }
        [JsonPropertyName("deg")]
        public int Deg { get; set; }
        [JsonPropertyName("gust")]
        public int Gust { get; set; }
    }

    public class Cloud
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }

    public class Rain
    {
        [JsonPropertyName("rain1h")]
        public int Rain1h { get; set; }
        [JsonPropertyName("rain3h")]
        public int Rain3h { get; set; }

    }

    public class Snow
    {
        [JsonPropertyName("snow1h")]
        public int Snow1h { get; set; }
        [JsonPropertyName("snow3h")]
        public int Snow3h { get; set; }

    }

    public class Sys
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("message")]
        public decimal Message { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }
        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
    }

    public class CurrentWeatherResponse
    {
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }
        
        [JsonPropertyName("weather")]
        public Weather[] Weather { get; set; }
        
        [JsonPropertyName("base")]
        public string Base { get; set; }
        
        [JsonPropertyName("main")]
        public Main Main { get; set; }
        
        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }
        
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
        
        [JsonPropertyName("clouds")]
        public Cloud Clouds { get; set; }
        
        [JsonPropertyName("rain")]
        public Rain Rain { get; set; }
        
        [JsonPropertyName("snow")]
        public Snow Snow { get; set; }
        
        [JsonPropertyName("dt")]
        public int TimeOfDataCalculation { get; set; }
        
        [JsonPropertyName("sys")]
        public Sys Sys { get; set; }
        
        [JsonPropertyName("timezone")]
        public int TimezoneOffsetSeconds { get; set; }
        
        [JsonPropertyName("id")]
        public int CityId { get; set; }
        
        [JsonPropertyName("name")]
        public string CityName { get; set; }
        
        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }

}