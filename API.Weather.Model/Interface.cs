using System.Threading.Tasks;
using API.Weather.Model;

namespace API.Weather.OpenWeatherMap
{
    public interface ICurrentWeatherClient
    {
        Task<WeatherLoad> Get(string city);
    }
}
