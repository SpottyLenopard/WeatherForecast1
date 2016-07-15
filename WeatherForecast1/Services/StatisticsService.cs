using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WeatherForecast1.Context;
using WeatherForecast1.Models;

namespace WeatherForecast1.Services
{
    public class StatisticsService
    {

        public List<CityStatistic> GetStats(string city = "")
        {
            using (var fc = new ForecastContext())
            {
                if (fc.CityStatistics != null)
                {
                    var cityStats = city != "" ? fc.CityStatistics.Include(c => c.City).Where(_ => _.City.name == city) : fc.CityStatistics.Include(c => c.City);
                    return cityStats.ToList<CityStatistic>();

                }

                return new List<CityStatistic>();
            }
        }
    }
}