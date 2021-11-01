using EntityFramework;
using Orm.Model;
using System;

namespace Orm.DAL
{
    public class OrmDbContext : DbContext
    {
        public OrmDbContext(string conn) : base(conn)
        {
            Users = new DbSet<Model.User>();
            Companys = new DbSet<Company>();
        }
        public OrmDbContext() : this("")
        {

        }

        public DbSet<Orm.Model.User> Users { get; set; }
        public DbSet<Company> Companys { get; set; }
    }
}
