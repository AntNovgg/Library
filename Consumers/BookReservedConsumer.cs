using CatalogService.Application.Common.Interfaces;
using Contracts;
using MassTransit;
using OrderingService.Application.Commands.AddOrder;
using OrderingService.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Consumers
{
    public class BookReservedConsumer : IConsumer<BookReservedEvent>
    {
        private readonly IOrderingServiceContext _context;
        public BookReservedConsumer(IOrderingServiceContext context)
        {
            _context = context;
        }
        public Task<Guid> Consume(ConsumeContext<BookReservedEvent> context) 
        {
            try
            {
                Order order = new Order(request.BookId,
                request.RenterId,
                request.OrderDate,
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
