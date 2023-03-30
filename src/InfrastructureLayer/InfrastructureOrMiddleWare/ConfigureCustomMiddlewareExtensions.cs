using Microsoft.AspNetCore.Builder;

namespace InfrastructureLayer.InfrastructureOrMiddleWare
{
    public static class ConfigureCustomMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware (this IApplicationBuilder app)
        {
            app.UseMiddleware<MiddlewareException>();
        }
    }
}
