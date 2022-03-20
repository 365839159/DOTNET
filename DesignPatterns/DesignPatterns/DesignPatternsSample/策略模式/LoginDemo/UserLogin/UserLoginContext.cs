using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.策略模式.LoginDemo.Login
{
    public class UserLoginContext
    {
        private UserLoginStrategy UserLoginStrategy { get; set; }
        public void SetUserLoginStrategy(UserLoginStrategy userLogin)
        {
            UserLoginStrategy = userLogin;
        }
        public UserLoginMessage Login(string code, string password)
        {
            return UserLoginStrategy.Check(new UserLoginParm(code, password));
        }
    }
}
