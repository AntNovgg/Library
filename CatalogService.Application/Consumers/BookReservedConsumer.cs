using CatalogService.Application.Common.Interfaces;
using Contracts;
using MassTransit;
using MassTransit.Transports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogService.Application.Consumers
{
    public class BookReservedConsumer : IConsumer<BookReservedEvent>
    {
        private readonly ICatalogServiceContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public BookReservedConsumer(ICatalogServiceContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<BookReservedEvent> context)
        {
            try
            {
                var entity = await _context.Books.FirstOrDefaultAsync(Book =>
                    Book.Id == context.Message.bookId);
                //availability check
                if (entity.IsAvailable == true) 
                { 
                    entity.BookReserved();
                    await _context.SaveChangesAsync(default(CancellationToken));
                }
                else
                {
                    await _publishEndpoint.Publish(new BookReservedFailedEvent(context.Message.orderId));
                }
                
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(BookReservedConsumer)} - {ex.Message}";
                throw new Exception(errorMessage);
            }
        }


    }
    
}
