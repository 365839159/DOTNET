using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    //[Authorize(policy: "ApiScope")]
    //[Authorize]

    public class IdentityServerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [HttpGet]
        public IActionResult Get2()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
