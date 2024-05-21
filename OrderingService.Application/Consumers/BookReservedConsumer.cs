using Contracts;
using MassTransit;
using OrderingService.Application.Commands.AddOrder;
using OrderingService.Application.Common.Interfaces;
using OrderingService.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderingService.Application.Consumers
{
    public class BookReservedConsumer : IConsumer<BookReservedEvent, Guid>
    {
        private readonly IOrderingServiceContext _context;
        public BookReservedConsumer(IOrderingServiceContext context)
        {
            _context = context;
        }
        public async Task<Guid> Consume(ConsumeContext<BookReservedEvent> context)
        {
            try
            {
                Order order = new Order(
                context.Message.BookId
                );

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync(default(CancellationToken));


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
