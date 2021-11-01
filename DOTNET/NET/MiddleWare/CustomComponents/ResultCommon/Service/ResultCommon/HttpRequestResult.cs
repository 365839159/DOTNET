using System;
using System.Collections.Generic;
using System.Text;

namespace CustomComponents.ResultCommon
{
    /// <summary>
    ///********************************************  
    /// 功能描述 ： Http后台请求返回结构包装
    /// 创 建 人 ：  zhang_hong 
    /// 创建时间 ： 2021/3/23 
    /// 修 改 人 ：  
    /// 修改时间 ：  
    /// 修改描述 ：  
    ///******************************************/
    /// </summary>
    public class HttpRequestResult<T>
    {
        public HttpResultStatus Status { get; set; }
        public T Data { get; set; }
    }
}
