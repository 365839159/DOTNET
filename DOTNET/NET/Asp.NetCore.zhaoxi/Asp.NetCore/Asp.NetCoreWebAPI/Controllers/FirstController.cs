using Asp.NetCore.Infrastructure.Filters;
using BusinessService.Asp.netCore.AutoFac;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FirstController : ControllerBase
    {
        private readonly IService _service;

        public FirstController(IService service)
        {
            _service = service;
        }

       
        [HttpPost]
        public object GetId()
        {
            return _service.GetId(1);
        }
    }
}