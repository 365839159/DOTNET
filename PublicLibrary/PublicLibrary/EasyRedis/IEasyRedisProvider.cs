using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyRedis
{
    public interface IEasyRedisProvider
    {
        #region keys
        Task<bool> Del(List<string> keys);
        Task<bool> Exists(string key);
        Task<string> Type(string key);
        #endregion

        #region string
        Task<bool> Set(string key, string value);
        Task<bool> SetNX(string key, string value);
        #endregion

    }
}
