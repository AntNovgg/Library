using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Aggregates.BookAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Books.Commands.AddBook
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Guid> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Book book = new Book(request.Tittle, request.AuthorId, request.BookGenre, true, request.BookCondition);

                _bookRepository.Add(book);
                await _bookRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

                return book.Id;
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(AddBookHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }
        }
    }
}
