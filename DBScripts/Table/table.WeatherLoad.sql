CREATE TABLE dbo.WeatherLoad
(
        [WeatherLoadId] int identity(1,1) not null,
        [WeatherProviderId] smallint not null,
        [LoadStartDateTime_UTC] DATETIME2 null,
        [LoadEndDateTime_UTC] DATETIME2 null,
        [LoadDurationMs] int null,
        [RecordCount] int null,
        [ResponseSizeBytes] bigint null,
        [ResponseId] int null,
        [Description] nvarchar(100) null,
        [Message] nvarchar(100) null,
        [Icon] varchar(20),
        [CreatedDateTime] DATETIME2,
        [ModifiedDateTime] DATETIME2 null,
        [DeletedDateTime] DATETIME2 null,
        [IsDeleted] BIT NOT NULL,
		CONSTRAINT PK_WeatherLoad_WeatherLoadId PRIMARY KEY CLUSTERED (WeatherLoadId)
)
GO

