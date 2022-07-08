using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Queries.Sample;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.ApiEndPoint.Sample.Queries
{
    public class GetSamples : EndpointBaseAsync.WithoutRequest.WithResult<IEnumerable<SampleViewModel>>
    {
        private readonly ISampleQueries _sampleQueries;

        public GetSamples(ISampleQueries sampleQueries)
        {
            _sampleQueries = sampleQueries;
        }

        [Route("api/v2/Sample/GetSamples")]
        [HttpGet]
        [SwaggerOperation(Summary = "v2 GetSamples ", Description = "GetSamples", OperationId = "Sample.v2.GetSamples", Tags = new[] { "Sample" })]
        public override async Task<IEnumerable<SampleViewModel>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var response = await _sampleQueries.GetSampleAsync();
            return response;
        }
    }
}
