using MediatR;

namespace MediatRSample.Domains
{
    public interface IDomainEvents
    {
        /// <summary>
        /// 获取领域事件
        /// </summary>
        /// <returns></returns>
        IEnumerable<INotification> GetDomainEvents();
        /// <summary>
        /// 添加领域事件
        /// </summary>
        void AddDomainEvent(INotification notification);
        /// <summary>
        /// 如果不存在添加领域事件
        /// </summary>
        void AddDomainEventIfAbsent(INotification notification);
        /// <summary>
        /// 清除领域事件
        /// </summary>
        void ClearDomainEvents();
    }
}
