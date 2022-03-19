using MediatR;

namespace MediatRSample.Domains
{
    public record UserInfoNotification(string name):INotification;
}
