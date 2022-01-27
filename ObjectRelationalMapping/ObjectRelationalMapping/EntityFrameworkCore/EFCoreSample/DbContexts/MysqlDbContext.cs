using Microsoft.EntityFrameworkCore;

namespace EFCoreSample.DbContexts
{
    public class MysqlDbContext : DbContextBase
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=root;password=root;database=Demo";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            optionsBuilder
                .UseMySql(connectionString, serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}
