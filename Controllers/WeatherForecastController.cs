using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Docker.WebAPI.Learning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAppsettings _appsettings;

        public WeatherForecastController(ILogger<WeatherForecastController> logger , IAppsettings appsettings)
        {
            _logger = logger;
            _appsettings = appsettings;

        }

        [HttpGet]
        
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("{id}")]
        
        public IEnumerable<WeatherForecast> Get(int id)
        {
           
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = id.ToString()
            })
            .ToArray();
        }

        [HttpGet("GetAppSetting")]
        public IAppsettings GetEnv([FromQuery]Log log)
        {
            var a = " dilip kumar2 ";
          
            return _appsettings;
        }
    }

    public class Log
    {
       [RegularExpression("/^[a-zA-Z]*$/")]
        public string username { get; set; }
        public int LogId { get; set; }
    }
}
