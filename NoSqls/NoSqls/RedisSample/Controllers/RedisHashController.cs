using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Model;
using ServiceStack.Redis;

namespace RedisSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RedisHashController : ControllerBase
    {
        private readonly string redisConn = "192.168.159.25";
        //private readonly string redisConn = "127.0.0.1";
        private readonly int redisPoint = 6379;


        #region 新增 、查询、批量
        /// <summary>
        /// 设置hash
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> SetEntryInHash(string hashId, string key, string value)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                bool result = redisClient.SetEntryInHash(hashId, key, value);
                return Task.FromResult(result);
            }
        }

        /// <summary>
        /// 获取hash
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<string> GetValueFromHash(string hashId, string key)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                string value = redisClient.GetValueFromHash(hashId, key);
                return Task.FromResult(value);
            }
        }
        /// <summary>
        /// 批量设置值
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> SetRangeInHash(string hashId, Dictionary<string, string> keyValues)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                redisClient.SetRangeInHash(hashId, keyValues);
                return Task.FromResult(true);
            }
        }

        /// <summary>
        /// 获取批量值
        /// </summary>
        /// <param name="hashId"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Dictionary<string, string>> GetAllEntriesFromHash(string hashId)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.GetAllEntriesFromHash(hashId);
                return Task.FromResult(result);
            }
        }

        #endregion

    }
}
