using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Aggregates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Commands.AddBook
{
    public class DeleteBookHandler : IRequestHandler<UpdateBookCommand, Guid>
    {
        private readonly ICatalogServiceContext _context;
        public DeleteBookHandler(ICatalogServiceContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {

                Book book = new Book(request.Title, request.Author, request.Genre, true, Book.Condition.Great);

                await _context.Books.AddAsync(book, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return book.Id;
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(DeleteBookHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
