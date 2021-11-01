using System;

namespace CustomComponents.ResultCommon
{
    /// <summary>
    /// 统一返回结果结构
    /// </summary>
    public class HttpResult<T>
    {
        public HttpResultStatus Status { get; }
        public T Data { get; }
        public HttpResult()
        {

        }
        public HttpResult(T data)
        {
            Data = data;
            Status = HttpResultStatus.Ok;
        }

        public HttpResult(HttpResultStatus status)
        {
            Status = status;
        }

        public HttpResult(HttpResultStatus status, string errorMessage)
        {
            Status = status;
            Status.SetErrorMessage(errorMessage);
        }

    }
    public class HttpResult : HttpResult<object>
    {
        public HttpResult(object data) : base(data)
        {

        }
        public HttpResult(HttpResultStatus status):base(status)
        {
        }
        public HttpResult(HttpResultStatus status, string errorMessage):base(status,errorMessage)
        {

        }

    }
}
