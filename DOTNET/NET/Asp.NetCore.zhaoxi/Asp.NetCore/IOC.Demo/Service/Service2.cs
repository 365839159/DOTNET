#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：Service2
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月23日 星期六 18:26
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
    public class Service2 : IService2
    {
        public Service2(IService1 service1)
        {
            service1.Show();
        }

        public void Show()
        {
            Console.WriteLine("Service2");
        }
    }
}