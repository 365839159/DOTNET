#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：BaseDAL
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月30日 星期六 13:50
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
using Asp.NetCore.Infrastructure.DBContext;
using Asp.NetCore.Model.Entity;
using IDataAccess.Asp.netCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.Asp.netCore
{
    public class BaseDAL<T, T2> : IBaseDAL<T, T2> where T : EntityBase where T2 : DBContextBase
    {
        //public MainDbContext db = null;
        //public BaseDAL(string conn)
        //{
        //    db = new MainDbContext(conn);
        //}

        public string conn;
        //public BaseDAL(string conn)
        //{
        //    this.conn = conn;
        //}

        //DbContext测试注入
        //MainDbContext mainContext;
        //ReadOnlyDbContext readOnlyContext;
        //public BaseDAL(MainDbContext mainContext, ReadOnlyDbContext readOnlyContext)
        //{
        //    this.mainContext = mainContext;
        //    this.readOnlyContext = readOnlyContext;
        //}

        T2 mainContext;
        public BaseDAL(T2 mainContext)
        {
            this.mainContext = mainContext;

        }
        public void SetContext(T2 mainContext)
        {
            this.mainContext = mainContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            return await mainContext.Insert(entity);
            //await db.Set<T>().AddAsync(entity);
            //db.SaveChanges();

            //using (var mainContext = new MainDbContext(conn))
            //{
            //    //await mainContext.Set<T>().AddAsync(entity);
            //    //mainContext.SaveChanges();
            //    return await mainContext.Insert(entity);
            //}
        }

        public int AddManyAsync(IEnumerable<T> entitys)
        {
            return mainContext.Insert(entitys);
            //await db.Set<T>().AddAsync(entity);
            //db.SaveChanges();

            //using (var mainContext = new MainDbContext(conn))
            //{
            //    //await mainContext.Set<T>().AddAsync(entity);
            //    //mainContext.SaveChanges();
            //    return await mainContext.Insert(entity);
            //}
        }

        public void Delete(T entity)
        {
            mainContext.Delete(entity);
            //using (var mainContext = new MainDbContext(conn))
            //{
            //    //mainContext.Set<T>().Remove(entity);
            //    //mainContext.SaveChanges();
            //    mainContext.Delete(entity);
            //}
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            mainContext.Delete(where);
            //using (var mainContext = new MainDbContext(conn))
            //{
            //    //IQueryable<T> qlist = mainContext.Set<T>().Where(where);
            //    //if (qlist != null)
            //    //{
            //    //    mainContext.Set<T>().RemoveRange(qlist);
            //    //    mainContext.SaveChanges();
            //    //}
            //    mainContext.Delete(where);
            //}
        }

        public T Update(T entity)
        {
            return mainContext.Update(entity);
        }

        public bool Update(T entity, params string[] propertyNames)
        {
            return mainContext.Update(entity, propertyNames);
            //using (var mainContext = new MainDbContext(conn))
            //{
            //    //EntityEntry entry = mainContext.Entry<T>(entity);
            //    //entry.State = EntityState.Unchanged;
            //    //foreach (var item in propertyNames)
            //    //{
            //    //    entry.Property(item).IsModified = true;
            //    //}
            //    //mainContext.SaveChanges();
            //    mainContext.Update(entity, propertyNames);
            //}
        }

        public int UpdateRange(Expression<Func<T, bool>> where, Action<T> updateExpression)
        {
            return mainContext.UpdateRange(where, updateExpression);

            //var ret = 0;
            //IQueryable<T> qlist = db.Set<T>().Where(where);
            //if (qlist != null)
            //{
            //    qlist.ToList().ForEach(updateExpression);
            //    db.Set<T>().UpdateRange(qlist.ToArray());
            //    ret = db.SaveChanges();
            //}
            //return ret;

            //var ret = 0;
            //using (var mainContext = new MainDbContext(conn))
            //{
            //    //IQueryable<T> qlist = mainContext.Set<T>().Where(where);
            //    //if (qlist != null)
            //    //{
            //    //    qlist.ToList().ForEach(updateExpression);
            //    //    mainContext.Set<T>().UpdateRange(qlist.ToArray());
            //    //    ret = mainContext.SaveChanges();
            //    //}

            //    ret = mainContext.UpdateRange(where, updateExpression);
            //}
            //return ret;
        }

        public async Task<T> FindFirst(Expression<Func<T, bool>> where)
        {
            return await mainContext.FindFirst(where);
            //using (var mainContext = new MainDbContext(conn))
            //{
            //    //return mainContext.Set<T>().Where(where)?.FirstOrDefault();
            //    return mainContext.FindFirst(where);
            //}
        }

        public List<T> FindAll(Expression<Func<T, bool>> where)
        //public IQueryable<T> GetEntityList(Expression<Func<T, bool>> where)
        {
            return mainContext.FindAll(where);
            //using (var mainContext = new MainDbContext(conn))
            //{
            //    //return mainContext.Set<T>().Where(where)?.FirstOrDefault();
            //    return mainContext.FindAll(where);
            //}
        }

        //public IQueryable<T> GetEntityListOrder<orderkey>(Expression<Func<T, bool>> where, Expression<Func<T, orderkey>> orderbykey,bool asc=true)
        //{
        //    using (var mainContext = new MainDbContext(conn))
        //    {
        //        IQueryable<T> qlist = mainContext.Set<T>().Where(where);
        //        if (asc)
        //        {
        //            qlist = qlist.OrderBy(orderbykey).AsQueryable<T>();
        //        }
        //        else
        //        {
        //            qlist = qlist.OrderByDescending(orderbykey).AsQueryable<T>();
        //        }
        //        return qlist;
        //    }
        //}

        //public IQueryable<T> GetEntityPaginationListOrder<orderkey>(int pageSize, int pageIndex, Expression<Func<T, bool>> where, Expression<Func<T, orderkey>> orderbykey, out int rowscount,bool asc=true)
        //{
        //    using (var mainContext = new MainDbContext(conn))
        //    {
        //        IQueryable<T> qlist = mainContext.Set<T>().Where(where);
        //        if (asc)
        //        {
        //            qlist = qlist.OrderBy(orderbykey).AsQueryable<T>();
        //        }
        //        else
        //        {
        //            qlist = qlist.OrderByDescending(orderbykey).AsQueryable<T>();
        //        }
        //        rowscount = qlist.ToList().Count;
        //        int skipcount = (pageIndex - 1) * pageSize;
        //        return qlist.Skip(skipcount).Take(pageSize);
        //    }
        //}

        public int SaveChanges()
        {
            return mainContext.SaveChanges();
            //using (var mainContext = new MainDbContext(conn))
            //{
            //    return mainContext.SaveChanges();
            //}
        }

        //public async Task<IDbContextTransaction> BeginTransactionAsync()
        //{
        //    return await mainContext.Database.BeginTransactionAsync();
        //}

        //public async Task CommitAsync(IDbContextTransaction transaction)
        //{
        //    await transaction.CommitAsync();
        //}

        //public async Task RollbackAsync(IDbContextTransaction transaction)
        //{
        //    await transaction.RollbackAsync();
        //}

        public IDbContextTransaction BeginTransaction()
        {
            return mainContext.BeginTransaction();
        }

        public void Commit(IDbContextTransaction transaction)
        {
            mainContext.Commit(transaction);
        }

        public void Rollback(IDbContextTransaction transaction)
        {
            mainContext.Rollback(transaction);
        }

        //public T ReadOnlyFindFirst(Expression<Func<T, bool>> where)
        //{
        //    return readOnlyContext.FindFirst(where);
        //    //using (var mainContext = new MainDbContext(conn))
        //    //{
        //    //    //return mainContext.Set<T>().Where(where)?.FirstOrDefault();
        //    //    return mainContext.FindFirst(where);
        //    //}
        //}

        //public List<T> ReadOnlyFindAll(Expression<Func<T, bool>> where)
        ////public IQueryable<T> GetEntityList(Expression<Func<T, bool>> where)
        //{
        //    return readOnlyContext.FindAll(where);
        //    //using (var mainContext = new MainDbContext(conn))
        //    //{
        //    //    //return mainContext.Set<T>().Where(where)?.FirstOrDefault();
        //    //    return mainContext.FindAll(where);
        //    //}
        //}
    }
}