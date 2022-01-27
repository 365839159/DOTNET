using EFCoreSample.Entitys;
using EFCoreSample.Entitys.PersonEntity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSample.DbContexts
{
    public class MyDbContext : DbContext
    {
        //1、配置类
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }

        /// <summary>
        ///2、加载连接字符串
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=.;uid=sa;pwd=zxc123...;database=Demo");
        }

        /// <summary>
        /// 3、加载实体配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
