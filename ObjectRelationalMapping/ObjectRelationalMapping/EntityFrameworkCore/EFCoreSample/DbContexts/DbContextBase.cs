using EFCoreSample.Entitys;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSample.DbContexts
{
    public class DbContextBase : DbContext 
    {
        public DbSet<Test> Test { get; set; }
    }
}
