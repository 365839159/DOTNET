#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：UserBLL
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
using IBusinessService.Asp.netCore.UserBLL;
using IDataAccess.Asp.netCore;

namespace BusinessService.Asp.netCore.UserBLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IRepositoryDAL<User> _repositoryDal;

        public UserBLL(IRepositoryDAL<User> repositoryDal)
        {
            _repositoryDal = repositoryDal;
        }

        public List<User> GetUsers()
        {
            return _repositoryDal.FindAll(s => true);
        }
    }
}