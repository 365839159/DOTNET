using EasyToUse.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyToUse.StackExchange.Redis
{
    public partial class StackExchangeProvider : IEasyToUseRedisProvider
    {
        private static readonly ConnectionMultiplexer redisConn = ConnectionMultiplexer.ConnectAsync(new ConfigurationOptions
        {
            EndPoints = { { "localhost", 6379 } },
            Password = "123456",
            AbortOnConnectFail = false
        }).Result;

        private readonly IDatabase redisClient;

        public StackExchangeProvider()
        {
            redisClient = redisConn.GetDatabase();
        }



    }
}
