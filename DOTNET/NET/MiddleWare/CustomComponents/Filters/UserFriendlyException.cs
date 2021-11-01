using System;
using System.Collections.Generic;
using System.Text;

namespace CustomComponents.CustomeException
{
    /// <summary>
    /// 自定义返回提示信息异常
    /// </summary>
    [Serializable]
    public class UserFriendlyException : Exception
    {
        /// <summary>
        /// 定义提示内容
        /// </summary>
        /// <param name="message"></param>
        public UserFriendlyException(string message) : base(message)
        {
        }

        public UserFriendlyException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
