using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomComponents.ResultCommon.Service
{
    public static class ResultCommonServiceExtensions
    {

        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddResultCommon(this Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            //if (services is null)
            //{
            //    throw 
            //}

            return services.AddSingleton(typeof(IResultCommonService), typeof(ResultCommonService));
        }
    }
}
