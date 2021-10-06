using AspNet.Models;
using AspNet.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Controllers
{
    [ApiController]
    [Route("api/forecasts")]
    public class WeatherForecastController : ControllerBase
    {
        private WeatherForecastService _service;

        public WeatherForecastController()
        {
            this._service = new WeatherForecastService(); // init service
        }

        [HttpGet]
        public ActionResult<List<WeatherForecast>> GetAll() => this._service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<WeatherForecast> Get(int id) => this._service.GetForecast(id);
    }
}
