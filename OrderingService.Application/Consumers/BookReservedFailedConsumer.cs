using Contracts;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderingService.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderingService.Application.Consumers
{
    public class BookReservedFailedConsumer : IConsumer<BookReservedFailedEvent>
    {
        private readonly IOrderingServiceContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public BookReservedFailedConsumer(IOrderingServiceContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<BookReservedFailedEvent> context)
        {
            try
            {
                var entity = await _context.Orders
                .FindAsync(new object[] { context.Message.orderId });
                _context.Orders.Remove(entity);
                await _context.SaveChangesAsync(default(CancellationToken));
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(BookReservedFailedConsumer)} - {ex.Message}";
                throw new Exception(errorMessage);
            }
        }
    }   
}
