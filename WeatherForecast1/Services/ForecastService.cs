using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using WeatherForecast1.Classes;
using WeatherForecast1.Context;
using WeatherForecast1.Interfaces;
using WeatherForecast1.Models;

namespace WeatherForecast1.Services
{
    public class OpenWeatherMapForecastService : IForecastService
    {
        public OpenWeatherMapForecastService()
        {

        }

        public Task<Forecast> GetForecast()
        {
            return GetForecast("Kiev");
        }

        public async Task<Forecast> GetForecast(string city)
        {

            if (!String.IsNullOrEmpty(city))
            {
                try
                {
                    string key = "ed7143c5070946e139cb0a559498dee4";
                    Configuration rootWebConfig1 = WebConfigurationManager.OpenWebConfiguration("/");
                    if (rootWebConfig1.AppSettings.Settings.Count > 0)
                    {
                        KeyValueConfigurationElement customSetting = rootWebConfig1.AppSettings.Settings["APPID"];
                        if (customSetting != null)
                            key = customSetting.Value;
                    }
                    string json = string.Empty;
                    using (WebClient client = new WebClient())
                    {                    
                        json = await client.DownloadStringTaskAsync($"http://api.openweathermap.org/data/2.5/forecast/daily?q={city}&units=metric&APPID={key}");
                    }
                    if (json != string.Empty)
                    {
                        Forecast f = new Forecast();
                        f = JsonConvert.DeserializeObject<Forecast>(json);
                        return f;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;
        }

        public async Task SaveForecastRequest(Forecast forecast)
        {
            using (var fc = new ForecastContext())
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
                var cityExists = await fc.Cities.AnyAsync(_ => _.id == newCity.id);
                if (!cityExists)
                    fc.Cities.Add(newCity);
                var cs = new CityStatistic {CityId = newCity.id, RequestTime = DateTime.Now};
                fc.CityStatistics.Add(cs);
                try
                {
                    await fc.SaveChangesAsync();
                }
                catch (Exception ae)
                {
                    throw ae;
                }
            }
        }
    }
}