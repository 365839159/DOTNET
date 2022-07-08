using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.ApiEndPoint.Test
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCommand>.WithResult<bool>
    {
        [Route("api/v1/Test/Create")]
        [HttpPost]
        [SwaggerOperation(Summary = "创建新用户", Description = "创建新用户", OperationId = "Test.Create", Tags = new[] { "TestApiEndPoint" })]
        public override Task<bool> HandleAsync(CreateCommand request, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }
    }

    public record CreateCommand { }
}
