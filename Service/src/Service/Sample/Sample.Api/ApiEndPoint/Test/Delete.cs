using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.ApiEndPoint.Test
{
    public class Delete : EndpointBaseAsync.WithRequest<int>.WithoutResult
    {
        [Route("api/v1/Test/Delete")]
        [HttpGet]
        [SwaggerOperation(Summary = "删除用户", Description = "删除用户", OperationId = "Test.Delete", Tags = new[] { "TestApiEndPoint" })]
        public override Task HandleAsync(int request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
