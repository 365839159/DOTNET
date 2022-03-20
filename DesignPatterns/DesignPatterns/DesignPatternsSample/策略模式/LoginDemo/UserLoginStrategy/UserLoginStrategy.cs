using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.策略模式.LoginDemo
{
    public interface UserLoginStrategy
    {
        public UserLoginMessage Check(UserLoginParm parm);
    }
}
