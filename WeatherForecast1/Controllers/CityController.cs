using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast1.Interfaces;
using WeatherForecast1.Models;


namespace WeatherForecast1.Controllers
{
    public class CityController : Controller
    {
        private ICityService _cs;

        public CityController(ICityService cs)
        {
            _cs = cs;
        }
        // GET: City
        public ActionResult Index()
        {
            var items = _cs.GetCities();
            return View(items);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(City city)
        {
            if (ModelState.IsValid)
                _cs.AddCity(city.name);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string city)
        {
            return View(_cs.GetCityByName(city));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(string city)
        {
            _cs.DeleteCity(city);
            return RedirectToAction("Index");
        }
    }
}