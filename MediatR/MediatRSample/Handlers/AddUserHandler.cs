using MediatR;
using MediatRSample.Models;

namespace MediatRSample.Handlers
{
    public class AddUserHandler : IRequestHandler<UserInfo, bool>
    {
        public async Task<bool> Handle(UserInfo request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(true);
        }
    }
}
