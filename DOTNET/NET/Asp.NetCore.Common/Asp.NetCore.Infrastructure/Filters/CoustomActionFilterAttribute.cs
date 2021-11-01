#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：CoustomActionFilterAttribute
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月30日 星期六 19:03
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Asp.NetCore.Infrastructure.Filters
{
    public class CoustomActionFilterAttribute : ActionFilterAttribute
    {
        private ILogger<CoustomActionFilterAttribute> _ILogger = null;

        public CoustomActionFilterAttribute(ILogger<CoustomActionFilterAttribute> logger)
        {
            _ILogger = logger;
            _ILogger.LogInformation($"{this.GetType().Name} 被构造。。。。");
        }

        /// <summary>
        /// 第二步执行
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _ILogger.LogInformation($"{this.GetType().Name}。OnActionExecuting 执行。。。。");
            base.OnActionExecuting(context);
        }


        /// <summary>
        /// 执行了Action之后的  第一步
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _ILogger.LogInformation($"{this.GetType().Name}。OnActionExecuted 执行。。。。");
            base.OnActionExecuted(context);
        }


        /// <summary>
        /// 第一步执行
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _ILogger.LogInformation($"{this.GetType().Name}。OnActionExecutionAsync 执行。。。。");
            return base.OnActionExecutionAsync(context, next);
        }

        /// <summary>
        /// Action执行以后，执行的第三步
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _ILogger.LogInformation($"{this.GetType().Name}。OnResultExecuting 执行。。。。");
            base.OnResultExecuting(context);
        }

        //视图渲染
        /// <summary>
        /// Action执行以后，执行的第四步
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _ILogger.LogInformation($"{this.GetType().Name}。OnResultExecuted 执行。。。。");
            base.OnResultExecuted(context);
        }

        /// <summary>
        /// Action执行以后，执行的第二步
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            _ILogger.LogInformation($"{this.GetType().Name}。OnResultExecutionAsync 执行。。。。");
            return base.OnResultExecutionAsync(context, next);
        }
    }


    /// <summary>
    /// 第二种写法 
    /// </summary>
    public class CustomActionFilterNewAttribute : Attribute, IActionFilter
    {
        private ILogger<CustomActionFilterNewAttribute> _ILogger = null;

        public CustomActionFilterNewAttribute(ILogger<CustomActionFilterNewAttribute> logger)
        {
            _ILogger = logger;
            _ILogger.LogInformation($"{this.GetType().Name} 被构造。。。。");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //context.HttpContext;//Http请求的上下文； 就可以获取到请求中的所有的信息 
            Console.WriteLine("CustomActionFilterNewAttribute.OnActionExecuted...");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.HttpContext.Request
            //1.记录日志
            //2.验证参数--就可以获取到参数，验证参数--如果参数验证不通过怎么办？
            //不能让你继续往后； 
            //context.Result = new ViewResult() {
            //    ViewName = "Views/Seconod/ParaError.cshtml"
            //};

            Console.WriteLine("CustomActionFilterNewAttribute.OnActionExecuting...");
        }
    }
}