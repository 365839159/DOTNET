using System;
using System.Collections.Generic;
using System.Text;

namespace CustomComponents.ResultCommon
{
    public class HttpResultFactory
    {
        private BusinessEnum _businessEnum;
        public HttpResultFactory(BusinessEnum businessEnum)
        {
            _businessEnum = businessEnum;
        }
        #region 实例方法
        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="businessEnum"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HttpResult CreateRessultOk(object data)
        {
            var httpResultStatus = HttpResultStatus.Ok;
            httpResultStatus.SetSourceCode(BusinessCode.BusinessIndexValue[_businessEnum]);
            var httpresult = new HttpResult(data);
            return httpresult;
        }
        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="businessEnum"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HttpResult<T> CreateRessultOk<T>(T data)
        {
            var httpResultStatus = HttpResultStatus.Ok;
            httpResultStatus.SetSourceCode(BusinessCode.BusinessIndexValue[_businessEnum]);
            var httpresult = new HttpResult<T>(data);
            return httpresult;
        }
        /// <summary>
        /// 返回400错误
        /// </summary>
        /// <param name="businessEnum"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public HttpResult CreateRessultBadRequest(string msg)
        {
            var httpResultStatus = HttpResultStatus.BadRequest;
            httpResultStatus.SetSourceCode(BusinessCode.BusinessIndexValue[_businessEnum]);
            var httpresult = new HttpResult(httpResultStatus, msg);
            return httpresult;
        }
        /// <summary>
        /// 返回401错误
        /// </summary>
        /// <param name="businessEnum"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public HttpResult CreateRessultUnauthorized(string msg)
        {
            var httpResultStatus = HttpResultStatus.Unauthorized;
            httpResultStatus.SetSourceCode(BusinessCode.BusinessIndexValue[_businessEnum]);
            var httpresult = new HttpResult(httpResultStatus, msg);
            return httpresult;
        }
        /// <summary>
        /// 返回500错误
        /// </summary>
        /// <param name="businessEnum"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public HttpResult CreateRessultServerError(string msg)
        {
            var httpResultStatus = HttpResultStatus.ServerError;
            httpResultStatus.SetSourceCode(BusinessCode.BusinessIndexValue[_businessEnum]);
            var httpresult = new HttpResult(httpResultStatus, msg);
            return httpresult;
        }
        /// <summary>
        /// 返回Httpresultstatus包含业务编码
        /// </summary>
        /// <param name="businessEnum"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public HttpResultStatus CreateRessultStatusForBusinessCode(HttpResultStatus httpResultStatus)
        {
            httpResultStatus.SetSourceCode(BusinessCode.BusinessIndexValue[_businessEnum]);
            return httpResultStatus;
        }
        #endregion




        #region 静态方法
        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="businessEnum"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HttpResult CreateRessultOk(BusinessEnum businessEnum, object data)
        {
            var httpResultStatus = HttpResultStatus.Ok;
            httpResultStatus.SetSourceCode(BusinessCode.BusinessIndexValue[businessEnum]);
            var httpresult = new HttpResult(data);
            return httpresult;
        }
        /// <summary>
        /// 返回成功-泛型方法
        /// </summary>
        /// <param name="businessEnum"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HttpResult<T> CreateRessultOkM<T>(BusinessEnum businessEnum, T data)
        {
            var httpResultStatus = HttpResultStatus.Ok;
            httpResultStatus.SetSourceCode(BusinessCode.BusinessIndexValue[businessEnum]);
            var httpresult = new HttpResult<T>(data);
            return httpresult;
        }
        /// <summary>
        /// 返回400错误
        /// </summary>
        /// <param name="businessEnum"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static HttpResult CreateRessultBadRequest(BusinessEnum businessEnum, string msg)
        {
            var httpResultStatus = HttpResultStatus.BadRequest;
            httpResultStatus.SetSourceCode(BusinessCode.BusinessIndexValue[businessEnum]);
            var httpresult = new HttpResult(httpResultStatus, msg);
            return httpresult;
        }
        /// <summary>
        /// 返回401错误
        /// </summary>
        /// <param name="businessEnum"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static HttpResult CreateRessultUnauthorized(BusinessEnum businessEnum, string msg)
        {
            var httpResultStatus = HttpResultStatus.Unauthorized;
            httpResultStatus.SetSourceCode(BusinessCode.BusinessIndexValue[businessEnum]);
            var httpresult = new HttpResult(httpResultStatus, msg);
            return httpresult;
        }
        /// <summary>
        /// 返回500错误
        /// </summary>
        /// <param name="businessEnum"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static HttpResult CreateRessultServerError(BusinessEnum businessEnum, string msg)
        {
            var httpResultStatus = HttpResultStatus.ServerError;
            httpResultStatus.SetSourceCode(BusinessCode.BusinessIndexValue[businessEnum]);
            var httpresult = new HttpResult(httpResultStatus, msg);
            return httpresult;
        }


        /// <summary>
        /// 返回Httpresultstatus包含业务编码
        /// </summary>
        /// <param name="businessEnum"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static HttpResultStatus CreateRessultStatusForBusinessCode(BusinessEnum businessEnum, HttpResultStatus httpResultStatus)
        {
            httpResultStatus.SetSourceCode(BusinessCode.BusinessIndexValue[businessEnum]);
            return httpResultStatus;
        } 
        #endregion
    }
}
