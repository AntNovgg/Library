using CatalogService.Application.Common.Interfaces;
using Contracts;
using MassTransit;
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
        public BookReservedConsumer(ICatalogServiceContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<BookReservedEvent> context)
        {
            try
            {
                var entity = await _context.Books.FirstOrDefaultAsync(Book =>
                    Book.Id == context.Message.bookId);
                entity.BookReserved();
                await _context.SaveChangesAsync(default(CancellationToken));
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(BookReservedConsumer)} - {ex.Message}";
                throw new Exception(errorMessage);
            }
        }


    }
    {
    }
}
