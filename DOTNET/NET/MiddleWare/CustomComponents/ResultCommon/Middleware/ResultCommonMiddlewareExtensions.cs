using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomComponents.ResultCommon.Middleware
{
    public static class ResultCommonMiddlewareExtensions
    {
        public static IApplicationBuilder UseResultCommon(
          this IApplicationBuilder builder)
        {
            if (builder is null)
            {

            }
            return builder.UseMiddleware<ResultCommonMiddleware>();
        }
    }
}
