#nullable enable
using System;
using System.Collections.Generic;

namespace API.Weather.Model
{
    public enum enumWeatherProvider
    {
        WP_OpenWeatherMap = 1
    }

    public class WeatherProvider
    {
        public int WeatherProviderId { get; set; } //PK
        public string? Name { get; set; }
        public string? Url { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}