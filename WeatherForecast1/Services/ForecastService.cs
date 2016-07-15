using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
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

        public Forecast GetForecast()
        {
            return GetForecast("Kiev");
        }

        public Forecast GetForecast(string city)
        {

            if (city != null && city != string.Empty)
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
                    WebClient client = new WebClient();
                    var json = client.DownloadString(string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&APPID=ed7143c5070946e139cb0a559498dee4", city));
                    Forecast f = new Forecast();
                    f = JsonConvert.DeserializeObject<Forecast>(json);
                    return f;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        public void SaveForecastRequest(Forecast forecast)
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
                if (fc.Cities.Where(_ => _.id == newCity.id).Count() == 0)
                    fc.Cities.Add(newCity);
                var cs = new CityStatistic { CityId = newCity.id, RequestTime = DateTime.Now };
                fc.CityStatistics.Add(cs);
                fc.SaveChanges();
            }
        }
    }
}