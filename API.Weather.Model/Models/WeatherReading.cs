#nullable enable
using System;
using System.Collections.Generic;

namespace API.Weather.Model
{

    public class WeatherReading
    {
        public int WeatherReadingId { get; set; } //PK
        public int WeatherLocationId { get; set; }
        public DateTime WeatherDateTime_UTC { get; set; }
        public decimal Temperature_C { get; set; }
        public decimal? FeelsLike_C { get; set; }
        public decimal? TempMin_C { get; set; }
        public decimal? TempMax_C { get; set; }
        public string? Description { get; set; }
        public Int16? Pressure_hPA { get; set; }
        public Int16? Pressure_SeaLevel_hPA { get; set; }
        public Int16? Pressure_GroundLevel_hPA { get; set; }
        public Int16? Humidity_Pct { get; set; }
        public decimal? WindSpeed_MS { get; set; }
        public Int16? WindSpeed_Deg { get; set; }
        public Int16? WindSpeed_Gust { get; set; }
        public Int16? CloudCover_Pct { get; set; }
        public int? Rain1h_mm { get; set; }
        public int? Rain3h_mm { get; set; }
        public int? Snow1h_mm { get; set; }
        public int? Snow3h_mm { get; set; }
        public string? WeatherIconId { get; set; }

        //header record
        public int WeatherLoadId { get; set; }
        public WeatherLoad? WeatherLoad { get; set; }

        //foreign key
        public WeatherLocation? WeatherLocation { get; set; }
    }


}