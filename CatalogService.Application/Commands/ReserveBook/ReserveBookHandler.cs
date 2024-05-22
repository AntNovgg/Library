using CatalogService.Application.Commands.AddBook;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Aggregates;
using Contracts;
using MassTransit;
using MassTransit.Transports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Commands.ReserveBook
{
    public class ReserveBookHandler
    {
        private readonly ICatalogServiceContext _context;
        private readonly IPublishEndpoint _publishEndpoint;
        public ReserveBookHandler(ICatalogServiceContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }
        public async Task Handle(ReserveBookCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var entity = await _context.Books.FirstOrDefaultAsync(Book =>
                     Book.Id == request.Id, cancellationToken);

                entity.BookReserved();
                
                await _publishEndpoint.Publish(new BookReservedEvent(entity.Id,
                    entity.Title,
                    entity.Author,
                    entity.BookGenre,
                    entity.IsAvailable,
                    entity.BookCondition)
                    ,cancellationToken);

            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(ReserveBookHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
