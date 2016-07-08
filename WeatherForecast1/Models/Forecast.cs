using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherForecast1.Classes;

namespace WeatherForecast1.Models
{
    public class Forecast
    {
        public City city { get; set; }
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<WeatherState> list { get; set; }
    }
}