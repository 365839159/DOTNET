using MediatR;

namespace MediatRSample.Domains.EventsHandler
{
    public class SMSHandler : INotificationHandler<UserInfoNotification>
    {
        public Task Handle(UserInfoNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"已发送短信给{notification.name }");
            return Task.FromResult(default(string));
        }
    }
}
