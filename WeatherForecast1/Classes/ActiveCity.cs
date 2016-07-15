using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeatherForecast1.Models;

namespace WeatherForecast1.Classes
{
    public class ActiveCity
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public City City { get; set; }
    }
}