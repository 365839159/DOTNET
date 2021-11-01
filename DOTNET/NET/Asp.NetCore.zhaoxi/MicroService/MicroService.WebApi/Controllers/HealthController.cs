using System;
using Microsoft.AspNetCore.Mvc;

namespace MicroService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [Route("Index")] //拼接到控制器上的route
        public IActionResult Index()
        {
            //this._logger.LogWarning($"This is HealthController {this._iConfiguration["Port"]}");
            Console.WriteLine("心跳正常");
            return Ok(); //HttpStatusCode--200
        }

    }
}