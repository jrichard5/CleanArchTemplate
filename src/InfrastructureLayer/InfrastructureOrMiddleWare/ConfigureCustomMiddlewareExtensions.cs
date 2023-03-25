using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
