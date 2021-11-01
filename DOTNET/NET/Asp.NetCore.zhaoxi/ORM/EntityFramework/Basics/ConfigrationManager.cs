using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    /// <summary>
    /// 读取根目录下面的连接字符串
    /// </summary>
    internal class ConfigrationManager
    {
        public static IConfigurationRoot configuration;
        static ConfigrationManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            configuration = builder.Build();
            _SqlConnectionString = configuration["connectionString"];
        }
        private static string _SqlConnectionString = null;
        public static string SqlConnectionString
        {
            get
            {
                return _SqlConnectionString;
            }
        }
        internal static void SetSqlConnectionString(string conn)
        {
            _SqlConnectionString = configuration[conn];
        }
    }
}
