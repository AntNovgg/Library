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

namespace CatalogService.Application.Books.Commands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _bookRepository.GetAsync(request.Id);
                _bookRepository.Update(entity);
                await _bookRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(UpdateBookHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
