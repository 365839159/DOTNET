using System.Collections.Generic;
using Asp.NetCore.Infrastructure.Filters;
using Asp.NetCore.Model.Entity;
using IBusinessService.Asp.netCore.UserBLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Asp.NetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _userBll;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserBLL userBll, ILogger<UserController> logger)
        {
            _userBll = userBll;
            _logger = logger;
        }
        //[TypeFilter(typeof(CoustomActionFilterAttribute))]
        [HttpPost]
        public List<User> GetUsers()
        {
            _logger.LogInformation("获取用户信息");
            return _userBll.GetUsers();
        }
    }
}