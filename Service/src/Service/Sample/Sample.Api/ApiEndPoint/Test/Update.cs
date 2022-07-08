using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.ApiEndPoint.Test
{
    public class Update : EndpointBaseAsync.WithRequest<int>.WithResult<bool>
    {
        [Route("api/v1/Test/Update")]
        [HttpGet]
        [SwaggerOperation(Summary = "修改用户", Description = "修改用户", OperationId = "Test.Update", Tags = new[] { "TestApiEndPoint" })]
        public override Task<bool> HandleAsync(int request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
