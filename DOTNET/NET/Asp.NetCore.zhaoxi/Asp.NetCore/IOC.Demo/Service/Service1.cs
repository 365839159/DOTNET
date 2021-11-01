#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：Service1
// 创 建 者：zhang xian cheng
// 创建时间：TIME
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion


using System;
using IOC.Demo.Interface;

namespace IOC.Demo.Service
{
    public class Service1:IService1
    {
        public Service1()
        {
        }

        public void Show()
        {
            Console.WriteLine("Service1");
        }
    }
}