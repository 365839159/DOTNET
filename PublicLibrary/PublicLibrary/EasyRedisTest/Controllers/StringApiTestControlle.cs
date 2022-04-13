using Microsoft.AspNetCore.Mvc;
using SampleEasyRedis;

namespace EasyRedisTest.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StringApiTestControlle : ControllerBase
    {
        private readonly IEasyRedisProvider easyRedisProvider;
        public StringApiTestControlle(IEasyRedisProvider easyRedisProvider)
        {
            this.easyRedisProvider = easyRedisProvider;
        }
        [HttpPost]
        public async Task<bool> Set(string key, string value)
        {
            return await easyRedisProvider.Set(key, value);
        }
        [HttpPost]
        public async Task<bool> Del(string key)
        {
            return await easyRedisProvider.Del(new List<string>() { key });
        }
    }
}
