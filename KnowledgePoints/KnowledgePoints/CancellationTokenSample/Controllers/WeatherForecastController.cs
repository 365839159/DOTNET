using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CancellationTokenSample.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost]
        public async Task GetToDo(CancellationToken cancellationToken)
        {
            await DownloadlAsync("http://www.baidu.com", 1000, cancellationToken);
        }
        static async Task DownloadlAsync(string url, int n, CancellationToken cancellationToken = default)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    string html = await httpClient.GetStringAsync(url);
                    Console.WriteLine(html);
                    if (cancellationToken.IsCancellationRequested)
                    {
                        Debug.WriteLine("È¡Ïû");
                        return;
                    }
                }
            }
        }
    }
}