using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using OrderingService.Infrastructure.Configurations;
using OrderingService.Application.Common.Interfaces;
using OrderingService.Domain.Seeds;

namespace OrderingService.Infrastructure
{
    public class OrderingServiceContext : DbContext, IOrderingServiceContext, IUnitOfWork
    {       
        public DbSet<Order> Orders { get; set; }
        public DbSet<Renter> Renters { get; set; }

        public OrderingServiceContext(DbContextOptions<OrderingServiceContext> options)
            : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Username=postgres; Password=1; Database=Library");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderConfig());
            builder.ApplyConfiguration(new RenterConfig());
            base.OnModelCreating(builder);
        }
        public void Migrate()
        {
            Database.Migrate();
        }



    }
}
