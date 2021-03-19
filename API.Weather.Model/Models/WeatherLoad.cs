#nullable enable
using System;
using System.Collections.Generic;

namespace API.Weather.Model
{
    public class WeatherLoad
    {
        public int WeatherLoadId { get; set; } //PK
        public enumWeatherProvider WeatherProviderId { get; set; }
        public DateTime LoadStartDateTime_UTC { get; set; }
        public DateTime? LoadEndDateTime_UTC { get; set; }
        public int LoadDurationMs { get; set; }
        public int RecordCount { get; set; }
        public long ResponseSizeBytes { get; set; }
        public int? ResponseId { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public string Icon { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public List<WeatherReading> WeatherReadings { get; set; }
    }
}