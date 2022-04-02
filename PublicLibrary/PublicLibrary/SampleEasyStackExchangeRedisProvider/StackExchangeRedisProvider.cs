using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Linq;
using SampleEasyRedis;

namespace SampleEasyStackExchangeRedisProvider
{
    public class StackExchangeRedisProvider : IEasyRedisProvider
    {
        public async Task<bool> Del(List<string> keys)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();
            long count = 0;
            List<RedisKey> redisKeys = new List<RedisKey>();
            foreach (var item in keys)
            {
                redisKeys.Add(new RedisKey(item));
            }
            if (redisKeys.Any())
            {
                count = await db.KeyDeleteAsync(redisKeys.ToArray());
            }
            return count > 0;
        }

        public Task<bool> Exists(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Set(string key, string value)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();
            if (string.IsNullOrEmpty(key))
                throw new Exception("key is null");
            return await db.SetAddAsync(key, value);

        }

        public Task<bool> SetNX(string key, string value)
        {
            throw new NotImplementedException();
        }

        public Task<string> Type(string key)
        {
            throw new NotImplementedException();
        }
    }
}

