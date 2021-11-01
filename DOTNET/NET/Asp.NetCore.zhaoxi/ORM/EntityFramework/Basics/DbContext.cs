using System;

namespace EntityFramework
{
    public class DbContext : IDisposable
    {
        //protected readonly string _sqlConnectionString;
        public DbContext(string sqlConnectionString)
        {
            if (!string.IsNullOrEmpty(sqlConnectionString))
            {
                ConfigrationManager.SetSqlConnectionString(sqlConnectionString);
            }
        }
        public DbContext() { }

        public void Dispose()
        {
        }
    }
}
