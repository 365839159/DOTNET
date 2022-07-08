using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Queries.Sample
{
    public class SampleQueries : ISampleQueries
    {
        private readonly IConfiguration _configutation;

        public SampleQueries(IConfiguration configuration)
        {
            _configutation = configuration;
        }

        public async Task<IEnumerable<SampleViewModel>> GetSampleAsync()
        {
            List<SampleViewModel> result = new List<SampleViewModel>();

            //sqlserver
            string sqlServer = "SELECT Top 10 * FROM U_Account";
            var conn = _configutation["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(conn))
            {
                var samples = await connection.QueryAsync(sqlServer);

                foreach (var item in samples ?? new List<dynamic>())
                {
                    result.Add(new SampleViewModel() { Name = item.LoginName });
                }

            }

            //mysql
            var mySqlConn = _configutation["ConnectionStrings:Mysql"];
            string mysql = "SELECT  * FROM SampleTable  limit 1";
            using (var connection = new MySqlConnection(mySqlConn))
            {
                var samples = await connection.QueryAsync(mysql);
                foreach (var item in samples ?? new List<dynamic>())
                {
                    result.Add(new SampleViewModel() { Name = item.name });
                }
            }
            return result;
        }
    }
}
