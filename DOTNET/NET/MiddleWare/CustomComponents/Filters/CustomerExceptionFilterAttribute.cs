
using CustomComponents.CustomeException;
using CustomComponents.ResultCommon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using WebAPICore.Infrastructure.Common.Api;
using WebAPICore.Infrastructure.Common.HttpHelper;
using WebAPICore.Infrastructure.Common.Logger;
using WebAPICore.Infrastructure.Extensions;

namespace CustomComponents.Filters
{

    /*
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
public class LogFilterAttribute : Attribute, IActionFilter //, IAuthorizationFilter, IExceptionFilter
*/
    public class CustomerExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private LogHelper logHelper = null;
        //private readonly IWebHostEnvironment environment = null;
        public CustomerExceptionFilterAttribute(LogHelper logHelper)
        {
            //NLog.LogManager.Configuration = new NLog.Extensions.Logging.NLogLoggingConfiguration(GloablOpretion.Configuration.GetSection("NLog"));
            this.logHelper = logHelper;
            //this.environment = environment;
        }

        public void OnException(ExceptionContext context)
        {
            var ri = HttpResultFactory.CreateRessultServerError(BusinessEnum.DataCenter, "抱歉，出错了");
            if (!(context.Exception is UserFriendlyException))
            {
                logHelper.LogError(context.Exception);
            }
            else
            {
                ri = HttpResultFactory.CreateRessultBadRequest(BusinessEnum.DataCenter, context.Exception.Message);
            }
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;//统一返回200状态
            context.Result = new JsonResult(ri);
        }
    }
    public class CustomerActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ActionDescriptor.EndpointMetadata.Any(it => it is IgnoreActionFilterAttribute))
            {
                //throw new NotImplementedException();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionDescriptor.EndpointMetadata.Any(it => it is IgnoreActionFilterAttribute))
            {
                //throw new NotImplementedException();
            }
        }
    }
    public class CustomerResultFilterAttribute : Attribute, IResultFilter
    {
        //private readonly ILogger logger = null;
        //private readonly ExceptionMessage exceptionMessage = null;
        ////private readonly IWebHostEnvironment environment = null;
        //public CustomerResultFilterAttribute(ILogger<CustomerResultFilterAttribute> logger
        //    , ExceptionMessage exceptionMessage)
        //{
        //    //NLog.LogManager.Configuration = new NLog.Extensions.Logging.NLogLoggingConfiguration(GloablOpretion.Configuration.GetSection("NLog"));
        //    this.logger = logger;
        //    this.exceptionMessage = exceptionMessage;
        //}

        public void OnResultExecuted(ResultExecutedContext context)
        {
            if (!context.ActionDescriptor.EndpointMetadata.Any(it => it is IgnoreResultFilterAttribute))
            {
                //throw new NotImplementedException();

                //if (exceptionMessage.message.IsNotNullOrEmpty())
                //{
                //    logger.LogError(exceptionMessage.message);
                //}
            }
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ActionDescriptor.EndpointMetadata.Any(it => it is IgnoreResultFilterAttribute))
            {
                //throw new NotImplementedException();
            }
        }
    }

    public class CustomerAuthraztionFilterAttribute : Attribute, IAuthorizationFilter
    {
        HttpClientHelper httpClientHelper;
        HttpRequestHelper httpRequestHelper;
        private UserCenterApi userCenterApi;
        //private IAU_TokenDAL<MainDbContext> tokenDAL;
        private ResultInfo ri;
        public CustomerAuthraztionFilterAttribute(HttpRequestHelper httpRequestHelper
            , UserCenterApi userCenterApi
            //, IAU_TokenDAL<MainDbContext> tokenDAL
            , ResultInfo ri, HttpClientHelper httpClientHelper)
        {
            this.httpRequestHelper = httpRequestHelper;
            this.userCenterApi = userCenterApi;
            //this.tokenDAL = tokenDAL;
            this.ri = ri;
            this.httpClientHelper = httpClientHelper;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var result = HttpResultFactory.CreateRessultUnauthorized(BusinessEnum.DataCenter, "未授权的访问");

            //if (context.Filters.Any(it => it is Microsoft.AspNetCore.Mvc.Authorization.IAllowAnonymousFilter))
            if (!context.ActionDescriptor.EndpointMetadata.Any(it => it is IgnoreAuthraztionFilterAttribute))
            //&& !context.ActionDescriptor)
            {
                //var ri = new ResultInfo();
                //ri.ReturnCode = 100001;//未授权的访问
                //ri.ReturnText = "未授权的访问";
                //未授权的访问
                //ri.ErrCode = 104000;

                var request = context.HttpContext.Request;
                //var response = context.HttpContext.Response;
                if (request != null)
                {
                    var session = context.HttpContext.Request.Headers["session"].ToString();
                    if (!string.IsNullOrEmpty(session))
                    {
                        int userId = userCenterApi.GetUserId(session);
                        if (userId > 0)
                        {
                            httpRequestHelper.SetSession("UserId", userId.ToString());
                            //UserIdentity.CurrentUser = new CurrentUserDto() { UserID = userId };
                            return;
                        }


                    }

                    //////UserIdentity userIdentity;

                    ////context.HttpContext.Request.Headers.Add("UserID", "123456");
                    //////context.HttpContext.Session.SetString("CurrentUserDto", Newtonsoft.Json.JsonConvert.SerializeObject(value));
                    //////context.HttpContext.Session.Set("UserID", Encoding.GetEncoding("utf-8").GetBytes("159062"));
                    ////context.HttpContext.Session.SetString("UserID", "159062");

                    ////string url = "http://test.api.forclass.net/UserCenter/Account/LoginAccount";
                    ////IDictionary<string, string> headers = new Dictionary<string, string>();
                    ////IDictionary<string, object> parameters = new Dictionary<string, object>();

                    ////headers.Add("Accept", "application/json");
                    ////headers.Add("Content-Type", "application/json");

                    ////parameters.Add("loginName", "congdong");
                    ////parameters.Add("password", "123456");

                    //////ri = httpClientHelper.Get<ResultInfo>(url: url, headers: headers,parameters: parameters);

                    ////ri = httpClientHelper.Post<ResultInfo>(url: url, headers: headers, parameters: parameters);

                    ////if (UserIdentity.CurrentUser == null)
                    ////{
                    ////    var session = context.HttpContext.Request.Headers["session"];
                    ////    if (!string.IsNullOrEmpty(session))
                    ////    {
                    ////        //根据session获取用户信息,获取到用户初始化CurrentUser

                    ////        //IAccountService service = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAccountService)) as IAccountService;
                    ////        //if (service != null)
                    ////        {
                    ////            //ri = service.GetUserID(session);
                    ////            if (ri.result != null && ri.result.Count > 0)
                    ////            {
                    ////                //int userId = ConvertHelper.GetInt(ri.result.First());
                    ////                //if (userId > 0)
                    ////                //{
                    ////                //    ri.ReturnCode = 1;//未授权的访问
                    ////                //    ri.ReturnText = "";
                    ////                //    UserIdentity.CurrentUser = new CurrentUserDto() { UserID = userId };
                    ////                //}
                    ////                context.HttpContext.Request.Headers.Add("UserID", "123456");
                    ////            }
                    ////        }

                    ////    }

                }

                if (!result.Status.Success)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;//统一返回200状态
                    context.Result = new JsonResult(result);
                    //context.Result = new RedirectResult();
                }
            }

        }
    }
}
