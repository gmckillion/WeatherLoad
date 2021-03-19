using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using API.Weather.Model;

namespace DB.Weather
{
    public class DBWeatherReading
    {
        SqlConnection _connection;



        public DBWeatherReading(string connectionString)
        {
            try
            {
                _connection = new SqlConnection(connectionString);
                _connection.Open();
            }
            catch(SqlException e)
            {
                throw new Exception(String.Format("Unable to open connection for connection string error '{0}'", connectionString), e);
            }
        }

        public int AddRow(API.Weather.Model.WeatherReading weatherReading)
        {
            string sprocName = "[dbo].[usp_WeatherReading_Add]";

            try
            {
                SqlCommand SqlCommand = new SqlCommand(sprocName, _connection);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                //add input paramters
                SqlCommand.Parameters.AddWithValue("@WeatherLoadId", weatherReading.WeatherLoadId);
                SqlCommand.Parameters.AddWithValue("@WeatherLocationId", weatherReading.WeatherLocationId);
                SqlCommand.Parameters.AddWithValue("@WeatherDateTime_UTC", weatherReading.WeatherDateTime_UTC);
                SqlCommand.Parameters.AddWithValue("@Temperature_C", weatherReading.Temperature_C);
                SqlCommand.Parameters.AddWithValue("@FeelsLike_C", weatherReading.FeelsLike_C);
                SqlCommand.Parameters.AddWithValue("@TempMin_C", weatherReading.TempMin_C);
                SqlCommand.Parameters.AddWithValue("@TempMax_C", weatherReading.TempMax_C);
                SqlCommand.Parameters.AddWithValue("@Pressure_hPA", weatherReading.Pressure_hPA);
                SqlCommand.Parameters.AddWithValue("@Pressure_SeaLevel_hPA", weatherReading.Pressure_SeaLevel_hPA);
                SqlCommand.Parameters.AddWithValue("@Pressure_GroundLevel_hPA", weatherReading.Pressure_GroundLevel_hPA);
                SqlCommand.Parameters.AddWithValue("@Humidity_Pct", weatherReading.Humidity_Pct);
                SqlCommand.Parameters.AddWithValue("@WindSpeed_MS", weatherReading.WindSpeed_MS);
                SqlCommand.Parameters.AddWithValue("@WindSpeed_Deg", weatherReading.WindSpeed_Deg);
                SqlCommand.Parameters.AddWithValue("@WindSpeed_Gust", weatherReading.WindSpeed_Gust);
                SqlCommand.Parameters.AddWithValue("@CloudCover_Pct", weatherReading.CloudCover_Pct);
                SqlCommand.Parameters.AddWithValue("@Rain1h_mm", weatherReading.Rain1h_mm);
                SqlCommand.Parameters.AddWithValue("@Rain3h_mm", weatherReading.Rain3h_mm);
                SqlCommand.Parameters.AddWithValue("@Snow1h_mm", weatherReading.Snow1h_mm);
                SqlCommand.Parameters.AddWithValue("@Snow3h_mm", weatherReading.Snow3h_mm);
                SqlCommand.Parameters.AddWithValue("@WeatherIconId", weatherReading.WeatherIconId);

                //Add output parameters
                SqlParameter weatherReadingId = new SqlParameter("@WeatherReadingId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                SqlCommand.Parameters.Add(weatherReadingId);

                if (_connection.State != ConnectionState.Open) { _connection.Open(); }
                SqlCommand.ExecuteNonQuery();

                //return the new primary key
                return (int)weatherReadingId.Value;  //GJM (int)SqlCommand.Parameters["@WeatherReadingId"].Value;
            }
            catch (SqlException e)
            {
                return -1;
                throw new Exception(String.Format("Error executing '{0}'", sprocName), e);
            }
        }

    }
}
