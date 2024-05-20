using MediatR;
using OrderingService.Application.Common.Interfaces;
using OrderingService.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Commands.AddOrder
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand, Guid>
    {
        private readonly IOrderingServiceContext _context;
        public AddOrderHandler(IOrderingServiceContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Order order = new Order(request.OrderDate,
                    request.ReturnDate);

                await _context.Orders.AddAsync(order, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return order.Id;
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(AddOrderHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
