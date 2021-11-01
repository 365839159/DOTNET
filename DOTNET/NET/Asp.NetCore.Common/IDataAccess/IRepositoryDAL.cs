﻿#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：IRepositoryDAL
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月30日 星期六 14:08
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using Asp.NetCore.Model.Entity;
using EntityFrameworkCore.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IDataAccess.Asp.netCore
{
    public interface IRepositoryDAL<T>:IBaseDAL<T, TestDbContext> where T:EntityBase
    {
        
    }
}