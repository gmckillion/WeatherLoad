IF EXISTS(SELECT object_id FROM sys.procedures where object_id = object_id('[dbo].[usp_WeatherLoad_Add]'))
BEGIN
	PRINT 'Dropping Procedure [dbo].[usp_WeatherLoad_Add]'
	DROP PROCEDURE [dbo].[usp_WeatherLoad_Add]
END

PRINT 'Creating Procedure [dbo].[usp_WeatherLoad_Add]'
GO

CREATE PROCEDURE [dbo].[usp_WeatherLoad_Add](@WeatherProviderId int, @LoadStartDateTime_UTC datetime2, @LoadEndDateTime_UTC datetime2, @LoadDurationMs int = null, 
	@RecordCount int = null, @ResponseSizeBytes bigint = null, @ResponseId int = null, @Description nvarchar(100) = null, @Message nvarchar(100) = null, @Icon varchar(20) = null,
	@WeatherLoadId int = null output)
AS BEGIN
	INSERT [dbo].[WeatherLoad]([WeatherProviderId], [LoadStartDateTime_UTC], [LoadEndDateTime_UTC], [LoadDurationMs],
		[RecordCount], [ResponseSizeBytes], [ResponseId], [Description], [Message], [Icon],
		[CreatedDateTime], [ModifiedDateTime], [DeletedDateTime], [IsDeleted])
	VALUES(@WeatherProviderId, @LoadStartDateTime_UTC, @LoadEndDateTime_UTC, @LoadDurationMs,
		@RecordCount, @ResponseSizeBytes, @ResponseId, @Description, @Message, @Icon,
		GETDATE(), GETDATE(), NULL, 0)

	SET @WeatherLoadId = SCOPE_IDENTITY()
	
END
GO
	