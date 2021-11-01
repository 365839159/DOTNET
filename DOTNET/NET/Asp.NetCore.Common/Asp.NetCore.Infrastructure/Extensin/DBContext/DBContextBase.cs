#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：DBContextBase
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月30日 星期六 12:20
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Asp.NetCore.Model.Entity;
using Asp.NetCore.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Asp.NetCore.Infrastructure.DBContext
{
    public class DBContextBase : DbContext, IDisposable
    {
        /// <summary>
        /// 是否启用视图跟踪
        /// </summary>
        public virtual bool EnableViewTracing
        {
            get { return false; }
        }

        /// <summary>
        /// 增加实体
        /// </summary>
        /// <typeparam name="T">继承class的实体类</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>返回受影响的行数</returns>
        public async Task<T> Insert<T>(T entity) where T : EntityBase
        {
            await this.Set<T>().AddAsync(entity);
            //this.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 增加实体
        /// </summary>
        /// <typeparam name="T">继承class的实体类</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>返回新增的实体</returns>
        public virtual int Insert<T>(IEnumerable<T> entity) where T : EntityBase
        {
            foreach (var item in entity)
            {
                this.Set<T>().Add(item);
            }

            //return this.SaveChanges();
            return 0;
        }


        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T">继承class的实体类</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>返回是否成功删除</returns>
        public virtual bool Delete<T>(T entity) where T : EntityBase
        {
            this.Entry<T>(entity).State = EntityState.Deleted;
            //return this.SaveChanges() > 0;
            return true;
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T">继承class的实体类</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>返回受影响的行数</returns>
        public virtual int Delete<T>(IEnumerable<T> entity) where T : EntityBase
        {
            foreach (var item in entity)
            {
                this.Entry<T>(item).State = EntityState.Deleted;
            }

            //return this.SaveChanges();
            return 0;
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T">继承class的实体类</typeparam>
        /// <param name="conditions">条件</param>
        /// <returns>返回受影响的行数</returns>
        public virtual int Delete<T>(Expression<Func<T, bool>> conditions) where T : EntityBase
        {
            //return this.Set<T>().Where(conditions).Delete();

            var ret = 0;
            IQueryable<T> qlist = this.Set<T>().Where(conditions);
            if (qlist != null)
            {
                this.Set<T>().RemoveRange(qlist);
                //ret = this.SaveChanges();
            }

            return ret;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T">class</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>返回修改后的实体</returns>
        public new T Update<T>(T entity) where T : EntityBase
        //public virtual T Update<T>(T entity) where T : class
        {
            this.Set<T>().Attach(entity);
            this.Entry<T>(entity).State = EntityState.Modified;
            //this.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 更新实体特定字段
        /// </summary>
        /// <typeparam name="T">继承class的实体类</typeparam>
        /// <param name="entity">更新的实体（更新后的）</param>
        /// <param name="propertyNames">更新实体的字段</param>
        /// <returns></returns>
        public bool Update<T>(T entity, params string[] propertyNames) where T : EntityBase
        {
            EntityEntry entry = this.Entry<T>(entity);
            //entry.State = EntityState.Unchanged;
            foreach (var item in propertyNames)
            {
                entry.Property(item).IsModified = true;
            }

            //return this.SaveChanges() > 0;
            return true;
        }

        /// <summary>
        /// 更新实体List
        /// </summary>
        /// <typeparam name="T">继承TableModelBase的实体类</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>返回受影响的行数</returns>
        public virtual int Update<T>(IEnumerable<T> entity) where T : EntityBase
        {
            foreach (var item in entity)
            {
                this.Set<T>().Attach(item);
                this.Entry<T>(item).State = EntityState.Modified;
            }

            //return this.SaveChanges();
            return 0;
        }

        /// <summary>
        /// 按条件更新特定字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">更新条件</param>
        /// <param name="updateExpression">更新字段值</param>
        /// <returns></returns>
        public int UpdateRange<T>(Expression<Func<T, bool>> where, Action<T> updateExpression) where T : EntityBase
        {
            var ret = 0;

            IQueryable<T> qlist = this.Set<T>().Where(where);
            if (qlist != null)
            {
                qlist.ToList().ForEach(updateExpression);
                this.Set<T>().UpdateRange(qlist.ToArray());
                //ret = this.SaveChanges();
            }

            return ret;
        }

        ///// <summary>
        ///// 更新实体
        ///// </summary>
        ///// <typeparam name="T">继承TableModelBase的实体类</typeparam>
        ///// <param name="conditions">条件</param>
        ///// <param name="updateExpression">更新表达式</param>
        ///// <returns>返回受影响的行数</returns>
        //public virtual int Update<T>(Expression<Func<T, bool>> conditions, Expression<Func<T, T>> updateExpression) where T : class
        //{
        //    return this.Set<T>().Where(conditions).Update(updateExpression);
        //}

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="whereLambd"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public int GetCount<T>(Expression<Func<T, bool>> conditions = null) where T : EntityBase
        {
            return conditions == null ? this.Set<T>().Count() : this.Set<T>().Where(conditions).Count();
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="whereLambd"></param>
        /// <returns></returns>
        public int GetCount<T, TR>(Expression<Func<T, bool>> conditions = null, Expression<Func<T, TR>> selector = null)
            where T : class
        {
            //return conditions == null ? this.Set<T>().Count() : this.Set<T>().Where(conditions).Select(selector).Count();
            if (conditions == null)
            {
                if (selector == null)
                {
                    return this.Set<T>().Count();
                }
                else
                {
                    return this.Set<T>().Select(selector).Distinct().Count();
                }
            }
            else
            {
                if (selector == null)
                {
                    return this.Set<T>().Where(conditions).Count();
                }
                else
                {
                    return this.Set<T>().Where(conditions).Select(selector).Distinct().Count();
                }
            }
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="whereLambd"></param>
        /// <returns></returns>
        public int GetCount<T1, T2, TR, TKey>(Expression<Func<T1, TR>> selector
            , Expression<Func<T1, bool>> conditions1 = null
            , Expression<Func<T2, bool>> conditions2 = null
            , Expression<Func<T1, TKey>> outerKey = null
            , Expression<Func<T2, TKey>> innerKey = null
        ) where T1 : class where T2 : class where TR : class
        {
            //return conditions1 == null ? this.Set<T1>().Count() : this.Set<T1>().Where(conditions1).Count();
            if (conditions1 == null)
            {
                if (conditions2 == null)
                {
                    return this.Set<T1>().Select(selector).Distinct().Count();
                }
                else
                {
                    return this.Set<T1>().Join(this.Set<T2>().Where(conditions2), outerKey, innerKey, (q1, q2) => q1)
                        .Select(selector).Distinct().Count();
                }
            }
            else
            {
                if (conditions2 == null)
                {
                    return this.Set<T1>().Where(conditions1).Distinct().Count();
                }
                else
                {
                    return this.Set<T1>().Where(conditions1)
                        .Join(this.Set<T2>().Where(conditions2), outerKey, innerKey, (q1, q2) => q1).Select(selector)
                        .Distinct().Count();
                }
            }
        }

        /// <summary>
        /// 查询数据[主键]
        /// </summary>
        /// <typeparam name="T">继承ModelBase的实体类</typeparam>
        /// <param name="keyValues">主键值</param>
        /// <returns>找到则返回实体，未找到返回NULL</returns>
        public override T Find<T>(params object[] keyValues) where T : class
        {
            return this.Set<T>().Find(keyValues);
        }

        /// <summary>
        /// 查询数据[主键]
        /// </summary>
        /// <typeparam name="T">继承ModelBase的实体类</typeparam>
        /// <param name="keyValues">主键值</param>
        /// <returns>找到则返回实体，未找到返回NULL</returns>
        public async Task<object> FindAsync<T>(T entity, params object[] keyValues) where T : EntityBase
        {
            return
                await this.Set<T>()
                    .FindAsync(keyValues); //.FirstAsync(); // .SelectMany("ClientIdx", "ClientIdx", keyValues).ToListAsync(); //.FindAsync(keyValues); //
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <typeparam name="T">继承ModelBase的实体类</typeparam>
        /// <param name="conditions">查询条件</param>
        /// <returns></returns>
        public virtual List<T> FindAll<T>(Expression<Func<T, bool>> conditions = null) where T : EntityBase
        {
#if DEBUG
            var sql = conditions == null
                ? this.DbQuery<T>().ToString()
                : this.DbQuery<T>().Where(conditions).ToString();
#endif

            if (conditions == null)
                return this.DbQuery<T>().AsNoTracking().ToList();
            else
                return this.DbQuery<T>().AsNoTracking().Where(conditions).ToList();
        }

        /// <summary>
        /// 按检索条件获取第一行实体
        /// </summary>
        /// <typeparam name="T">继承class的实体类</typeparam>
        /// <param name="where">检索条件</param>
        /// <returns></returns>
        public async Task<T> FindFirst<T>(Expression<Func<T, bool>> where) where T : EntityBase
        {
            Task<T> tt = Task.Run(() => { return this.Set<T>().Where(where)?.FirstOrDefault(); });
            return await tt;
        }

        /// <summary>
        /// 查询转换
        /// </summary>
        /// <param name="conditions">查询条件</param>
        /// <param name="selector">查询字段</param>
        /// <returns></returns>
        public virtual List<TResult> FindAll<TSource, TResult>(Expression<Func<TSource, bool>> conditions,
            Expression<Func<TSource, TResult>> selector) where TSource : EntityBase
        {
            var queryableList =
                conditions == null ? this.DbQuery<TSource>() : this.DbQuery<TSource>().Where(conditions);
            return queryableList.Select(selector).ToList();
        }


        /// <summary>
        /// 计算数据[求总数]
        /// </summary>
        /// <typeparam name="T">继承ModelBase的实体类</typeparam>
        /// <param name="conditions">查询条件</param>
        /// <param name="groupBy">分组条件</param>
        /// <returns></returns>
        public virtual List<T> Count<T>(Expression<Func<T, bool>> conditions,
            Func<IQueryable<T>, IQueryable<T>> groupBy) where T : EntityBase
        {
            var queryableList = conditions == null ? this.DbQuery<T>() : this.DbQuery<T>().Where(conditions);
            queryableList = groupBy(queryableList);
            return queryableList.ToList();
        }

        /// <summary>
        /// 获取DbSet
        /// </summary>
        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// 获取DbQuery
        /// </summary>
        protected DbSet<TEntity> DbQuery<TEntity>() where TEntity : EntityBase
        {
            // if (!this.EnableViewTracing && typeof(ViewModelBase).IsAssignableFrom(typeof(TEntity)))
            //     return (DbSet<TEntity>) this.Set<TEntity>().AsNoTracking(); //.AsNoTracking();
            return this.Set<TEntity>();
        }

        public override int SaveChanges()
        {
            var result = base.SaveChanges();
            return result;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return this.Database.BeginTransaction();
        }

        public void Commit(IDbContextTransaction transaction)
        {
            transaction.Commit();
        }

        public void Rollback(IDbContextTransaction transaction)
        {
            transaction.Rollback();
        }

        protected virtual void Dispose(bool disposing)
        {
            base.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}