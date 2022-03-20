using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.策略模式.LoginDemo.LoginStrategy
{
    internal class OtherStrategy : UserLoginStrategy
    {
        public UserLoginMessage Check(UserLoginParm parm)
        {
            //........业务逻辑
            if (SMSOrEmailOrAccount(parm))
            {
                return new UserLoginMessage(true, $"{parm.code}登录成功!");
            }
            return new UserLoginMessage(false, $"{parm.code} 登录失败！");
        }

        private bool SMSOrEmailOrAccount(UserLoginParm parm)
        {
            return
                (parm.code == "sms" && parm.password == "password")
                ||
                (parm.code == "email" && parm.password == "password")
                ||
                (parm.code == "account" && parm.password == "password");
        }
    }
}
