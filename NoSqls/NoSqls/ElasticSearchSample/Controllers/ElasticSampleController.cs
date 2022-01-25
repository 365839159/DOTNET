using ElasticSearchSample.ElasticProvider;
using ElasticSearchSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace ElasticSearchSample.Controllers
{

    public class ElasticSampleController : BaseController
    {
        private readonly IElasticClient _client;
        public ElasticSampleController(IElasticProvider provider)
        {
            _client = provider.GetElasticClient();
        }

        [HttpGet]
        public object Query()
        {

            Func<SearchDescriptor<UserInfo>, ISearchRequest> selector = s => s.Query(
                q => q.Term(u => u.Name, "zxc") && q.Term(u => u.Age, 12)
                );

            var result = _client.Search(selector);

            //var document=  result.Hits.Select(s => s.Source);
            var document = result.Documents.ToList();
            return document;
        }

        [HttpGet]
        public void Insert()
        {
            List<UserInfo> userInfos = new List<UserInfo> {
             new UserInfo(){  Name="zxc", Adress="北京", Age=12, Id=1, Phone="1234567891"}
            };
            var result = _client.IndexMany<UserInfo>(userInfos);
        }
    }
}
