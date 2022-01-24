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
            var result = _client.Search<UserInfo>(
                  s => s.Query(
                      s => s.Term(
                          u => u.Name, "zxc"))).Hits.ToList();
            return result;

        }

        [HttpGet]
        public void Insert()
        {
            List<UserInfo> userInfos = new List<UserInfo> {

             new UserInfo(){  Name="zxc", Adress="北京", Age=12, Id=1, Phone="1234567891"}
            };
            var result = _client.BulkAll<UserInfo>(userInfos);

        }
    }
}
