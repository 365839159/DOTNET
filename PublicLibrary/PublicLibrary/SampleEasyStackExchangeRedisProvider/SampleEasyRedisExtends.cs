using Microsoft.Extensions.DependencyInjection;
using SampleEasyRedis;
using System;

namespace SampleEasyStackExchangeRedisProvider
{
    public static class SampleEasyRedisExtends
    {

        public static void AddSampleEasyRedis(this IServiceCollection service)
        {
            service.AddScoped<IEasyRedisProvider, StackExchangeRedisProvider>();
        }
    }
}
