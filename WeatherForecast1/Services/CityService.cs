using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherForecast1.Classes;
using WeatherForecast1.Models;

namespace WeatherForecast1.Services
{
    public class CityService
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
    }
}