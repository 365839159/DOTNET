using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;
namespace RedisSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RedisStringController : ControllerBase
    {
        //private readonly string redisConn = "192.168.159.25";
        private readonly string redisConn = "127.0.0.1";
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
        #region 添加 、 获取 、过期时间
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> SetString(string key, string value)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                //不指定过期时间
                //var response = redisClient.Set<string>(key, value);

                //设置过期时间
                //var response = redisClient.Set<string>(key, value,TimeSpan.FromSeconds(10));

                //设定特定的过期时间
                var response = redisClient.Set<string>(key, value, DateTime.Now.AddDays(10));

                return Task.FromResult(response);
            }
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<object> GetString(string key)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                string value = redisClient.Get<string>(key);
                return Task.FromResult<object>(value);
            }
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<object> GetValue(string key)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                string value = redisClient.GetValue(key);
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
        public Task<bool> SetStringAll(Dictionary<string, string> keyValue)
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
        public Task<object> GetStringAll(List<string> parms)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var values = redisClient.GetAll<string>(parms);
                return Task.FromResult<object>(values);
            }
        }

        #endregion

        #region 追加、获取旧值在赋新值

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="appendValue">需要追加的值</param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> AppendToValue(string key, string appendValue)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                //注意 ： 如果 key 在之前有  追加的值是这样 "zxc"zxc，没有是这样 zxczxc
                var values = redisClient.AppendToValue(key, appendValue);
                return Task.FromResult<object>(values);
            }
        }

        /// <summary>
        /// 获取旧值并设置新值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> GetAndSetValue(string key, string newValue)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var oldValue = redisClient.GetAndSetValue(key, newValue);
                var value = redisClient.Get<string>(key);
                return Task.FromResult<object>(new { oldValue, value });
            }
        }

        #endregion

        #region 自增、自减

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> Increment(string key, uint count)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var values = redisClient.Increment(key, count);
                redisClient.IncrementValue(key);
                redisClient.IncrementValueBy(key, count);
                return Task.FromResult<object>(values);
            }
        }


        /// <summary>
        /// 减
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> Decrement(string key, uint count)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var values = redisClient.Decrement(key, count);
                redisClient.DecrementValue(key);
                redisClient.DecrementValueBy(key, (int)count);
                return Task.FromResult<object>(values);
            }
        }

        #endregion


        #region add 、 set 区别
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> AddString(string key, string value)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                //没有这个key 才能成功
                var response = redisClient.Add<string>(key, value, DateTime.Now.AddDays(10));

                return Task.FromResult(response);
            }
        }


        #endregion


        #region 扩展

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> Extension()
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                bool b = redisClient.ContainsKey("zxc");//包含key
                var type = redisClient.GetEntryType("zxc");//获取类型
                return Task.FromResult(true);
            }
        }
        #endregion

    }
}
