using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet31Keyclock.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
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
        [HttpGet]
        [Authorize]
        public IActionResult G2()
        {
            var a = User.Claims.FirstOrDefault()?.Value;
            return Ok("Authorized" + a);
        }
        [HttpGet]
        [Authorize]
        public IActionResult defaultAuth()
        {
            var a = User.Claims.FirstOrDefault(x=>x.Type=="azp")?.Value;
            return Ok("Authorized whit :" + a);
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "second_auth")]
        public IActionResult secondAuth()
        {
            var a = User.Claims.FirstOrDefault(x=>x.Type=="azp")?.Value;
            return Ok("Authorized whit :" + a);
        }
    }
}
