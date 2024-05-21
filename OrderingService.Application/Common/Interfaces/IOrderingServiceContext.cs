using Microsoft.EntityFrameworkCore;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Common.Interfaces
{
    public interface IOrderingServiceContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Renter> Renters { get; set; }
        void Migrate();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
