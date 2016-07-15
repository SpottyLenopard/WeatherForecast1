using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<City> GetCities()
        {
            return cities;
        }

        public void AddCity(string cityName)
        {
            return;
        }

        public void DeleteCity(string cityName)
        {
            return;
        }

        public City GetCityByName(string name)
        {
            return null;
        }
    }
}