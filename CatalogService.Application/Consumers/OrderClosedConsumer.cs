using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Aggregates.BookAggregate;
using Contracts;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Consumers
{
    public class OrderClosedConsumer : IConsumer<OrderClosedEvent>
    {
        private readonly ICatalogServiceContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderClosedConsumer(ICatalogServiceContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<OrderClosedEvent> context)
        {
            try
            {
                var entity = await _context.Books.FirstOrDefaultAsync(Book =>
                  Book.Id == context.Message.bookId);
                entity.BookRated((Condition)context.Message.BookCondition);
                await _context.SaveChangesAsync(default(CancellationToken));
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(OrderClosedConsumer)} - {ex.Message}";
                throw new Exception(errorMessage);
            }
        }


    }
}
