using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Commands.Sample;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.ApiEndPoint.Sample.Command
{
    public class SampleUpdate : EndpointBaseAsync.WithRequest<SampleCommand>.WithResult<bool>
    {
        private readonly IMediator _mediator;

        public SampleUpdate(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("api/v2/Sample/SampleCommand")]
        [HttpPost]
        [SwaggerOperation(Summary = "v2 SampleCommand ", Description = "SampleCommand", OperationId = "Sample.v2.SampleCommand", Tags = new[] { "Sample" })]
        public override async Task<bool> HandleAsync(SampleCommand request, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
