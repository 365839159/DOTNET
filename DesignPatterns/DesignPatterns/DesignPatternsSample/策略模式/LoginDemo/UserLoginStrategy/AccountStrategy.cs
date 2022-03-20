using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.策略模式.LoginDemo
{
    public class AccountStrategy : UserLoginStrategy
    {
        public UserLoginMessage Check(UserLoginParm parm)
        {
            //........业务逻辑
            if (parm.code == "account" && parm.password == "password")
            {
                return new UserLoginMessage(true, $"{parm.code}登录成功!");
            }
            return new UserLoginMessage(false, $"{parm.code} 登录失败！");
        }
    }
}
