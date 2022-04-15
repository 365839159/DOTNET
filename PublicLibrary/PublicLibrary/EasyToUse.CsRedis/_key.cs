using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyToUse.CsRedis
{
    public partial class CsRedisProvider
    {

        public Task<bool> Del(List<string> keys)
        {
            throw new NotImplementedException();
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
