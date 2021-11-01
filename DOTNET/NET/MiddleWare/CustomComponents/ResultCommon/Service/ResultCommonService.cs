using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebAPICore.Infrastructure.Extensions;

namespace CustomComponents.ResultCommon.Service
{
    public class ResultCommonService : IResultCommonService
    {
        public ObjectResult ResultCommon(object obj)
        {
            object resultValue = null;

            //重新包装返回格式
            if (obj is ResultInfo)
            {
                var resultinfo = (ResultInfo)obj;
                resultValue = resultinfo.result;
            }
            else
            {
                resultValue = obj;
            }

            var result = HttpResultFactory.CreateRessultOk(BusinessEnum.DataCenter, resultValue);

            // context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;//统一返回200状态
            ObjectResult objectResult = new ObjectResult(result);
            return objectResult;
        }
    }
}

