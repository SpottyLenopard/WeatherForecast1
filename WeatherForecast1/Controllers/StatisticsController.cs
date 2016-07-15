using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast1.Services;

namespace WeatherForecast1.Controllers
{
    public class StatisticsController : Controller
    {
        private StatisticsService _ss;

        public StatisticsController()
        {
            _ss = new StatisticsService();
        }
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStats(string city = "")
        {
            var items =  _ss.GetStats(city);
            
            return View(items);
        }
    }
}