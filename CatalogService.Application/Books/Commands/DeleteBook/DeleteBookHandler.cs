using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Aggregates;
using CatalogService.Domain.Aggregates.BookAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Books.Commands.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _bookRepository.GetAsync(request.Id);
                _bookRepository.Delete(entity);
                await _bookRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(DeleteBookHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
