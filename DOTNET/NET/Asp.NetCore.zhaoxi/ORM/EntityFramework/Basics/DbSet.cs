using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntityFramework.SqlHelper;
namespace EntityFramework
{
    public class DbSet<T>
    {
        /// <summary>
        /// 查找
        /// =================================
        ///  SELECT *.* FROM [TABLE]
        /// =================================
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Find()
        {
            List<T> list = new List<T>();
            Type type = typeof(T);
            //读取实体中的属性
            var proprties = type.GetProperties().Select(s => "[" + s.Name + "]");
            //将属性通过 " , " 相连
            string proprtiesStr = string.Join(",", proprties);
            //拼接sql
            string sql = $"SELECT {proprtiesStr} FROM [{typeof(T).Name}] ";
            //执行sql语句
            SqlDataReader sqlDataReader = ExecuteReader(sql);
            //便利数据
            while (sqlDataReader.Read())
            {
                //创建对象存储值
                T obj = (T)Activator.CreateInstance(type);
                foreach (var propertyInfo in type.GetProperties())
                {
                    propertyInfo.SetValue(obj, sqlDataReader[propertyInfo.Name] is DBNull ? null : sqlDataReader[propertyInfo.Name]);
                }
                list.Add(obj);
            }
            return list;
        }
    }
}
