using DesignPatternsSample.策略模式.LoginDemo.Enum;
using DesignPatternsSample.策略模式.LoginDemo.LoginStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.策略模式.LoginDemo.Factory
{
    public class UserLoginCheckFactory
    {
        public static UserLoginStrategy CreateUserLogin(UserLoginMode mode)
        {
            UserLoginStrategy userLoginCheck;
            switch (mode)
            {
                case UserLoginMode.Account:
                    userLoginCheck = new AccountStrategy();
                    break;
                case UserLoginMode.Phone:
                    userLoginCheck = new PhoneStrategy();
                    break;
                case UserLoginMode.Email:
                    userLoginCheck = new EmailStrategy();
                    break;
                case UserLoginMode.Other:
                    userLoginCheck = new OtherStrategy();
                    break;
                default:
                    throw new AggregateException($"{mode}:不存在的登录校验类型！");
            }
            return userLoginCheck;
        }
    }
}
