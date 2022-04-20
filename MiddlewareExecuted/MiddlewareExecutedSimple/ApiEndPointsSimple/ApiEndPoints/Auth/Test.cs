using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiEndPointsSimple.ApiEndPoints.Auth
{
    [ApiVersionNeutral]
    public class Test : Ardalis.ApiEndpoints.EndpointBaseAsync.WithRequest<Query>.WithActionResult<Result>
    {
        [HttpPost("/api/v1/Test")]
        [SwaggerOperation(Description = "Test", Tags = new[] { "Works", "Query" },Summary = "根据Id,获取对应的学程基本信息")]
        public override Task<ActionResult<Result>> HandleAsync(Query request, CancellationToken cancellationToken = default)
        {
            ActionResult<Result> result = new ActionResult<Result>(new Result());
            return Task.FromResult(result);
        }
    }
}
