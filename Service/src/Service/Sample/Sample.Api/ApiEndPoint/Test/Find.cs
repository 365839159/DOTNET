using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.ApiEndPoint.Test
{
    public class Find : EndpointBaseAsync.WithRequest<TestQueries>.WithResult<TestResponse>
    {
        [Route("api/v1/Test/Find")]
        [HttpGet]
        [SwaggerOperation(Summary = "查找用户", Description = "查找用户", OperationId = "Test.Find", Tags = new[] { "TestApiEndPoint" })]
        public override Task<TestResponse> HandleAsync(TestQueries request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }

    public record TestQueries
    {
        public int Id { get; set; }
    }
    public record TestResponse {
        public string Name { get; set; }
    }
}
