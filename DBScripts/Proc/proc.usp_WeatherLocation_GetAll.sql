IF EXISTS(SELECT object_id FROM sys.procedures where object_id = object_id('[dbo].[usp_WeatherLocation_GetAll]'))
BEGIN
	PRINT 'Dropping Procedure [dbo].[usp_WeatherLocation_GetAll]'
	DROP PROCEDURE [dbo].[usp_WeatherLocation_GetAll]
END

PRINT 'Creating Procedure [dbo].[usp_WeatherLocation_GetAll]'
GO

CREATE PROCEDURE [dbo].[usp_WeatherLocation_GetAll](@WeatherLocationId int = null, @CityId int = null, @CityName VARCHAR(50) = null, @CountryISO VARCHAR(3) = null)
AS BEGIN

	SELECT [WeatherLocationId]
		  ,[CityId]
		  ,[CityISO]
		  ,[CityName]
		  ,[State]
		  ,[CountryISO]
		  ,[Longitude]
		  ,[Latitude]
		  ,[CreatedDateTime]
		  ,[ModifiedDateTime]
		  ,[DeletedDateTime]
		  ,[IsDeleted]
	  FROM [dbo].[WeatherLocation]
	  WHERE [WeatherLocationId] = ISNULL(@WeatherLocationId, [WeatherLocationId])
	    AND [CityName] = ISNULL(@CityName, [CityName])
		AND [CountryISO] = ISNULL(@CountryISO, [CountryISO])
		AND [CityId] = ISNULL(@CityId, [CityId])
END
GO

	exec usp_WeatherLocation_GetAll @CityId =2643741