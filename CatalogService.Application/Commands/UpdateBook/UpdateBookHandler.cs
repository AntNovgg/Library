using CatalogService.Application.Commands.UpdateBook;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Aggregates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Commands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly ICatalogServiceContext _context;
        public UpdateBookHandler(ICatalogServiceContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var entity = await _context.Books.FirstOrDefaultAsync(Book =>
                    Book.Id == request.Id, cancellationToken);
                entity.BookUpdate(request.Title, request.Author, request.BookGenre, request.IsAvailable, request.BookCondition);
                


                

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(UpdateBookHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
