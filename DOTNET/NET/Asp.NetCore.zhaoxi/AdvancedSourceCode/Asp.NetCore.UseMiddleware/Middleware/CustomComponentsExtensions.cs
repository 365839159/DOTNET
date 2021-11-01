using Microsoft.AspNetCore.Builder;

namespace Asp.NetCore.UseMiddleware.Middleware
{
    public static class CustomComponentsExtensions
    {
        public static IApplicationBuilder UseCustomComponents(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomComponentsMiddleware>();
        }
    }
}
