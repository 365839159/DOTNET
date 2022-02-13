using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;
namespace RedisSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RedisSampleController : ControllerBase
    {
        private readonly string redisConn = "192.168.159.25";
        private readonly int redisPoint = 6379;
        /// <summary>
        /// 刷新db
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> Flush()
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                redisClient.FlushDb();
            }
            return Task.FromResult<bool>(true);
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> Set(string key, string value)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var response = redisClient.Set<string>(key, value);
                return Task.FromResult(response);
            }
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<object> Get(string key)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                string value = redisClient.Get<string>(key);
                return Task.FromResult<object>(value);
            }
        }

        /// <summary>
        /// 批量设置值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> SetAll(Dictionary<string, string> keyValue)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                redisClient.SetAll<string>(keyValue);
                return Task.FromResult(true);
            }
        }

        /// <summary>
        /// 批量根据key获取
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> GetAll(List<string> parms)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var values = redisClient.GetAll<string>(parms);
                return Task.FromResult<object>(values);
            }
        }

    }
}
