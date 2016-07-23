using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WeatherForecast1.Classes;
using WeatherForecast1.Interfaces;
using WeatherForecast1.Models;

namespace WeatherForecast1.Services
{
    public class CityService : ICityService
    {
        private static List<City> cities;

        public CityService()
        {
            if (cities == null)
                cities = new List<City>
                {
                    new City { name = "Kiev" },
                    new City { name = "Lviv" },
                    new City { name = "Kharkiv" },
                    new City { name = "Dnipropetrovsk" },
                    new City { name = "Odessa" },
                };
        }

        public Task<List<City>> GetCities()
        {
            return Task.FromResult(cities);
        }

        public Task AddCity(string cityName)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCity(string cityName)
        {
            throw new NotImplementedException();
        }

        public Task<City> GetCityByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}