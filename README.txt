READ ME
=======

=================================
==      WeatherLoad 1.0        ==
==  OpenWeatherMap API Caller  ==
==    (with insert into DB)    ==
==                             ==
==     Gary McKillion 2021     ==
=================================

DATABASE DEPLOYMENT
   (SQL SERVER)
===================

Execute the following SQL scripts, in order:

1) Tables\*.sql (all scripts)
2) Keys\ForeignKeys.sql
3) Proc\*.sql (all scripts)
4) Data\*.sql (all scripts)
5) Indexes\indexes.sql

INSTRUCTIONS
============

The WeatherLoad Solution consists of the following projects:

API.Weather.OpenWeatherMap - API Wrapper to the OpenWeatherMap API (only CurrentWeather is implemented in this release)
DB.Weather - Provides CRUD operations over the Weather Objects in the Database
API.Weather.Model - Weather Model classes used by the Database objects to represent the DB table structure.  Presented by the API.Weather.OpenWeatherMap via the ICurrentWeatherClient (in this Model libary)
WeatherLoad - A simple console application to call the OpenWeatherMap API and insert the results into the database

CONFIGURATION
=============
Open WeatherLoad\appsettings.json (this will need to be copied to the target exe folder e.g. Debug)

Add a valid KEY for OpenWeatherMap at APISettings \ OpenWeatherMap \ AccessKey
Add your database server and name along with your username and password in the database connection string at ConnectionStrings \ WeatherDatabase

TESTING
=======

Calling WeatherLoad.exe

Example: WeatherLoad "New York"

NOTE: This utility is a demonstrator, supported cities are: London, Madrid, Paris, New York, Sydney.  Supported Cities are stored in the database table "dbo.Location"