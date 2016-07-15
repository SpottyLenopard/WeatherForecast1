using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WeatherForecast1.Classes;

namespace WeatherForecast1.Models
{
    public class City
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int? population { get; set; }
    }
}