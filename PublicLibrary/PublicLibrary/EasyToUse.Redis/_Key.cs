using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyToUse.Redis
{
    public partial interface IEasyToUseRedisProvider
    {
        Task<bool> Del(string key);
        Task<bool> Exists(string key);
        Task<string> Type(string key);
    }
}
