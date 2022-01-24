using Nest;

namespace ElasticSearchSample.ElasticProvider
{
    public interface IElasticProvider
    {
        IElasticClient GetElasticClient();
    }
}
