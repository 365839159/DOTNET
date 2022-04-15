using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToUse.StackExchange.Redis
{
    public partial class StackExchangeProvider
    {
        public async Task<bool> Set<T>(string key, T value, TimeSpan? expiry = null)
        {
            string redisValue = JsonConvert.SerializeObject(value);
            return await redisClient.StringSetAsync(key, redisValue, expiry);
        }
        public Task<bool> SetNX(string key, string value)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get<T>(string key)
        {
            RedisKey redisKey = new RedisKey(key);
            string redisValue = await redisClient.StringGetAsync(redisKey);
            return JsonConvert.DeserializeObject<T>(redisValue);
        }


    }
}
