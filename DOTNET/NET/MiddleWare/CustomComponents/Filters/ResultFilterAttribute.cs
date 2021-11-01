using CustomComponents.ResultCommon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebAPICore.Infrastructure.Extensions;

namespace CustomComponents.Filters
{
    /// <summary>
    ///********************************************  
    /// 功能描述 ：  返回结果包装
    /// 创 建 人 ：  zhang_hong 
    /// 创建时间 ： 2021/3/24
    /// 修 改 人 ：  
    /// 修改时间 ：  
    /// 修改描述 ：  
    ///******************************************/
    /// </summary>
    public class ResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                object resultvalue = null;
                var objResult = context.Result as ObjectResult;
                if (objResult != null)
                {
                    //重新包装返回格式
                    if (objResult.Value is ResultInfo)
                    {
                        var resultinfo = (ResultInfo)objResult.Value;
                        resultvalue = resultinfo.result;
                    }
                    else
                    {
                        resultvalue = objResult.Value;
                    }
                }
                var result = HttpResultFactory.CreateRessultOk(BusinessEnum.DataCenter, resultvalue);

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;//统一返回200状态
                context.Result = new ObjectResult(result);
            }
            base.OnActionExecuted(context);
        }
    }
}
