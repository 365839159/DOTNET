using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediatRSample.Domains
{
    public class BaseEntity : IDomainEvents
    {
        [NotMapped]
        private IList<INotification> events = new List<INotification>();
        public void AddDomainEvent(INotification notification)
        {
            events.Add(notification);
        }

        public void AddDomainEventIfAbsent(INotification notification)
        {
            throw new NotImplementedException();
        }

        public void ClearDomainEvents()
        {
            events.Clear();
        }

        public IEnumerable<INotification> GetDomainEvents()
        {
            return events;
        }
    }
}
