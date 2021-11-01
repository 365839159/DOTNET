using CustomComponents.ResultCommon.Service;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomComponents.ResultCommon.Middleware
{
    public class ResultCommonMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IResultCommonService _resultCommonService;
        public ResultCommonMiddleware(RequestDelegate next, IResultCommonService resultCommonService)
        {
            _next = next;
            _resultCommonService = resultCommonService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value.Contains("swagger"))
            {
                await _next(context);
                return;
            }
            #region

            var response = context.Response.Body;
            try
            {
                MemoryStream ms1 = null;
                StreamWriter writer = null;
                HttpRequest request = context.Request;
                if (request.Path.Value.Contains("swagger"))
                {
                    await _next(context);
                    return;
                }
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

                    string result = string.Empty;
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

                        object obj = JsonConvert.DeserializeObject(responseJsonResult);
                        var objResult = _resultCommonService.ResultCommon(obj);
                        responseJsonResult = JsonConvert.SerializeObject(objResult.Value);
                        result = responseJsonResult;
                        //await context.Response.WriteAsync(responseJsonResult, Encoding.UTF8);
                    }

                    using (var write = new StreamWriter(response))
                    {
                        await write.WriteAsync(result);
                        await write.FlushAsync();
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
            finally
            {
                context.Response.Body = response;
            }
            #endregion


            #region 
            //context.Response.ContentType = "application/json";
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
            //                object obj = JsonConvert.DeserializeObject(api.ResponseBody);
            //                var objResult = _resultCommonService.ResultCommon(obj);
            //                api.ResponseBody = JsonConvert.SerializeObject(objResult.Value);
            //                context.Response.ContentLength = 99999;
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
            //}            //context.Response.ContentType = "application/json";
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
            //                object obj = JsonConvert.DeserializeObject(api.ResponseBody);
            //                var objResult = _resultCommonService.ResultCommon(obj);
            //                api.ResponseBody = JsonConvert.SerializeObject(objResult.Value);
            //                context.Response.ContentLength = 99999;
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

            #endregion


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
