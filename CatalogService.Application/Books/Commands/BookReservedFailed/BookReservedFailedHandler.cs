using CatalogService.Application.Commands.DeleteBook;
using CatalogService.Application.Common.Interfaces;
using Contracts;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Books.Commands.BookReservedFailed
{
    public class BookReservedFailedHandler : IRequestHandler<BookReservedFailedCommand>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public BookReservedFailedHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(BookReservedFailedCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _publishEndpoint.Publish(new BookReservedFailedEvent(request.OrderId));
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(BookReservedFailedHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
