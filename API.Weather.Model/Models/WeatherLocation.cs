#nullable enable
using System;
using System.Collections.Generic;

namespace API.Weather.Model
{
    public class WeatherLocation
    {
        public int WeatherLocationId { get; set; } //PK
        public int CityId { get; set; }
        public string? CityISO { get; set; }
        public string? CityName { get; set; }
        public string? State { get; set; }
        public string? CountryISO { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}