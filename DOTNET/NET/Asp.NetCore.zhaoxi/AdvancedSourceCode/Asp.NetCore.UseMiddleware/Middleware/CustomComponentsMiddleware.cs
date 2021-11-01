using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ResultCommon;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using Abp.Web.Models;

namespace Asp.NetCore.UseMiddleware.Middleware
{
    public class CustomComponentsMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomComponentsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var session = context.Request.Query["session"];

            if (!string.IsNullOrWhiteSpace(session))
            {
                //var culture = new CultureInfo(cultureQuery);

                //CultureInfo.CurrentCulture = culture;
                //CultureInfo.CurrentUICulture = culture;
                System.Console.WriteLine(session);

            }
            #region
            //var requestReader = new StreamReader(context.Request.Body);

            //var requestContent = await requestReader.ReadToEndAsync();
            //Console.WriteLine($"Request Body: {requestContent}");

            //using (var ms = new MemoryStream())
            //{
            //    context.Response.Body = ms;
            //    await _next(context);
            //    context.Response.Body.Position = 0;

            //    var responseReader = new StreamReader(context.Response.Body);

            //    var responseContent = responseReader.ReadToEnd();
            //    Console.WriteLine($"Response Body: {responseContent}");
            //   // await context.Response.WriteAsync(responseContent);
            //    context.Response.Body.Position = 0;
            //}

            //context.Request.EnableBuffering();
            //var api = new zxc
            //{

            //    httptype = context.Request.Method,
            //    query = context.Request.QueryString.Value,
            //    url = context.Request.Path,
            //    requname = "",
            //    ip = context.Request.Host.Value,
            //    body = ""
            //};


            //var request = context.Request.Body;

            //var response = context.Response.Body;

            //try
            //{
            //    using (var newRequest = new MemoryStream())
            //    {
            //        context.Request.Body = newRequest;

            //        using (var newResponse = new MemoryStream())
            //        {

            //            context.Response.Body = newResponse;

            //            using (var reader = new StreamReader(request))
            //            {
            //                api.body = await reader.ReadToEndAsync();
            //                if (string.IsNullOrEmpty(api.body))
            //                {
            //                    await _next.Invoke(context);
            //                }

            //            }
            //            using (var weite = new StreamWriter(newRequest))
            //            {

            //                await weite.WriteAsync(api.body);
            //                await weite.FlushAsync();
            //                newRequest.Position = 0;
            //                context.Request.Body = newRequest;
            //                await _next(context);
            //            }

            //            using (var reader = new StreamReader(newResponse))
            //            {
            //                newResponse.Position = 0;
            //                api.ResponseBody = await reader.ReadToEndAsync();
            //            }
            //            using (var write = new StreamWriter(response))
            //            {
            //                await write.WriteAsync(api.ResponseBody);
            //                await write.FlushAsync();
            //            }

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            //finally
            //{
            //    context.Request.Body = request;
            //    context.Response.Body = response;
            //}

            //context.Response.OnCompleted(() => { return Task.CompletedTask; });
            #endregion



            try
            {
                MemoryStream ms1 = null;
                StreamWriter writer = null;
                HttpRequest request = context.Request;
                // 获取请求body内容
                if (request.Method.ToLower().Equals("post"))
                {
                    // 启用倒带功能，就可以让 Request.Body 可以再次读取
                    request.EnableBuffering();

                    Stream stream = request.Body;
                    //获取到body值
                    string bodyAsText = await new StreamReader(request.Body).ReadToEndAsync();

                    //修改body值
                    bodyAsText = Regex.Replace(bodyAsText, "(\":\")([0-9]{16,19})(\",)", "\":$2,");

                    //放到流中回填回去
                    ms1 = new MemoryStream();
                    writer = new StreamWriter(ms1);
                    writer.Write(bodyAsText);
                    writer.Flush();
                    request.Body = ms1;
                    request.Body.Position = 0;
                }



                //获取到Response.body内容
                using (var ms = new MemoryStream())
                {
                    var orgBodyStream = context.Response.Body;
                    context.Response.Body = ms;
                    //context.Response.ContentType = "multipart/form-data";
                    //执行controller中正常逻辑代码
                    await _next(context);

                    using (var sr = new StreamReader(ms))
                    {
                        ms.Seek(0, SeekOrigin.Begin);
                        //得到Action的返回值
                        var responseJsonResult = sr.ReadToEnd();
                        ms.Seek(0, SeekOrigin.Begin);
                        //如下代码若不注释则会显示Action的返回值 这里做了注释 则清空Action传过来的值  
                        //  await ms.CopyToAsync(orgBodyStream);
                        //responseJsonResult = Regex.Replace(responseJsonResult, "(\":)([0-9]{16,})(,)", "$1\"$2\"$3");
                        //var alterResult = responseJsonResult;

                        context.Response.Body = orgBodyStream;
                        //显示修改后的数据 

                        responseJsonResult = ResultExecuting(responseJsonResult);
                        await context.Response.WriteAsync(responseJsonResult, Encoding.UTF8);
                    }
                }
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
                if (ms1 != null)
                {
                    ms1.Close();
                    ms1.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 重写返回结果结构
        /// </summary>
        /// <param name="context"></param>
        public string ResultExecuting(string str)
        {
            //// 判断是否由控制器触发，如果不是则不做任何处理
            //if (!context.ActionDescriptor.IsControllerAction() || context.Result is Microsoft.AspNetCore.Mvc.RedirectResult)
            //{
            //    return;
            //}
            //context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;//统一返回200
            Dictionary<string, object> objectresult = new Dictionary<string, object>();
            object ss = null;
            HttpResult httpresult = new HttpResult(null);
            #region  转换返回数据格式为小写
            //转换返回数据格式为小写
            //if (true)
            //{
            //    JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            //    jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //    Dictionary<string, object> dictconvert = JsonConvert.DeserializeObject<Dictionary<string, object>>(str);
            //    if (dictconvert.Count > 0)
            //    {
            //        //查找出嵌套的listDict，转换格式
            //        var dictlistwhere = dictconvert.Where(p => p.Value is List<Dictionary<string, object>>).FirstOrDefault();
            //        var listdict = dictlistwhere.Value;
            //        string wherekey = dictlistwhere.Key;
            //        if (listdict != null)
            //        {
            //            string dictlistlowerStr = JsonConvert.SerializeObject(listdict, jsonSerializerSettings);
            //            listdict = JsonConvert.DeserializeObject(dictlistlowerStr);
            //            dictconvert[wherekey] = listdict;
            //        }
            //        //外层结构格式转换
            //        string lowerStr = JsonConvert.SerializeObject(dictconvert, jsonSerializerSettings);
            //        object resultjson = JsonConvert.DeserializeObject(lowerStr);
            //        ss = resultjson;
            //    }
            //}
            #endregion
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            httpresult = HttpResultFactory.CreateRessultOk(BusinessEnum.ResourceCenter, JsonConvert.DeserializeObject(str, jsonSerializerSettings));

            return JsonConvert.SerializeObject(httpresult);

        }
    }

    public class zxc
    {
        public string httptype { get; set; }
        public string query { get; set; }
        public string url { get; set; }
        public string MyProperty { get; set; }
        public string requname { get; set; }
        public string ip { get; set; }
        public string body { get; set; }

        public string ResponseBody { get; set; }
    }
}
