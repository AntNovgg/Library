using CatalogService.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<CatalogServiceContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<ICatalogServiceContext>(provider =>
                provider.GetService<CatalogServiceContext>());
            return services;
        }
    }
}
