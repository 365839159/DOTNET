#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：Service3
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月23日 星期六 18:29
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
    public class Service3 : IService3
    {
        public Service3(IService2 service2)
        {
            service2.Show();
        }

        public void Show()
        {
            Console.WriteLine("service3");
        }
    }
}