using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> GetStats(string city = "")
        {
            var items = await _ss.GetStats(city);
            
            if (items.Any())
                return View(items);
            return
                View("EmptyStats");
        }
    }
}