using MediatR;

namespace MediatRSample.Domains.EventsHandler
{
    public class EmailHandler : INotificationHandler<UserInfoNotification>
    {
        public Task Handle(UserInfoNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"已发送邮件给{notification.name }");
            return Task.FromResult(default(string));
        }
    }
}
