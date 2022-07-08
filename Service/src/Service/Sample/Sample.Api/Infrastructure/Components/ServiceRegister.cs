using MediatR;
using Sample.Application;
using Sample.Infrastructure;
using System.Reflection;

namespace Sample.Api.Infrastructure.Components
{
    public static class ServiceRegister
    {
        public static void AddComponents(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddApplicationServices();
            services.AddInfrastructureService(configuration);
        }
    }
}
