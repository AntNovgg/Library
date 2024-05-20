using OrderingService.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<OrderingServiceContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IOrderingServiceContext>(provider =>
                provider.GetService<OrderingServiceContext>());
            return services;
        }
    }
}
