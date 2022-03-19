using MediatR;
using MediatRSample.Domains;
using Microsoft.EntityFrameworkCore;

namespace MediatRSample.DbContexts
{
    public class UserDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public UserDbContext(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
            base.OnConfiguring(optionsBuilder);
        }
        /// <summary>
        /// 重写savechanges
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //获取继承IDomainEvents 的有事件的 entity
            var domainEntities = this.ChangeTracker.Entries<IDomainEvents>().Where(s => s.Entity.GetDomainEvents().Any());
            //取出所有的事件
            var domainEvents = domainEntities.SelectMany(s => s.Entity.GetDomainEvents().ToList());
            //清除继承IDomainEvents 的有事件的 entity
            domainEntities.ToList().ForEach(e => e.Entity.ClearDomainEvents());
            //循环发布事件
            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
