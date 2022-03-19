using MediatR;
using MediatRSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddUser")]
        public async Task<bool> AddUser(UserInfo userInfo)
        {
            var response = await _mediator.Send(userInfo);
            return response;
        }

    }
}
