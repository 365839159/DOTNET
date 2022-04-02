using Microsoft.AspNetCore.Mvc;
using SampleEasyRedis;

namespace EasyRedisTest.Controllers
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
        private readonly IEasyRedisProvider easyRedisProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEasyRedisProvider easyRedisProvider)
        {
            _logger = logger;
            this.easyRedisProvider = easyRedisProvider;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            easyRedisProvider.Set("zxc", "zxc");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}