using CatalogService.Domain.Aggregates.BookAggregate;
using Microsoft.EntityFrameworkCore;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderingServiceContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public OrderRepository(OrderingServiceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;

        }

        public async Task<Order> GetAsync(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            return order;
        }
        public async Task<IEnumerable<Order>> ListAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }
        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }
    }
}
