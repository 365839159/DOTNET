using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DaprController : ControllerBase
    {
        private readonly DaprClient _daprClient;
        public DaprController(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var result = await _daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(HttpMethod.Get, "BackEnd-Api", "GetWeatherForecast");
            return result;
        }
    }
}
