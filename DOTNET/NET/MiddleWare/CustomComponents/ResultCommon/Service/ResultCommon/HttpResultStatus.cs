using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomComponents.ResultCommon
{
    /// <summary>
    ///统一返回结果状态信息
    /// </summary>
    public class HttpResultStatus
    {
        public static readonly HttpResultStatus Ok = new HttpResultStatus(200, string.Empty);
        public static readonly HttpResultStatus BadRequest = new HttpResultStatus(400, "Invalid Operation");
        public static readonly HttpResultStatus Unauthorized = new HttpResultStatus(401, "Unauthorized");
        public static readonly HttpResultStatus ServerError = new HttpResultStatus(500, "Server Error");

        private readonly string _message;
        private string _errorMessage;
        private string _sourceCode;
        public int Code { get; }
        public string SourceCode => _sourceCode;
        public bool Success { get; } = false;
        public string Message => $"{_message}:{_errorMessage}".TrimEnd(':');

        public HttpResultStatus(int code, string message)
        {
            Success = code == 200;
            Code = code;
            _message = message;
        }
        public  void SetSourceCode(string sourceCode)
        {
            _sourceCode = sourceCode;
        }
        public void SetErrorMessage(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage) || Code == Ok.Code)
            {
                return;
            }

            _errorMessage = errorMessage;
        }

        public static IEnumerable<HttpResultStatus> List() =>
            new[] { Ok, BadRequest, Unauthorized, ServerError };

        public static HttpResultStatus From(int code)
        {
            var state = List().SingleOrDefault(s => s.Code == code);

            return state;
        }
    }
}
