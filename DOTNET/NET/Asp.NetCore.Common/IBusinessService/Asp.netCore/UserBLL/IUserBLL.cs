#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：IUserBLL
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月30日 星期六 15:00
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System.Collections.Generic;
using Asp.NetCore.Model.Entity;

namespace IBusinessService.Asp.netCore.UserBLL
{
    public interface IUserBLL
    {
        public List<User> GetUsers();
    }
}