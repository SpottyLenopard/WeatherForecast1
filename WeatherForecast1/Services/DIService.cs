using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast1.Interfaces;

namespace WeatherForecast1.Services
{
    public class DIService : IDependencyResolver
    {
        private IKernel _kernel;

        public DIService(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IForecastService>().To<OpenWeatherMapForecastService>();
            _kernel.Bind<ICityService>().To<DBCityService>();

        }
    }
}