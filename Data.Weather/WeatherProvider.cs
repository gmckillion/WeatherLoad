using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using API.Weather.Model;

namespace DB.Weather
{
    public class DBWeatherProvider
    {
        SqlConnection _connection;



        public DBWeatherProvider(string connectionString)
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

        public API.Weather.Model.WeatherProvider GetRow(API.Weather.Model.enumWeatherProvider weatherProvider)
        {
            string sprocName = "[dbo].[usp_WeatherProvider_Get]";

            try
            {
                SqlCommand SqlCommand = new SqlCommand(sprocName, _connection);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                //add input paramters
                SqlCommand.Parameters.AddWithValue("@WeatherProviderId", weatherProvider);

                
                API.Weather.Model.WeatherProvider result = new API.Weather.Model.WeatherProvider();
                if (_connection.State != ConnectionState.Open) { _connection.Open(); }
                SqlDataReader reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    result.WeatherProviderId = (int)reader["WeatherProviderId"];
                    result.Name = (string)reader["Name"];
                    result.Url = (string)reader["URL"];
                    result.Priority = (int)reader["Priority"];
                    result.IsActive = (bool)reader["IsActive"];
                }

                //return the record
                return result;
            }
            catch (SqlException e)
            {
                throw new Exception(String.Format("Error executing '{0}'", sprocName), e);
            }
        }

    }
}
