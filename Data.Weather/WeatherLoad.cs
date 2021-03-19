using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using API.Weather.Model;

namespace DB.Weather
{
    public class DBWeatherLoad
    {
        SqlConnection _connection;

        public DBWeatherLoad(string connectionString)
        {
            try
            {
                _connection = new SqlConnection(connectionString);
                _connection.Open();
            }
            catch (SqlException e)
            {
                throw new Exception(String.Format("Unable to open connection for connection string error '{0}'", connectionString), e);
            }
        }

        public int AddRow(API.Weather.Model.WeatherLoad weatherLoad)
        {
            string sprocName = "[dbo].[usp_WeatherLoad_Add]";

            try
            {
                SqlCommand SqlCommand = new SqlCommand(sprocName, _connection);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                //add input paramters
                SqlCommand.Parameters.AddWithValue("@WeatherProviderId", weatherLoad.WeatherProviderId);
                SqlCommand.Parameters.AddWithValue("@LoadStartDateTime_UTC", weatherLoad.LoadStartDateTime_UTC);
                SqlCommand.Parameters.AddWithValue("@LoadEndDateTime_UTC", weatherLoad.LoadEndDateTime_UTC);
                SqlCommand.Parameters.AddWithValue("@LoadDurationMS", weatherLoad.LoadDurationMs);
                SqlCommand.Parameters.AddWithValue("@RecordCount", weatherLoad.RecordCount);
                SqlCommand.Parameters.AddWithValue("@ResponseSizeBytes", weatherLoad.ResponseSizeBytes);
                SqlCommand.Parameters.AddWithValue("@ResponseId", weatherLoad.ResponseId);
                SqlCommand.Parameters.AddWithValue("@Description", weatherLoad.Description);
                SqlCommand.Parameters.AddWithValue("@Message", weatherLoad.Message);
                SqlCommand.Parameters.AddWithValue("@Icon", weatherLoad.Icon);

                //Add output parameters
                SqlParameter weatherLoadId = new SqlParameter("@WeatherLoadId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                SqlCommand.Parameters.Add(weatherLoadId);

                if (_connection.State != ConnectionState.Open) { _connection.Open(); }
                SqlCommand.ExecuteNonQuery();

                //return the new primary key
                return (int)weatherLoadId.Value; 
            }
            catch (SqlException e)
            {
                return -1;
                throw new Exception(String.Format("Error executing '{0}'", sprocName), e);
            }
        }

    }
}
