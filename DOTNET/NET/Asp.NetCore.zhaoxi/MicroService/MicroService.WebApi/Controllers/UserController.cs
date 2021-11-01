using System;
using Microsoft.AspNetCore.Mvc;

namespace MicroService.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("get 被调用");
            return new JsonResult(new {name = "zxc", age = 18});
        }
    }
}