using MediatR;

namespace MediatRSample.Models
{
    public record UserInfo(string name, int age, string addres):IRequest<bool>;

}
