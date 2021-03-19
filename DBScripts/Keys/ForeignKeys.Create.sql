--WeatherReading
ALTER TABLE [dbo].[WeatherReading]
ADD CONSTRAINT FK_WeatherReading_WeatherLoadId
FOREIGN KEY (WeatherLoadId) REFERENCES WeatherLoad(WeatherLoadId);

ALTER TABLE [dbo].[WeatherReading]
ADD CONSTRAINT FK_WeatherReading_WeatherLocationId
FOREIGN KEY (WeatherLocationId) REFERENCES WeatherLocation(WeatherLocationId);

--WeatherLoad
ALTER TABLE [dbo].[WeatherLoad]
ADD CONSTRAINT FK_WeatherLoad_WeatherProviderId
FOREIGN KEY (WeatherProviderId) REFERENCES WeatherProvider(WeatherProviderId);