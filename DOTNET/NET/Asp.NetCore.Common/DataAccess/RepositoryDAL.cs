#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：RepositoryDAL
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月30日 星期六 14:07
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using Asp.NetCore.Model.Entity;
using DataAccess.Asp.netCore;
using EntityFrameworkCore.Base;
using IDataAccess.Asp.netCore;

namespace DataAccess
{
    public class RepositoryDAL<T> : BaseDAL<T, TestDbContext>, IRepositoryDAL<T> where T : EntityBase
    {
        public RepositoryDAL(TestDbContext mainContext) : base(mainContext)
        {
        }
    }
}