using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyToUse.StackExchange.Redis
{
    public partial class StackExchangeProvider
    {

        public async Task<bool> Del(string key)
        {
            return await redisClient.KeyDeleteAsync(key);
        }

        public Task<bool> Exists(string key)
        {
            throw new NotImplementedException();
        }
        public Task<string> Type(string key)
        {
            throw new NotImplementedException();
        }
    }
}
