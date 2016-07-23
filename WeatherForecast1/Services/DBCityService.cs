using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<List<City>> GetCities()
        {
            using (var fc = new ForecastContext())
            {
                bool hasActiveCities = await fc.ActiveCities.AnyAsync();
                if (hasActiveCities)
                {
                    var cities = await(from c in fc.Cities
                                 join ac in fc.ActiveCities on c.id equals ac.CityId
                                 select c).ToListAsync();

                    return cities;

                }

                else
                    return new List<City>();
            }
        }

        public async Task AddCity(string cityName)
        {
            using (var fc = new ForecastContext())
            {
                var forecast = await _fs.GetForecast(cityName);
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
                    bool cityExists = await fc.Cities.AnyAsync(_ => _.id == newCity.id);
                    if (!cityExists)
                        fc.Cities.Add(newCity);
                    ActiveCity ac = new ActiveCity
                    {
                        CityId = newCity.id,
                    };
                    bool activeCityExists = await fc.ActiveCities.AnyAsync(_ => _.CityId == newCity.id);
                    if (!activeCityExists)
                        fc.ActiveCities.Add(ac);
                    try
                    {
                        await fc.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public async Task DeleteCity(string cityName)
        {
            using (var fc = new ForecastContext())
            {
                var city = await GetCityByName(cityName);

                if (city != null)
                {
                    var ac = await fc.ActiveCities.FirstOrDefaultAsync(_ => _.CityId == city.id);
                    if (ac != null)
                    {
                        fc.ActiveCities.Remove(ac);
                        try
                        {
                            await fc.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }

        }

        public async Task<City> GetCityByName(string name)
        {
            using (var fc = new ForecastContext())
            {
                List<City> cities = null;
                try
                {
                    cities = await fc.Cities.Where(_ => _.name == name).ToListAsync();
                }
                catch (Exception ex)
                {                   
                    throw ex;
                }
                if (cities.Any())
                    return cities.FirstOrDefault<City>();

                return null;
            }
        }
    }
}