using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.策略模式.LoginDemo
{
    public class UserLoginMessage
    {
        public UserLoginMessage(bool status, string message)
        {
            Status = status;
            Message = message;
        }
        public bool Status { get; init; }
        public string Message { get; init; }
    }
}
