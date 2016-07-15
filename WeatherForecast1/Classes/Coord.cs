using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeatherForecast1.Classes
{
    [ComplexType]
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
}