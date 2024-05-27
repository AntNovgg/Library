using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Aggregates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Commands.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly ICatalogServiceContext _context;
        public DeleteBookHandler(ICatalogServiceContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Books
                .FindAsync(new object[] { request.Id }, cancellationToken);
                _context.Books.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(DeleteBookHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
