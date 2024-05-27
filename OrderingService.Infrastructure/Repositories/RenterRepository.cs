using Microsoft.EntityFrameworkCore;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using OrderingService.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Infrastructure.Repositories
{
    public class RenterRepository : IRenterRepository
    {
        private readonly OrderingServiceContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public RenterRepository(OrderingServiceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Renter Add(Renter renter)
        {
            return _context.Renters.Add(renter).Entity;

        }

        public async Task<Renter> GetAsync(int renterId)
        {
            var renter = await _context.Renters.FindAsync(renterId);

            return renter;
        }

        public void Update(Renter renter)
        {
            _context.Entry(renter).State = EntityState.Modified;
        }
    }
}
