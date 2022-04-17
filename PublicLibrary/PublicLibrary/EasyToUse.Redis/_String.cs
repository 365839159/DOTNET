using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyToUse.Redis
{
    public partial interface IEasyToUseRedisProvider
    {
        Task<bool> Set<T>(string key, T value, TimeSpan? expiry = null);
        Task<T> Get<T>(string key);
        Task<bool> SetNX(string key, string value);
    }
}
