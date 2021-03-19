CREATE TABLE [dbo].[WeatherLocation]
(
        [WeatherLocationId] int identity(1,1) not null,
		[CityId] int null,
		[CityISO] nvarchar(3) null,
		[CityName] nvarchar(50) null,
		[State] nvarchar(50) null,
		[CountryISO] nvarchar(3) null,
		[Longitude] numeric(9,6) null,
		[Latitude] numeric(9,6) null,
        [CreatedDateTime] DATETIME2,
        [ModifiedDateTime] DATETIME2 null,
        [DeletedDateTime] DATETIME2 null,
        [IsDeleted] BIT NOT NULL,
		CONSTRAINT PK_WeatherLocation_WeatherLocationId PRIMARY KEY CLUSTERED (WeatherLocationId)
)
GO
