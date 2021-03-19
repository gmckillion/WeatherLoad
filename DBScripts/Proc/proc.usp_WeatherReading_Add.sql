IF EXISTS(SELECT object_id FROM sys.procedures where object_id = object_id('[dbo].[usp_WeatherReading_Add]'))
BEGIN
	PRINT 'Dropping Procedure [dbo].[usp_WeatherReading_Add]'
	DROP PROCEDURE [dbo].[usp_WeatherReading_Add]
END

PRINT 'Creating Procedure [dbo].[usp_WeatherReading_Add]'
GO

CREATE PROCEDURE [dbo].[usp_WeatherReading_Add](@WeatherLoadId int, @WeatherLocationId int, @WeatherDateTime_UTC datetime2, @Temperature_C decimal(9,2), @FeelsLike_C decimal(9,2) = null, @TempMin_C  decimal(9,2) = null, @TempMax_C  decimal(9,2) = null,
			@Description nvarchar(50) = null, @Pressure_hPA smallint = null, @Pressure_SeaLevel_hPA smallint = null, @Pressure_GroundLevel_hPA smallint = null, @Humidity_Pct smallint = null, @WindSpeed_MS smallint = null,
			@WindSpeed_Deg smallint = null, @WindSpeed_Gust smallint = null, @CloudCover_Pct smallint = null, @Rain1h_mm smallint = null, @Rain3h_mm smallint = null, @Snow1h_mm smallint = null, @Snow3h_mm smallint = null, @WeatherIconId varchar(20) = null,
			@WeatherReadingId int = null output)
AS BEGIN

	INSERT INTO [dbo].[WeatherReading]([WeatherLoadId], [WeatherLocationId], [WeatherDateTime_UTC], [Temperature_C], [FeelsLike_C], [TempMin_C], [TempMax_C],
										[Description], [Pressure_hPA], [Pressure_SeaLevel_hPA], [Pressure_GroundLevel_hPA], [Humidity_Pct], [WindSpeed_MS],
										[WindSpeed_Deg], [WindSpeed_Gust], [CloudCover_Pct], [Rain1h_mm], [Rain3h_mm], [Snow1h_mm], [Snow3h_mm], [WeatherIconId])
     VALUES (@WeatherLoadId, @WeatherLocationId, @WeatherDateTime_UTC, @Temperature_C, @FeelsLike_C, @TempMin_C, @TempMax_C,
			@Description, @Pressure_hPA, @Pressure_SeaLevel_hPA, @Pressure_GroundLevel_hPA, @Humidity_Pct, @WindSpeed_MS,
			@WindSpeed_Deg, @WindSpeed_Gust, @CloudCover_Pct, @Rain1h_mm, @Rain3h_mm, @Snow1h_mm, @Snow3h_mm, @WeatherIconId)

	SET @WeatherReadingId = SCOPE_IDENTITY()
	
END
GO
	