using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task.BLL.Abstracrions;
using Task.BLL.Models;


namespace TaskResmi_asp.net_core.Controllers
{
    [Produces("application/json")]
    public class ForecastController : Controller
    {
        private readonly IForecastService _service;
        public ForecastController(IForecastService service) => _service = service;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("forecast/add")]
        public IActionResult AddForecast([FromForm] ForecastModel model)
        {
            try
            {
                _service.Add(model);
            }
            catch (Exception e)
            {
                return Json(NotFound(e.InnerException?.Message));
            }

            return Json(Ok());
        }
        [HttpGet]
        [Route("forecast/list")]
        public IActionResult ForecastList()
        {
            var forecastList = _service.Get().ToList();
            ViewData.Add("temperature", _service.Temperature);
            return View("ForecastList", forecastList);
        }
    }
}