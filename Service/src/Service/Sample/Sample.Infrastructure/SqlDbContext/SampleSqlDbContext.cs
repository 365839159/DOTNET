using Microsoft.EntityFrameworkCore;
using Sample.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.SqlDbContext
{
    public class SampleSqlDbContext : DbContext, IUnitOfWork
    {
        public SampleSqlDbContext(DbContextOptions<SampleSqlDbContext> options) : base(options)
        {
        }



        /// <summary>
        /// 实现工作单元（领域事件）
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> SaveChangAndPublishDomainEventAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
