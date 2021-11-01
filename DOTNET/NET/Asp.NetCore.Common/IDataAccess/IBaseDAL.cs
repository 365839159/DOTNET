#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：IBaseDAL
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月30日 星期六 13:51
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace IDataAccess.Asp.netCore
{
    public interface IBaseDAL<T, T2>
    {
        Task<T> AddAsync(T entity);
        int AddManyAsync(IEnumerable<T> entitys);
        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        T Update(T entity);

        bool Update(T entity, params string[] propertyNames);

        int UpdateRange(Expression<Func<T, bool>> where, Action<T> updateExpression);

        Task<T> FindFirst(Expression<Func<T, bool>> where);

        List<T> FindAll(Expression<Func<T, bool>> where);

        //IQueryable<T> GetEntityListOrder<orderkey>(Expression<Func<T, bool>> where, Expression<Func<T, orderkey>> orderbykey, bool asc = true);

        //IQueryable<T> GetEntityPaginationListOrder<orderkey>(int pageSize, int pageIndex, Expression<Func<T, bool>> where, Expression<Func<T, orderkey>> orderbykey, out int rowscount, bool asc = true);

        int SaveChanges();

        //Task<IDbContextTransaction> BeginTransactionAsync();
        //Task CommitAsync(IDbContextTransaction transaction);
        //Task RollbackAsync(IDbContextTransaction transaction);
        IDbContextTransaction BeginTransaction();
        void Commit(IDbContextTransaction transaction);
        void Rollback(IDbContextTransaction transaction);


        //T ReadOnlyFindFirst(Expression<Func<T, bool>> where);
        //List<T> ReadOnlyFindAll(Expression<Func<T, bool>> where);
    }
}