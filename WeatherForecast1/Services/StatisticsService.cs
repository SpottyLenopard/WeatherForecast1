using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WeatherForecast1.Context;
using WeatherForecast1.Models;
using System.Threading.Tasks;

namespace WeatherForecast1.Services
{
    public class StatisticsService
    {

        public async Task<List<CityStatistic>> GetStats(string city = "")
        {
            using (var fc = new ForecastContext())
            {
                if (fc.CityStatistics != null)
                {
                    var cityStats =
                        await
                            fc.CityStatistics.Include(c => c.City)
                                .Where(_ => _.City.name == city || city == string.Empty).ToListAsync();
                    return cityStats;

                }

                return new List<CityStatistic>();
            }
        }
    }
}