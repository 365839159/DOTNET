using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DaprFrontEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaprController : ControllerBase
    {
        private readonly ILogger<DaprController> _logger;
        private readonly DaprClient _daprClient;
        public DaprController(ILogger<DaprController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }


        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            using var httpClient = DaprClient.CreateInvokeHttpClient();

            var result = await httpClient.GetAsync("http://backend/WeatherForecast");
            var resultContent = string.Format("result is {0} {1}", result.StatusCode, await result.Content.ReadAsStringAsync());
            return Ok(resultContent);
        }

        [HttpGet("get2")]
        public async Task<ActionResult> Get2Async()
        {
            using var daprClient = new DaprClientBuilder().Build();
            var result = await daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(HttpMethod.Get, "backend", "WeatherForecast");
            return Ok(result);
        }

        [HttpGet("di")]
        public async Task<ActionResult> GetDIAsync()
        {
            var result = await _daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(HttpMethod.Get, "backend", "WeatherForecast");
            return Ok(result);
        }


    }
}
