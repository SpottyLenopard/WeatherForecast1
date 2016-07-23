using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast1.Models;

namespace WeatherForecast1.Interfaces
{
    public interface ICityService
    {
        Task<List<City>> GetCities();

        Task AddCity(string cityName);

        Task DeleteCity(string cityName);

        Task<City> GetCityByName(string name);
    }
}
