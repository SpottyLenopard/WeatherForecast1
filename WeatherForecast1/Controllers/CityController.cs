using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            var items = await _cs.GetCities();
            return View(items);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(City city)
        {
            if (ModelState.IsValid)
                try
                {
                    await _cs.AddCity(city.name);
                }
                catch (Exception ex)
                {

                    return View("Error");
                }
                
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(string city)
        {
            try
            {
                var cityToDelete = await _cs.GetCityByName(city);
                return View(cityToDelete);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirm(string city)
        {
            try
            {
                await _cs.DeleteCity(city);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}