CREATE TABLE dbo.WeatherProvider
(
        [WeatherProviderId] smallint not null,
        [Name] nvarchar(100) null,
		[URL] nvarchar(200) not null,
        [Priority] BIT not null,
        [IsActive] BIT not null,
		CONSTRAINT PK_WeatherProvider_WeatherProviderId PRIMARY KEY CLUSTERED (WeatherProviderId)
)
GO
