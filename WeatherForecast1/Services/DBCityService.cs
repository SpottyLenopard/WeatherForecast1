using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherForecast1.Classes;
using WeatherForecast1.Context;
using WeatherForecast1.Interfaces;
using WeatherForecast1.Models;

namespace WeatherForecast1.Services
{
    public class DBCityService : ICityService
    {
        IForecastService _fs;
        public DBCityService(IForecastService fs)
        {
            _fs = fs;
        }
        public List<City> GetCities()
        {
            using (var fc = new ForecastContext())
            {
                if (fc.ActiveCities != null)
                {
                    var cities = from c in fc.Cities
                                 join ac in fc.ActiveCities on c.id equals ac.CityId
                                 select c;

                    return cities.ToList<City>();

                }

                else
                    return new List<City>();
            }
        }

        public void AddCity(string cityName)
        {
            using (var fc = new ForecastContext())
            {
                Forecast forecast = _fs.GetForecast(cityName);
                if (forecast != null)
                {
                    City newCity = new City
                    {
                        id = forecast.city.id,
                        name = forecast.city.name,
                        country = forecast.city.country,
                        population = forecast.city.population,
                        coord = new Coord
                        {
                            lat = forecast.city.coord.lat,
                            lon = forecast.city.coord.lon,
                        },
                    };
                    if (fc.Cities.Where(_ => _.id == newCity.id).Count() == 0)
                        fc.Cities.Add(newCity);
                    ActiveCity ac = new ActiveCity
                    {
                        CityId = newCity.id,
                    };
                    if (fc.ActiveCities.Where(_ => _.CityId == newCity.id).Count() == 0)
                        fc.ActiveCities.Add(ac);
                    fc.SaveChanges();
                }
            }
        }

        public void DeleteCity(string cityName)
        {
            using (var fc = new ForecastContext())
            {
                var city = GetCityByName(cityName);

                if (city != null)
                {
                    var ac = fc.ActiveCities.Where(_ => _.CityId == city.id).FirstOrDefault();
                    if (ac != null)
                    {
                        fc.ActiveCities.Remove(ac);
                        fc.SaveChanges();
                    }
                }
            }

        }

        public City GetCityByName(string name)
        {
            using (var fc = new ForecastContext())
            {
                var cities = fc.Cities.Where(_ => _.name == name);
                if (cities.Count() > 0)
                    return cities.FirstOrDefault<City>();

                return null;
            }
        }
    }
}