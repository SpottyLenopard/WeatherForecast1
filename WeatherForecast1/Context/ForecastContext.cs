using System;
using System.Collections.Generic;
using System.Data.Entity;
using WeatherForecast1.Classes;
using WeatherForecast1.Models;

namespace WeatherForecast1.Context
{
    public class ForecastContext:DbContext
    {
        public ForecastContext()
            : base()
        {
            Database.SetInitializer<ForecastContext>(new CreateDatabaseIfNotExists<ForecastContext>());
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<ActiveCity> ActiveCities { get; set; }

        public DbSet<CityStatistic> CityStatistics { get; set; }
    }
}