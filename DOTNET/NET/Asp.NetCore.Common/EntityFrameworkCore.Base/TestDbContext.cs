#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：TestDbContext
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月30日 星期六 13:20
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using Asp.NetCore.Infrastructure.DBContext;
using Asp.NetCore.Infrastructure.Extensin;
using Asp.NetCore.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Base
{
    public class TestDbContext : DBContextBase
    {
        private readonly string _conn;

        public TestDbContext()
        {
            _conn = "SqlConnectionString";
        }

        public TestDbContext(string sqlConnectionStringConfigName)
        {
            _conn = sqlConnectionStringConfigName;
        }

        //配置连接字符串
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = GloablOpretion.Configuration.GetSection(_conn).Value;

            if (connectionString is null)
            {
                throw new Exception("In Config  Not Find " + _conn);
            }

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}