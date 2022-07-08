using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Commands.Sample;
using Sample.Application.Queries.Sample;
using System.Net;

namespace Sample.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ISampleQueries _sampleQueries;
        public SampleController(IMediator mediator, ISampleQueries sampleQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _sampleQueries = sampleQueries ?? throw new ArgumentNullException(nameof(sampleQueries));
        }
        [Route("SampleCommand")]
        [HttpPost]
        public async Task<ActionResult<bool>> SampleCommand([FromBody] SampleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Route("GetSamples")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleViewModel>>> GetSamples()
        {
            var response = await _sampleQueries.GetSampleAsync();
            return Ok(response);
        }
    }
}
