using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;

namespace RedisSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RedisSetAndZSetController : ControllerBase
    {
        //private readonly string redisConn = "192.168.159.25";
        private readonly string redisConn = "127.0.0.1";
        private readonly int redisPoint = 6379;
        //set 是一个自动去重的集合

        /// <summary>
        /// 向 set 集合中添加 item
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> AddItemToSet(string setId, string item)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                redisClient.AddItemToSet(setId, item);
                return Task.FromResult(true);
            }
        }
    }
}
