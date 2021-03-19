--WeatherLoad
IF EXISTS(select object_id from sys.indexes where [name] = 'IX_WeatherLoad_LoadStartDateTime_UTC' and object_id = OBJECT_ID('dbo.WeatherLoad'))
BEGIN
	PRINT 'Dropping Index [IX_WeatherLoad_LoadStartDateTime_UTC]'
	DROP INDEX [IX_WeatherLoad_LoadStartDateTime_UTC] ON [dbo].[WeatherLoad]
END

PRINT 'Creating Index [IX_WeatherLoad_LoadStartDateTime_UTC]'
CREATE NONCLUSTERED INDEX [IX_WeatherLoad_LoadStartDateTime_UTC] ON [dbo].[WeatherLoad](LoadStartDateTime_UTC)
GO

--WeatherReading
IF EXISTS(select object_id from sys.indexes where [name] = 'IX_WeatherReading_WeatherLoadId' and object_id = OBJECT_ID('dbo.WeatherReading'))
BEGIN
	PRINT 'Dropping Index [IX_WeatherReading_WeatherLoadId]'
	DROP INDEX [IX_WeatherReading_WeatherLoadId] ON [dbo].[WeatherReading]
END

PRINT 'Creating Index [IX_WeatherReading_WeatherLoadId]'
CREATE NONCLUSTERED INDEX [IX_WeatherReading_WeatherLoadId] ON [dbo].[WeatherReading]([WeatherLoadId])
GO

--WeatherReading
IF EXISTS(select object_id from sys.indexes where [name] = 'IX_WeatherReading_WeatherDateTime_UTC' and object_id = OBJECT_ID('dbo.WeatherReading'))
BEGIN
	PRINT 'Dropping Index [IX_WeatherReading_WeatherDateTime_UTC]'
	DROP INDEX [IX_WeatherReading_WeatherDateTime_UTC] ON [dbo].[WeatherReading]
END

PRINT 'Creating Index [IX_WeatherReading_WeatherDateTime_UTC]'
CREATE NONCLUSTERED INDEX [IX_WeatherReading_WeatherDateTime_UTC] ON [dbo].[WeatherReading]([WeatherDateTime_UTC])
GO

--WeatherReading
IF EXISTS(select object_id from sys.indexes where [name] = 'IX_WeatherReading_LocationId' and object_id = OBJECT_ID('dbo.WeatherReading'))
BEGIN
	PRINT 'Dropping Index [IX_WeatherReading_LocationId]'
	DROP INDEX [IX_WeatherReading_LocationId] ON [dbo].[WeatherReading]
END

PRINT 'Creating Index [IX_WeatherReading_LocationId]'
CREATE NONCLUSTERED INDEX [IX_WeatherReading_LocationId] ON [dbo].[WeatherReading]([WeatherLocationId])
GO


