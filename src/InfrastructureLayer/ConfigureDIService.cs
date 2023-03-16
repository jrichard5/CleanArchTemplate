using ApplicationLayer.InterfaceRepositories;
using InfrrastructureLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrrastructureLayer
{
    public static class ConfigureDIService
    {
        //TODO: Add connection string
        //Looking at a working example in Github.  https://github.com/ardalis/CleanArchitecture/blob/main/src/Clean.Architecture.Infrastructure/StartupSetup.cs
        public static void ConfigureDbStuff(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<EntityContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ICatRepository, CatRepository>();
        }


        //TODO: Remove this for final commit
        //This is an extension method that you call in the WebAPI's startup
        //public static IServiceCollection ConfigureServices(this IServiceCollection services)
        //{
        //    //services.AddDbContext<EntityContext>

        //    services.AddScoped<ICatRepository, CatRepository>();

        //    return services;
        //}


        //I'm going to try using options builder because that is what I remember
        //I cannot remember where options builder is suppose to go
        /*
        public static void ConfigureServices(OptionsBuilder<DbContext> optionsBuilder)
        {
            optionsBuilder.Services.AddScoped<ICatRepository, CatRepository>();

            optionsBuilder.
        }
        */


    }
}
