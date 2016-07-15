using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast1.Interfaces;


namespace WeatherForecast1.Controllers
{
    public class ForecastController : Controller
    {
        private IForecastService _fs;

        public ForecastController(IForecastService forecastService)
        {
            _fs = forecastService;
        }
        // GET: Forecast
        public ActionResult Index()
        {
            var fc = _fs.GetForecast();
            return View();
        }

        public ActionResult GetForecastFor(string city, int days = 1)
        {
            var fc = _fs.GetForecast(city);
            if (fc != null)
            {
                _fs.SaveForecastRequest(fc);
                fc.list = fc.list.GetRange(0, days);
                return View(fc);
            }

            return View("Error");

        }
    }
}