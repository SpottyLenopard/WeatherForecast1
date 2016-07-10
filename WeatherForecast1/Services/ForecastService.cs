using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WeatherForecast1.Interfaces;
using WeatherForecast1.Models;

namespace WeatherForecast1.Services
{
    public class OpenWeatherMapForecastService : IForecastService
    {
        public OpenWeatherMapForecastService()
        { }

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
            return GetForecast();
        }
    }
}