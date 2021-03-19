using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.SqlTypes;
using API.Weather.Model;

namespace DB.Weather
{
    public class DBWeatherLocation
    {
        SqlConnection _connection;



        public DBWeatherLocation(string connectionString)
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


        public API.Weather.Model.WeatherLocation GetByCity(int cityId)
        {
            List<API.Weather.Model.WeatherLocation> result;

            List<SqlParameter> varParams = new List<SqlParameter>();
            SqlParameter newParameter = new SqlParameter("@CityId", cityId);
            varParams.Add(newParameter);

            result = this.Get(varParams);

            if (result.Count > 0)
            {
                return result[0];
            }
            else
            {
                return null;
            }
        }

        public List<API.Weather.Model.WeatherLocation> GetByCity(string cityName)
        {
            List<API.Weather.Model.WeatherLocation> result;

            List<SqlParameter> varParams = new List<SqlParameter>();
            SqlParameter newParameter = new SqlParameter("@CityName", cityName);
            varParams.Add(newParameter);

            result = this.Get(varParams);
            return result;
        }

        protected List<API.Weather.Model.WeatherLocation> Get(List<SqlParameter> varParams)
        {
            string sprocName = "[dbo].[usp_WeatherLocation_GetAll]";
            API.Weather.Model.WeatherLocation weatherLocation = null;
            List<API.Weather.Model.WeatherLocation> result = new List<API.Weather.Model.WeatherLocation>();

            try
            {
                SqlCommand SqlCommand = new SqlCommand(sprocName, _connection);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlCommand.Parameters.Clear();
                SqlCommand.Parameters.AddRange(varParams.ToArray());    

                if (_connection.State != ConnectionState.Open) { _connection.Open(); }
                SqlDataReader dr = SqlCommand.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        weatherLocation = new API.Weather.Model.WeatherLocation
                        {
                            WeatherLocationId = (int)dr["WeatherLocationId"],
                            CityId = (int)dr["CityId"],
                            CityISO = Convert.IsDBNull(dr["CityISO"]) ? (string)null : (string)dr["CityISO"],
                            CityName = Convert.IsDBNull(dr["CityName"]) ? (string)null : (string)dr["CityName"],
                            State = Convert.IsDBNull(dr["State"]) ? (string)null : (string)dr["State"],
                            CountryISO = Convert.IsDBNull(dr["CountryISO"]) ? (string)null : (string)dr["CountryISO"],
                            Longitude = (decimal)dr["Longitude"],
                            Latitude = (decimal)dr["Latitude"]
                        };

                        result.Add(weatherLocation);
                    }
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
