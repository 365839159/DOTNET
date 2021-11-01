#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：Service
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月30日 星期六 09:08
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using BusinessService.Asp.netCore.AutoFac;

namespace IBusinessService.Asp.netCore.AutoFac
{
    public class Service:IService
    {
        public int GetId(int id)
        {
            return id;
        }
    }
}