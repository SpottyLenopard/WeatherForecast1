using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast1.Services;

namespace WeatherForecast1.Controllers
{
    public class CityController : Controller
    {
        private CityService cs;

        public CityController()
        {
            cs = new CityService();
        }
        // GET: City
        public ActionResult Index()
        {
            var items = cs.GetCities();
            return View(items);
        }
    }
}