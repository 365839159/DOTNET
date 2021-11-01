using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace EntityFramework
{
    public static class SqlHelper
    {
        //定义一个连接字符串
        private static readonly string constr = ConfigrationManager.SqlConnectionString;



        /// <summary>
        /// 执行增、删、改的
        /// </summary>
        /// <param name="sql">需要执行的Sql语句</param>
        /// <param name="pms">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    if (pms != null && pms.Length > 0)
                    {
                        comm.Parameters.AddRange(pms);
                    }
                    conn.Open();
                    return comm.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 返回单个元素
        /// </summary>
        /// <param name="sql">需要执行的sql语句</param>
        /// <param name="pms">参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    if (pms != null && pms.Length > 0)
                    {
                        comm.Parameters.AddRange(pms);
                    }
                    conn.Open();
                    return comm.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="sql">执行sql语句</param>
        /// <param name="pms">参数</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            SqlConnection conn = new SqlConnection(constr);

            using (SqlCommand comm = new SqlCommand(sql, conn))
            {
                if (pms != null && pms.Length > 0)
                {
                    comm.Parameters.AddRange(pms);
                }
                try
                {
                    conn.Open();
                    //System.Data.CommandBehavior.CloseConnection表示在关闭read 的同时，会把相关联的都关闭
                    return comm.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    conn.Close();
                    conn.Dispose();
                    throw;
                }
            }
        }
    }
}
