using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyToUse.CsRedis
{
    public   partial class CsRedisProvider
    {
        public Task<bool> Set(string key, string value)
        {
            var csredis = new CSRedis.CSRedisClient("127.0.0.1:6379,password=123,defaultDatabase=13,prefix=my_");
            RedisHelper.Initialization(csredis);
            
            throw new NotImplementedException();
        }

        public Task<bool> SetNX(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
