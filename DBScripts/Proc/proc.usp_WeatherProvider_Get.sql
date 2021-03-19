IF EXISTS(SELECT object_id FROM sys.procedures where object_id = object_id('[dbo].[usp_WeatherProvider_Get]'))
BEGIN
	PRINT 'Dropping Procedure [dbo].[usp_WeatherProvider_Get]'
	DROP PROCEDURE [dbo].[usp_WeatherProvider_Get]
END

PRINT 'Creating Procedure [dbo].[usp_WeatherProvider_Get]'
GO

CREATE PROCEDURE [dbo].[usp_WeatherProvider_Get](@WeatherProviderId int)
AS BEGIN

	SELECT [WeatherProviderId]
		  ,[Name]
		  ,[URL]
		  ,[Priority]
		  ,[IsActive]
	FROM [dbo].[WeatherProvider]
	WHERE [WeatherProviderId] = @WeatherProviderId

END
GO

	