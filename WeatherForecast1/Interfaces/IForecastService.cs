using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast1.Models;

namespace WeatherForecast1.Interfaces
{
    public interface IForecastService
    {
        Forecast GetForecast();
        Forecast GetForecast(string city);
    }
}
