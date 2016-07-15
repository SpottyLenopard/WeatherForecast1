using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace WeatherForecast1.Models
{
    public class CityStatistic
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public City City { get; set; }

        public DateTime RequestTime { get; set; }
    }
}