using EasyToUse.Redis;
using Microsoft.AspNetCore.Mvc;


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
        private readonly IEasyToUseRedisProvider easyToUseRedisProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEasyToUseRedisProvider easyToUseRedisProvider)
        {
            _logger = logger;
            this.easyToUseRedisProvider = easyToUseRedisProvider;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            while (true)
            {
                easyToUseRedisProvider.Set("zxc", "zxc");
                easyToUseRedisProvider.Del("zxc");
            }


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