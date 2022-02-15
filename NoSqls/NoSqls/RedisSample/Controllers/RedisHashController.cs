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
        //private readonly string redisConn = "192.168.159.25";
        private readonly string redisConn = "127.0.0.1";
        private readonly int redisPoint = 6379;


        #region 新增 、查询、批量
        /// <summary>
        /// 设置 hash
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
        /// 获取 hash
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


        /// <summary>
        /// 不存在才设置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> SetEntryInHashIfNotExists(string hashId, string key, string value)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                bool result = redisClient.SetEntryInHashIfNotExists(hashId, key, value);
                return Task.FromResult(result);
            }
        }

        /// <summary>
        /// 设置对象
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> StoreAsHash(UserInfo user)
        {
            //string 类型： 首先把对象序列化为一个json 然后存储redis 的  string 里面，如果我们需要修改某个属性值的时候，就需要先取出来序列化为对象在操作，最后在写进去
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                redisClient.StoreAsHash(user);
                return Task.FromResult(true);
            }
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<UserInfo> GetFromHash(int Id)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.GetFromHash<UserInfo>(Id);
                return Task.FromResult(result);
            }
        }

        /// <summary>
        /// 获取hash中的总数
        /// </summary>
        /// <param name="hashId"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<long> GetHashCount(string hashId)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.GetHashCount(hashId);
                return Task.FromResult(result);
            }
        }


        /// <summary>
        /// 获取hash中所有的key
        /// </summary>
        /// <param name="hashId"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<List<string>> GetHashKeys(string hashId)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.GetHashKeys(hashId);
                return Task.FromResult(result);
            }
        }

        /// <summary>
        /// 获取hash中所有的value
        /// </summary>
        /// <param name="hashId"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<List<string>> GetHashValues(string hashId)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.GetHashValues(hashId);
                return Task.FromResult(result);
            }
        }

        /// <summary>
        /// 移除hash 数据集中的 key 的数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> RemoveEntryFromHash(string hashId, string key)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.RemoveEntryFromHash(hashId, key);
                return Task.FromResult(result);
            }
        }

        /// <summary>
        /// 判断 hash 数据集中是否有存在 key 的数据 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> HashContainsEntry(string hashId, string key)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.HashContainsEntry(hashId, key);
                return Task.FromResult(result);
            }
        }

        /// <summary>
        ///  hash 数据集中的 key 的 value 加  incrementBy 返回加完后的结果（自增）
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <param name="incrementBy"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<long> IncrementValueInHash(string hashId, string key, int incrementBy)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.IncrementValueInHash(hashId, key, incrementBy);
                return Task.FromResult(result);
            }
        }



    }
    public class UserInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
