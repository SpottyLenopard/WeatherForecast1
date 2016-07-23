using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> GetForecastFor(string city, int days = 1)
        {

            var fc = await _fs.GetForecast(city);
            if (fc != null)
            {
                try
                {
                    await _fs.SaveForecastRequest(fc);
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
                fc.list = fc.list.GetRange(0, days);
                return View(fc);
            }
            return View("Error");

        }
    }
}