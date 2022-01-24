using Nest;

namespace ElasticSearchSample.ElasticProvider
{
    public class ElasticProvider : IElasticProvider
    {

        private IElasticClient _client;
        public IElasticClient GetElasticClient()
        {
            if (_client == null)
            {
                _client = new ElasticClient(new ConnectionSettings(new Uri("http://127.0.0.1:9200")).DefaultIndex("userinfo"));
            }
            return _client;
        }
    }
}
