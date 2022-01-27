using ElasticSearchSample.ElasticProvider;
using ElasticSearchSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace ElasticSearchSample.Controllers
{

    public class InsertController : BaseController
    {
        private readonly IElasticClient _client;
        public InsertController(IElasticProvider provider)
        {
            _client = provider.GetElasticClient();
        }

        /// <summary>
        /// IndexDocument 添加
        /// </summary>
        [HttpPost]
        public async Task<object> IndexDocumentAsync()
        {
            UserInfo userInfo = new UserInfo()
            {
                Id = 1,
                Adress = "北京",
                Age = 12,
                Name = "张三",
                Phone = "159714412222"
            };
            var result = await _client.IndexDocumentAsync(userInfo);
            return result;
        }

        /// <summary>
        /// index
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<Object> IndexAsync()
        {
            UserInfo userInfo = new UserInfo()
            {
                Id = 1,
                Adress = "北京",
                Age = 12,
                Name = "张三",
                Phone = "159714412222"
            };
            var result = await _client.IndexAsync(userInfo, s => s.Index("userinfo"));
            return result;
        }
        /// <summary>
        /// index
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> IndexAsync2()
        {
            IIndexRequest<UserInfo> request = new IndexRequest<UserInfo>();
            request.Document = new UserInfo()
            {
                Id = 1,
                Adress = "北京",
                Age = 12,
                Name = "张三",
                Phone = "159714412222"
            };
            var result = await _client.IndexAsync(request);
            return result;
        }
    }
}
